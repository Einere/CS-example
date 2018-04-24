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

namespace CS_example_winform
{
    public partial class Ch05_Ex04 : Form
    {
        public Ch05_Ex04()
        {
            InitializeComponent();
        }

        private void Ch05_Ex04_Load(object sender, EventArgs e)
        {
            string[] Drv_list;
            TreeNode root;
            //get all drive list
            Drv_list = Environment.GetLogicalDrives();

            foreach(string Drv in Drv_list)
            {
                root = trvDir.Nodes.Add(Drv);
                root.ImageIndex = 2; //image list number

                //set first node to be 1st drive
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lstFiles.SelectedItems;

            foreach (ListViewItem item in siList) OpenItem(item);
        }

        public void OpenItem(ListViewItem item)
        {
            TreeNode node, child;

            if(item.Tag.ToString() == "D")
            {
                //expand selected treeview's node
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
            else
            {
                Process.Start(IblPath.Text + "\\" + item.Text);
            }

        }

        private void trvDir_AfterSelect(object sender, TreeViewEventArgs e)
        {

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DirectoryInfo di;
            DirectoryInfo[] diarray;
            ListViewItem item;
            FileInfo[] fiArray;

            try
            {
                di = new DirectoryInfo(e.Node.FullPath);
                IblPath.Text = e.Node.FullPath.Substring(0, 2) + e.Node.FullPath.Substring(3);
                lstFiles.Items.Clear();

                diarray = di.GetDirectories();
                foreach(DirectoryInfo tdis in diarray)
                {
                    item = lstFiles.Items.Add(tdis.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add(tdis.LastWriteTime.ToString());
                    item.ImageIndex = 0;
                    item.Tag = "0";
                }

                fiArray = di.GetFiles();
                foreach(FileInfo fis in fiArray)
                {
                    item = lstFiles.Items.Add(fis.Name);
                    item.SubItems.Add(fis.Length.ToString());
                    item.SubItems.Add(fis.LastWriteTime.ToString());
                    item.ImageIndex = 1;
                    item.Tag = "F";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
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
            mnuList.Checked = false;
            mnuSmall.Checked = false;
            mnuLarge.Checked = false;

            switch (item.Text)
            {
                case "detail":
                    mnuDetail.Checked = true;
                    lstFiles.View = View.Details;
                    break;
                case "simple":
                    mnuList.Checked = true;
                    lstFiles.View = View.List;
                    break;
                case "small icon":
                    mnuSmall.Checked = true;
                    lstFiles.View = View.SmallIcon;
                    break;
                case "large icon":
                    mnuLarge.Checked = true;
                    lstFiles.View = View.LargeIcon;
                    break;
            }
        }
    }
}
