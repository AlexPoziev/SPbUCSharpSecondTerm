namespace Calculator;

public partial class Calculator : Form
{
    private CalculationCore core = new CalculationCore();

    public Calculator()
    {
        InitializeComponent();

        expressionConveyor.DataBindings.Add("Text", core, "DisplayNumber", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void ClearClick(object sender, EventArgs e)
    {
        core.ClearCalculator();
    }

    private void ChangeSignClick(object sender, EventArgs e)
    {
        core.ChangeSignOfNumber();
    }

    private void NumberOrOperationButtonClick(object sender, EventArgs e)
    {
        var senderButton = sender as Button;

        core.AddElement(senderButton!.Text.First());
    }
}