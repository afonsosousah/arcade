using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using GFNAppLauncher.Properties;
using MonoTorrent;
using MonoTorrent.Client;

namespace GFNAppLauncher
{
	public class Form1 : Form
	{
		private WebClient client = new WebClient();

		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

		public static ClientEngine engine;

		private string DownloadGamePath;

		private IContainer components = null;

		private Panel panel1;

		private PictureBox pictureBox1;

		private Label label2;

		private Panel panel2;

		private Label label5;
        private Label label3;
        private Label label4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
        private Guna.UI2.WinForms.Guna2Button button7;
        private Guna.UI2.WinForms.Guna2Button button8;
        private Guna.UI2.WinForms.Guna2Button button10;
        private Guna.UI2.WinForms.Guna2Button button4;
        private Guna.UI2.WinForms.Guna2Button button9;
        private Guna.UI2.WinForms.Guna2Button button2;
        private Guna.UI2.WinForms.Guna2Button button1;
        private Guna.UI2.WinForms.Guna2Button button5;
        private Guna.UI2.WinForms.Guna2Button button19;
        private Guna.UI2.WinForms.Guna2Button button18;
        private Guna.UI2.WinForms.Guna2Button button29;
        private Guna.UI2.WinForms.Guna2Button button30;
        private Guna.UI2.WinForms.Guna2Button button34;
        private Guna.UI2.WinForms.Guna2Button button16;
        private Guna.UI2.WinForms.Guna2Button button14;
        private Guna.UI2.WinForms.Guna2Button button15;
        private Guna.UI2.WinForms.Guna2Button button17;
        private Guna.UI2.WinForms.Guna2Button button6;
        private Guna.UI2.WinForms.Guna2Button button33;
        private Guna.UI2.WinForms.Guna2Button button32;
        private Guna.UI2.WinForms.Guna2Button button31;
        private Guna.UI2.WinForms.Guna2Button button11;
        private Guna.UI2.WinForms.Guna2Button button13;
        private Guna.UI2.WinForms.Guna2Button button26;
        private Guna.UI2.WinForms.Guna2Button button27;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button button23;
        private Guna.UI2.WinForms.Guna2Button button24;
        private Panel panel3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2GradientButton button3;
        private Guna.UI2.WinForms.Guna2GradientButton button25;
        private Guna.UI2.WinForms.Guna2GradientButton button20;
        private Guna.UI2.WinForms.Guna2GradientButton button22;
        private Guna.UI2.WinForms.Guna2GradientButton button21;
        private Guna.UI2.WinForms.Guna2Button button12;

		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect,
			int nTopRect,
			int nRightRect,
			int nBottomRect,
			int nWidthEllipse,
			int nHeightEllipse
		);

        Form2 form2 = new Form2();

        public Form1()
		{
			AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
			InitializeComponent();
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
			Directory.CreateDirectory("C:\\Arcade");
			base.FormClosing += Form1_Closing;
			base.MouseDown += Form1_MouseDown;
		}

		private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
		{
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string value = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
				string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
				string text = null;
				for (int i = 0; i <= manifestResourceNames.Count() - 1; i++)
				{
					string text2 = manifestResourceNames[i];
					if (text2.EndsWith(value))
					{
						text = text2;
						break;
					}
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					using (Stream stream = executingAssembly.GetManifestResourceStream(text))
					{
						byte[] array = new byte[stream.Length];
						stream.Read(array, 0, array.Length);
						return Assembly.Load(array);
					}
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(base.Handle, 161, 2, 0);
			}
		}

