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

namespace CS_example_winform
{
    public partial class Ch05_Ex01 : Form
    {
        Child child;
        int nChild = 0;

        public Ch05_Ex01()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = new Child();
            child.MdiParent = this;
            child.Text = "NONAMED" + nChild++;
            child.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream str = openFileDialog1.OpenFile();
                StreamReader reader = new StreamReader(str);

                child = new Child();
                child.MdiParent = this;
                child.Text = "NONAMED" + nChild++;
                child.Show();

                child.GetTextBox().Text = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            string fName = "";

            if(child.Text.Substring(0, "NONAMED".Length) == "NONAEMD")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) { fName = saveFileDialog1.FileName; }
                else return;
            }
            else { fName = child.Text; }

            StreamWriter write = new StreamWriter(fName);
            write.Write(child.GetTextBox().Text);
            write.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                child = (Child)(this.ActiveMdiChild);
                string fName = saveFileDialog1.FileName;
                StreamWriter write = new StreamWriter(fName);
                write.Write(child.GetTextBox().Text);
                write.Close();
                child.Text = fName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.GetTextBox().Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.GetTextBox().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.GetTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.GetTextBox().Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.GetTextBox().SelectAll();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (child.GetTextBox().WordWrap)
            {
                child.GetTextBox().WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                child.GetTextBox().WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) child.GetTextBox().Font = fontDialog1.Font;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) child.GetTextBox().ForeColor = colorDialog1.Color; 
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) child.GetTextBox().BackColor = colorDialog1.Color;
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }
    }
}
