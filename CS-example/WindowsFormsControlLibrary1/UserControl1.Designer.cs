namespace WindowsFormsControlLibrary1
{
    partial class UserControl1
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.post_pb_profile = new System.Windows.Forms.PictureBox();
            this.post_lb_id = new System.Windows.Forms.Label();
            this.post_lb_time = new System.Windows.Forms.Label();
            this.post_pb_pic = new System.Windows.Forms.PictureBox();
            this.post_tb_comment = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.post_pb_profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.post_pb_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // post_pb_profile
            // 
            this.post_pb_profile.Location = new System.Drawing.Point(10, 10);
            this.post_pb_profile.Name = "post_pb_profile";
            this.post_pb_profile.Size = new System.Drawing.Size(50, 50);
            this.post_pb_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.post_pb_profile.TabIndex = 0;
            this.post_pb_profile.TabStop = false;
            // 
            // post_lb_id
            // 
            this.post_lb_id.AutoSize = true;
            this.post_lb_id.Location = new System.Drawing.Point(86, 30);
            this.post_lb_id.Name = "post_lb_id";
            this.post_lb_id.Size = new System.Drawing.Size(38, 12);
            this.post_lb_id.TabIndex = 1;
            this.post_lb_id.Text = "label1";
            // 
            // post_lb_time
            // 
            this.post_lb_time.AutoSize = true;
            this.post_lb_time.Location = new System.Drawing.Point(246, 30);
            this.post_lb_time.Name = "post_lb_time";
            this.post_lb_time.Size = new System.Drawing.Size(38, 12);
            this.post_lb_time.TabIndex = 2;
            this.post_lb_time.Text = "label2";
            // 
            // post_pb_pic
            // 
            this.post_pb_pic.Location = new System.Drawing.Point(10, 66);
            this.post_pb_pic.Name = "post_pb_pic";
            this.post_pb_pic.Size = new System.Drawing.Size(400, 400);
            this.post_pb_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.post_pb_pic.TabIndex = 3;
            this.post_pb_pic.TabStop = false;
            // 
            // post_tb_comment
            // 
            this.post_tb_comment.Enabled = false;
            this.post_tb_comment.Location = new System.Drawing.Point(10, 472);
            this.post_tb_comment.Multiline = true;
            this.post_tb_comment.Name = "post_tb_comment";
            this.post_tb_comment.Size = new System.Drawing.Size(400, 89);
            this.post_tb_comment.TabIndex = 4;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.post_tb_comment);
            this.Controls.Add(this.post_pb_pic);
            this.Controls.Add(this.post_lb_time);
            this.Controls.Add(this.post_lb_id);
            this.Controls.Add(this.post_pb_profile);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(422, 572);
            ((System.ComponentModel.ISupportInitialize)(this.post_pb_profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.post_pb_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox post_pb_profile;
        private System.Windows.Forms.Label post_lb_id;
        private System.Windows.Forms.Label post_lb_time;
        private System.Windows.Forms.PictureBox post_pb_pic;
        private System.Windows.Forms.TextBox post_tb_comment;
    }
}
