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
    public partial class Ch04_Ex05 : Form
    {
        Ch04_Ex05_01 child;
        int nChild = 0;

        public Ch04_Ex05()
        {
            InitializeComponent();
            LoadSetting();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open stream
                Stream stream = openFileDialog1.OpenFile();
                StreamReader reader = new StreamReader(stream);

                /*
                //read text
                textBox1.Text = reader.ReadToEnd();
                
                //close stream
                reader.Close();
                stream.Close();

                //save file name
                this.Text = openFileDialog1.FileName;
                */

                child = new Ch04_Ex05_01();
                child.MdiParent = this;
                child.Text = "Nonaed" + nChild++;
                child.Show();

                child.getTextBox().Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get file name
            string fname = this.Text;

            //open stream
            StreamWriter writer = new StreamWriter(fname);

            //save text
            writer.Write(textBox1.Text);

            //close stream
            writer.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //get file name
                string fname = saveFileDialog1.FileName;

                //open stream
                StreamWriter writer = new StreamWriter(fname);

                //save text
                writer.Write(textBox1.Text);

                //close stream
                writer.Close();

                //set file name
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

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void autoWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.WordWrap)
            {
                textBox1.WordWrap = false;
                autoWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                textBox1.WordWrap = true;
                autoWrapToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void Ch04_Ex05_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void LoadSetting()
        {
            try
            {
                RegistryKey subkey = Registry.LocalMachine.OpenSubKey("software\\NotePad");

                string fname = subkey.GetValue("FontName").ToString();
                Single fsize = Convert.ToSingle(subkey.GetValue("FontSize"));

                textBox1.Font = new System.Drawing.Font(fname, fsize);

                int color;
                color = Convert.ToInt32(subkey.GetValue("ForeColor"));
                textBox1.ForeColor = System.Drawing.Color.FromArgb(color);

                color = Convert.ToInt32(subkey.GetValue("BackColor"));
                textBox1.BackColor = System.Drawing.Color.FromArgb(color);
            }
            catch
            {

            }
        }

        private void SaveSetting()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("software", true);
                RegistryKey newkey = rk.CreateSubKey("NotePad");

                newkey.SetValue("FontName", textBox1.Font.FontFamily.GetName(0));
                newkey.SetValue("FontSize", Convert.ToString(textBox1.Font.Size));

                newkey.SetValue("ForeColor", Convert.ToString(textBox1.ForeColor.ToArgb()));
                newkey.SetValue("BackColor", Convert.ToString(textBox1.BackColor.ToArgb()));
            }
            catch
            {

            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void badookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = new Ch04_Ex05_01();
            child.MdiParent = this;
            child.Text = "Nonamed" + nChild++;
            child.Show();
        }


    }
}
