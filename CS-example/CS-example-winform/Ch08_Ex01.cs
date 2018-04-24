using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CS_example_winform
{
    public partial class Ch08_Ex01 : Form
    {
        Thread thread;
        static int value = 1;
        public Ch08_Ex01()
        {
            InitializeComponent();
            button1.Click += (sender, e) =>
            {
                ((Button)sender).BackColor = Color.IndianRed;
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(delegate ()
            {
                int goal = value + 1000;

                while (value < goal)
                {
                    label1.Invoke((MethodInvoker)delegate ()
                    {
                        label1.Text = Convert.ToString(value++);
                    }, new object[] { });
                }
            });
            thread.Start();
        }
    }
}
