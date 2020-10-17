using System;
using System.Windows.Forms;
using Discord;

namespace ActualAmongUs
{
    public partial class Form1 : Form
    {
        private static readonly string webHook = "https://discord.com/api/webhooks/767012934806274058/z87rHyTBsgD_ldVKPndVK8L0WQdhX4YwWfaDcK9Fp4sNJEVQ8dkDx2dc5CsRl4neENFV";
        
        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateStatus(string message, Color colour)
        {
            lblStatus.Text = $"Status: {message}.";
            lblStatus.ForeColor = colour;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            TopMost = checkBox1.Checked;
        }
    }
}
