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
    public partial class Ch07_Ex04 : Form
    {
        
        public Ch07_Ex04()
        {
            InitializeComponent();
            dataSet1.Tables["Person"].Rows.Add(new object[] { 1, "kim", 30 });
            dataSet1.Tables["person"].Rows.Add(new object[] { 2, "kong", 35 });
            dataSet1.Tables["person"].Rows.Add(new object[] { 3, "park", 20 });
            dataSet1.Tables["person"].Rows.Add(new object[] { 4, "lee", 25 });

            dataGridView1.DataSource = dataSet1.Tables["Person"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataSet1.Tables["Person"].Rows.Add(new object[]
            {
                dataSet1.Tables["Person"].Rows.Count + 1,
                textBox1.Text,
                Convert.ToInt32(textBox2.Text)
            });
        }
    }
}
