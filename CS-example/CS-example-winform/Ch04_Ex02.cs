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
    public partial class Ch04_Ex02 : Form
    {
        StreamReader fileReader;
        StreamWriter fileWriter;

        public Ch04_Ex02()
        {
            InitializeComponent();
        }

        private void Ch04_Ex02_Load(object sender, EventArgs e)
        {
            try
            {
                fileReader = new StreamReader("phone.txt");
            }
            catch
            {
                MessageBox.Show("file open failed!");
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if(fileReader == null)
            {
                MessageBox.Show("file reader is null!");
                return;
            }

            if (fileReader.Peek() < 0) fileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            this.nameTextBox.Text = fileReader.ReadLine();
            this.phoneTextBox.Text = fileReader.ReadLine();

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.CompareTo("") == 0)
            {
                MessageBox.Show("enter the cooperation name");
                return;
            }
            if(phoneTextBox.Text.CompareTo("") == 0)
            {
                MessageBox.Show("enter the phone number");
                return;
            }

            if(fileReader != null)
            {
                fileReader.Close();
                fileReader.Dispose();
                fileReader = null;
            }
            if(this.fileWriter == null) { this.fileWriter = new StreamWriter("phone.txt", true); }

            fileWriter.WriteLine(this.nameTextBox.Text);
            fileWriter.WriteLine(this.phoneTextBox.Text);
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
            fileWriter = null;

            nameTextBox.Clear();
            phoneTextBox.Clear();
            nameTextBox.Focus();

            if (fileReader == null) fileReader = new StreamReader("phone.txt");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (this.fileReader != null) this.fileReader.Close();
            if (this.fileWriter != null) this.fileWriter.Close();
            this.Close();
        }
    }
}
