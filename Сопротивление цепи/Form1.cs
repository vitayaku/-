using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сопротивление_цепи
{
    public partial class Form1 : Form
    {
        double R;
        double R1, R2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty)
                MessageBox.Show("Для расчета сопротивления цепи необходимо указать сопротивление 2-х резисторов!", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(radioButton2.Checked)
            {
                try
                {
                    R1 = Convert.ToDouble(textBox1.Text);
                    R2 = Convert.ToDouble(textBox2.Text);
                    R = R1 + R2;
                    if (R < 1000) listBox1.Items.Add("Сопротивление равно " + R + " ОМ");
                    else listBox1.Items.Add("Сопротивление равно " + R / 1000 + " КОМ");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка " + ex.Message, "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else if (radioButton1.Checked)
            {
                try
                {
                    R1 = Convert.ToDouble(textBox1.Text);
                    R2 = Convert.ToDouble(textBox2.Text);
                    R = R1 * R2 / (R1 + R2) ;
                    if (R < 1000) listBox1.Items.Add("Сопротивление равно " + R + " ОМ");
                    else listBox1.Items.Add("Сопротивление равно " + R / 1000 + " КОМ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка " + ex.Message, "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }
        // Сопротивлением может быть только целое число
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9')||e.KeyChar == (char)Keys.Back) return;
            else e.Handled = true; 
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back) return;
            else e.Handled = true;
        }
    }
}
