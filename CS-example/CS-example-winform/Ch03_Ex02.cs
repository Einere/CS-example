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
    public partial class Ch03_Ex02 : Form
    {
        public Ch03_Ex02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                checkedListBox1.Items.Add(listBox1.SelectedItem, false);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if(checkedListBox1.SelectedIndex >= 0)
            {
                foreach (int n in checkedListBox1.CheckedIndices)
                {
                    listBox1.Items.Add(checkedListBox1.Items[n - cnt]);
                    checkedListBox1.Items.RemoveAt(n - cnt);
                    cnt++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex >= 0)
            {
                foreach(int n in checkedListBox1.CheckedIndices)
                {
                    textBox1.Text = textBox1.Text + checkedListBox1.Items[n].ToString() + "\r\n";
                }
            }
        }
    }
}
