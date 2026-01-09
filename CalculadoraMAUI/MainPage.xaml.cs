using Android.Animation;

namespace CalculadoraMAUI
{
    public partial class MainPage : ContentPage
    {
        enum Operation
        {
            NONE,
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE
        }
        double currentNumber = 0;
        double storedNumber = 0;
        double tempNumber = 0;
        Operation currentOperation = Operation.NONE;



        public MainPage()
        {
            InitializeComponent();
        }


        private void OnNumberPress(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Text;
            string display = ResultLbl.Text;

            if (number == "," && display.Contains(","))
            {
                return;
            }

            if (Double.Parse(ResultLbl.Text) == 0 && number != "," && !ResultLbl.Text.Contains(","))
            {
                display = number;
            }
            else
            {
                display += number;

            }

            ResultLbl.Text = display;
        }

        private void OnOperatorPress(object sender, EventArgs e)
        {
            storedNumber = Double.Parse(ResultLbl.Text.Replace(",", "."));
            currentNumber = 0;
            ResultLbl.Text = "0";
            Button button = (Button)sender;
            switch(button.Text)
            {
                case ("+"):
                    {
                        currentOperation = Operation.ADD;
                        break;
                    }
                case ("-"):
                    {
                        currentOperation = Operation.SUBTRACT;
                        break;
                    }
                case ("x"):
                    {
                        currentOperation = Operation.MULTIPLY;
                        break;
                    }
                case ("/"):
                    {
                        currentOperation = Operation.DIVIDE;
                        break;
                    }
                default:
                    {
                        currentOperation = Operation.NONE;
                        break;
                    }
            }
        }
        

        private void OnBackspacePress(object sender, EventArgs e)
        {
            if (ResultLbl.Text.Length > 1)
            {
                ResultLbl.Text = ResultLbl.Text[..^1];

            }
            else
            {
                ResultLbl.Text = "0";
            }
        }

        private void OnEqualsPress(object sender, EventArgs e)
        {
            currentNumber = Double.Parse(ResultLbl.Text.Replace(",", "."));
            ResultLbl.Text = Calculate().ToString();
        }

        private void OnClearPress(object sender, EventArgs e)
        {
            storedNumber = 0;
            currentNumber = 0;
            tempNumber = 0;
            ResultLbl.Text = "0";
        }

        private double Calculate()
        {
            double result = 0;
            if(tempNumber == 0)
            {
                tempNumber = currentNumber;

            }
            switch(currentOperation)
            {
                case (Operation.ADD):
                    {
                        result = storedNumber + tempNumber;
                        break;
                    }
                case (Operation.SUBTRACT):
                    {
                        result = storedNumber - tempNumber;
                        break;
                    }
                case (Operation.MULTIPLY):
                    {
                        result = storedNumber * tempNumber;
                        break;
                    }
                case (Operation.DIVIDE):
                    {
                        result = storedNumber / tempNumber;
                        break;
                    }
                default:
                    {
                        result = tempNumber;
                        break;
                    }
            }

            storedNumber = result;
            return result;
        }
    }
}
