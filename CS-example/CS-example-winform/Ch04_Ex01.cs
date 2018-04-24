using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_example_winform
{
    public partial class Ch04_Ex01 : Form
    {
        public Ch04_Ex01()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true) { pictureBox1.Visible = false; }
            else pictureBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) pictureBox1.Image = Image.FromFile(@"C:\Users\HJ\Desktop\einere\이미지\무민움짤_음수.GIF");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) pictureBox1.Image = Image.FromFile(@"C:\Users\HJ\Desktop\einere\이미지\무민움짤_포근한바람.GIF");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) pictureBox1.Image = Image.FromFile(@"C:\Users\HJ\Desktop\einere\이미지\무민움짤_꽃꽂이.GIF");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0) MessageBox.Show("input message");
            else MessageBox.Show(textBox1.Text);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) this.textBox1.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.ForeColor;
            colorDialog1.ShowDialog();
            this.ForeColor = colorDialog1.Color;
            //this.BackColor = colorDialog1.Color;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible) textBox1.Visible = false;
            else textBox1.Visible = true;
        }
    }
}
