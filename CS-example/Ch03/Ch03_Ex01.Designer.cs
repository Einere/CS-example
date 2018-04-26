namespace Ch03
{
    partial class Ch03_Ex01
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
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.cb_month = new System.Windows.Forms.ComboBox();
            this.cb_day = new System.Windows.Forms.ComboBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.bt_calc = new System.Windows.Forms.Button();
            this.lb_alert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_year
            // 
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Location = new System.Drawing.Point(12, 12);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(121, 20);
            this.cb_year.TabIndex = 0;
            this.cb_year.Text = "year";
            this.cb_year.SelectedIndexChanged += new System.EventHandler(this.cb_changed);
            this.cb_year.TextChanged += new System.EventHandler(this.cb_changed);
            // 
            // cb_month
            // 
            this.cb_month.FormattingEnabled = true;
            this.cb_month.Location = new System.Drawing.Point(139, 12);
            this.cb_month.Name = "cb_month";
            this.cb_month.Size = new System.Drawing.Size(121, 20);
            this.cb_month.TabIndex = 1;
            this.cb_month.Text = "month";
            this.cb_month.SelectedIndexChanged += new System.EventHandler(this.cb_changed);
            this.cb_month.TextChanged += new System.EventHandler(this.cb_changed);
            // 
            // cb_day
            // 
            this.cb_day.FormattingEnabled = true;
            this.cb_day.Location = new System.Drawing.Point(266, 12);
            this.cb_day.Name = "cb_day";
            this.cb_day.Size = new System.Drawing.Size(121, 20);
            this.cb_day.TabIndex = 2;
            this.cb_day.Text = "day";
            this.cb_day.SelectedIndexChanged += new System.EventHandler(this.cb_changed);
            this.cb_day.TextChanged += new System.EventHandler(this.cb_changed);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(12, 38);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(375, 195);
            this.tb_log.TabIndex = 3;
            // 
            // bt_calc
            // 
            this.bt_calc.Location = new System.Drawing.Point(312, 239);
            this.bt_calc.Name = "bt_calc";
            this.bt_calc.Size = new System.Drawing.Size(75, 23);
            this.bt_calc.TabIndex = 4;
            this.bt_calc.Text = "calculate";
            this.bt_calc.UseVisualStyleBackColor = true;
            this.bt_calc.Click += new System.EventHandler(this.bt_calc_Click);
            // 
            // lb_alert
            // 
            this.lb_alert.AutoSize = true;
            this.lb_alert.Location = new System.Drawing.Point(12, 244);
            this.lb_alert.Name = "lb_alert";
            this.lb_alert.Size = new System.Drawing.Size(38, 12);
            this.lb_alert.TabIndex = 5;
            this.lb_alert.Text = "label1";
            // 
            // Ch03_Ex01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 272);
            this.Controls.Add(this.lb_alert);
            this.Controls.Add(this.bt_calc);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.cb_day);
            this.Controls.Add(this.cb_month);
            this.Controls.Add(this.cb_year);
            this.Name = "Ch03_Ex01";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Ch03_Ex01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.ComboBox cb_month;
        private System.Windows.Forms.ComboBox cb_day;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button bt_calc;
        private System.Windows.Forms.Label lb_alert;
    }
}