		private void Form1_Closing(object sender, CancelEventArgs e)
		{
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\runthis++.exe"))
			{
				Process.Start("B:\\Arcade\\runthis++.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
			client.DownloadFile("https://picteon.dev/files/Explorer++.exe", "B:\\Arcade\\runthis++.exe");
			Cursor = Cursors.Default;
            Process.Start("B:\\Arcade\\runthis++.exe");
        }

		private void button8_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\proshac.exe"))
			{
				Process.Start("B:\\Arcade\\proshac.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
			client.DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/runthis.exe", "B:\\Arcade\\proshac.exe");
			Cursor = Cursors.Default;
            Process.Start("B:\\Arcade\\proshac.exe");
        }

		private void button9_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\discord\\discord-portable.exe"))
			{
				Process.Start("B:\\Arcade\\discord\\discord-portable.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
			DownloadFile("https://www.dropbox.com/s/4fcsg5ll8ttqp1y/discord-portable-win32-0.0.308-6.zip?dl=1", "B:\\Arcade\\discord.zip");
			Cursor = Cursors.Default;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\CTRLTAB.exe"))
			{
				Process.Start("B:\\Arcade\\CTRLTAB.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
			client.DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/CTRLTAB.exe", "B:\\Arcade\\CTRLTAB.exe");
			Cursor = Cursors.Default;
            Process.Start("B:\\Arcade\\CTRLTAB.exe");
        }

		private void button1_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\Firefox\\runthis.exe"))
			{
				Process.Start("B:\\Arcade\\Firefox\\runthis.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
		    DownloadFile("https://www.dropbox.com/s/m7nd5airj4lyd13/Firefox.zip?dl=1", "B:\\Arcade\\Firefox.zip");
			Cursor = Cursors.Default;
		}

		private void button2_Click(object sender, EventArgs e)
		{
            //Notepad
			if (File.Exists("B:\\Arcade\\notepad.exe"))
			{
				Process.Start("B:\\Arcade\\notepad.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
			DownloadFileAsync("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/Notepad2.exe", "B:\\Arcade\\notepad.exe");
			Cursor = Cursors.Default;
		}

		public void DownloadFile(string urlAddress, string location)
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadFileCompleted += Completed;
				webClient.DownloadProgressChanged += ProgressChanged;
				Uri address = new Uri(urlAddress);
				try
				{
					try
					{
						webClient.DownloadFileAsync(address, location);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
				}
			}
		}

		private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private async void Completed(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				MessageBox.Show("Download has been canceled.");
				return;
			}

            OneClickExtract("B:\\Arcade\\Firefox.zip", "B:\\Arcade", "B:\\Arcade\\Firefox\\runthis.exe");

            OneClickExtract("B:\\Arcade\\discord.zip", "B:\\Arcade\\discord", "B:\\Arcade\\discord\\discord-portable.exe");

            OneClickExtract("B:\\Arcade\\bnet.zip", "B:\\Arcade\\", "B:\\Arcade\\Battle.netPortable\\Battle.netPortable.exe");

            OneClickExtract("B:\\Arcade\\EpicGames.zip", "B:\\Arcade", "B:\\Arcade\\Epic Games\\Launcher\\Engine\\Binaries\\Win64\\EpicGamesLauncher.exe");

            OneClickExtract("B:\\Arcade\\FDM.zip", "B:\\Arcade\\Free Download Manager", "B:\\Arcade\\Free Download Manager\\fdm.exe");

            OneClickExtract("B:\\Arcade\\Twitch.zip", "B:\\Arcade\\Twitch Studio", "B:\\Arcade\\Twitch Studio\\Bin\\TwitchStudio.exe");

            OneClickExtract("B:\\Arcade\\CrystalLauncher.zip", "B:\\Arcade\\", "B:\\Arcade\\Crystal-Launcher\\launcher.exe");

            try
            {
                if (File.Exists("B:\\Arcade\\desktop.zip"))
                {
                    await AsyncExtract("B:\\Arcade\\desktop.zip", "B:\\Arcade");
                    File.Delete("B:\\Arcade\\desktop.zip");
                    try
                    {
                        /*Process process = new Process();
                        ProcessStartInfo processStartInfo = new ProcessStartInfo();
                        processStartInfo.WorkingDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\arcade\\WinXShell";
                        processStartInfo.CreateNoWindow = true;
                        processStartInfo.FileName = "C:\\Program Files (x86)\\Steam\\steamapps\\arcade\\WinXShell\\start.bat";
                        process.StartInfo = processStartInfo;
                        process.Start();*/

                        StartDesktop();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

            try
			{
                if(File.Exists("B:\\Arcade\\Arcade.zip"))
                {
				    File.Delete("B:\\Arcade\\runthis++.exe");
				    await AsyncExtract("B:\\Arcade\\Arcade.zip", "B:\\Arcade");
				    File.Delete("B:\\Arcade\\Arcade.zip");
                }

			}
			catch (Exception)
			{
			}

            try
			{
                if(File.Exists("B:\\Arcade\\winrar.zip"))
                {
				    await AsyncExtract("B:\\Arcade\\winrar.zip", "B:\\Arcade\\winrar");
				    File.Delete("B:\\Arcade\\winrar.zip");
				    Process.Start("B:\\Arcade\\winrar\\runthis.exe");
                    WaitNSeconds(1);
                    if (File.Exists("B:\\Arcade\\winrar\\runme.exe"))
                    {
                        Process.Start("B:\\Arcade\\winrar\\runme.exe");
                    }
                    else
                    {
                        try
                        {
                            File.Move("B:\\Arcade\\winrar\\WinRAR.exe", "B:\\Arcade\\winrar\\runme.exe");
                            Process.Start("B:\\Arcade\\winrar\\runme.exe");
                        }
                        catch (Exception ex ) { MessageBox.Show(ex.Message); }
                    }
                }

            }
			catch (Exception)
			{
			}

			try
			{
                if(File.Exists("B:\\Arcade\\parsec.zip"))
                {
				    await AsyncExtract("B:\\Arcade\\parsec.zip", "B:\\Arcade\\parsec");
				    File.Delete("B:\\Arcade\\parsec.zip");
                    Process.Start("B:\\Arcade\\parsec\\service\\pservice.exe");
                    Process process = new Process();
                    process.StartInfo.FileName = "B:\\Arcade\\parsec\\parsecd.exe";
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.WorkingDirectory = "B:\\Arcade\\parsec\\";
                    process.Start();
                }

            }
			catch (Exception)
			{
			}
		}

        private void WaitNSeconds(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void button3_Click(object sender, EventArgs e)
		{
			if (base.TopMost)
			{
				base.TopMost = false;
			}
			else if (!base.TopMost)
			{
				base.TopMost = true;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void button23_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button24_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\7-Zip\\runthis.exe"))
			{
				Process.Start("B:\\Arcade\\7-Zip\\runthis.exe");
				return;
			}
			Cursor = Cursors.WaitCursor;
			DownloadFile("https://pproxy500.es/files/Arcade.zip", "B:\\Arcade\\Arcade.zip");
			Cursor = Cursors.Default;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (File.Exists("B:\\Arcade\\winrar\\runthis.exe"))
			{
				Process.Start("B:\\Arcade\\winrar\\runthis.exe");
                WaitNSeconds(1);
                if (File.Exists("B:\\Arcade\\winrar\\runme.exe"))
                {
                    Process.Start("B:\\Arcade\\winrar\\runme.exe");
                }
                else 
                {
                    try
                    {
                	    File.Move("B:\\Arcade\\winrar\\WinRAR.exe", "B:\\Arcade\\winrar\\runme.exe");
				        Process.Start("B:\\Arcade\\winrar\\runme.exe");
                    }
                    catch(Exception){}
                }
			}
			else
			{
				Cursor = Cursors.WaitCursor;
				DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/WinRAR_Unplugged.zip", "B:\\Arcade\\winrar.zip");
				Cursor = Cursors.Default;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("B:\\Arcade\\Firefox\\runthis.exe", "portablegames.xyz");
			}
			catch (Exception)
			{
			}
		}

        public string ColorMode = "Dark Mode";

		private void button22_Click(object sender, EventArgs e)
		{
			if (BackColor == Color.WhiteSmoke)
			{
                ColorMode = "Dark Mode";
				button22.Text = "Light Mode";
				BackColor = Color.FromArgb(48, 48, 48);
				panel1.BackColor = Color.FromArgb(24, 20, 19);
                progressBar1.FillColor = Color.FromArgb(40, 40, 40);
                label3.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                button20.BackColor = Color.FromArgb(26, 22, 21);
                button21.BackColor = Color.FromArgb(26, 22, 21);
                button22.BackColor = Color.FromArgb(26, 22, 21);
                button25.BackColor = Color.FromArgb(26, 22, 21);
                button3.BackColor = Color.FromArgb(26, 22, 21);
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button btn = ctrl as Guna.UI2.WinForms.Guna2Button;
                        btn.FillColor = Color.FromArgb(40, 40, 40);
                        btn.BorderThickness = 0;
                        btn.ForeColor = Color.White;
                    }
                }
                foreach (Control ctrl in panel2.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button btn = ctrl as Guna.UI2.WinForms.Guna2Button;
                        btn.FillColor = Color.FromArgb(40, 40, 40);
                        btn.BorderThickness = 0;
                        btn.ForeColor = Color.White;
                    }
                }

                //Game saves window
                form2.panel3.BackColor = Color.FromArgb(40, 40, 40);
                form2.BackColor = Color.FromArgb(48, 48, 48);
                form2.label1.ForeColor = Color.White;
                form2.label2.ForeColor = Color.White;
                form2.label3.ForeColor = Color.White;
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button btn = ctrl as Guna.UI2.WinForms.Guna2Button;
                        btn.FillColor = Color.FromArgb(40, 40, 40);
                        btn.BorderThickness = 0;
                        btn.ForeColor = Color.White;
                    }
                }
            }
			else if (BackColor == Color.FromArgb(48, 48, 48))
			{
                ColorMode = "Light Mode";
                button22.Text = "Dark Mode";
				BackColor = Color.WhiteSmoke;
				panel1.BackColor = Color.LightGray;
                progressBar1.FillColor = Color.LightGray;
                label3.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                button20.BackColor = Color.FromArgb(205, 205, 205);
                button21.BackColor = Color.FromArgb(205, 205, 205);
                button22.BackColor = Color.FromArgb(205, 205, 205);
                button25.BackColor = Color.FromArgb(205, 205, 205);
                button3.BackColor = Color.FromArgb(205, 205, 205);
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button btn = ctrl as Guna.UI2.WinForms.Guna2Button;
                        btn.FillColor = Color.Transparent;
                        btn.BorderThickness = 1;
                        btn.ForeColor = Color.Black;
                    }
                }
                foreach (Control ctrl in panel2.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button btn = ctrl as Guna.UI2.WinForms.Guna2Button;
                        btn.FillColor = Color.WhiteSmoke;
                        btn.BorderThickness = 1;
                        btn.ForeColor = Color.Black;
                    }
                }

                //Game saves window
                form2.panel3.BackColor = Color.LightGray;
                form2.BackColor = Color.WhiteSmoke;
                form2.label1.ForeColor = Color.Black;
                form2.label2.ForeColor = Color.Black;
                form2.label3.ForeColor = Color.Black;
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button btn = ctrl as Guna.UI2.WinForms.Guna2Button;
                        btn.FillColor = Color.Transparent;
                        btn.BorderThickness = 1;
                        btn.ForeColor = Color.Black;
                    }
                }
            }
		}

		private void button25_Click(object sender, EventArgs e)
		{
            if (Directory.Exists("B:\\Arcade\\WinXShell"))
			{
				try
				{
                    /*Process process = new Process();
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.WorkingDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\arcade\\WinXShell";
					processStartInfo.CreateNoWindow = true;
					processStartInfo.FileName = "C:\\Program Files (x86)\\Steam\\steamapps\\arcade\\WinXShell\\start.bat";
					process.StartInfo = processStartInfo;
					process.Start();*/

                    StartDesktop();

                }
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message);
				}
			}
			else
			{
                DownloadFile("https://www.dropbox.com/s/gmckos0bl46v7x9/WinXShell.zip?dl=1", "B:\\Arcade\\desktop.zip");
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			//GTA 5
			/*if (File.Exists("B:\\Arcade\\Games\\Grand Theft Auto V\\GTA5.exe"))
			{
				Process.Start("B:\\Arcade\\Games\\Grand Theft Auto V\\GTA5.exe");
				return;
			}
            else 
            {*/
                DownloadGame("Dropbox:Grand Theft Auto V", "B:/Arcade/Games/Grand Theft Auto V");
            //}
			/*if (button26.Text == "Normal Drive")
			{
				DownloadGame("ArcadeDrive:FireForce/Grand Theft Auto V", "B:/Arcade/Games/Grand Theft Auto V");
			}
			else if (button26.Text == "Backup Drive")
			{
				DownloadGame("ArcadeBackup:FireForce/Grand Theft Auto V", "B:/Arcade/Games/Grand Theft Auto V");
			}
			else if (button26.Text == "Backup Drive 2")
			{
				DownloadGame("ArcadeBackup2:FireForce/Grand Theft Auto V", "B:/Arcade/Games/Grand Theft Auto V");
			}*/

			//Savegame after 1st mission
			if (!Directory.Exists(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves"))
			{
				client.DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/Goldberg_SocialClub_Emu_Saves.zip", userPath + "\\AppData\\Roaming\\Goldberg_SocialClub_Emu_Saves.zip");
				ZipFile.ExtractToDirectory(userPath + "\\AppData\\Roaming\\Goldberg_SocialClub_Emu_Saves.zip", userPath + "\\AppData\\Roaming\\");
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			//RDR2
			if (File.Exists("B:\\Arcade\\Games\\Red Dead Redemption 2\\Launcher.exe"))
			{
				Process process = new Process();
				process.StartInfo.FileName = "B:\\Arcade\\Games\\Red Dead Redemption 2\\Launcher.exe";
				process.StartInfo.WorkingDirectory = "B:\\Arcade\\Games\\Red Dead Redemption 2\\";
			}
            else
            {
                DownloadGame("Dropbox:Red Dead Redemption 2", "B:/Arcade/Games/Red Dead Redemption 2");
            }
			/*else if (button26.Text == "Normal Drive")
			{
				DownloadGame("ArcadeDrive:FireForce/Red Dead Redemption 2", "B:/Arcade/Games/Red Dead Redemption 2");
			}
			else if (button26.Text == "Backup Drive")
			{
				DownloadGame("ArcadeBackup:FireForce/Red Dead Redemption 2", "B:/Arcade/Games/Red Dead Redemption 2");
			}
			else if (button26.Text == "Backup Drive 2")
			{
				DownloadGame("ArcadeBackup2:FireForce/Red Dead Redemption 2", "B:/Arcade/Games/Red Dead Redemption 2");
			}*/
		}

		private void button13_Click(object sender, EventArgs e)
		{
			//Detroit Become Human
			if (File.Exists("B:\\Arcade\\Games\\Detroit Become Human\\DetroitBecomeHuman.exe"))
			{
				Process.Start("B:\\Arcade\\Games\\Detroit Become Human\\DetroitBecomeHuman.exe");
			}
			else if (button26.Text == "Normal Drive")
			{
				DownloadGame("ArcadeDrive:FireForce/Detroit Become Human", "B:/Arcade/Games/Detroit Become Human");
			}
			else if (button26.Text == "Backup Drive")
			{
				DownloadGame("ArcadeBackup:FireForce/Detroit Become Human", "B:/Arcade/Games/Detroit Become Human");
			}
			else if (button26.Text == "Backup Drive 2")
			{
				DownloadGame("ArcadeBackup2:FireForce/Detroit Become Human", "B:/Arcade/Games/Detroit Become Human");
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.Description = "Select Folder to Save";
				folderBrowserDialog.ShowDialog();
				if (Directory.Exists("C:\\Fake"))
				{
					ZipFile.CreateFromDirectory(folderBrowserDialog.SelectedPath, "C:\\Fake\\ArcadeBackup.zip");
					return;
				}
				Directory.CreateDirectory("C:\\Fake");
				ZipFile.CreateFromDirectory(folderBrowserDialog.SelectedPath, "C:\\Fake\\ArcadeBackup.zip");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			try
			{
				ZipFile.ExtractToDirectory("C:\\Fake\\ArcadeBackup.zip", "B:\\Arcade\\Loaded");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			try
			{
				File.Delete("C:\\Fake\\ArcadeBackup.zip");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		public void Test()
		{
			System.Timers.Timer timer = new System.Timers.Timer(100.0);
			timer.AutoReset = true;
			timer.Elapsed += OnTimedEvent;
			timer.Start();
		}

		private async void OnTimedEvent(object source, ElapsedEventArgs e)
		{
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void CopyDirectory(string SourcePath, string DestinationPath)
		{
			string[] directories = Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories);
			foreach (string text in directories)
			{
				Directory.CreateDirectory(text.Replace(SourcePath, DestinationPath));
			}
			string[] files = Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);
			foreach (string text2 in files)
			{
				File.Copy(text2, text2.Replace(SourcePath, DestinationPath), true);
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			//Battle.NET
			if (File.Exists("B:\\Arcade\\Battle.netPortable\\Battle.netPortable.exe"))
			{
                Process p = new Process();
                p.StartInfo.FileName = "B:\\Arcade\\Battle.netPortable\\Battle.netPortable.exe";
                p.StartInfo.WorkingDirectory = "B:\\Arcade\\Battle.netPortable\\";
                p.Start();
                return;
			}
			Cursor = Cursors.WaitCursor;
            DownloadFile("https://www.dropbox.com/s/urvjobttjtljv1w/Battle.netPortable.zip?dl=1", "B:\\Arcade\\bnet.zip");
			Cursor = Cursors.Default;
		}

		private void button18_Click(object sender, EventArgs e)
		{
			//Parsec
			if (File.Exists("B:\\Arcade\\parsec\\parsecd.exe"))
			{
				Process.Start("B:\\Arcade\\parsec\\service\\pservice.exe");
				Process process = new Process();
				process.StartInfo.FileName = "B:\\Arcade\\parsec\\parsecd.exe";
				process.StartInfo.UseShellExecute = true;
				process.StartInfo.WorkingDirectory = "B:\\Arcade\\parsec\\";
				process.Start();
			}
			else
			{
				Cursor = Cursors.WaitCursor;
				DownloadFile("https://builds.parsecgaming.com/package/parsec-flat-windows32.zip", "B:\\Arcade\\parsec.zip");
				Cursor = Cursors.Default;
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			if (panel2.Visible)
			{
				panel2.Hide();
			}
			else if (!panel2.Visible)
			{
                panel2.Show();
                //MessageBox.Show("Arcade Games are not available right now. Please try again later!");
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			if (panel2.Visible)
			{
				panel2.Hide();
			}
			else if (!panel2.Visible)
			{
                panel2.Show();
                //MessageBox.Show("Arcade Games are not available right now. Please try again later!");
            }
		}

		private void button17_Click(object sender, EventArgs e)
		{
            //Cyberpunk 2077
            if (File.Exists("B:\\Arcade\\Games\\Cyberpunk 2077\\bin\\x64\\Cyberpunk2077.exe"))
            {
                Process process = new Process();
                process.StartInfo.FileName = "B:\\Arcade\\Games\\Cyberpunk 2077\\bin\\x64\\Cyberpunk2077.exe";
                process.StartInfo.WorkingDirectory = "B:\\Arcade\\Games\\Cyberpunk 2077\\bin\\x64\\";
            }
            else
            {
                DownloadGame("Dropbox:Cyberpunk 2077", "B:/Arcade/Games/Cyberpunk 2077");
            }
            /*else if (button26.Text == "Normal Drive")
            {
                DownloadGame("ArcadeDrive:FireForce/CP2077", "B:/Arcade/Games/Cyberpunk 2077");
            }
            else if (button26.Text == "Backup Drive")
            {
                DownloadGame("ArcadeBackup:FireForce/CP2077", "B:/Arcade/Games/Cyberpunk 2077");
            }
            else if (button26.Text == "Backup Drive 2")
            {
                DownloadGame("ArcadeBackup2:FireForce/CP2077", "B:/Arcade/Games/Cyberpunk 2077");
            }*/

        }

		private void label7_Click(object sender, EventArgs e)
		{
		}

		private void DownloadGame(string drivePath, string destPath)
		{
			if (Directory.Exists(userPath + "\\.config\\rclone"))
			{
				client.DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/rclone.conf", userPath + "\\.config\\rclone\\rclone.conf");
			}
			else
			{
				Directory.CreateDirectory(userPath + "\\.config\\rclone");
				client.DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/rclone.conf", userPath + "\\.config\\rclone\\rclone.conf");
			}
			if (!File.Exists("B:\\Arcade\\downloader.exe"))
			{
				client.DownloadFile("https://www.dropbox.com/s/effszj9qix42x32/rclone.exe?dl=1", "B:\\Arcade\\downloader.exe");
			}

            Process process = new Process();

            process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);

			process.StartInfo.FileName = "B:\\Arcade\\downloader.exe";
			process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "copy -P \"" + drivePath + "\" \"" + destPath + "\" --drive-acknowledge-abuse";
			process.Start();
            form3.Show(this);
            process.BeginOutputReadLine();
		}

        Form3 form3 = new Form3();

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(Process.GetProcessesByName("downloader").Length > 0)
            {
                if (e.Data.Contains("ETA"))
                {
                    string string1 = e.Data;
                    string string2 = string1.Substring(string1.IndexOf("Transferred:"));
                    int progress = 0;
                    int index = string2.IndexOf('%');

                    form3.textBox1.Invoke(new Action(() => form3.textBox1.Text = string2));

                    if (index >= 0)
                    {
                        string sub = string2.Substring(0, index);
                        string sub2 = sub.Substring(sub.IndexOf(",") + 1);
                        int.TryParse(sub2, out progress);
                    }
                    form3.guna2ProgressBar1.Invoke(new Action(() => form3.guna2ProgressBar1.Value = progress));
                }

                if(e.Data.Contains("Elapsed"))
                {
                    form3.textBox2.Invoke(new Action(() => form3.textBox2.Text = e.Data));
                }

                var lines = form3.textBox3.Lines.Length;

                if (e.Data.Contains("*") && !e.Data.Contains("ETA") && lines < 4)
                {
                    form3.textBox3.Invoke(new Action(() => form3.textBox3.AppendText(Environment.NewLine)));
                    form3.textBox3.Invoke(new Action(() => form3.textBox3.AppendText(e.Data)));
                }
                else if(e.Data.Contains("*") && !e.Data.Contains("ETA") && lines >= 4)
                {
                    form3.textBox3.Invoke(new Action(() => form3.textBox3.Text.Remove(0, form3.textBox3.Text.Length)));
                    form3.textBox3.Invoke(new Action(() => form3.textBox3.AppendText(Environment.NewLine)));
                    form3.textBox3.Invoke(new Action(() => form3.textBox3.AppendText(e.Data)));
                }
            }

        }

        private void button26_Click(object sender, EventArgs e)
		{
			if (button26.Text == "Normal Drive")
			{
				button26.Text = "Backup Drive";
			}
			else if (button26.Text == "Backup Drive")
			{
				button26.Text = "Backup Drive 2";
			}
			else if (button26.Text == "Backup Drive 2")
			{
				button26.Text = "Normal Drive";
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button25 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button20 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button22 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button21 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button26 = new Guna.UI2.WinForms.Guna2Button();
            this.button27 = new Guna.UI2.WinForms.Guna2Button();
            this.button6 = new Guna.UI2.WinForms.Guna2Button();
            this.button33 = new Guna.UI2.WinForms.Guna2Button();
            this.button32 = new Guna.UI2.WinForms.Guna2Button();
            this.button31 = new Guna.UI2.WinForms.Guna2Button();
            this.button11 = new Guna.UI2.WinForms.Guna2Button();
            this.button13 = new Guna.UI2.WinForms.Guna2Button();
            this.button12 = new Guna.UI2.WinForms.Guna2Button();
            this.button17 = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.button7 = new Guna.UI2.WinForms.Guna2Button();
            this.button8 = new Guna.UI2.WinForms.Guna2Button();
            this.button10 = new Guna.UI2.WinForms.Guna2Button();
            this.button4 = new Guna.UI2.WinForms.Guna2Button();
            this.button9 = new Guna.UI2.WinForms.Guna2Button();
            this.button2 = new Guna.UI2.WinForms.Guna2Button();
            this.button1 = new Guna.UI2.WinForms.Guna2Button();
            this.button5 = new Guna.UI2.WinForms.Guna2Button();
            this.button19 = new Guna.UI2.WinForms.Guna2Button();
            this.button18 = new Guna.UI2.WinForms.Guna2Button();
            this.button29 = new Guna.UI2.WinForms.Guna2Button();
            this.button30 = new Guna.UI2.WinForms.Guna2Button();
            this.button34 = new Guna.UI2.WinForms.Guna2Button();
            this.button16 = new Guna.UI2.WinForms.Guna2Button();
            this.button14 = new Guna.UI2.WinForms.Guna2Button();
            this.button15 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.button23 = new Guna.UI2.WinForms.Guna2Button();
            this.button24 = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button25);
            this.panel1.Controls.Add(this.button20);
            this.panel1.Controls.Add(this.button22);
            this.panel1.Controls.Add(this.button21);
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 469);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
            this.button3.CheckedState.Parent = this.button3;
            this.button3.CustomImages.Parent = this.button3;
            this.button3.FillColor = System.Drawing.Color.Transparent;
            this.button3.FillColor2 = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.HoverState.Parent = this.button3;
            this.button3.Image = global::GFNAppLauncher.Properties.Resources.icons8_double_up_48;
            this.button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button3.ImageOffset = new System.Drawing.Point(5, 0);
            this.button3.Location = new System.Drawing.Point(-1, 386);
            this.button3.Name = "button3";
            this.button3.ShadowDecoration.Parent = this.button3;
            this.button3.Size = new System.Drawing.Size(177, 45);
            this.button3.TabIndex = 67;
            this.button3.Text = "Topmost";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
            this.button25.CheckedState.Parent = this.button25;
            this.button25.CustomImages.Parent = this.button25;
            this.button25.FillColor = System.Drawing.Color.Transparent;
            this.button25.FillColor2 = System.Drawing.Color.Transparent;
            this.button25.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.ForeColor = System.Drawing.Color.White;
            this.button25.HoverState.Parent = this.button25;
            this.button25.Image = global::GFNAppLauncher.Properties.Resources.icons8_wallpaper_48;
            this.button25.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button25.ImageOffset = new System.Drawing.Point(5, 0);
            this.button25.Location = new System.Drawing.Point(0, 285);
            this.button25.Name = "button25";
            this.button25.ShadowDecoration.Parent = this.button25;
            this.button25.Size = new System.Drawing.Size(177, 45);
            this.button25.TabIndex = 66;
            this.button25.Text = "Desktop";
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
            this.button20.CheckedState.Parent = this.button20;
            this.button20.CustomImages.Parent = this.button20;
            this.button20.FillColor = System.Drawing.Color.Transparent;
            this.button20.FillColor2 = System.Drawing.Color.Transparent;
            this.button20.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.HoverState.Parent = this.button20;
            this.button20.Image = global::GFNAppLauncher.Properties.Resources.icons8_apps_tab_48;
            this.button20.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button20.ImageOffset = new System.Drawing.Point(5, 0);
            this.button20.Location = new System.Drawing.Point(0, 185);
            this.button20.Name = "button20";
            this.button20.ShadowDecoration.Parent = this.button20;
            this.button20.Size = new System.Drawing.Size(177, 44);
            this.button20.TabIndex = 63;
            this.button20.Text = "Apps";
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
            this.button22.CheckedState.Parent = this.button22;
            this.button22.CustomImages.Parent = this.button22;
            this.button22.FillColor = System.Drawing.Color.Transparent;
            this.button22.FillColor2 = System.Drawing.Color.Transparent;
            this.button22.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.HoverState.Parent = this.button22;
            this.button22.Image = global::GFNAppLauncher.Properties.Resources.icons8_last_quarter_48;
            this.button22.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button22.ImageOffset = new System.Drawing.Point(5, 0);
            this.button22.Location = new System.Drawing.Point(0, 336);
            this.button22.Name = "button22";
            this.button22.ShadowDecoration.Parent = this.button22;
            this.button22.Size = new System.Drawing.Size(177, 44);
            this.button22.TabIndex = 65;
            this.button22.Text = "Light Mode";
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
            this.button21.CheckedState.Parent = this.button21;
            this.button21.CustomImages.Parent = this.button21;
            this.button21.FillColor = System.Drawing.Color.Transparent;
            this.button21.FillColor2 = System.Drawing.Color.Transparent;
            this.button21.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.HoverState.Parent = this.button21;
            this.button21.Image = global::GFNAppLauncher.Properties.Resources.icons8_game_controller_48;
            this.button21.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button21.ImageOffset = new System.Drawing.Point(5, 0);
            this.button21.Location = new System.Drawing.Point(0, 235);
            this.button21.Name = "button21";
            this.button21.ShadowDecoration.Parent = this.button21;
            this.button21.Size = new System.Drawing.Size(177, 44);
            this.button21.TabIndex = 64;
            this.button21.Text = "Games";
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2PictureBox1.Image = global::GFNAppLauncher.Properties.Resources.ezgif_7_b1023c26ff19;
            this.guna2PictureBox1.Location = new System.Drawing.Point(13, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(148, 148);
            this.guna2PictureBox1.TabIndex = 14;
            this.guna2PictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GFNAppLauncher.Properties.Resources.defaultLogoBlack;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 148);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button26);
            this.panel2.Controls.Add(this.button27);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button33);
            this.panel2.Controls.Add(this.button32);
            this.panel2.Controls.Add(this.button31);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button17);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.ForeColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(189, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 392);
            this.panel2.TabIndex = 38;
            this.panel2.Visible = false;
            // 
            // button26
            // 
            this.button26.BorderRadius = 5;
            this.button26.CheckedState.Parent = this.button26;
            this.button26.CustomBorderColor = System.Drawing.Color.Black;
            this.button26.CustomImages.Parent = this.button26;
            this.button26.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button26.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.ForeColor = System.Drawing.Color.White;
            this.button26.HoverState.Parent = this.button26;
            this.button26.Location = new System.Drawing.Point(262, 313);
            this.button26.Name = "button26";
            this.button26.ShadowDecoration.Parent = this.button26;
            this.button26.Size = new System.Drawing.Size(125, 65);
            this.button26.TabIndex = 62;
            this.button26.Text = "Normal Drive";
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button27
            // 
            this.button27.BorderRadius = 5;
            this.button27.CheckedState.Parent = this.button27;
            this.button27.CustomBorderColor = System.Drawing.Color.Black;
            this.button27.CustomImages.Parent = this.button27;
            this.button27.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button27.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.HoverState.Parent = this.button27;
            this.button27.Location = new System.Drawing.Point(2, 313);
            this.button27.Name = "button27";
            this.button27.ShadowDecoration.Parent = this.button27;
            this.button27.Size = new System.Drawing.Size(254, 65);
            this.button27.TabIndex = 61;
            this.button27.Text = "Game Saves";
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::GFNAppLauncher.Properties.Resources.defaultLogoBlack;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.BorderRadius = 5;
            this.button6.CheckedState.Parent = this.button6;
            this.button6.CustomImages.Parent = this.button6;
            this.button6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.HoverState.Parent = this.button6;
            this.button6.Image = global::GFNAppLauncher.Properties.Resources.defaultLogoBlack;
            this.button6.ImageSize = new System.Drawing.Size(120, 120);
            this.button6.Location = new System.Drawing.Point(394, 143);
            this.button6.Name = "button6";
            this.button6.ShadowDecoration.Parent = this.button6;
            this.button6.Size = new System.Drawing.Size(126, 136);
            this.button6.TabIndex = 59;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button33
            // 
            this.button33.BackgroundImage = global::GFNAppLauncher.Properties.Resources.Logo_Horizon_Zero_Dawn_svg;
            this.button33.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button33.BorderRadius = 5;
            this.button33.CheckedState.Parent = this.button33;
            this.button33.CustomImages.Parent = this.button33;
            this.button33.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button33.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button33.ForeColor = System.Drawing.Color.Black;
            this.button33.HoverState.Parent = this.button33;
            this.button33.Image = global::GFNAppLauncher.Properties.Resources.hzd_logo_main_640x300;
            this.button33.ImageSize = new System.Drawing.Size(120, 60);
            this.button33.Location = new System.Drawing.Point(263, 143);
            this.button33.Name = "button33";
            this.button33.ShadowDecoration.Parent = this.button33;
            this.button33.Size = new System.Drawing.Size(126, 136);
            this.button33.TabIndex = 58;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button32
            // 
            this.button32.BackgroundImage = global::GFNAppLauncher.Properties.Resources.imageedit_1_7287934016;
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.BorderRadius = 5;
            this.button32.CheckedState.Parent = this.button32;
            this.button32.CustomImages.Parent = this.button32;
            this.button32.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button32.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button32.ForeColor = System.Drawing.Color.Black;
            this.button32.HoverState.Parent = this.button32;
            this.button32.Image = global::GFNAppLauncher.Properties.Resources.DBZKakarot;
            this.button32.ImageSize = new System.Drawing.Size(120, 60);
            this.button32.Location = new System.Drawing.Point(133, 143);
            this.button32.Name = "button32";
            this.button32.ShadowDecoration.Parent = this.button32;
            this.button32.Size = new System.Drawing.Size(126, 136);
            this.button32.TabIndex = 57;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button31
            // 
            this.button31.BackgroundImage = global::GFNAppLauncher.Properties.Resources.JFO_Logo_Primary_RGB_Black;
            this.button31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button31.BorderRadius = 5;
            this.button31.CheckedState.Parent = this.button31;
            this.button31.CustomImages.Parent = this.button31;
            this.button31.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button31.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button31.ForeColor = System.Drawing.Color.Black;
            this.button31.HoverState.Parent = this.button31;
            this.button31.Image = global::GFNAppLauncher.Properties.Resources.star_wars_jedi_hero_logo;
            this.button31.ImageSize = new System.Drawing.Size(120, 80);
            this.button31.Location = new System.Drawing.Point(2, 143);
            this.button31.Name = "button31";
            this.button31.ShadowDecoration.Parent = this.button31;
            this.button31.Size = new System.Drawing.Size(126, 136);
            this.button31.TabIndex = 56;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button11
            // 
            this.button11.BackgroundImage = global::GFNAppLauncher.Properties.Resources.image;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.BorderRadius = 5;
            this.button11.CheckedState.Parent = this.button11;
            this.button11.CustomImages.Parent = this.button11;
            this.button11.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button11.ForeColor = System.Drawing.Color.Black;
            this.button11.HoverState.Parent = this.button11;
            this.button11.Image = global::GFNAppLauncher.Properties.Resources.GTA_5_logo;
            this.button11.ImageSize = new System.Drawing.Size(100, 90);
            this.button11.Location = new System.Drawing.Point(133, 1);
            this.button11.Name = "button11";
            this.button11.ShadowDecoration.Parent = this.button11;
            this.button11.Size = new System.Drawing.Size(126, 136);
            this.button11.TabIndex = 55;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.BackgroundImage = global::GFNAppLauncher.Properties.Resources.detroitbecomehumanBlack;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.BorderRadius = 5;
            this.button13.CheckedState.Parent = this.button13;
            this.button13.CustomImages.Parent = this.button13;
            this.button13.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button13.ForeColor = System.Drawing.Color.Black;
            this.button13.HoverState.Parent = this.button13;
            this.button13.Image = global::GFNAppLauncher.Properties.Resources.Detroit_become_human_logo;
            this.button13.ImageSize = new System.Drawing.Size(120, 40);
            this.button13.Location = new System.Drawing.Point(394, 1);
            this.button13.Name = "button13";
            this.button13.ShadowDecoration.Parent = this.button13;
            this.button13.Size = new System.Drawing.Size(126, 136);
            this.button13.TabIndex = 54;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.BackgroundImage = global::GFNAppLauncher.Properties.Resources.PngItem_912112;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button12.BorderRadius = 5;
            this.button12.CheckedState.Parent = this.button12;
            this.button12.CustomImages.Parent = this.button12;
            this.button12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button12.ForeColor = System.Drawing.Color.Black;
            this.button12.HoverState.Parent = this.button12;
            this.button12.Image = global::GFNAppLauncher.Properties.Resources.Red_Dead_Redemption_2_Logo;
            this.button12.ImageSize = new System.Drawing.Size(120, 45);
            this.button12.Location = new System.Drawing.Point(264, 1);
            this.button12.Name = "button12";
            this.button12.ShadowDecoration.Parent = this.button12;
            this.button12.Size = new System.Drawing.Size(126, 136);
            this.button12.TabIndex = 48;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button17
            // 
            this.button17.BackgroundImage = global::GFNAppLauncher.Properties.Resources.unnamed1;
            this.button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button17.BorderRadius = 5;
            this.button17.CheckedState.Parent = this.button17;
            this.button17.CustomImages.Parent = this.button17;
            this.button17.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button17.ForeColor = System.Drawing.Color.Black;
            this.button17.HoverState.Parent = this.button17;
            this.button17.Image = global::GFNAppLauncher.Properties.Resources.cyberpunk;
            this.button17.ImageSize = new System.Drawing.Size(126, 45);
            this.button17.Location = new System.Drawing.Point(2, 0);
            this.button17.Name = "button17";
            this.button17.ShadowDecoration.Parent = this.button17;
            this.button17.Size = new System.Drawing.Size(126, 136);
            this.button17.TabIndex = 46;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(517, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(406, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 64);
            this.label3.TabIndex = 42;
            this.label3.Text = "Available Drives:\r\nNormal Drive\r\nBackup Drive\r\nBackup Drive 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(583, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 32);
            this.label2.TabIndex = 32;
            this.label2.Text = "Loaded Path:\r\nB:\\Arcade\\Loaded";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(190, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(517, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // progressBar1
            // 
            this.progressBar1.BorderRadius = 5;
            this.progressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.progressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.progressBar1.Location = new System.Drawing.Point(189, 444);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(181)))), ((int)(((byte)(210)))));
            this.progressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(181)))), ((int)(((byte)(210)))));
            this.progressBar1.ShadowDecoration.Parent = this.progressBar1;
            this.progressBar1.Size = new System.Drawing.Size(519, 12);
            this.progressBar1.TabIndex = 43;
            this.progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BorderRadius = 5;
            this.button7.CheckedState.Parent = this.button7;
            this.button7.CustomBorderColor = System.Drawing.Color.Black;
            this.button7.CustomImages.Parent = this.button7;
            this.button7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button7.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.HoverState.Parent = this.button7;
            this.button7.Image = global::GFNAppLauncher.Properties.Resources.file_explorer_icon;
            this.button7.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button7.Location = new System.Drawing.Point(190, 46);
            this.button7.Name = "button7";
            this.button7.ShadowDecoration.Parent = this.button7;
            this.button7.Size = new System.Drawing.Size(125, 65);
            this.button7.TabIndex = 44;
            this.button7.Text = "Explorer++";
            this.button7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button7.TextOffset = new System.Drawing.Point(-7, 0);
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BorderRadius = 5;
            this.button8.CheckedState.Parent = this.button8;
            this.button8.CustomBorderColor = System.Drawing.Color.Black;
            this.button8.CustomImages.Parent = this.button8;
            this.button8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button8.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.HoverState.Parent = this.button8;
            this.button8.Image = global::GFNAppLauncher.Properties.Resources.ProcessHacker;
            this.button8.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button8.Location = new System.Drawing.Point(321, 46);
            this.button8.Name = "button8";
            this.button8.ShadowDecoration.Parent = this.button8;
            this.button8.Size = new System.Drawing.Size(125, 65);
            this.button8.TabIndex = 45;
            this.button8.Text = "ProcessHacker";
            this.button8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BorderRadius = 5;
            this.button10.CheckedState.Parent = this.button10;
            this.button10.CustomBorderColor = System.Drawing.Color.Black;
            this.button10.CustomImages.Parent = this.button10;
            this.button10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button10.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.HoverState.Parent = this.button10;
            this.button10.Image = global::GFNAppLauncher.Properties.Resources.AHK;
            this.button10.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button10.Location = new System.Drawing.Point(452, 46);
            this.button10.Name = "button10";
            this.button10.ShadowDecoration.Parent = this.button10;
            this.button10.Size = new System.Drawing.Size(125, 65);
            this.button10.TabIndex = 46;
            this.button10.Text = "Ctrl-Tab";
            this.button10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button10.TextOffset = new System.Drawing.Point(-22, 0);
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BorderRadius = 5;
            this.button4.CheckedState.Parent = this.button4;
            this.button4.CustomBorderColor = System.Drawing.Color.Black;
            this.button4.CustomImages.Parent = this.button4;
            this.button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button4.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.HoverState.Parent = this.button4;
            this.button4.Image = global::GFNAppLauncher.Properties.Resources._7zip;
            this.button4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button4.ImageSize = new System.Drawing.Size(25, 20);
            this.button4.Location = new System.Drawing.Point(583, 46);
            this.button4.Name = "button4";
            this.button4.ShadowDecoration.Parent = this.button4;
            this.button4.Size = new System.Drawing.Size(125, 65);
            this.button4.TabIndex = 47;
            this.button4.Text = "7-Zip‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ";
            this.button4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button4.TextOffset = new System.Drawing.Point(-22, 0);
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BorderRadius = 5;
            this.button9.CheckedState.Parent = this.button9;
            this.button9.CustomBorderColor = System.Drawing.Color.Black;
            this.button9.CustomImages.Parent = this.button9;
            this.button9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button9.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.HoverState.Parent = this.button9;
            this.button9.Image = global::GFNAppLauncher.Properties.Resources._91_Discord_logo_logos_512;
            this.button9.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button9.Location = new System.Drawing.Point(190, 117);
            this.button9.Name = "button9";
            this.button9.ShadowDecoration.Parent = this.button9;
            this.button9.Size = new System.Drawing.Size(125, 65);
            this.button9.TabIndex = 48;
            this.button9.Text = "Discord‎‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎";
            this.button9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button9.TextOffset = new System.Drawing.Point(-10, 0);
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BorderRadius = 5;
            this.button2.CheckedState.Parent = this.button2;
            this.button2.CustomBorderColor = System.Drawing.Color.Black;
            this.button2.CustomImages.Parent = this.button2;
            this.button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.HoverState.Parent = this.button2;
            this.button2.Image = global::GFNAppLauncher.Properties.Resources.notepad;
            this.button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button2.Location = new System.Drawing.Point(321, 117);
            this.button2.Name = "button2";
            this.button2.ShadowDecoration.Parent = this.button2;
            this.button2.Size = new System.Drawing.Size(125, 65);
            this.button2.TabIndex = 49;
            this.button2.Text = "Notepad";
            this.button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button2.TextOffset = new System.Drawing.Point(-20, 0);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BorderRadius = 5;
            this.button1.CheckedState.Parent = this.button1;
            this.button1.CustomBorderColor = System.Drawing.Color.Black;
            this.button1.CustomImages.Parent = this.button1;
            this.button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverState.Parent = this.button1;
            this.button1.Image = global::GFNAppLauncher.Properties.Resources.Firefox;
            this.button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button1.Location = new System.Drawing.Point(452, 117);
            this.button1.Name = "button1";
            this.button1.ShadowDecoration.Parent = this.button1;
            this.button1.Size = new System.Drawing.Size(125, 65);
            this.button1.TabIndex = 50;
            this.button1.Text = "‎‏‏‎ ‎‏‏‎‏Firefox‎‏‏‎ ‎‏‏‎‏‎‏‏‎ ‎‏‏‎‏";
            this.button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button1.TextOffset = new System.Drawing.Point(-20, 0);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BorderRadius = 5;
            this.button5.CheckedState.Parent = this.button5;
            this.button5.CustomBorderColor = System.Drawing.Color.Black;
            this.button5.CustomImages.Parent = this.button5;
            this.button5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button5.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.HoverState.Parent = this.button5;
            this.button5.Image = global::GFNAppLauncher.Properties.Resources.Winrar;
            this.button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button5.Location = new System.Drawing.Point(582, 117);
            this.button5.Name = "button5";
            this.button5.ShadowDecoration.Parent = this.button5;
            this.button5.Size = new System.Drawing.Size(125, 65);
            this.button5.TabIndex = 51;
            this.button5.Text = "Winrar";
            this.button5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button5.TextOffset = new System.Drawing.Point(-24, 0);
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Transparent;
            this.button19.BorderRadius = 5;
            this.button19.CheckedState.Parent = this.button19;
            this.button19.CustomBorderColor = System.Drawing.Color.Black;
            this.button19.CustomImages.Parent = this.button19;
            this.button19.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button19.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.HoverState.Parent = this.button19;
            this.button19.Image = global::GFNAppLauncher.Properties.Resources.battle_net;
            this.button19.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button19.Location = new System.Drawing.Point(190, 188);
            this.button19.Name = "button19";
            this.button19.ShadowDecoration.Parent = this.button19;
            this.button19.Size = new System.Drawing.Size(125, 65);
            this.button19.TabIndex = 52;
            this.button19.Text = "Battle.NET";
            this.button19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button19.TextOffset = new System.Drawing.Point(-10, 0);
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Transparent;
            this.button18.BorderRadius = 5;
            this.button18.CheckedState.Parent = this.button18;
            this.button18.CustomBorderColor = System.Drawing.Color.Black;
            this.button18.CustomImages.Parent = this.button18;
            this.button18.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button18.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.White;
            this.button18.HoverState.Parent = this.button18;
            this.button18.Image = global::GFNAppLauncher.Properties.Resources.parsec;
            this.button18.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button18.Location = new System.Drawing.Point(321, 188);
            this.button18.Name = "button18";
            this.button18.ShadowDecoration.Parent = this.button18;
            this.button18.Size = new System.Drawing.Size(125, 65);
            this.button18.TabIndex = 53;
            this.button18.Text = "‏‏‎ ‎‏‏‎Parsec ‏‏‎  ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎‏";
            this.button18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button18.TextOffset = new System.Drawing.Point(-10, 0);
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.Transparent;
            this.button29.BorderRadius = 5;
            this.button29.CheckedState.Parent = this.button29;
            this.button29.CustomBorderColor = System.Drawing.Color.Black;
            this.button29.CustomImages.Parent = this.button29;
            this.button29.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button29.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.ForeColor = System.Drawing.Color.White;
            this.button29.HoverState.Parent = this.button29;
            this.button29.Image = global::GFNAppLauncher.Properties.Resources.epicgames;
            this.button29.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button29.Location = new System.Drawing.Point(452, 188);
            this.button29.Name = "button29";
            this.button29.ShadowDecoration.Parent = this.button29;
            this.button29.Size = new System.Drawing.Size(125, 65);
            this.button29.TabIndex = 54;
            this.button29.Text = "Epic Games";
            this.button29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button29.TextOffset = new System.Drawing.Point(-10, 0);
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Transparent;
            this.button30.BorderRadius = 5;
            this.button30.CheckedState.Parent = this.button30;
            this.button30.CustomBorderColor = System.Drawing.Color.Black;
            this.button30.CustomImages.Parent = this.button30;
            this.button30.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button30.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.ForeColor = System.Drawing.Color.White;
            this.button30.HoverState.Parent = this.button30;
            this.button30.Image = global::GFNAppLauncher.Properties.Resources.FDM;
            this.button30.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button30.Location = new System.Drawing.Point(582, 188);
            this.button30.Name = "button30";
            this.button30.ShadowDecoration.Parent = this.button30;
            this.button30.Size = new System.Drawing.Size(125, 65);
            this.button30.TabIndex = 55;
            this.button30.Text = "‏‏‎ ‎FDM ‏‏‎ ‎ ‏‏‎ ‎";
            this.button30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button30.TextOffset = new System.Drawing.Point(-20, 0);
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.Transparent;
            this.button34.BorderRadius = 5;
            this.button34.CheckedState.Parent = this.button34;
            this.button34.CustomBorderColor = System.Drawing.Color.Black;
            this.button34.CustomImages.Parent = this.button34;
            this.button34.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button34.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button34.ForeColor = System.Drawing.Color.White;
            this.button34.HoverState.Parent = this.button34;
            this.button34.Image = global::GFNAppLauncher.Properties.Resources.twitch;
            this.button34.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button34.Location = new System.Drawing.Point(190, 259);
            this.button34.Name = "button34";
            this.button34.ShadowDecoration.Parent = this.button34;
            this.button34.Size = new System.Drawing.Size(125, 65);
            this.button34.TabIndex = 56;
            this.button34.Text = "Twitch Studio";
            this.button34.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Transparent;
            this.button16.BorderRadius = 5;
            this.button16.CheckedState.Parent = this.button16;
            this.button16.CustomBorderColor = System.Drawing.Color.Black;
            this.button16.CustomImages.Parent = this.button16;
            this.button16.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button16.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.HoverState.Parent = this.button16;
            this.button16.Location = new System.Drawing.Point(190, 359);
            this.button16.Name = "button16";
            this.button16.ShadowDecoration.Parent = this.button16;
            this.button16.Size = new System.Drawing.Size(125, 65);
            this.button16.TabIndex = 57;
            this.button16.Text = "Delete Save";
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.BorderRadius = 5;
            this.button14.CheckedState.Parent = this.button14;
            this.button14.CustomBorderColor = System.Drawing.Color.Black;
            this.button14.CustomImages.Parent = this.button14;
            this.button14.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button14.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.HoverState.Parent = this.button14;
            this.button14.Location = new System.Drawing.Point(321, 359);
            this.button14.Name = "button14";
            this.button14.ShadowDecoration.Parent = this.button14;
            this.button14.Size = new System.Drawing.Size(125, 65);
            this.button14.TabIndex = 58;
            this.button14.Text = "Save";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.BorderRadius = 5;
            this.button15.CheckedState.Parent = this.button15;
            this.button15.CustomBorderColor = System.Drawing.Color.Black;
            this.button15.CustomImages.Parent = this.button15;
            this.button15.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button15.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.HoverState.Parent = this.button15;
            this.button15.Location = new System.Drawing.Point(452, 359);
            this.button15.Name = "button15";
            this.button15.ShadowDecoration.Parent = this.button15;
            this.button15.Size = new System.Drawing.Size(125, 65);
            this.button15.TabIndex = 59;
            this.button15.Text = "Restore";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.guna2Button1.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::GFNAppLauncher.Properties.Resources.RegWorkshop;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(321, 259);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(125, 65);
            this.guna2Button1.TabIndex = 60;
            this.guna2Button1.Text = "RegWorkshop";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // button23
            // 
            this.button23.BackgroundImage = global::GFNAppLauncher.Properties.Resources.CloseButton1;
            this.button23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button23.BorderRadius = 10;
            this.button23.CheckedState.Parent = this.button23;
            this.button23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button23.CustomImages.Parent = this.button23;
            this.button23.FillColor = System.Drawing.Color.Transparent;
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button23.ForeColor = System.Drawing.Color.Maroon;
            this.button23.HoverState.Parent = this.button23;
            this.button23.Location = new System.Drawing.Point(34, 3);
            this.button23.Name = "button23";
            this.button23.ShadowDecoration.Parent = this.button23;
            this.button23.Size = new System.Drawing.Size(20, 20);
            this.button23.TabIndex = 61;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.BackgroundImage = global::GFNAppLauncher.Properties.Resources.MinimizeButton1;
            this.button24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button24.BorderRadius = 10;
            this.button24.CheckedState.Parent = this.button24;
            this.button24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button24.CustomImages.Parent = this.button24;
            this.button24.FillColor = System.Drawing.Color.Transparent;
            this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button24.ForeColor = System.Drawing.Color.Maroon;
            this.button24.HoverState.Parent = this.button24;
            this.button24.Location = new System.Drawing.Point(8, 3);
            this.button24.Name = "button24";
            this.button24.ShadowDecoration.Parent = this.button24;
            this.button24.Size = new System.Drawing.Size(20, 20);
            this.button24.TabIndex = 62;
            this.button24.TextOffset = new System.Drawing.Point(0, -1);
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button23);
            this.panel3.Controls.Add(this.button24);
            this.panel3.Location = new System.Drawing.Point(654, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(61, 27);
            this.panel3.TabIndex = 63;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.guna2Button2.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = global::GFNAppLauncher.Properties.Resources.Steam_Logo;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.Location = new System.Drawing.Point(452, 259);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(125, 65);
            this.guna2Button2.TabIndex = 64;
            this.guna2Button2.Text = "Steam USG";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button2.TextOffset = new System.Drawing.Point(-10, 0);
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 5;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.guna2Button3.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Image = global::GFNAppLauncher.Properties.Resources.crystal;
            this.guna2Button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button3.ImageSize = new System.Drawing.Size(27, 27);
            this.guna2Button3.Location = new System.Drawing.Point(582, 259);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(125, 65);
            this.guna2Button3.TabIndex = 65;
            this.guna2Button3.Text = "Crystal";
            this.guna2Button3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button3.TextOffset = new System.Drawing.Point(-26, 0);
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(720, 465);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::GFNAppLauncher.Properties.Resources.defaultLogoBlack1;
            this.Name = "Form1";
            this.Text = "Arcade";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void button28_Click(object sender, EventArgs e)
		{

		}

		private void button27_Click(object sender, EventArgs e)
		{
            form2.Show(this);
            Form2.ParentFormObject = this;
		}

		private void button29_Click(object sender, EventArgs e)
		{
			//EpicGames
			if (File.Exists("B:\\Arcade\\Epic Games\\Launcher\\Engine\\Binaries\\Win64\\EpicGamesLauncher.exe"))
			{
				Process.Start("B:\\Arcade\\Epic Games\\Launcher\\Engine\\Binaries\\Win64\\EpicGamesLauncher.exe");
				return;
			}
            else 
            { 
                Cursor = Cursors.WaitCursor;
                DownloadFile("https://www.dropbox.com/s/donmd2ykc5mhyu7/Epic%20Games.zip?dl=1", "B:\\Arcade\\EpicGames.zip");
			    Cursor = Cursors.Default;
            }

		}

		private void button30_Click(object sender, EventArgs e)
		{
			//FDM
			if (File.Exists("B:\\Arcade\\Free Download Manager\\fdm.exe"))
			{
				Process.Start("B:\\Arcade\\Free Download Manager\\fdm.exe");
				return;
			}
            else 
            { 
            	Cursor = Cursors.WaitCursor;
			    DownloadFile("https://portablegames.xyz/fireforce/FDM.zip", "B:\\Arcade\\FDM.zip");
			    Cursor = Cursors.Default;
            }

		}

        private void button31_Click(object sender, EventArgs e)
        {
			//Star Wars Jedi
			if (File.Exists("B:\\Arcade\\Games\\Star Wars Jedi Fallen Order\\SwGame\\Binaries\\Win64\\starwarsjedifallenorder.exe"))
			{
				Process process = new Process();
				process.StartInfo.FileName = "B:\\Arcade\\Games\\Star Wars Jedi Fallen Order\\SwGame\\Binaries\\Win64\\starwarsjedifallenorder.exe";
				process.StartInfo.WorkingDirectory = "B:\\Arcade\\Games\\Star Wars Jedi Fallen Order\\SwGame\\Binaries\\Win64\\";
			}
			else if (button26.Text == "Normal Drive")
			{
				MessageBox.Show("Only Available in Backup Drive 2");
			}
			else if (button26.Text == "Backup Drive")
			{
				MessageBox.Show("Only Available in Backup Drive 2");
			}
			else if (button26.Text == "Backup Drive 2")
			{
				DownloadGame("ArcadeBackup2:FireForce/Star Wars Jedi Fallen Order", "B:/Arcade/Games/Star Wars Jedi Fallen Order");
			}
		}

        private void button32_Click(object sender, EventArgs e)
        {
			//DBZ Kakarot
			if (File.Exists("B:\\Arcade\\Games\\Dragon Ball Z Kakarot\\AT\\Binaries\\Win64\\AT-Win64-Shipping.exe"))
			{
				Process process = new Process();
				process.StartInfo.FileName = "B:\\Arcade\\Games\\Dragon Ball Z Kakarot\\AT\\Binaries\\Win64\\AT-Win64-Shipping.exe";
				process.StartInfo.WorkingDirectory = "B:\\Arcade\\Games\\Dragon Ball Z Kakarot\\AT\\Binaries\\Win64\\";
			}
			else if (button26.Text == "Normal Drive")
			{
				DownloadGame("ArcadeDrive:FireForce/Dragon Ball Z Kakarot", "B:/Arcade/Games/Dragon Ball Z Kakarot");
			}
			else if (button26.Text == "Backup Drive")
			{
				MessageBox.Show("Only Available in Normal Drive");
			}
			else if (button26.Text == "Backup Drive 2")
			{
				MessageBox.Show("Only Available in Normal Drive");
			}
		}

        private void button33_Click(object sender, EventArgs e)
        {
			//Horizon Zero Dawn
			if (File.Exists("B:\\Arcade\\Games\\Horizon Zero Dawn\\HorizonZeroDawn.exe"))
			{
				Process process = new Process();
				process.StartInfo.FileName = "B:\\Arcade\\Games\\Horizon Zero Dawn\\HorizonZeroDawn.exe";
				process.StartInfo.WorkingDirectory = "B:\\Arcade\\Games\\Horizon Zero Dawn\\";
			}
			else if (button26.Text == "Normal Drive")
			{
				DownloadGame("ArcadeDrive:FireForce/Horizon Zero Dawn", "B:/Arcade/Games/Horizon Zero Dawn");
			}
			else if (button26.Text == "Backup Drive")
			{
				DownloadGame("ArcadeBackup:FireForce/Horizon Zero Dawn", "B:/Arcade/Games/Horizon Zero Dawn");
			}
			else if (button26.Text == "Backup Drive 2")
			{
				DownloadGame("ArcadeBackup2:FireForce/Horizon Zero Dawn", "B:/Arcade/Games/Horizon Zero Dawn");
			}
		}

        private void button34_Click(object sender, EventArgs e)
        {
			//Twitch Studio
			if (File.Exists("B:\\Arcade\\Twitch Studio\\Bin\\TwitchStudio.exe"))
			{
				Process process = new Process();
				process.StartInfo.FileName = "B:\\Arcade\\Twitch Studio\\Bin\\TwitchStudio.exe";
				process.StartInfo.UseShellExecute = true;
				process.StartInfo.WorkingDirectory = "B:\\Arcade\\Twitch Studio\\Bin\\";
				process.Start();
			}
            else
            {
			    Cursor = Cursors.WaitCursor;
			    DownloadFile("https://www.dropbox.com/s/hq44gfnsyl95ith/Twitch%20Studio.zip?dl=1", "B:\\Arcade\\Twitch.zip");
                Cursor = Cursors.Default;
            }

		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //RegWorkshop
            if (File.Exists("B:\\Arcade\\RegWorkshopX64.exe"))
            {
                Process process = new Process();
                process.StartInfo.FileName = "B:\\Arcade\\RegWorkshopX64.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = "B:\\Arcade\\";
                process.Start();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                DownloadFileAsync("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/RegWorkshopX64.exe", "B:\\Arcade\\RegWorkshopX64.exe");
                Cursor = Cursors.Default;
            }

        }

        public async Task AsyncExtract(string zipPath, string destPath)
        {
            if (File.Exists(zipPath))
            {
                await Task.Run(() => ZipFile.ExtractToDirectory(zipPath, destPath));
                File.Delete(zipPath);
            }
        }

        public async static Task OneClickExtract(string zipPath, string destPath, string exePath)
        {
            if (File.Exists(zipPath))
            {
                await Task.Run(() => ZipFile.ExtractToDirectory(zipPath, destPath));
                File.Delete(zipPath);
                await Task.Delay(1000);
                Process.Start(exePath);
            }
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            //Steam USG
            if(!File.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Steamworks Shared\\_CommonRedist\\OpenAL\\2.0.7.0\\steam.exe.old"))
            {
                if(!File.Exists("B:\\Arcade\\steam.exe"))
                {
                    client.DownloadFile("https://github.com/afonsosousah/afonsosousah.github.io/raw/master/files/steam.exe", "B:\\Arcade\\steam.exe");
                }
                Process proc = new Process();
                proc.StartInfo.FileName = "C:\\Program Files (x86)\\Steam\\_steam_installer\\SteamSetup.exe";
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
                foreach (Process p in Process.GetProcessesByName("steam"))
                {
                    p.Kill();
                }
                Process.Start("B:\\Arcade\\steam.exe");
                if (Directory.Exists("C:\\Users\\kiosk\\AppData\\Local\\NVIDIA Corporation"))
                {
                    Directory.Move("C:\\Users\\kiosk\\AppData\\Local\\NVIDIA Corporation", "C:\\Users\\kiosk\\AppData\\Local\\Bruh");
                }
                else
                {
                    MessageBox.Show("NVIDIA Corporation directory not found");
                }
                File.Copy("C:\\Program Files (x86)\\Steam\\steam.exe.old", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Steamworks Shared\\_CommonRedist\\OpenAL\\2.0.7.0\\steam.exe.old");
                Process.Start("C:\\Windows\\System32\\cmd.exe", "/C START \"\" \"C:/Program Files (x86)/Steam/steamapps/common/Steamworks Shared/_CommonRedist/OpenAL/2.0.7.0/steam.exe.old\"");
            }
            else
            {
                Process.Start("C:\\Windows\\System32\\cmd.exe", "/C START \"\" \"C:/Program Files (x86)/Steam/steamapps/common/Steamworks Shared/_CommonRedist/OpenAL/2.0.7.0/steam.exe.old\"");
            }
        }
        public async static Task DownloadFileAsync(string address, string fileName)
        {
            WebClient wc = new WebClient();
            await Task.Run(() => wc.DownloadFile(address, fileName));
            Process.Start(fileName);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //RegWorkshop
            if (File.Exists("B:\\Arcade\\Crystal-Launcher\\launcher.exe"))
            {
                Process process = new Process();
                process.StartInfo.FileName = "B:\\Arcade\\Crystal-Launcher\\launcher.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = "B:\\Arcade\\Crystal-Launcher\\";
                process.Start();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                DownloadFile("https://www.dropbox.com/s/9vt1fibqrr4gvt2/Crystal-Launcher.zip?dl=1", "B:\\Arcade\\CrystalLauncher.zip");
                Cursor = Cursors.Default;
            }
        }

        public void StartDesktop()
        {
            Process.Start("cmd.exe", "/C del \"C:\\Users\\kiosk\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\*.lnk\"");
            Process.Start("cmd.exe", "/C del \"C:\\Users\\kiosk\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\*.exe\"");
            Process.Start("cmd.exe", "/C xcopy /s B:\\Arcade\\WinXShell\\Shortcuts \"C:\\Users\\kiosk\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\"");
            Process.Start("cmd.exe", "/C xcopy /s B:\\Arcade\\WinXShell\\DesktopShortcuts \"%USERPROFILE%\\Desktop\"");

            Process.Start("cmd.exe", "/C REG ADD \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders\" /f /v {374DE290-123F-4565-9164-39C4925E467B} /t REG_EXPAND_SZ /d \"B:\\Arcade\"");

            Process.Start("B:\\Arcade\\WinXShell\\bin\\switcheroo\\nintendoswitch.exe");
            Process.Start("cmd.exe", "/C reg add \"HKEY_CURRENT_USER\\Control Panel\\Desktop\" /v Wallpaper /t REG_SZ /d \"B:\\Arcade\\WinXShell\\bin\\shell\\123.jpg\" /f");
            foreach (Process p in Process.GetProcessesByName("gfndesktop"))
            {
                p.Kill();
            }
            Process.Start("B:\\Arcade\\WinXShell\\bin\\shell\\explorer.exe");
            Process.Start("B:\\Arcade\\WinXShell\\bin\\shell\\wallpaperchanger.exe");
            foreach (Process p in Process.GetProcessesByName("explorer"))
            {
                p.Kill();
            }
            Process.Start("B:\\Arcade\\WinXShell\\bin\\shell\\explorer.exe");
            Process.Start("B:\\Arcade\\WinXShell\\bin\\shell\\wallpaperchanger.exe");
            foreach (Process p in Process.GetProcessesByName("explorer"))
            {
                p.Kill();
            }
            File.Delete("B:\\Arcade\\WinXShell\\bin\\shell\\WinXShell.lua");
            Process.Start("B:\\Arcade\\WinXShell\\bin\\shell\\explorer.exe");
            Process.Start("B:\\Arcade\\WinXShell\\bin\\shell\\wallpaperchanger.exe");

            Process.Start("C:\\Program Files\\Classic Shell\\ClassicStartMenu.exe");
            Process.Start("cmd.exe", "/C start \"\" \"C:\\Program Files\\Classic Shell\\ClassicStartMenu.exe\" -xml \"B:\\Arcade\\WinXShell\\bin\\shell\\Menu_Settings.xml\"");
        }
    }
}
