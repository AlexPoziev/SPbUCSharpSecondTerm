using System.Windows.Forms;

namespace FindPair
{
    public partial class FindPair : Form
    {
        private Button? previousButton;

        private Button? prepreviousButton;

        private readonly FindPairCore core;

        private bool needToClear = false;

        public FindPair(int size)
        {
            InitializeComponent();

            core = new FindPairCore(size);

            FindPairPanel.ColumnCount = size;
            FindPairPanel.RowCount = size;

            FindPairPanel.ColumnStyles.Clear();

            FindPairPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;

            // add a column style for each column!
            for (int i = 0; i < FindPairPanel.ColumnCount * FindPairPanel.RowCount; ++i)
            {
                FindPairPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            // add a column style for each column!
            for (int i = 0; i < FindPairPanel.ColumnCount * FindPairPanel.RowCount; ++i)
            {
                FindPairPanel.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    FindPairPanel.Controls.Add(new Button { AutoSize = false }, j, i);
                    var button = FindPairPanel.GetControlFromPosition(j, i);
                    if (button != null)
                    {
                        button.Click += ButtonClick;
                        button.Dock = DockStyle.Fill;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonClick(object? sender, EventArgs e)
        {
            if (needToClear && prepreviousButton != null && previousButton != null)
            {
                prepreviousButton.Text = "";
                previousButton.Text = "";
            }

            if (sender is Button)
            {
                if (sender is not Button button)
                {
                    throw new ArgumentException(nameof(button));
                }

                var frame = (button.Parent as TableLayoutPanel)?.GetCellPosition(button) ?? throw new ArgumentNullException();
                (int x, int y) coordinates = (frame.Row, frame.Column);

                (int result, needToClear, var isPair) = core.ChoiceMaker(coordinates);

                if (isPair && previousButton != null)
                {
                    button.Click -= ButtonClick;
                    previousButton.Click -= ButtonClick;
                }

                button.Text = result.ToString();
                
                prepreviousButton = previousButton;
                previousButton = button;

               
            }
        }

        private void FindPairPanelClick(object sender, PaintEventArgs e)
        {
        }
    }
}