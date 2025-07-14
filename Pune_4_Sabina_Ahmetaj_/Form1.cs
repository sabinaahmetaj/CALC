using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pune_4_Sabina_Ahmetaj_
{
    public partial class Form1 : Form
    {
        private double currentvalue = 0;
        private double previousvalue = 0;
        private string currentoperation = string.Empty;
        private List<string> history = new List<string>();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textdisplay1.Text = "0";
            textdisplay2.Text = string.Empty;
        }

        private void buttonnum_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textdisplay1.Text == "0")
            {
                textdisplay1.Text = button.Text;
            }
            else
            {
                textdisplay1.Text += button.Text;
            }

        }

        private void buttonoperator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            previousvalue = double.Parse(textdisplay1.Text);
            currentoperation = button.Text;
            textdisplay2.Text = previousvalue.ToString() + " " + currentoperation;
            textdisplay1.Text = "0";

            {
                MessageBox.Show("Invalid input.Please enter a valid number.");
                return;
            }
            currentoperation = button.Text;
            textdisplay2.Text = previousvalue.ToString() + " " + currentoperation;
            textdisplay1.Text = "0";
        }

        private void buttonequal_Click(object sender, EventArgs e)
        {
            double parsedCurrentValue;
            if (!double.TryParse(textdisplay1.Text, out parsedCurrentValue))
            {
                MessageBox.Show("Invalid input. Please enter a valid number");
                return;

            }
            currentvalue = parsedCurrentValue;
            string operationResult = string.Empty;
            textdisplay2.Text += " " + currentvalue.ToString();
            switch (currentoperation)
            {
                case "+":
                    textdisplay1.Text = (previousvalue + currentvalue).ToString();
                    break;
                case "-":
                    textdisplay1.Text = (previousvalue - currentvalue).ToString();
                    break;
                case "*":
                    textdisplay1.Text = (previousvalue * currentvalue).ToString();
                    break;
                case "÷":
                    if (currentvalue != 0)
                        textdisplay1.Text = (previousvalue / currentvalue).ToString();
                    else
                        MessageBox.Show("Division by 0 cannot be done");
                    break;
                case "^":
                    textdisplay2.Text = $" {previousvalue} ^ {currentvalue} ";
                    textdisplay1.Text = Math.Pow(previousvalue, currentvalue).ToString();
                    break;
                case "%":
                    textdisplay2.Text = $" {previousvalue} & {currentvalue} ";
                    textdisplay1.Text = (previousvalue * (currentvalue / 100)).ToString();
                    break;
                default:
                    textdisplay2.Text = $"{textdisplay1.Text} = ";
                    break;


            }
            //textdisplay1.Text = operationResult;
            //string historyEntry = $"{previousvalue} {currentoperation} {currentvalue} = {operationResult}";
            //history.Add(historyEntry);
            //textdisplay2.Text = string.Empty;
            //previousvalue = Double.Parse(textdisplay1.Text);
            //currentoperation = string.Empty;

        }

        private void buttonclear_click(object sender, EventArgs e)
        {
            textdisplay1.Text = "0";
            textdisplay2.Text = string.Empty;
            previousvalue = 0;
            currentoperation = string.Empty;
        }

        private void buttondelete_click(object sender, EventArgs e)
        {
            if (textdisplay1.Text.Length > 1)
            {
                textdisplay1.Text = textdisplay1.Text.Substring(0, textdisplay1.Text.Length - 1);
            }
            else
            {
                textdisplay1.Text = "0";
            }
        }

        private void buttonpm_click(object sender, EventArgs e)
        {
            double grade = double.Parse(textdisplay1.Text);
            grade = -grade;
            textdisplay1.Text = grade.ToString();
        }

        private void buttondecimal_click(object sender, EventArgs e)
        {
            if (!textdisplay1.Text.Contains("."))
            {
                textdisplay1.Text += ".";
            }
        }

        private void buttonraport_click(object sender, EventArgs e)
        {
            double grade = double.Parse(textdisplay1.Text);
            if (grade != 0)
            {
                textdisplay1.Text = (1 / grade).ToString();
            }
            else
            {
                MessageBox.Show("Can not be divided by 0");

            }

        }

        private void buttonsr_click(object sender, EventArgs e)
        {
            double grade = double.Parse(textdisplay1.Text);
            if (grade >= 0)
            {
                textdisplay1.Text = Math.Sqrt(grade).ToString();

            }
            else
                MessageBox.Show("The square root of a negative number can not be found");
        }

        private void buttonminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonexp_click(object sender, EventArgs e)
        {
            double x;
            x = Convert.ToDouble(textdisplay1.Text) * Convert.ToDouble(textdisplay1.Text);
            textdisplay1.Text = Convert.ToString(x);
        }

        private void buttonce_click(object sender, EventArgs e)
        {
            textdisplay1.Text = "0";
        }

        private void buttonpercent_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentoperation))
            {
                double current = double.Parse(textdisplay1.Text);
                textdisplay1.Text = (current / 100).ToString();
            }
            else
            {

                currentvalue = double.Parse(textdisplay1.Text);
                double result = previousvalue * (currentvalue / 100);
                textdisplay1.Text = result.ToString();
                textdisplay2.Text = $"{previousvalue} {currentoperation} {currentvalue}%";
            }
        }

        private void buttonhistory_click(object sender, EventArgs e)
        {
            if (history.Count == 0)
            {
                MessageBox.Show("No history available");
                return;
            }
            string historyDisplay = string.Join("\n", history);
            MessageBox.Show(historyDisplay, "Calculation history");

        }

        private void buttonmultiply_click(object sender, EventArgs e)
        {
            previousvalue = double.Parse(textdisplay1.Text);
            currentoperation = "*";
            textdisplay2.Text = previousvalue.ToString() + "*";
            textdisplay1.Text = "0";
        }

        private void buttonadd_click(object sender, EventArgs e)
        {
            previousvalue = double.Parse(textdisplay1.Text);
            currentoperation = "+";
            textdisplay2.Text = previousvalue.ToString() + "+";
            textdisplay1.Text = "0";
        }

        private void buttonminus_click(object sender, EventArgs e)
        {
            previousvalue = double.Parse(textdisplay1.Text);
            currentoperation = "-";
            textdisplay2.Text = previousvalue.ToString() + "-";
            textdisplay1.Text = "0";
        }

        private void buttondivide_click(object sender, EventArgs e)
        {
            previousvalue = double.Parse(textdisplay1.Text);
            currentoperation = "÷";
            textdisplay2.Text = previousvalue.ToString() + "÷";
            textdisplay1.Text = "0";
        }
    }

}

