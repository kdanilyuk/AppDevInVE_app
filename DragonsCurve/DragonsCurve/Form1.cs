using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Threading;
using PaintLibrary;

namespace DragonsCurve
{
    public partial class Form1 : Form
    {
        private string path = @"D:\Study\4sem\ДЕЛФИ курсовая\Saved\";

        Color backColor = Color.FromArgb(222, 230, 255);
        Color foreColor = Color.FromArgb(28, 36, 64);
        Color buttonBackColor = Color.FromArgb(201, 214, 255);
        Color graphColor = Color.FromArgb(222, 230, 255);
        Color graphPenColor = Color.FromArgb(222, 222, 180);

        public Form1()
        {
            Thread splashThread = new Thread(new ThreadStart(StartSplashForm));
            splashThread.Start();
            Thread.Sleep(5000);
            splashThread.Abort();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Настраивание цветовой палитры формы 
            this.BackColor = backColor;
            label1.ForeColor = foreColor;
            radioButton1.ForeColor = foreColor;
            radioButton2.ForeColor = foreColor;
            richTextBox1.ForeColor = foreColor;
            richTextBox1.BackColor = backColor;
            toolStrip1.BackColor = backColor;
            toolStrip1.ForeColor = foreColor;
            button1.BackColor = buttonBackColor;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = foreColor;
            button2.BackColor = buttonBackColor;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = foreColor;
            button3.BackColor = buttonBackColor;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = foreColor;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Установление radiobutton
            radioButton1.Select();
            richTextBox1.Text = "13";
        }

        private void StartSplashForm()
        {
            Application.Run(new SplashForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k; // Сложность фрактала
            if (radioButton1.Checked)
            {
                k = int.Parse(richTextBox1.Text);
            }
            else //(radioButton2.Enabled)
            {
                k = Client.GetComplexity();
                richTextBox1.Text = "Server: " + k.ToString();
            }
            Painter painter = new Painter(pictureBox1, k, graphPenColor);
            painter.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            var bgcolor = new SolidBrush(graphColor);
            g.FillRectangle(bgcolor, 0, 0, 660, 516);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Process.Start(path + "DragonCurveInfo.docx");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Process.Start(path + "DragonPresentation.pptx");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            int complexity = 0;
            int.TryParse(richTextBox1.Text, out complexity);
            Painter.SaveAllData(pictureBox1, complexity);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Process.Start(path + "DragonCurveInfo.xls");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:\Study\4sem\ДЕЛФИ курсовая\Help.chm");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            backColor = Color.FromArgb(rnd.Next(0, 50), rnd.Next(0, 50), rnd.Next(0, 50));
            foreColor = Color.FromArgb(rnd.Next(200, 255), rnd.Next(200, 255), rnd.Next(200, 255));
            buttonBackColor = Color.FromArgb(rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100));
            graphColor = Color.FromArgb(rnd.Next(200, 255), rnd.Next(200, 255), rnd.Next(200, 255));
            graphPenColor = Color.FromArgb(rnd.Next(180, 210), rnd.Next(180, 255), rnd.Next(170, 244));
            // Настраивание цветовой палитры формы 
            this.BackColor = backColor;
            label1.ForeColor = foreColor;
            radioButton1.ForeColor = foreColor;
            radioButton2.ForeColor = foreColor;
            richTextBox1.ForeColor = foreColor;
            richTextBox1.BackColor = backColor;
            toolStrip1.BackColor = backColor;
            toolStrip1.ForeColor = foreColor;
            button1.BackColor = buttonBackColor;
            button1.ForeColor = foreColor;
            button2.BackColor = buttonBackColor;
            button2.ForeColor = foreColor;
            button3.BackColor = buttonBackColor;
            button3.ForeColor = foreColor;
        }
    }
}
