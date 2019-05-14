using System;
using System.Windows.Forms;


namespace DragonsCurve
{
    public partial class SplashForm : Form
    {
        private Timer timer1;

        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 150;
            progressBar1.Step = 1;
            timer1 = new Timer();
            timer1.Interval = 25; 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            //if (progressBar1.Value == 150) Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
