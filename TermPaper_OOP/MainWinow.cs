using TermPaper_OOP.Classes;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP
{
    public partial class Scene : Form
    {
        private readonly List<IDrawable> _objects = new List<IDrawable>();
        private readonly Random _random = new();
        private int selecterButton = 0;

        public Scene()
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
            foreach (var obj in _objects)
            {
                obj.Draw(graph, DrawType.Pen, 2f);
            }
        }

        private void CreateLines()
        {
            for (int i = 0; i < 10; i++)
            {
                Line line = new Line(
                    _random.Next(0, Size.Width - 150),
                    _random.Next(0, Size.Height - 150),
                    _random.Next(0, Size.Width - 150),
                    _random.Next(0, Size.Height - 150),
                    Color.Blue
                    );

                var rect = new Classes.Rectangle(
                    _random.Next(0, Size.Width - 150),
                    _random.Next(0, Size.Height - 150),
                    _random.Next(0, 200),
                    _random.Next(0, 200),
                    Color.Red
                    );

                _objects.Add(line);
                _objects.Add(rect);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // button.Name
        }
    }
}