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
    public partial class Ch05_Ex03_1 : Form
    {
        public event EventHandler Changed;
        public Ch05_Ex03_1()
        {
            InitializeComponent();
            this.btnApply.Enabled = false;
        }

        private void Color_Scroll(object sender, ScrollEventArgs e)
        {
            this.btnApply.Enabled = true;
            this.BackColor = Color.FromArgb(this.hsbRed.Value, this.hsbGreen.Value, this.hsbBlue.Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(Changed != null)
            {
                if(this.btnApply.Enabled == true)
                {
                    Changed(this, e);
                }
            }
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(Changed != null)
            {
                Changed(this, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
