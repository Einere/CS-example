using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using insta_packet;
using System.Collections;
using WindowsFormsControlLibrary1;

namespace insta_server
{
    public partial class Client : Form
    {
        private NetworkStream stream = null;
        private TcpClient client = null;
        private StreamReader f_reader = null;
        private StreamWriter f_writer = null;
        private bool is_connected = false;
        private bool is_login = false;
        private string login_id = null;
        private string search_id = null;
        private string login_password = null;
        private Thread thread = null;
        private static int size = 1024 * 10;
        private byte[] r_buffer = new byte[size];
        private byte[] w_buffer = new byte[size];
        private Flag success = null;
        private Member member = null;
        private Post post = null;
        private Queue<Post> post_Q = new Queue<Post>();
        private Dictionary<string, Image> map = new Dictionary<string, Image>();

        public Client()
        {
            InitializeComponent();

            flpn_home.Parent = this;
            pn_search.Parent = this;
            pn_upload.Parent = this;
            pn_mypage.Parent = this;
            tb_id.Enabled = false;
            tb_password.Enabled = false;
            bt_login.Enabled = false;
            bt_signup.Enabled = false;
        }

        private void pb_home_icon_Click(object sender, EventArgs e)
        {
            flpn_home.Visible = true;
            pn_search.Visible = false;
            pn_upload.Visible = false;
            pn_mypage.Visible = false;
            pb_home_icon.BackColor = Color.FromArgb(150, Color.BurlyWood);
            pb_search_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_upload_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_mypage_icon.BackColor = Color.FromArgb(0, Color.White);

            if (is_login) load_home();
            else MessageBox.Show("please log in");
        }

        private void load_home()
        {
            //reset post_Q & map& flpn_home
            this.post_Q.Clear();
            this.map.Clear();
            flpn_home.Controls.Clear();

            //set request packet to server
            this.post = new Post();
            this.post.Type = (int)PacketType.post;
            this.post.purpose = 2;

            //send request packet to server
            Packet.Serialize(this.post).CopyTo(w_buffer, 0);
            this.send();

            Thread.Sleep(5000);

            //receive packet until end
            while (this.stream.DataAvailable)
            {
                //receive result packet from server
                //if error occur during prepare stream & r_buffer
                if (!preparing_receive()) return;

                Packet packet = (Packet)Packet.Deserialize(this.r_buffer);

                switch (packet.Type)
                {
                    //if receive Member packet
                    case (int)PacketType.member:
                        {
                            this.member = (Member)Packet.Deserialize(this.r_buffer);

                            if(this.member.purpose == 5)
                            {
                                try
                                {
                                    map.Add(this.member.ID, new ImageConverter().ConvertFrom(this.member.profile_pic) as Image);
                                }
                                catch(ArgumentException e)
                                {
                                    MessageBox.Show(string.Format("duplicate id when input data map... id : {0}",this.member.ID));
                                }
                                
                            }
                        }
                        break;
                    //if receive Post packet
                    case (int)PacketType.post:
                        {
                            this.post = (Post)Packet.Deserialize(this.r_buffer);

                            if(this.post.purpose == 2)
                            {
                                this.post_Q.Enqueue(this.post);
                            }
                        }
                        break;
                }
            }

            //add post at flpn_home
            foreach (Post p in post_Q)
            {
                //alloc new post panel and set data
                UserControl1 tmp = new UserControl1();
                tmp.SetProfile(map[p.ID]);
                tmp.SetId(p.ID);
                tmp.SetPic(new ImageConverter().ConvertFrom(p.picture) as Image);
                tmp.SetComment(p.comment);
                tmp.SetTime(new DateTimeConverter().ConvertToString(p.time));

                //add flpn_post
                flpn_home.Controls.Add(tmp);
            }

        }

