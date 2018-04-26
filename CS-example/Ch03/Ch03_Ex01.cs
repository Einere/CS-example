using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch03
{
    public partial class Ch03_Ex01 : Form
    {
        public Ch03_Ex01()
        {
            InitializeComponent();
        }

        public enum CB_parse_case
        {
            None,
            Year,
            Month,
            Day,
            Combine
        }

        private void Ch03_Ex01_Load(object sender, EventArgs e)
        {
            DateTime local = DateTime.Now;

            for (int i = local.Year - 100; i < local.Year; i++) cb_year.Items.Add(i);
            cb_year.SelectedIndex = cb_year.Items.Count - 1;

            for (int i = 1; i < 12; i++) cb_month.Items.Add(i);
            for (int i = 1; i < 31; i++) cb_day.Items.Add(i);
        }

        private bool is_date(int y, int m, int d)
        {
            return y >= 0 && m > 0 && m < 13 && d > 0 && d <= DateTime.DaysInMonth(y, m);
        }

        private CB_parse_case get_cb_parse_case()
        {
            if (cb_year.SelectedItem == null) return CB_parse_case.Year;
            else if (cb_month.SelectedItem == null) return CB_parse_case.Month;
            else if (cb_day.SelectedItem == null) return CB_parse_case.Day;
            else if (is_date((int)cb_year.SelectedItem, (int)cb_month.SelectedItem, (int)cb_day.SelectedItem)) return CB_parse_case.Combine;
            return CB_parse_case.None;
        }

        private void cb_changed(object sender, EventArgs e)
        {
            switch (get_cb_parse_case())
            {
                case CB_parse_case.Year:
                    lb_alert.Text = "select year";
                    break;
                case CB_parse_case.Month:
                    lb_alert.Text = "select month";
                    break;
                case CB_parse_case.Day:
                    lb_alert.Text = "select day";
                    break;
                case CB_parse_case.Combine:
                    lb_alert.Text = "check year, month, day";
                    break;
                default:
                    lb_alert.Text = "^.^";
                    break;
            }
        }

        private void bt_calc_Click(object sender, EventArgs e)
        {
            if (get_cb_parse_case() != CB_parse_case.None) return;

            int year = (int)cb_year.SelectedItem;
            int month = (int)cb_month.SelectedItem;
            int day = (int)cb_day.SelectedItem;

            DateTime birth = new DateTime(year, month, day);
            DateTime now = DateTime.Now;

            tb_log.Text += "age : " + (now.Year - birth.Year + 1).ToString() + "\r\n";

        }
    }
}
