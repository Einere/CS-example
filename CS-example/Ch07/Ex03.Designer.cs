namespace Ch07
{
    partial class Ex03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_book = new System.Windows.Forms.Label();
            this.lb_periodical = new System.Windows.Forms.Label();
            this.lb_food = new System.Windows.Forms.Label();
            this.tb_book = new System.Windows.Forms.TextBox();
            this.tb_periodical = new System.Windows.Forms.TextBox();
            this.tb_food = new System.Windows.Forms.TextBox();
            this.bt_display = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_book
            // 
            this.lb_book.AutoSize = true;
            this.lb_book.Location = new System.Drawing.Point(10, 10);
            this.lb_book.Margin = new System.Windows.Forms.Padding(3);
            this.lb_book.Name = "lb_book";
            this.lb_book.Size = new System.Drawing.Size(32, 12);
            this.lb_book.TabIndex = 0;
            this.lb_book.Text = "book";
            // 
            // lb_periodical
            // 
            this.lb_periodical.AutoSize = true;
            this.lb_periodical.Location = new System.Drawing.Point(10, 40);
            this.lb_periodical.Name = "lb_periodical";
            this.lb_periodical.Size = new System.Drawing.Size(60, 12);
            this.lb_periodical.TabIndex = 1;
            this.lb_periodical.Text = "periodical";
            // 
            // lb_food
            // 
            this.lb_food.AutoSize = true;
            this.lb_food.Location = new System.Drawing.Point(10, 70);
            this.lb_food.Name = "lb_food";
            this.lb_food.Size = new System.Drawing.Size(29, 12);
            this.lb_food.TabIndex = 2;
            this.lb_food.Text = "food";
            // 
            // tb_book
            // 
            this.tb_book.Location = new System.Drawing.Point(90, 7);
            this.tb_book.Name = "tb_book";
            this.tb_book.Size = new System.Drawing.Size(100, 21);
            this.tb_book.TabIndex = 3;
            // 
            // tb_periodical
            // 
            this.tb_periodical.Location = new System.Drawing.Point(90, 37);
            this.tb_periodical.Name = "tb_periodical";
            this.tb_periodical.Size = new System.Drawing.Size(100, 21);
            this.tb_periodical.TabIndex = 4;
            // 
            // tb_food
            // 
            this.tb_food.Location = new System.Drawing.Point(90, 67);
            this.tb_food.Name = "tb_food";
            this.tb_food.Size = new System.Drawing.Size(100, 21);
            this.tb_food.TabIndex = 5;
            // 
            // bt_display
            // 
            this.bt_display.Location = new System.Drawing.Point(30, 110);
            this.bt_display.Name = "bt_display";
            this.bt_display.Size = new System.Drawing.Size(75, 23);
            this.bt_display.TabIndex = 6;
            this.bt_display.Text = "display";
            this.bt_display.UseVisualStyleBackColor = true;
            this.bt_display.Click += new System.EventHandler(this.bt_display_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.Location = new System.Drawing.Point(30, 150);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(75, 23);
            this.bt_clear.TabIndex = 7;
            this.bt_clear.Text = "clear";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(30, 190);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 8;
            this.bt_exit.Text = "exit";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // Ex03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 450);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_display);
            this.Controls.Add(this.tb_food);
            this.Controls.Add(this.tb_periodical);
            this.Controls.Add(this.tb_book);
            this.Controls.Add(this.lb_food);
            this.Controls.Add(this.lb_periodical);
            this.Controls.Add(this.lb_book);
            this.Name = "Ex03";
            this.Text = "Ex03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_book;
        private System.Windows.Forms.Label lb_periodical;
        private System.Windows.Forms.Label lb_food;
        private System.Windows.Forms.TextBox tb_book;
        private System.Windows.Forms.TextBox tb_periodical;
        private System.Windows.Forms.TextBox tb_food;
        private System.Windows.Forms.Button bt_display;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_exit;
    }
}