using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch09
{
    public partial class Form1 : Form
    {
        DataSet1 dataset;

        public Form1()
        {
            InitializeComponent();
            dataset = new DataSet1();
            dataset.Tables["Person"].Rows.Add(new object[] { 1, "kim", 20 });
            dataset.Tables["Person"].Rows.Add(new object[] { 2, "lee", 22 });
            dataset.Tables["Person"].Rows.Add(new object[] { 3, "park", 24 });
            dataGridView1.DataSource = dataset.Tables["Person"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataset.Tables["Person"].Rows.Add(new object[] { dataset.Tables["Person"].Rows.Count + 1, textBox1.Text, Convert.ToInt64(textBox2.Text) });
        }
    }
}
