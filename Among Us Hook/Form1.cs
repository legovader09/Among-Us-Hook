using System;
using System.Drawing;
using System.Windows.Forms;

namespace Among_Us_Hook
{
    public partial class Form1 : Form
    {
        private static string webHook = "";
        private static string channelID = "";
        internal bool micMuted = false;
        protected dWebHook dcWeb = new dWebHook();
        public Form1()
        {
            InitializeComponent();
        }

        public bool Connect()
        {
            try
            {
                dcWeb.ProfilePicture = "";
                dcWeb.UserName = "Hooks";
                dcWeb.WebHook = webHook;
                dcWeb.AppID = "DomsAmongUsHook";

                if (checkBox2.Checked) { dcWeb.SendMessageAsync("au webhook"); UpdateStatus("Established Webhook.", Color.Green); }

                return true;
            }
            catch (Exception ex)
            {
                UpdateStatus(ex.Message, Color.Red);
                return false;
            };
        }

        public void UpdateStatus(string message, Color colour)
        {
            lblStatus.Text = $"Status: {message}";
            lblStatus.ForeColor = colour;
        }

        public bool RunSetup()
        {
            try
            {
                var dia = new CustomDialog
                {
                    PromptMsg = "Please enter your Webhook URL:",
                    title = "Enter Webhook URL",
                };
                if (Properties.Settings.Default.WebhookURL != "")
                {
                    dia.returnVal = Properties.Settings.Default.WebhookURL;
                }

                if (dia.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.WebhookURL = dia.returnVal;
                }
                dia.Dispose();

                var dia2 = new CustomDialog
                {
                    PromptMsg = "Please enter your voice channel ID:",
                    title = "Enter Voice Channel ID"
                };
                if (Properties.Settings.Default.VChannelID != "")
                {
                    dia.returnVal = Properties.Settings.Default.VChannelID;
                }

                if (dia2.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.VChannelID = dia.returnVal;
                }
                dia2.Dispose();

                Properties.Settings.Default.Save();
                return true;
            }
            catch { return false; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.TopMost;
            checkBox2.Checked = Properties.Settings.Default.CheckWebhook;
            TopMost = checkBox1.Checked;
            Connect();

            if (Properties.Settings.Default.WebhookURL == "" || Properties.Settings.Default.VChannelID == "")
            {
                if (RunSetup())
                {
                    channelID = Properties.Settings.Default.VChannelID;
                    webHook = Properties.Settings.Default.WebhookURL;
                }
                else { RunSetup(); }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckWebhook = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dcWeb.SendMessageAsync($"auwebhook mute {channelID}"))
            {
                micMuted = true;
                UpdateStatus("All microphones muted.", Color.Green);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dcWeb.SendMessageAsync($"auwebhook unmute {channelID}"))
            {
                micMuted = false;
                UpdateStatus("All microphones unmuted.", Color.DarkOrange);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dcWeb.SendMessageAsync($"auwebhook end {channelID}"))
            {
                micMuted = false;
                UpdateStatus("Game Ended.", Color.Red);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (micMuted) { dcWeb.SendMessageAsync($"auwebhook end {channelID}"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunSetup();
        }
    }
}
