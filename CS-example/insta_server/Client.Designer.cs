namespace insta_server
{
    partial class Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.lb_ip = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_subject = new System.Windows.Forms.Label();
            this.lb_id = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_signup = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.bt_login = new System.Windows.Forms.Button();
            this.bt_signup = new System.Windows.Forms.Button();
            this.pb_home_icon = new System.Windows.Forms.PictureBox();
            this.pb_upload_icon = new System.Windows.Forms.PictureBox();
            this.pb_search_icon = new System.Windows.Forms.PictureBox();
            this.pb_mypage_icon = new System.Windows.Forms.PictureBox();
            this.pn_home = new System.Windows.Forms.Panel();
            this.pn_search = new System.Windows.Forms.Panel();
            this.lb_search = new System.Windows.Forms.ListBox();
            this.bt_search = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.pn_upload = new System.Windows.Forms.Panel();
            this.bt_upload = new System.Windows.Forms.Button();
            this.tb_upload = new System.Windows.Forms.TextBox();
            this.pb_upload = new System.Windows.Forms.PictureBox();
            this.bt_find = new System.Windows.Forms.Button();
            this.tb_find = new System.Windows.Forms.TextBox();
            this.pn_mypage = new System.Windows.Forms.Panel();
            this.pn_post = new System.Windows.Forms.Panel();
            this.bt_view_list = new System.Windows.Forms.Button();
            this.bt_view_grid = new System.Windows.Forms.Button();
            this.tb_profile = new System.Windows.Forms.TextBox();
            this.bt_edit = new System.Windows.Forms.Button();
            this.lb_post_count = new System.Windows.Forms.Label();
            this.lb_post = new System.Windows.Forms.Label();
            this.pb_profile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_home_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_upload_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mypage_icon)).BeginInit();
            this.pn_search.SuspendLayout();
            this.pn_upload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_upload)).BeginInit();
            this.pn_mypage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Location = new System.Drawing.Point(12, 15);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(16, 12);
            this.lb_ip.TabIndex = 0;
            this.lb_ip.Text = "IP";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(12, 42);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(26, 12);
            this.lb_port.TabIndex = 1;
            this.lb_port.Text = "port";
            // 
            // lb_subject
            // 
            this.lb_subject.AutoSize = true;
            this.lb_subject.Location = new System.Drawing.Point(110, 80);
            this.lb_subject.Name = "lb_subject";
            this.lb_subject.Size = new System.Drawing.Size(89, 12);
            this.lb_subject.TabIndex = 2;
            this.lb_subject.Text = "Mini Instagram";
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Location = new System.Drawing.Point(12, 112);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(15, 12);
            this.lb_id.TabIndex = 3;
            this.lb_id.Text = "id";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(12, 139);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(61, 12);
            this.lb_password.TabIndex = 4;
            this.lb_password.Text = "password";
            // 
            // lb_signup
            // 
            this.lb_signup.AutoSize = true;
            this.lb_signup.Location = new System.Drawing.Point(12, 188);
            this.lb_signup.Name = "lb_signup";
            this.lb_signup.Size = new System.Drawing.Size(99, 12);
            this.lb_signup.TabIndex = 5;
            this.lb_signup.Text = "has no account?";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(79, 12);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(167, 21);
            this.tb_ip.TabIndex = 6;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(79, 39);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(167, 21);
            this.tb_port.TabIndex = 7;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(79, 109);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(167, 21);
            this.tb_id.TabIndex = 8;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(79, 136);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(167, 21);
            this.tb_password.TabIndex = 9;
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(252, 12);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(75, 48);
            this.bt_connect.TabIndex = 10;
            this.bt_connect.Text = "connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(252, 109);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(75, 48);
            this.bt_login.TabIndex = 11;
            this.bt_login.Text = "log in";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // bt_signup
            // 
            this.bt_signup.Location = new System.Drawing.Point(252, 183);
            this.bt_signup.Name = "bt_signup";
            this.bt_signup.Size = new System.Drawing.Size(75, 23);
            this.bt_signup.TabIndex = 12;
            this.bt_signup.Text = "sign up";
            this.bt_signup.UseVisualStyleBackColor = true;
            this.bt_signup.Click += new System.EventHandler(this.bt_signup_Click);
            // 
            // pb_home_icon
            // 
            this.pb_home_icon.Image = ((System.Drawing.Image)(resources.GetObject("pb_home_icon.Image")));
            this.pb_home_icon.Location = new System.Drawing.Point(12, 372);
            this.pb_home_icon.Name = "pb_home_icon";
            this.pb_home_icon.Size = new System.Drawing.Size(131, 127);
            this.pb_home_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_home_icon.TabIndex = 13;
            this.pb_home_icon.TabStop = false;
            this.pb_home_icon.Click += new System.EventHandler(this.pb_home_icon_Click);
            // 
            // pb_upload_icon
            // 
            this.pb_upload_icon.Image = ((System.Drawing.Image)(resources.GetObject("pb_upload_icon.Image")));
            this.pb_upload_icon.Location = new System.Drawing.Point(12, 505);
            this.pb_upload_icon.Name = "pb_upload_icon";
            this.pb_upload_icon.Size = new System.Drawing.Size(131, 127);
            this.pb_upload_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_upload_icon.TabIndex = 14;
            this.pb_upload_icon.TabStop = false;
            this.pb_upload_icon.Click += new System.EventHandler(this.pb_upload_icon_Click);
            // 
            // pb_search_icon
            // 
            this.pb_search_icon.Image = ((System.Drawing.Image)(resources.GetObject("pb_search_icon.Image")));
            this.pb_search_icon.Location = new System.Drawing.Point(149, 372);
            this.pb_search_icon.Name = "pb_search_icon";
            this.pb_search_icon.Size = new System.Drawing.Size(131, 127);
            this.pb_search_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_search_icon.TabIndex = 15;
            this.pb_search_icon.TabStop = false;
            this.pb_search_icon.Click += new System.EventHandler(this.pb_search_icon_Click);
            // 
            // pb_mypage_icon
            // 
            this.pb_mypage_icon.Image = ((System.Drawing.Image)(resources.GetObject("pb_mypage_icon.Image")));
            this.pb_mypage_icon.Location = new System.Drawing.Point(149, 505);
            this.pb_mypage_icon.Name = "pb_mypage_icon";
            this.pb_mypage_icon.Size = new System.Drawing.Size(131, 127);
            this.pb_mypage_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_mypage_icon.TabIndex = 16;
            this.pb_mypage_icon.TabStop = false;
            this.pb_mypage_icon.Click += new System.EventHandler(this.pb_mypage_icon_Click);
            // 
            // pn_home
            // 
            this.pn_home.Location = new System.Drawing.Point(345, 12);
            this.pn_home.Name = "pn_home";
            this.pn_home.Size = new System.Drawing.Size(677, 620);
            this.pn_home.TabIndex = 17;
            // 
            // pn_search
            // 
            this.pn_search.Controls.Add(this.lb_search);
            this.pn_search.Controls.Add(this.bt_search);
            this.pn_search.Controls.Add(this.tb_search);
            this.pn_search.Location = new System.Drawing.Point(345, 12);
            this.pn_search.Name = "pn_search";
            this.pn_search.Size = new System.Drawing.Size(677, 620);
            this.pn_search.TabIndex = 18;
            this.pn_search.Visible = false;
            // 
            // lb_search
            // 
            this.lb_search.FormattingEnabled = true;
            this.lb_search.ItemHeight = 12;
            this.lb_search.Location = new System.Drawing.Point(3, 30);
            this.lb_search.Name = "lb_search";
            this.lb_search.Size = new System.Drawing.Size(671, 580);
            this.lb_search.TabIndex = 2;
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(599, 1);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(75, 23);
            this.bt_search.TabIndex = 1;
            this.bt_search.Text = "search";
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(3, 3);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(583, 21);
            this.tb_search.TabIndex = 0;
            // 
            // pn_upload
            // 
            this.pn_upload.Controls.Add(this.bt_upload);
            this.pn_upload.Controls.Add(this.tb_upload);
            this.pn_upload.Controls.Add(this.pb_upload);
            this.pn_upload.Controls.Add(this.bt_find);
            this.pn_upload.Controls.Add(this.tb_find);
            this.pn_upload.Location = new System.Drawing.Point(345, 12);
            this.pn_upload.Name = "pn_upload";
            this.pn_upload.Size = new System.Drawing.Size(677, 620);
            this.pn_upload.TabIndex = 19;
            this.pn_upload.Visible = false;
            // 
            // bt_upload
            // 
            this.bt_upload.Location = new System.Drawing.Point(298, 594);
            this.bt_upload.Name = "bt_upload";
            this.bt_upload.Size = new System.Drawing.Size(75, 23);
            this.bt_upload.TabIndex = 4;
            this.bt_upload.Text = "upload";
            this.bt_upload.UseVisualStyleBackColor = true;
            // 
            // tb_upload
            // 
            this.tb_upload.Location = new System.Drawing.Point(3, 471);
            this.tb_upload.Multiline = true;
            this.tb_upload.Name = "tb_upload";
            this.tb_upload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_upload.Size = new System.Drawing.Size(671, 117);
            this.tb_upload.TabIndex = 3;
            // 
            // pb_upload
            // 
            this.pb_upload.Location = new System.Drawing.Point(3, 32);
            this.pb_upload.Name = "pb_upload";
            this.pb_upload.Size = new System.Drawing.Size(671, 433);
            this.pb_upload.TabIndex = 2;
            this.pb_upload.TabStop = false;
            // 
            // bt_find
            // 
            this.bt_find.Location = new System.Drawing.Point(3, 3);
            this.bt_find.Name = "bt_find";
            this.bt_find.Size = new System.Drawing.Size(75, 23);
            this.bt_find.TabIndex = 1;
            this.bt_find.Text = "find";
            this.bt_find.UseVisualStyleBackColor = true;
            // 
            // tb_find
            // 
            this.tb_find.Location = new System.Drawing.Point(84, 5);
            this.tb_find.Name = "tb_find";
            this.tb_find.Size = new System.Drawing.Size(590, 21);
            this.tb_find.TabIndex = 0;
            // 
            // pn_mypage
            // 
            this.pn_mypage.Controls.Add(this.pn_post);
            this.pn_mypage.Controls.Add(this.bt_view_list);
            this.pn_mypage.Controls.Add(this.bt_view_grid);
            this.pn_mypage.Controls.Add(this.tb_profile);
            this.pn_mypage.Controls.Add(this.bt_edit);
            this.pn_mypage.Controls.Add(this.lb_post_count);
            this.pn_mypage.Controls.Add(this.lb_post);
            this.pn_mypage.Controls.Add(this.pb_profile);
            this.pn_mypage.Location = new System.Drawing.Point(345, 12);
            this.pn_mypage.Name = "pn_mypage";
            this.pn_mypage.Size = new System.Drawing.Size(677, 620);
            this.pn_mypage.TabIndex = 20;
            this.pn_mypage.Visible = false;
            // 
            // pn_post
            // 
            this.pn_post.Location = new System.Drawing.Point(3, 166);
            this.pn_post.Name = "pn_post";
            this.pn_post.Size = new System.Drawing.Size(671, 451);
            this.pn_post.TabIndex = 7;
            this.pn_post.Visible = false;
            // 
            // bt_view_list
            // 
            this.bt_view_list.Location = new System.Drawing.Point(432, 137);
            this.bt_view_list.Name = "bt_view_list";
            this.bt_view_list.Size = new System.Drawing.Size(75, 23);
            this.bt_view_list.TabIndex = 6;
            this.bt_view_list.Text = "list";
            this.bt_view_list.UseVisualStyleBackColor = true;
            // 
            // bt_view_grid
            // 
            this.bt_view_grid.Location = new System.Drawing.Point(337, 137);
            this.bt_view_grid.Name = "bt_view_grid";
            this.bt_view_grid.Size = new System.Drawing.Size(75, 23);
            this.bt_view_grid.TabIndex = 5;
            this.bt_view_grid.Text = "grid";
            this.bt_view_grid.UseVisualStyleBackColor = true;
            // 
            // tb_profile
            // 
            this.tb_profile.Location = new System.Drawing.Point(185, 32);
            this.tb_profile.Multiline = true;
            this.tb_profile.Name = "tb_profile";
            this.tb_profile.Size = new System.Drawing.Size(489, 95);
            this.tb_profile.TabIndex = 4;
            // 
            // bt_edit
            // 
            this.bt_edit.Location = new System.Drawing.Point(599, 3);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(75, 23);
            this.bt_edit.TabIndex = 3;
            this.bt_edit.Text = "edit";
            this.bt_edit.UseVisualStyleBackColor = true;
            // 
            // lb_post_count
            // 
            this.lb_post_count.AutoSize = true;
            this.lb_post_count.Location = new System.Drawing.Point(296, 9);
            this.lb_post_count.Name = "lb_post_count";
            this.lb_post_count.Size = new System.Drawing.Size(11, 12);
            this.lb_post_count.TabIndex = 2;
            this.lb_post_count.Text = "0";
            // 
            // lb_post
            // 
            this.lb_post.AutoSize = true;
            this.lb_post.Location = new System.Drawing.Point(185, 9);
            this.lb_post.Name = "lb_post";
            this.lb_post.Size = new System.Drawing.Size(29, 12);
            this.lb_post.TabIndex = 1;
            this.lb_post.Text = "post";
            // 
            // pb_profile
            // 
            this.pb_profile.Image = ((System.Drawing.Image)(resources.GetObject("pb_profile.Image")));
            this.pb_profile.Location = new System.Drawing.Point(3, 3);
            this.pb_profile.Name = "pb_profile";
            this.pb_profile.Size = new System.Drawing.Size(176, 157);
            this.pb_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_profile.TabIndex = 0;
            this.pb_profile.TabStop = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 644);
            this.Controls.Add(this.pn_search);
            this.Controls.Add(this.pn_mypage);
            this.Controls.Add(this.pn_upload);
            this.Controls.Add(this.pn_home);
            this.Controls.Add(this.pb_mypage_icon);
            this.Controls.Add(this.pb_search_icon);
            this.Controls.Add(this.pb_upload_icon);
            this.Controls.Add(this.pb_home_icon);
            this.Controls.Add(this.bt_signup);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.lb_signup);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_id);
            this.Controls.Add(this.lb_subject);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.lb_ip);
            this.Name = "Client";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pb_home_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_upload_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mypage_icon)).EndInit();
            this.pn_search.ResumeLayout(false);
            this.pn_search.PerformLayout();
            this.pn_upload.ResumeLayout(false);
            this.pn_upload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_upload)).EndInit();
            this.pn_mypage.ResumeLayout(false);
            this.pn_mypage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_subject;
        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_signup;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Button bt_signup;
        private System.Windows.Forms.PictureBox pb_home_icon;
        private System.Windows.Forms.PictureBox pb_upload_icon;
        private System.Windows.Forms.PictureBox pb_search_icon;
        private System.Windows.Forms.PictureBox pb_mypage_icon;
        private System.Windows.Forms.Panel pn_home;
        private System.Windows.Forms.Panel pn_search;
        private System.Windows.Forms.ListBox lb_search;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Panel pn_upload;
        private System.Windows.Forms.Button bt_find;
        private System.Windows.Forms.TextBox tb_find;
        private System.Windows.Forms.Button bt_upload;
        private System.Windows.Forms.TextBox tb_upload;
        private System.Windows.Forms.PictureBox pb_upload;
        private System.Windows.Forms.Panel pn_mypage;
        private System.Windows.Forms.Panel pn_post;
        private System.Windows.Forms.Button bt_view_list;
        private System.Windows.Forms.Button bt_view_grid;
        private System.Windows.Forms.TextBox tb_profile;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.Label lb_post_count;
        private System.Windows.Forms.Label lb_post;
        private System.Windows.Forms.PictureBox pb_profile;
    }
}

