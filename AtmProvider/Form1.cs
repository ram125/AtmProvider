using System.ComponentModel.DataAnnotations;

namespace AtmProvider
{
    public partial class Form1 : Form
    {

        private int amount = 2000;
        private int pin = 2342;
        private int tries = 3;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int value) || !(value % 10 == 0))
            {
                errorProvider1.SetError(textBox1, "invalid amount");
            }
            else if (amount < Int16.Parse(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "not enough money");
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty);
            }
            if (textBox2.Text.Length != 4 || !int.TryParse(textBox2.Text, out _))
            {
                errorProvider2.SetError(textBox2, "too short");
                if (!int.TryParse(textBox2.Text, out _))
                {
                    errorProvider2.SetError(textBox2, "invalid pin");
                }
            }
            else if (pin != Int16.Parse(textBox2.Text))
            {
                if (tries > 1)
                {
                    MessageBox.Show("wrong pin");
                    tries--;
                }
                else
                {
                    MessageBox.Show("card is blocked");
                }
            }
            else
            {
                errorProvider2.SetError(textBox2, string.Empty);
            }
            if (errorProvider1.GetError(textBox1).Equals(string.Empty) && errorProvider2.GetError(textBox2).Equals(string.Empty))
            {
                MessageBox.Show("Thanks");
            }
            else
            {
                MessageBox.Show(errorProvider1.GetError(textBox1) + Environment.NewLine + errorProvider2.GetError(textBox2));
            }
        }
    }
}