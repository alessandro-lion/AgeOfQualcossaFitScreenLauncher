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
        private string AO2resparm = "";
        private static string MSGamesFolder = "C:\\Program Files (x86)\\Microsoft Games\\";
        private static string MSGamesFolderw32 = "C:\\Program Files\\Microsoft Games\\";
        private static string AOMX = MSGamesFolder+"Age of Mythology\\aomx.exe";
        private static string AOM = MSGamesFolder+"\\Age of Mythology\\aom.exe";
        private static string AOE2Conquer = MSGamesFolder + "\\Age of Empires II\\Age2_X1\\age2_x1.Exe";
        private static string AOE2 = MSGamesFolder + "\\Age of Empires II\\EMPIRES2.EXE";

        private static string AOMXw32 = MSGamesFolderw32 + "Age of Mythology\\aomx.exe";
        private static string AOMw32 = MSGamesFolderw32 + "\\Age of Mythology\\aom.exe";
        private static string AOE2Conquerw32 = MSGamesFolderw32 + "\\Age of Empires II\\Age2_X1\\age2_x1.Exe";
        private static string AOE2w32 = MSGamesFolderw32 + "\\Age of Empires II\\EMPIRES2.EXE";

        private StringCollection gamepath = new StringCollection();
        private StringCollection gamearg = new StringCollection();
        private int dx;
        private int dy;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //TODO:
            //Loading TXT messages resources
            //System.Resources.ResourceManager rm = new System.Resources.ResourceManager("WpfApplication3.Properties.Resources", Assembly.GetExecutingAssembly());
            //MessageBox.Show(rm.GetString("String1"));

            dx = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
             dy = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            // Checking screen resolution and set AOQresparm
            AOQresparm = " xres=" + dx.ToString()+ " yres="+ dy.ToString();
            labelres.Text = "SIZE:" + AOQresparm;

            if ((dx > 1279) && (dy > 1023))
            { AO2resparm = " 1280"; }
            else if ((dx > 1023) && (dy > 767))
            {    AO2resparm = " 1024";   }
            else if ((dx > 799) && (dy > 599))
            // 800x600
            // 1024x768
            // 1280x1024
            { AO2resparm = " 800"; }

            // Inspecting filesystem
            CheckAOGame("Age of Mythology", AOM, AOQresparm);
            CheckAOGame("Age of Mythology Titan Expansion", AOMX, AOQresparm);
            CheckAOGame("Age of Empires II", AOE2, AO2resparm);
            CheckAOGame("Age of Empires II The Conquer", AOE2Conquer, AO2resparm);

            CheckAOGame("Age of Mythology", AOMw32, AOQresparm);
            CheckAOGame("Age of Mythology Titan Expansion", AOMXw32, AOQresparm);
            CheckAOGame("Age of Empires II", AOE2w32, AO2resparm);
            CheckAOGame("Age of Empires II The Conquer", AOE2Conquerw32, AO2resparm);

            //TODO: FIX BY INSPECTING ACTUAL SYSTEM VOLUMES RATHER THAN HARDCODED DRIVES
            if (listBox1.Items.Count == 0)
            {
                // DRIVE G:
                String ssearch = "C:\\";
                String srval = "G:\\";
                CheckAOGame("Age of Mythology", AOM.Replace(ssearch,srval), AOQresparm);
                CheckAOGame("Age of Mythology Titan Expansion", AOMX.Replace(ssearch, srval), AOQresparm);
                CheckAOGame("Age of Empires II", AOE2.Replace(ssearch, srval), AO2resparm);
                CheckAOGame("Age of Empires II The Conquer", AOE2Conquer.Replace(ssearch, srval), AO2resparm);

                CheckAOGame("Age of Mythology", AOMw32.Replace(ssearch, srval), AOQresparm);
                CheckAOGame("Age of Mythology Titan Expansion", AOMXw32.Replace(ssearch, srval), AOQresparm);
                CheckAOGame("Age of Empires II", AOE2w32.Replace(ssearch, srval), AO2resparm);
                CheckAOGame("Age of Empires II The Conquer", AOE2Conquerw32.Replace(ssearch, srval), AO2resparm);


            }
        }
        private void CheckAOGame(string Title, string Path, string Arg)
        {
            //If the game exist I add it to the Listbox on the form
            try

            { 
            FileInfo sFile = new FileInfo(Path);
            if (sFile.Exists)
            {
                listBox1.Items.Add(Title);
                gamepath.Add(Path);
                gamearg.Add(Arg);
            }
            }
            catch (Exception exception)

             {
                System.Diagnostics.Debug.Print(exception.Message + " but I don't care \n");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count >0)
                {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = gamepath[listBox1.SelectedIndex];
                startInfo.WorkingDirectory = new FileInfo(gamepath[listBox1.SelectedIndex]).Directory.FullName;

                startInfo.Arguments = gamearg[listBox1.SelectedIndex];
                Process.Start(startInfo);

                labelres.Text = "Lancià " + startInfo.FileName + " parm: "+ startInfo.Arguments;
            }
            else
            {
                labelres.Text = "Seesiona un zugo soea lista!";
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
    }
}
