using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS_example_winform
{
    public partial class Ch04_Ex04 : Form
    {
        StreamReader reader;
        StreamWriter writer;

        public Ch04_Ex04()
        {
            InitializeComponent();
        }

        private void Ch04_Ex04_Load(object sender, EventArgs e)
        {
            try
            {
                reader = new StreamReader("phone.txt");
            }
            catch
            {
                MessageBox.Show("failed to open file");
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if(reader == null)
            {
                MessageBox.Show("file reader is null");
                return;
            }

            if (reader.Peek() < 0) reader.BaseStream.Seek(0, SeekOrigin.Begin);

            this.tbName.Text = reader.ReadLine();
            this.tbPhone.Text = reader.ReadLine();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(tbName.Text.CompareTo("") == 0)
            {
                MessageBox.Show("type the name");
                return;
            }
            if(tbPhone.Text.CompareTo("") == 0)
            {
                MessageBox.Show("type the phone");
                return;
            }
            if(reader != null)
            {
                reader.Close();
                reader.Dispose();
                reader = null;
            }
            if (this.writer == null) this.writer = new StreamWriter("phone.txt", true);

            writer.WriteLine(this.tbName.Text);
            writer.WriteLine(this.tbPhone.Text);
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;

            tbName.Clear();
            tbPhone.Clear();
            tbName.Focus();

            if (reader == null) this.reader = new StreamReader("phone.txt");
                
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (this.reader != null) this.reader.Close();
            if (this.writer != null) this.writer.Close();

            this.Close();
        }
    }
}
