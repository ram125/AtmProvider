using System.ComponentModel.DataAnnotations;

namespace AtmProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int value))
            {
                errorProvider1.SetError(textBox1, "invalid amount");
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
                    errorProvider2.SetError(textBox2, "invalid password");
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