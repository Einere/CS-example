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
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }

        public TextBox GetTextBox()
        {
            return this.textBox1;
        }
    }
}
