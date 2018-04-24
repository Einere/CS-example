namespace insta_client
{
    partial class Server
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
            this.lb_ip = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.lb_port = new System.Windows.Forms.Label();
            this.bt_start = new System.Windows.Forms.Button();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.lb_account = new System.Windows.Forms.Label();
            this.lb_log = new System.Windows.Forms.Label();
            this.lv_member = new System.Windows.Forms.ListView();
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Location = new System.Drawing.Point(12, 9);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(16, 12);
            this.lb_ip.TabIndex = 0;
            this.lb_ip.Text = "IP";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(34, 6);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(306, 21);
            this.tb_ip.TabIndex = 1;
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(362, 9);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(27, 12);
            this.lb_port.TabIndex = 2;
            this.lb_port.Text = "Port";
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(508, 4);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 3;
            this.bt_start.Text = "start";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(395, 6);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(93, 21);
            this.tb_port.TabIndex = 4;
            // 
            // lb_account
            // 
            this.lb_account.AutoSize = true;
            this.lb_account.Location = new System.Drawing.Point(12, 52);
            this.lb_account.Name = "lb_account";
            this.lb_account.Size = new System.Drawing.Size(126, 12);
            this.lb_account.TabIndex = 5;
            this.lb_account.Text = "Member Account List";
            this.lb_account.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Location = new System.Drawing.Point(362, 52);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(66, 12);
            this.lb_log.TabIndex = 6;
            this.lb_log.Text = "Server Log";
            // 
            // lv_member
            // 
            this.lv_member.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Index,
            this.ID,
            this.Password});
            this.lv_member.GridLines = true;
            this.lv_member.Location = new System.Drawing.Point(12, 67);
            this.lv_member.Name = "lv_member";
            this.lv_member.Size = new System.Drawing.Size(346, 371);
            this.lv_member.TabIndex = 7;
            this.lv_member.UseCompatibleStateImageBehavior = false;
            this.lv_member.View = System.Windows.Forms.View.Details;
            // 
            // Index
            // 
            this.Index.Text = "Index";
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Password
            // 
            this.Password.Text = "Password";
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(364, 67);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(424, 371);
            this.tb_log.TabIndex = 8;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.lv_member);
            this.Controls.Add(this.lb_log);
            this.Controls.Add(this.lb_account);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.lb_ip);
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label lb_account;
        private System.Windows.Forms.Label lb_log;
        private System.Windows.Forms.ListView lv_member;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Password;
    }
}

