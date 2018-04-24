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
using System.Diagnostics;

namespace _2013726058_CHJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Drv_list;
            TreeNode root;
            Drv_list = Environment.GetLogicalDrives();

            foreach(string Drv in Drv_list)
            {
                root = trvDir.Nodes.Add(Drv);
                root.ImageIndex = 2;

                if (trvDir.SelectedNode == null) trvDir.SelectedNode = root;
                root.SelectedImageIndex = root.ImageIndex;
                root.Nodes.Add("");
            }

        }

        public void setPlus(TreeNode node)
        {
            string path;
            DirectoryInfo dir;
            DirectoryInfo[] di;

            try
            {
                path = node.FullPath;
                dir = new DirectoryInfo(path);
                di = dir.GetDirectories();
                if (di.Length > 0) node.Nodes.Add("");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;

            foreach(ListViewItem item in siList)
            {
                OpenItem(item);
            }
        }

        public void OpenItem(ListViewItem item)
        {
            TreeNode node;
            TreeNode child;

            if(item.Tag.ToString() == "D")
            {
                node = trvDir.SelectedNode;
                node.Expand();

                child = node.FirstNode;
                while(child != null)
                {
                    if(child.Text == item.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            else{
                //for file execute
                Process.Start(txtPath.Text + "\\" + item.Text);
            }
        }

        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string path;
            DirectoryInfo dir;
            DirectoryInfo[] di;
            TreeNode node;

            try
            {
                e.Node.Nodes.Clear();
                path = e.Node.FullPath;
                dir = new DirectoryInfo(path);
                di = dir.GetDirectories();

                foreach(DirectoryInfo dirs in di)
                {
                    node = e.Node.Nodes.Add(dirs.Name);
                    setPlus(node);
                }
            }
            catch(Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DirectoryInfo dir;
            DirectoryInfo[] di;
            ListViewItem item;
            FileInfo[] fi;

            try
            {
                dir = new DirectoryInfo(e.Node.FullPath);
                txtPath.Text = e.Node.FullPath.Substring(0, 2) + e.Node.FullPath.Substring(3);
                lvwFiles.Items.Clear();

                //for directory
                di = dir.GetDirectories();
                foreach(DirectoryInfo dirs in di)
                {
                    item = lvwFiles.Items.Add(dirs.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add(dirs.LastWriteTime.ToString());
                    item.ImageIndex = 0;
                    item.Tag = "D";
                }

                //for file
                fi = dir.GetFiles();
                foreach(FileInfo fils in fi)
                {
                    item = lvwFiles.Items.Add(fils.Name);
                    item.SubItems.Add(fils.Length.ToString());
                    item.SubItems.Add(fils.LastWriteTime.ToString());
                    item.ImageIndex = 1;
                    item.Tag = "F";
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            mnuDetail.Checked = false;
            mnuSimply.Checked = false;
            mnuSmall.Checked = false;
            mnuLarge.Checked = false;

            switch (item.Text)
            {
                case "detail":
                    mnuDetail.Checked = true;
                    lvwFiles.View = View.Details;
                    break;
                case "simply":
                    mnuSimply.Checked = true;
                    lvwFiles.View = View.List;
                    break;
                case "small icon":
                    mnuSmall.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;
                case "large icon":
                    mnuLarge.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
            }
        }
    }
}