        private void pb_search_icon_Click(object sender, EventArgs e)
        {
            flpn_home.Visible = false;
            pn_search.Visible = true;
            pn_upload.Visible = false;
            pn_mypage.Visible = false;
            pb_home_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_search_icon.BackColor = Color.FromArgb(150, Color.BurlyWood);
            pb_upload_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_mypage_icon.BackColor = Color.FromArgb(0, Color.White);

            //if loged in
            if (this.is_login)
            {
                //init lb_search
                lb_search.Items.Clear();

                //set Member packet to send
                Member request = new Member();
                request.Type = (int)PacketType.member;
                request.purpose = 3;

                //serialize and send
                Packet.Serialize(request).CopyTo(this.w_buffer, 0);
                send();

                MessageBox.Show(string.Format("DataAvailable : {0}", this.stream.DataAvailable));

                //receive result packet until end
                while (this.stream.DataAvailable)
                {
                    //receive result packet from server
                    //if error occur during prepare stream & r_buffer
                    if (!preparing_receive()) return;

                    Packet packet = (Packet)Packet.Deserialize(this.r_buffer);

                    //if result packet is Member
                    if (packet.Type == (int)PacketType.member)
                    {
                        this.member = (Member)Packet.Deserialize(this.r_buffer);

                        //if result packet is for member list
                        if (this.member.purpose == 3 && this.member.ID != this.login_id)
                        {
                            lb_search.Items.Add(this.member.ID);
                            //MessageBox.Show(string.Format("received id : {0}", this.member.ID));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("not loged in");
            }
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            //for all element. it change collection, so can't use foreach
            for(int i=0; i<lb_search.Items.Count; i++)
            {
                //if listbox item don't contain search word, remove that item
                if (!lb_search.Items[i].ToString().Contains(tb_search.Text)) lb_search.Items.RemoveAt(i--);
            }
        }

        private void lb_search_DoubleClick(object sender, EventArgs e)
        {
            //set search id
            if (lb_search.SelectedItem != null) this.search_id = lb_search.SelectedItem.ToString();

            //trigger bt_grid
            pb_mypage_icon_Click(null, null);
        }

        private void pb_upload_icon_Click(object sender, EventArgs e)
        {
            flpn_home.Visible = false;
            pn_search.Visible = false;
            pn_upload.Visible = true;
            pn_mypage.Visible = false;
            pb_home_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_search_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_upload_icon.BackColor = Color.FromArgb(150, Color.BurlyWood);
            pb_mypage_icon.BackColor = Color.FromArgb(0, Color.White);
            tb_find.Enabled = false;

            if (this.is_login)
            {
                bt_find.Enabled = true;
                tb_upload.Enabled = true;
                bt_upload.Enabled = true;
            }
            else
            {
                bt_find.Enabled = false;
                tb_upload.Enabled = false;
                bt_upload.Enabled = false;

                MessageBox.Show("not loged in");
            }
        }

        private void bt_find_Click(object sender, EventArgs e)
        {
            //if select picture
            if(OFD.ShowDialog() == DialogResult.OK)
            {
                tb_find.Text = OFD.FileName;
                pb_upload.Image = Image.FromFile(OFD.FileName);
            } 
        }

        private void bt_upload_Click(object sender, EventArgs e)
        {
            //if don't select picture
            if (pb_upload.Image == null)
            {
                MessageBox.Show("select picture to upload");
                return;
            }

            //send post packet to server
            this.post = new Post();
            this.post.Type = (int)PacketType.post;
            this.post.purpose = 1;
            this.post.ID = this.login_id;
            this.post.picture = new ImageConverter().ConvertTo(pb_upload.Image, typeof(byte[])) as byte[];
            this.post.comment = tb_upload.Text;
            this.post.time = DateTime.Now;

            //send post packet
            Packet.Serialize(post).CopyTo(this.w_buffer, 0);
            this.send();

            MessageBox.Show("uploading...");

            //receive result packet from server
            //if error occur during prepare stream & r_buffer
            if (!preparing_receive()) return;

            Packet packet = (Packet)Packet.Deserialize(this.r_buffer);

            //if received flag packet
            if (packet.Type == (int)PacketType.flag)
            {
                this.success = (Flag)Packet.Deserialize(this.r_buffer);

                if (this.success.success)
                {
                    //if success to upload
                    MessageBox.Show("upload sucess");

                    //reset control
                    tb_find.Text = null;
                    pb_upload.Image = null;
                    tb_upload.Text = null;
                }
                else
                {
                    //if fail to upload
                    MessageBox.Show("upload failed");
                }
            }
        }

        private void pb_mypage_icon_Click(object sender, EventArgs e)
        {
            flpn_home.Visible = false;
            pn_search.Visible = false;
            pn_upload.Visible = false;
            pn_mypage.Visible = true;
            pb_home_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_search_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_upload_icon.BackColor = Color.FromArgb(0, Color.White);
            pb_mypage_icon.BackColor = Color.FromArgb(150, Color.BurlyWood);
            flpn_post.Controls.Clear();
            this.post_Q.Clear();

            if (!this.is_login)
            {
                MessageBox.Show("not loged in");
                return;
            }
            if (this.search_id != null)
            {
                bt_modify.Visible = false;
                tb_profile.Enabled = false;
            }

            //set member packet to send server
            this.member = new Member();
            this.member.Type = (int)PacketType.member;
            this.member.purpose = 4;
            if (this.search_id == null) this.member.ID = this.login_id;
            else this.member.ID = this.search_id;

            //serialize send to server
            Packet.Serialize(this.member).CopyTo(this.w_buffer, 0);
            this.send();

            Thread.Sleep(3000);

            //receive result packet until end
            while (this.stream.DataAvailable)
            {
                //if error occur during prepare stream & r_buffer
                if (!preparing_receive()) return;

                Packet result = (Packet)Packet.Deserialize(this.r_buffer);
                switch (result.Type)
                {
                    //if receive member pacekt
                    case (int)PacketType.member:
                        {
                            this.member = (Member)Packet.Deserialize(this.r_buffer);
                            if (this.member.purpose == 4)
                            {
                                pb_profile.Image = new ImageConverter().ConvertFrom(this.member.profile_pic) as Image;
                                tb_profile.Text = this.member.comment;
                                lb_post_count.Text = this.member.post_count.ToString();
                            }
                            break;
                        }
                    //if receive post packet
                    case (int)PacketType.post:
                        {
                            this.post = (Post)Packet.Deserialize(this.r_buffer);

                            //push received packet to post_Q
                            this.post_Q.Enqueue(this.post);

                            break;
                        }
                }
            }
            //trigger bt_grid
            bt_view_grid.PerformClick();

            this.search_id = null;
        }

        private void bt_view_grid_Click(object sender, EventArgs e)
        {
            //reset flpn_post
            flpn_post.Controls.Clear();
            
            foreach(Post p in post_Q)
            {
                //make new picturebox, add to flpn_post
                PictureBox pb = new PictureBox();
                pb.Size = new Size(200, 200);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = new ImageConverter().ConvertFrom(p.picture) as Image;
                flpn_post.Controls.Add(pb);
            }

        }

        private void bt_view_list_Click(object sender, EventArgs e)
        {
            //reset flpn_post
            flpn_post.Controls.Clear();

            foreach(Post p in post_Q)
            {
                //alloc new post panel and set data
                UserControl1 tmp = new UserControl1();
                tmp.SetProfile(pb_profile.Image);
                tmp.SetId(login_id);
                tmp.SetTime(new DateTimeConverter().ConvertToString(p.time));
                tmp.SetPic(new ImageConverter().ConvertFrom(p.picture) as Image);
                tmp.SetComment(p.comment);
                
                //add flpn_post
                flpn_post.Controls.Add(tmp);
            }
        }

        private void pb_profile_Click(object sender, EventArgs e)
        {
            //open dialog and select picture
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pb_profile.Image = Image.FromFile(OFD.FileName);
            }
        }

        private void bt_modify_Click(object sender, EventArgs e)
        {
            //set Member packet to modify
            Member mem = new Member();
            mem.Type = (int)PacketType.member;
            mem.purpose = 6;
            mem.ID = login_id;
            mem.profile_pic = new ImageConverter().ConvertTo(pb_profile.Image, typeof(byte[])) as byte[];
            mem.comment = tb_profile.Text;

            //serialize and send Member packet
            Packet.Serialize(mem).CopyTo(this.w_buffer, 0);
            this.send();

            MessageBox.Show("send modify packet...");

            //receive result packet
            if (!preparing_receive()) return;

            Packet packet = (Packet)Packet.Deserialize(this.r_buffer);
            if (packet.Type == (int)PacketType.flag)
            {
                this.success = (Flag)Packet.Deserialize(this.r_buffer);
                //if success to modify 
                if (this.success.success) MessageBox.Show("success to modify member info");
                else MessageBox.Show("failed to modify member info");
            }

        }

        private void send()
        {
            if(this.stream != null)
            {
                //write w_buffer's data at stream, and flush
                this.stream.Write(this.w_buffer, 0, this.w_buffer.Length);
                this.stream.Flush();

                //init w_buffer
                for (int i = 0; i < size; i++) this.w_buffer[i] = 0;
            }
            else
            {
                MessageBox.Show("this.stream is null");
            }
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            //check if connected
            if (!this.is_connected)
            {
                //make client socket
                this.client = new TcpClient();
                try
                {
                    //connect to server
                    this.client.Connect(this.tb_ip.Text, int.Parse(this.tb_port.Text));
                }
                catch
                {
                    MessageBox.Show("connect error");
                    return;
                }

                this.is_connected = true;
                //get stream
                this.stream = this.client.GetStream();

                //set enable textbox and button
                tb_ip.Enabled = false;
                tb_port.Enabled = false;
                tb_id.Enabled = true;
                tb_password.Enabled = true;
                bt_login.Enabled = true;
                bt_signup.Enabled = true;

                //set this button to "disconnect"
                bt_connect.ForeColor = Color.OrangeRed;
                bt_connect.Text = "disconnect";
            }
            else
            {
                //close stream
                if (this.stream != null)
                {
                    this.stream.Close();
                    this.stream = null;
                }

                //close socket
                if (this.client != null)
                {
                    //this.client.Close();
                    //this.client = null;
                }

                this.is_connected = false;

                //set enable textbox and button
                tb_ip.Enabled = true;
                tb_port.Enabled = true;
                tb_id.Enabled = false;
                tb_password.Enabled = false;
                bt_login.Enabled = false;
                bt_signup.Enabled = false;

                //set this button to "connect"
                bt_connect.ForeColor = Color.Black;
                bt_connect.Text = "connect";
            }
        }

        private bool preparing_receive()
        {
            //receive result packet from server
            int n_read = 0;

            try
            {
                //read data from stream to r_buffer
                n_read = this.stream.Read(this.r_buffer, 0, size);
            }
            catch
            {
                MessageBox.Show("failed to read stream");
                return false;
            }

            //if r_buffer is null
            if (this.r_buffer == null)
            {
                MessageBox.Show("r_buffer is null");
                return false;
            }

            //need to deal when disconnecting signal recieved
            if (n_read == 0)
            {
                this.is_connected = false;
                MessageBox.Show("received 0 length packet");
                return false;
            }

            return true;
        }

        private void bt_signup_Click(object sender, EventArgs e)
        {
            if (this.is_connected)
            {
                //set packet to send
                Member mem = new Member();
                mem.Type = (int)PacketType.member;
                mem.purpose = 1;
                mem.ID = this.tb_id.Text;
                mem.password = this.tb_password.Text;
                mem.profile_pic = new ImageConverter().ConvertTo(Image.FromFile("C:/Users/HJ/Desktop/공부/3-1/응용소프트웨어실습/[과제]02 - instagram/profile_img.jpg"), typeof(byte[])) as byte[];
                mem.comment = null;
                mem.post_count = 0;

                //serialize packet and send
                Packet.Serialize(mem).CopyTo(this.w_buffer, 0);
                this.send();

                //receive result packet from server
                //if error occur during prepare stream & r_buffer
                if (!preparing_receive()) return;

                Packet packet = (Packet)Packet.Deserialize(this.r_buffer);

                //if received flag packet
                if (packet.Type == (int)PacketType.flag)
                {
                    this.success = (Flag)Packet.Deserialize(this.r_buffer);

                    if (this.success.success)
                    {
                        MessageBox.Show("sign up success");
                    }
                    else
                    {
                        MessageBox.Show("sign up fail");
                    }
                }
            }
            else
            {
                MessageBox.Show("not connected");
            }
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (this.is_connected)
            {
                //set packet to send
                Member mem = new Member();
                mem.Type = (int)PacketType.member;
                mem.purpose = 2;
                mem.ID = tb_id.Text;
                mem.password = tb_password.Text;

                //serialize packet and send
                Packet.Serialize(mem).CopyTo(this.w_buffer, 0);
                this.send();

                //receive result packet from server
                //if error occur during prepare stream & r_buffer
                if (!preparing_receive()) return;

                Packet packet = (Packet)Packet.Deserialize(this.r_buffer);

                //if received flag packet
                if (packet.Type == (int)PacketType.flag)
                {
                    this.success = (Flag)Packet.Deserialize(this.r_buffer);

                    if (this.success.success)
                    {
                        //if success to log in
                        MessageBox.Show("log in success");

                        //change bt_login button
                        bt_login.ForeColor = Color.OrangeRed;
                        bt_login.Text = "log out";

                        //set log_in_id & log_in_password
                        this.is_login = true;
                        this.login_id = tb_id.Text;
                        this.login_password = tb_password.Text;
                    }
                    else
                    {
                        //if fail to log in
                        MessageBox.Show("log in fail");
                    }
                }
            }
            else
            {
                MessageBox.Show("not connected");
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close socket and stream
            if (this.client != null) this.client.Close();
            if (this.stream != null) this.stream.Close();
        }

        private void post_tb_id_Click(object sender, EventArgs e)
        {

        }

        
    }
}
