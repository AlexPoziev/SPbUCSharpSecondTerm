namespace Calculator;

public class CalculationCore
{
    private char fractionalSign = '.';

    public string DisplayNumber { get; private set; } = "0";

    private string tempCalculationValue = "0";

    private char operationSign;

    private States currentState = States.DotInNumber;

    public void ChangeSignOfNumber()
    {
        if (DisplayNumber != "0")
        {
            DisplayNumber = "-" + DisplayNumber;
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
            var tempValue = DisplayNumber;
            DisplayNumber = CalculatorUtils.PerformTwoFloatStringsOperation(tempCalculationValue, DisplayNumber, operationSign);
            tempCalculationValue = operationSign == newElement ? tempValue : string.Empty;

            if (newElement != '=')
            {
                operationSign = newElement;
            }
        }
    }

    public void AddElement(char newElement)
    {
        switch (currentState)
        {
            #region

            case States.NumberTyping:
                if (char.IsDigit(newElement))
                {
                    if (DisplayNumber == "0")
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
                    break;
                }

                if (CalculatorUtils.IsOperationOrEqualitySign(newElement))
                {
                    PerformCalculatorOperation(newElement);

                    break;
                }

                break;

            #endregion

            case States.DotInNumber:
                if (char.IsDigit(newElement))
                {
                    DisplayNumber += newElement;
                }

                break;

            case States.NumberAfterDot:
                if (CalculatorUtils.IsOperationOrEqualitySign(newElement))
                {
                    PerformCalculatorOperation(newElement);

                    break;
                }

                if (char.IsDigit(newElement))
                {
                    DisplayNumber += newElement;

                    break;
                }

                break;

            case States.OperationSign:
                if (CalculatorUtils.IsOperationOrEqualitySign(newElement))
                {
                    if (newElement == operationSign)
                    {
                        if (tempCalculationValue != string.Empty)
                        {
                            DisplayNumber = CalculatorUtils.PerformTwoFloatStringsOperation(DisplayNumber, tempCalculationValue, newElement);
                        }
                        else
                        {
                            operationSign = newElement;
                        }

                        break;
                    }
                }

                if (char.IsDigit(newElement))
                {
                    tempCalculationValue = DisplayNumber;
                    DisplayNumber = newElement.ToString();

                    break;
                }

                break;
        }
    }
}