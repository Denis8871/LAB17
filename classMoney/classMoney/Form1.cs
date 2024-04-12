using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace classMoney
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void callConverter()
        {
            Currency curr = new Currency(Convert.ToDouble(textBox2.Text), comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            textBox3.Text = curr.getMoney().ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            callConverter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(0);
            comboBox1.Text = comboBox1.Items[0].ToString();

            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(1);
            comboBox2.Text = comboBox2.Items[1].ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                !(Char.IsControl(e.KeyChar)))
            {
                if (textBox2.Text.Length == 0)
                    e.Handled = true;
                if (!((e.KeyChar.ToString() == ",") &&
                    (textBox2.Text.IndexOf(",") == -1)) )
                    e.Handled = true;
                 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: pictureBox1.Image = Properties.Resources.RUB; break;
                case 1: pictureBox1.Image = Properties.Resources.USD; break;
                case 2: pictureBox1.Image = Properties.Resources.EUR; break;
            }
            if (textBox3.Text.Length != 0 && comboBox2.SelectedIndex != -1)
                callConverter();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: pictureBox2.Image = Properties.Resources.RUB; break;
                case 1: pictureBox2.Image = Properties.Resources.USD; break;
                case 2: pictureBox2.Image = Properties.Resources.EUR; break;
            }
            if (textBox3.Text.Length != 0 && comboBox1.SelectedIndex != -1)
                callConverter();
        }
    }
}
