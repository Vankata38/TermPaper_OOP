namespace TermPaper_OOP
{
    public partial class MainWindow : Form
    {
        private readonly List<VectorObject> vectorObjects = new List<VectorObject>();
        private readonly Random _random = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        override protected void OnLoad(EventArgs e)
        {
            CreateLines();
            base.OnLoad(e);
        }

        override protected void OnPaint(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            foreach (var vectorObject in vectorObjects)
            {
                vectorObject.Draw(graph);
            }
        }

        private void CreateLines()
        {
            for (int i = 0; i < 10; i++)
            {
                Line line = new Line(
                    _random.Next(0, 1900),
                    _random.Next(0, 1900),
                    _random.Next(0, 500),
                    _random.Next(0, 500),
                    Color.Blue
                    );

                Rectangle rect = new Rectangle(
                    _random.Next(0, 1900),
                    _random.Next(0, 1900),
                    _random.Next(0, 500),
                    _random.Next(0, 500),
                    Color.Red
                    );

                vectorObjects.Add(line);
                vectorObjects.Add(rect);
            }
        }
    }
}