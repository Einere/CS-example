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
    public partial class Ch03_Ex04 : Form
    {
        public Ch03_Ex04()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem(
                new string[]
                {
                    textBox1.Text, textBox2.Text, (string)comboBox1.SelectedItem
                }));
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null) return;
            else listView1.FocusedItem.Remove();
        }
    }
}
