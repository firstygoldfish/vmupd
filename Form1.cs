using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Renci.SshNet;

namespace vmupd
{
    public partial class Form1 : Form
    {
		String srvip = "192.168.56.21";
		String srvuser = "oracle";
		String srvpswd = "delta1";
		string NL = Environment.NewLine;
		public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

		}

        private void butVMUpdate_Click(object sender, EventArgs e)
        {
			var confirmResult = MessageBox.Show("Ensure your VM is started and you are connected to the Azure VPN before continuing.  Once the process has started it should NOT be interrupted or data loss will occur." + NL + NL + "Are you sure to update your VM?",
									 "Confirm Update!!",
									 MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
				txtOutput.Clear();
				butVMUpdate.Enabled = false;
				try
				{
					var ssh = new SshClient(srvip, srvuser, srvpswd);
					lblStatus.Text = "Running...";
					statusStrip1.BackColor = ColorTranslator.FromHtml("#00cc6a");
					addtext("Connecting securely to VM...");
					ssh.Connect();
					var result = ssh.RunCommand("echo connected to $HOSTNAME" + NL);
					addtext(result.Result);
					result = ssh.RunCommand("rm -f ~/install.sh; sshpass -p \"delta1\" scp  -o ConnectTimeout=10 oracle@10.0.1.14:/backups/vmupdate/install.sh ~/");
					if (result.Error.Length > 0)
					{
						errtext(result.Error);
						resetForm(ssh);
					}
					else
					{
						addtext("Running upgrade script...");
						result = ssh.RunCommand("chmod 755 ~/install.sh");
						if (result.Error.Length > 0)
						{
							addtext(result.Error);;
							resetForm(ssh);
						}
						else
						{
							var cmd = ssh.CreateCommand("~/install.sh 2>&1");
							var cmdresult = cmd.BeginExecute();

							using (var reader = new StreamReader(cmd.OutputStream, Encoding.UTF8, true, 1024))
							{
								while (!cmdresult.IsCompleted || !reader.EndOfStream)
								{
									string line = reader.ReadLine();
									if (line != null)
									{
										addtext(line);
										Application.DoEvents();
									}
									Application.DoEvents();
								}
							}

							//cmd.EndExecute(cmdresult);

							resetForm(ssh);
						}
					}
				}
				catch (System.Net.Sockets.SocketException)
				{
					errtext("Connection failed.");
					resetForm(null);
				}
				catch (Renci.SshNet.Common.SshAuthenticationException)
				{
					errtext("Authentication failed.");
					resetForm(null);
				}
			}
		}

		private void addtext(String text)
        {
			txtOutput.AppendText(text);
			txtOutput.AppendText(NL);
        }

		private void errtext(String text)
        {
			addtext("ERROR: " + text);
			addtext("Update terminated.");
		}

		private void resetForm(SshClient ssh)
        {
			butVMUpdate.Enabled = true;
			lblStatus.Text = "Ready";
			statusStrip1.BackColor = Form1.DefaultBackColor;
			if (ssh != null && ssh.IsConnected) ssh.Disconnect();
		}

        private void butHelp_Click(object sender, EventArgs e)
        {
			String helpText = "This application is used to update the OASys Instance on your local virtual machine (VM)." + NL + NL;
			helpText += " - Ensure that your local virtual machine is running" + NL + " - Ensure you are connected to the OASys Azure VPN" + NL + NL;
			helpText += "This process will OVERWRITE your OASys application AND database so you will lose ANY data that you have created locally." + NL + NL;
			helpText += "Click the 'Update VM' (RUN) button to begin the process. Once the process has started it should NOT be interrupted or data loss will occur.";
			MessageBox.Show(helpText,"VMUpd : Capita");
        }
    }
}
