using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void SetProfile(Image pic)
        {
            post_pb_profile.Image = pic;
        }

        public Image GetProfile()
        {
            return post_pb_profile.Image;
        }

        public void SetId(string str)
        {
            post_lb_id.Text = str;
        }

        public string GetId()
        {
            return post_lb_id.Text;
        }

        public void SetTime(string str)
        {
            post_lb_time.Text = str;
        }

        public string GetTime()
        {
            return post_lb_time.Text;
        }

        public void SetPic(Image img)
        {
            post_pb_pic.Image = img;
        }

        public Image GetPic()
        {
            return post_pb_pic.Image;
        }

        public void SetComment(string str)
        {
            post_tb_comment.Text = str;
        }

        public string GetComment()
        {
            return post_tb_comment.Text;
        }
    }
}
