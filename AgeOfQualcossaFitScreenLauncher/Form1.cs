using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AgeOfQualcossaFitScreenLauncher
{
    public partial class Form1 : Form
    {
        private string AOQresparm = "";
        private static string AOMX = "C:\\Program Files (x86)\\Microsoft Games\\Age of Mythology\\aomx.exe";
        private static string AOM = "C:\\Program Files (x86)\\Microsoft Games\\Age of Mythology\\aom.exe";
        private static string AOE2Conquer = "C:\\Program Files (x86)\\Microsoft Games\\Age of Empires II\\Age2_X1\\age2_x1.Exe";
        private static string AOE2 = "C:\\Program Files (x86)\\Microsoft Games\\Age of Empires II\\EMPIRES2.EXE";
        private StringCollection gamepath = new StringCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Checking screen resolution and set AOQresparm
            AOQresparm = " xres=" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString()+ " yres="+ System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
            labelres.Text = "SIZE:" + AOQresparm;
            // Inspecting filesystem
            CheckAOGame("Age of Mythology", AOM);
            CheckAOGame("Age of Mythology Titan Expansion", AOMX);
            CheckAOGame("Age of Empires II", AOE2);
            CheckAOGame("Age of Empires II The Conquer", AOE2Conquer);

        }
        private void CheckAOGame(string Title, string Path)
        {
            //If the game exist I add it to the Listbox on the form
            try

            { 
            FileInfo sFile = new FileInfo(AOMX);
            if (sFile.Exists)
            {
                listBox1.Items.Add(Title);
                gamepath.Add(Path);
            }
            }
            catch (Exception exception)

             {
                System.Diagnostics.Debug.Print(exception.Message + " but I don't care \n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >0)
                {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = gamepath[listBox1.SelectedIndex];


                startInfo.Arguments = AOQresparm;
                Process.Start(startInfo);
            }
            else
            {
                labelres.Text = "Seesiona un zugo soea lista!";
            }
        }
    }
}
