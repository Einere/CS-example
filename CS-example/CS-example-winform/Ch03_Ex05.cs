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
    public partial class Ch03_Ex05 : Form
    {
        public Ch03_Ex05()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Ch03_Ex05_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("Name", 50, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Age", 50, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Number", 200, HorizontalAlignment.Left);
        }

        private void clearTextBox()
        {
            this.nameTextBox.Text = "";
            this.ageTextBox.Text = "";
            this.numTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item;
            string[] str = new string[3];

            if (nameTextBox.Text.CompareTo("") != 0) str.SetValue(nameTextBox.Text, 0);
            else str.SetValue("NULL", 0);
            if (ageTextBox.Text.CompareTo("") != 0) str.SetValue(ageTextBox.Text, 1);
            else str.SetValue("NULL", 1);
            if (numTextBox.Text.CompareTo("") != 0) str.SetValue(numTextBox.Text, 2);
            else str.SetValue("NULL", 2);

            item = new ListViewItem(str);
            this.listView1.Items.Add(item);

            clearTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null) listView1.FocusedItem.Remove();
            clearTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListViewItem item;
            string[] str = new string[3];

            if (nameTextBox.Text.CompareTo("") != 0) str.SetValue(nameTextBox.Text, 0);
            else {
                item = listView1.FocusedItem;
                str.SetValue(item.SubItems[0].Text, 0);
            }
            if (ageTextBox.Text.CompareTo("") != 0) str.SetValue(ageTextBox.Text, 1);
            else {
                item = listView1.FocusedItem;
                str.SetValue(item.SubItems[1].Text, 1);
            }
            if (numTextBox.Text.CompareTo("") != 0) str.SetValue(numTextBox.Text, 2);
            else {
                item = listView1.FocusedItem;
                str.SetValue(item.SubItems[2].Text, 2);
            }

            item = new ListViewItem(str);
            this.listView1.Items.Add(item);
            this.listView1.FocusedItem.Remove();

            clearTextBox();
        }
    }
}
