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
        double result = 0;
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

            if (Double.Parse(ResultLbl.Text) == 0 )
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
                        Console.WriteLine("operation set to add");
                        currentOperation = Operation.ADD;
                        break;
                    }
                case ("-"):
                    {
                        Console.WriteLine("operation set to subtract");
                        currentOperation = Operation.SUBTRACT;
                        break;
                    }
                case ("x"):
                    {
                        Console.WriteLine("operation set to multiply");
                        currentOperation = Operation.MULTIPLY;
                        break;
                    }
                case ("/"):
                    {
                        Console.WriteLine("operation set to divide");
                        currentOperation = Operation.DIVIDE;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("operation set to none");
                        currentOperation = Operation.NONE;
                        break;
                    }
            }
        }
        

        private void OnBackspacePress(object sender, EventArgs e)
        {
            ResultLbl.Text = ResultLbl.Text[..^1];
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
            result = 0;
            ResultLbl.Text = "0";
        }

        private double Calculate()
        {
            Console.WriteLine("Calculating...");
            switch(currentOperation)
            {
                case (Operation.ADD):
                    {
                        result = storedNumber + currentNumber;
                        break;
                    }
                case (Operation.SUBTRACT):
                    {
                        result = storedNumber - currentNumber;
                        break;
                    }
                case (Operation.MULTIPLY):
                    {
                        result = storedNumber * currentNumber;
                        break;
                    }
                case (Operation.DIVIDE):
                    {
                        result = storedNumber / currentNumber;
                        break;
                    }
                default:
                    {
                        result = currentNumber;
                        break;
                    }
            }

            Console.WriteLine($"Result: {result}");

            return result;
        }
    }
}
