using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CS_example_winform
{
    public partial class Ch05_Ex05 : Form
    {
        private Thread m_threadPlus;
        private Thread m_threadMinus;

        private int m_nValue = 0;
        private int m_nPlusCount = 0;
        private int m_nMinusCount = 0;

        public delegate void DelegateshowText(string strLabel, string strText);
        public DelegateshowText DelegateShowTextInstance;

        public Ch05_Ex05()
        {
            DelegateShowTextInstance = new DelegateshowText(this.ShowText);
            InitializeComponent();
        }

        private void ShowText(string strLabel, string strText)
        {
            switch (strLabel)
            {
                case "label1":
                    label1.Text = strText;
                    break;
                case "label2":
                    label2.Text = strText;
                    break;
                case "label3":
                    label3.Text = strText;
                    break;
            }
        }

        private void ThreadPlus()
        {
            while(m_nPlusCount < 1000)
            {
                int nValue = m_nValue + 1;
                Thread.Sleep(1);
                m_nValue = nValue;
                Invoke(DelegateShowTextInstance, new object[] { "label1", Convert.ToString(m_nValue) });
                m_nPlusCount++;
                Invoke(DelegateShowTextInstance, new object[] { "label2", Convert.ToString(m_nPlusCount) });
            }
        }

        private void ThreadMinus()
        {
            while(m_nMinusCount > -1000)
            {
                int nValue = m_nValue - 1;
                Thread.Sleep(1);
                m_nValue = nValue;
                Invoke(DelegateShowTextInstance, new object[] { "label1", Convert.ToString(m_nValue) });
                m_nMinusCount--;
                Invoke(DelegateShowTextInstance, new object[] { "label3", Convert.ToString(m_nMinusCount) });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_threadPlus = new Thread(new ThreadStart(ThreadPlus));
            m_threadMinus = new Thread(new ThreadStart(ThreadMinus));

            m_threadPlus.Start();
            m_threadMinus.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_threadPlus.IsAlive == true) m_threadPlus.Abort();
            if (m_threadMinus.IsAlive == true) m_threadMinus.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_nValue = 0;
            m_nPlusCount = 0;
            m_nMinusCount = 0;

            label1.Text = m_nValue.ToString();
            label2.Text = m_nPlusCount.ToString();
            label3.Text = m_nMinusCount.ToString();
        }
    }
}
