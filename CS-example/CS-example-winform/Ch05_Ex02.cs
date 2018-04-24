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
    public partial class Ch05_Ex02 : Form
    {
        public Ch05_Ex02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ch05_Ex02_2 md = new Ch05_Ex02_2();
            md.Owner = this;
            md.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ch05_Ex02_2 md = new Ch05_Ex02_2();
            DialogResult dResult = md.ShowDialog();

            if (dResult == DialogResult.OK) MessageBox.Show("OK");
            else MessageBox.Show("Cancel");
        }
    }
}
