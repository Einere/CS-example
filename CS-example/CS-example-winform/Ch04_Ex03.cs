using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace CS_example_winform
{
    public partial class Ch04_Ex03 : Form
    {
        public Ch04_Ex03()
        {
            InitializeComponent();
            
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.WordWrap)
            {
                textBox1.WordWrap = false;
                autoToolStripMenuItem.Checked = false;
            }
            else
            {
                textBox1.WordWrap = true;
                autoToolStripMenuItem.Checked = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open stream
                Stream strm = openFileDialog1.OpenFile();
                StreamReader reader = new StreamReader(strm);

                //read text data
                textBox1.Text = reader.ReadToEnd();

                //close stream
                reader.Close();
                strm.Close();

                //set form title
                this.Text = openFileDialog1.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get current file name
            string fname = this.Text;

            //open stream
            StreamWriter writer = new StreamWriter(fname);

            //save text data
            writer.Write(textBox1.Text);

            //close stream
            writer.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //get selected file name
                string fname = saveFileDialog1.FileName;

                //open stream
                StreamWriter writer = new StreamWriter(fname);

                //save text data
                writer.Write(textBox1.Text);

                //close stream
                writer.Close();

                //set form title
                this.Text = fname;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }
    }
}
