using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch07
{
    public partial class Ex03 : Form
    {
        public Ex03()
        {
            InitializeComponent();
            lb_book.ForeColor = Color.CadetBlue;
            lb_periodical.ForeColor = Color.Tan;
            lb_food.ForeColor = Color.OrangeRed;
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            SolidBrush clearBr = new SolidBrush(Ex03.DefaultBackColor);
            Graphics g = this.CreateGraphics();

            tb_book.Clear();
            tb_periodical.Clear();
            tb_food.Clear();

            tb_book.Focus();

            g.FillEllipse(clearBr, 150, 150, 100, 100);
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_display_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            decimal totalSales;
            decimal booksales;
            decimal periodicalSalse;
            decimal foodSales;

            try
            {
                booksales = Decimal.Parse(tb_book.Text);
                periodicalSalse = Decimal.Parse(tb_periodical.Text);
                foodSales = Decimal.Parse(tb_food.Text);
                totalSales = booksales + periodicalSalse + foodSales;

                SolidBrush bookBr = new SolidBrush(Color.CadetBlue);
                SolidBrush periodBr = new SolidBrush(Color.Tan);
                SolidBrush foodBr = new SolidBrush(Color.OrangeRed);

                if(totalSales != 0)
                {
                    int endBook = (int)(booksales / totalSales * 360);
                    int endPeriodical = (int)(periodicalSalse / totalSales * 360);
                    int endFood = (int)(foodSales / totalSales * 360);

                    g.FillPie(bookBr, 150, 150, 100, 100, 0, endBook);
                    g.FillPie(periodBr, 150, 150, 100, 100, endBook, endPeriodical);
                    g.FillPie(foodBr, 150, 150, 100, 100, endBook + endPeriodical, endFood);
                }
            }
            catch
            {
                MessageBox.Show("error");
            }


        }
    }
}
