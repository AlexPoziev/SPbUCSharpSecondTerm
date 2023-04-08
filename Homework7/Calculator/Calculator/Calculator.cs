namespace Calculator;

public partial class Calculator : Form
{
    private CalculationCore core = new CalculationCore();

    public Calculator()
    {
        InitializeComponent();

        expressionConveyor.DataBindings.Add("Text", core, "CurrentNumber", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void Calculator_Load(object sender, EventArgs e)
    {

    }

    private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    private void OperationsTable_Paint(object sender, PaintEventArgs e)
    {

    }

    private void NumberClick(object sender, EventArgs e)
    {

    }

    private void OperationClick(object sender, EventArgs e)
    {

    }

    private void ResultClick(object sender, EventArgs e)
    {

    }

    private void ClearClick(object sender, EventArgs e)
    {
        
    }

    private void ChangeSignClick(object sender, EventArgs e)
    {

    }
}