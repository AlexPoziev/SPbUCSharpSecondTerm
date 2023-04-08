using System.ComponentModel;

namespace Calculator;

public class CalculationCore : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly char fractionalSign = '.';

    private string displayNumber = "0";

    public string DisplayNumber { 
        get
        {
            return displayNumber;
        }

        private set
        {
            displayNumber = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayNumber)));
        }
    }

    private string tempCalculationValue = "0";

    private char operationSign = ' ';

    private States currentState = States.NumberTyping;

    public void ChangeSignOfNumber()
    {
        if (currentState != States.Error && DisplayNumber != "0")
        {
            if (DisplayNumber[0] == '-')
            {
                DisplayNumber = DisplayNumber.Substring(1);
            }
            else
            {
                DisplayNumber = "-" + DisplayNumber;
            }
        }
    }

    public void ClearCalculator()
    {
        DisplayNumber = "0";
        tempCalculationValue = "0";
        operationSign = ' ';
        currentState = States.NumberTyping;
    }

    private enum States
    {
        NumberTyping,
        DotInNumber,
        NumberAfterDot,
        OperationSign,
        EqualitySign,
        Error,
    }

    private void PerformOperationWithDisplayAndTempNumbers()
    {
        var tempValue = DisplayNumber;

        DisplayNumber = CalculatorUtils.PerformTwoFloatStringsOperation(tempCalculationValue, DisplayNumber, operationSign);
        
        tempCalculationValue = tempValue;
    }

    private void PerformCalculatorOperation(char newElement)
    {
        if (operationSign == ' ')
        {
            operationSign = newElement;
            tempCalculationValue = DisplayNumber;
        }
        else
        {
            PerformOperationWithDisplayAndTempNumbers();
            operationSign = newElement;
        }

        currentState = States.OperationSign;
    }

    public void AddElement(char newElement)
    {
        switch (currentState)
        {
            case States.NumberTyping:
                if (char.IsDigit(newElement))
                {
                    if (DisplayNumber == "0" || DisplayNumber == "Error")
                    {
                        DisplayNumber = newElement.ToString();
                    }
                    else
                    {
                        DisplayNumber += newElement;
                    }

                    break;
                }

                if (newElement == fractionalSign)
                {
                    DisplayNumber += fractionalSign;

                    currentState = States.DotInNumber;

                    break;
                }

                if (CalculatorUtils.IsOperationSign(newElement))
                {
                    try
                    {
                        PerformCalculatorOperation(newElement);
                    }
                    catch (DivideByZeroException)
                    {
                        ClearCalculator();
                        currentState = States.Error;
                        DisplayNumber = "Error";
                    }

                    break;
                }

                if (operationSign != ' ' && newElement == '=')
                {
                    try
                    {
                        PerformOperationWithDisplayAndTempNumbers();
                    }
                    catch (DivideByZeroException)
                    {
                        ClearCalculator();
                        currentState = States.Error;
                        DisplayNumber = "Error";

                        break;
                    }

                    currentState = States.EqualitySign;

                    break;
                }

                break;

            case States.DotInNumber:
                if (char.IsDigit(newElement))
                {
                    DisplayNumber += newElement;
                    currentState = States.NumberAfterDot;
                }

                break;

            case States.NumberAfterDot:
                if (CalculatorUtils.IsOperationSign(newElement))
                {
                    try
                    {
                        PerformCalculatorOperation(newElement);
                    }
                    catch (DivideByZeroException)
                    {
                        ClearCalculator();
                        currentState = States.Error;
                        DisplayNumber = "Error";
                    }

                    break;
                }

                if (char.IsDigit(newElement))
                {
                    DisplayNumber += newElement;

                    break;
                }

                if (operationSign != ' ' && newElement == '=')
                {
                    try
                    {
                        PerformOperationWithDisplayAndTempNumbers();
                    }
                    catch (DivideByZeroException)
                    {
                        ClearCalculator();
                        currentState = States.Error;
                        DisplayNumber = "Error";

                        break;
                    }

                    currentState = States.EqualitySign;

                    break;
                }

                break;

            case States.OperationSign:
                if (CalculatorUtils.IsOperationSign(newElement))
                {
                    operationSign = newElement;
                }

                if (newElement == '=')
                {
                    try
                    {
                        DisplayNumber = CalculatorUtils.PerformTwoFloatStringsOperation(tempCalculationValue, DisplayNumber, operationSign);
                    }
                    catch (DivideByZeroException)
                    {
                        ClearCalculator();
                        currentState = States.Error;
                        DisplayNumber = "Error";
                    }
                }

                if (char.IsDigit(newElement))
                {
                    tempCalculationValue = DisplayNumber;
                    DisplayNumber = newElement.ToString();

                    currentState = States.NumberTyping;

                    break;
                }

                break;

            case States.EqualitySign:
                if (newElement == '=')
                {
                    try
                    {
                        DisplayNumber = CalculatorUtils.PerformTwoFloatStringsOperation(DisplayNumber, tempCalculationValue, operationSign);
                    }
                    catch (DivideByZeroException)
                    {
                        ClearCalculator();
                        currentState = States.Error;
                        DisplayNumber = "Error";
                    }

                    break;
                }

                if (char.IsDigit(newElement))
                {
                    tempCalculationValue = DisplayNumber;
                    DisplayNumber = newElement.ToString();

                    currentState = States.NumberTyping;

                    break;
                }

                if (CalculatorUtils.IsOperationSign(newElement))
                {
                    operationSign = newElement;

                    break;
                }

                break;

            case States.Error:
                if (char.IsDigit(newElement))
                {
                    tempCalculationValue = "0";
                    DisplayNumber = newElement.ToString();
                    currentState = States.NumberTyping;

                    break;
                }

                break;
        }
    }
}