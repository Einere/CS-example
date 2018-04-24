﻿using System;
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
    public partial class Ch05_Ex03 : Form
    {
        public Ch05_Ex03()
        {
            InitializeComponent();
        }

        private void Dialog_Changed(object obj, EventArgs e)
        {
            Form dlg = obj as Form;
            this.BackColor = dlg.BackColor;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ch05_Ex03_1 mad = new Ch05_Ex03_1();
            mad.Owner = this;
            mad.Changed += new EventHandler(Dialog_Changed);
            mad.Show();
        }
    }
}
