using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFNAppLauncher
{
    public partial class Form2 : Form
    {

		private string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


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

		public static Form ParentFormObject { get; set; }

		public Form2()
        {
			AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
			InitializeComponent();
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
			panel3.MouseDown += Form2_MouseDown;
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

		private void Form2_Load(object sender, EventArgs e)
        {

        }

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void Form2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(base.Handle, 161, 2, 0);
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void button24_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void guna2Button1_Click(object sender, EventArgs e)
        {
			//Load SocialClub savegame
			if (File.Exists("C:\\Program Files (x86)\\Steam\\ssfn_SCSave.zip"))
			{
				if (!Directory.Exists(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves"))
				{
					Directory.CreateDirectory(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves");
				}
				if (Directory.Exists(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves\\GTA V"))
				{
					Directory.Delete(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves\\GTA V", true);
				}
				if (Directory.Exists(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves\\RDR2"))
				{
					Directory.Delete(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves\\RDR2", true);
				}
				ZipFile.ExtractToDirectory("C:\\Program Files (x86)\\Steam\\ssfn_SCSave.zip", userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves");
				MessageBox.Show("Savegame Loaded!");
			}
			else { MessageBox.Show("Savegame not found."); }
		}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
			//Save SocialClub savegame
			if (Directory.Exists(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves"))
			{
				if (File.Exists("C:\\Program Files (x86)\\Steam\\ssfn_SCSave.zip"))
				{
					File.Delete("C:\\Program Files (x86)\\Steam\\ssfn_SCSave.zip");
				}
				ZipFile.CreateFromDirectory(userPath + "\\AppData\\Roaming\\Goldberg SocialClub Emu Saves", "C:\\Program Files (x86)\\Steam\\ssfn_SCSave.zip");
				MessageBox.Show("Savegame Saved!");
			}
			else { MessageBox.Show("Savegame not found."); }
		}

        private void guna2Button3_Click(object sender, EventArgs e)
        {
			//Load Cyberpunk Save
			if (File.Exists("C:\\Program Files (x86)\\Steam\\ssfn_CPSave.zip"))
			{
				if (!Directory.Exists(userPath + "\\Saved Games\\CD Projekt Red"))
				{
					Directory.CreateDirectory(userPath + "\\Saved Games\\CD Projekt Red");
				}
				if (Directory.Exists(userPath + "\\Saved Games\\CD Projekt Red\\Cyberpunk 2077"))
				{
					Directory.Delete(userPath + "\\Saved Games\\CD Projekt Red\\Cyberpunk 2077", true);
				}
				ZipFile.ExtractToDirectory("C:\\Program Files (x86)\\Steam\\ssfn_CPSave.zip", userPath + "\\Saved Games\\CD Projekt Red\\");
				MessageBox.Show("Savegame Loaded!");
			}
			else { MessageBox.Show("Savegame not found."); }
		}

        private void guna2Button4_Click(object sender, EventArgs e)
        {
			//Save Cyberpunk Save
			if (Directory.Exists(userPath + "\\Saved Games\\CD Projekt Red\\Cyberpunk 2077"))
			{
				if (File.Exists("C:\\Program Files (x86)\\Steam\\ssfn_CPSave.zip"))
				{
					File.Delete("C:\\Program Files (x86)\\Steam\\ssfn_CPSave.zip");
				}
				ZipFile.CreateFromDirectory(userPath + "\\Saved Games\\CD Projekt Red\\", "C:\\Program Files (x86)\\Steam\\ssfn_CPSave.zip");
				MessageBox.Show("Savegame Saved!");
			}
			else { MessageBox.Show("Savegame not found."); }
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
