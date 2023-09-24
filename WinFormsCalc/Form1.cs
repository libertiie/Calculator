using System.Data;

namespace WinFormsCalc
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text.Replace("+/-", "*(-1)");
            textBoxOutput.Text = currentCalculation;
        }

        private void rjButton19_Click(object sender, EventArgs e)
        {
            // Reset the calculation and empty the textbox
            textBoxOutput.Text = "0";
            currentCalculation = "";
        }

        private void Button_Equal_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("×", "*").Trim().ToString().Replace("÷", "/").Replace("−", "-");

            try
            {
                textBoxOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = textBoxOutput.Text;
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = "0";
                currentCalculation = "";
            }
        }

    }
}