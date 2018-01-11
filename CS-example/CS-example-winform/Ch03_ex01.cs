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
    public partial class Ch03_Ex01 : Form
    {
        public Ch03_Ex01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.SelectedText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(radioButton1.Text, textBox1.Font.Size);
            textBox1.Font = f;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(radioButton2.Text, textBox1.Font.Size);
            textBox1.Font = f;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(radioButton3.Text, textBox1.Font.Size);
            textBox1.Font = f;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Font f;
            if (checkBox1.Checked) f = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, System.Drawing.FontStyle.Bold | textBox1.Font.Style);
            else f = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, System.Drawing.FontStyle.Bold ^ textBox1.Font.Style);

            textBox1.Font = f;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Font f;
            if (checkBox1.Checked) f = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, System.Drawing.FontStyle.Underline | textBox1.Font.Style);
            else f = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, System.Drawing.FontStyle.Underline ^ textBox1.Font.Style);

            textBox1.Font = f;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Font f;
            if (checkBox1.Checked) f = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, System.Drawing.FontStyle.Italic | textBox1.Font.Style);
            else f = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, System.Drawing.FontStyle.Italic ^ textBox1.Font.Style);

            textBox1.Font = f;
        }
    }
}
