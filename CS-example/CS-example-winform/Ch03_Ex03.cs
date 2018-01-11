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
    public partial class Ch03_Ex03 : Form
    {
        public Ch03_Ex03()
        {
            InitializeComponent();
        }

        private void Ch03_Ex03_Load(object sender, EventArgs e)
        {
            for(int i = 1990; i <= 2000; i++) { comboBox1.Items.Add(i); }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "your age is " + (2017 - (int)comboBox1.SelectedItem + 1);
        }
    }
}
