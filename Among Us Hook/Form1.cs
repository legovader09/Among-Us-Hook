using System;
using System.Drawing;
using System.Windows.Forms;

namespace Among_Us_Hook
{
    public partial class Form1 : Form
    {
        private static readonly string webHook = "https://discord.com/api/webhooks/767012934806274058/z87rHyTBsgD_ldVKPndVK8L0WQdhX4YwWfaDcK9Fp4sNJEVQ8dkDx2dc5CsRl4neENFV";
        private static readonly string channelID = "764643880762081301";
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

                dcWeb.SendMessageAsync("au webhook");
                UpdateStatus("Established Webhook", Color.Green);
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
            lblStatus.Text = $"Status: {message}.";
            lblStatus.ForeColor = colour;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.TopMost;
            TopMost = checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = checkBox1.Checked;
            Properties.Settings.Default.Save();
            Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dcWeb.SendMessageAsync($"auwebhook mute {channelID}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dcWeb.SendMessageAsync($"auwebhook unmute {channelID}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dcWeb.SendMessageAsync($"auwebhook end {channelID}");
        }
    }
}
