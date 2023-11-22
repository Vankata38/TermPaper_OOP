using TermPaper_OOP.Classes;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP
{
    public partial class Scene : Form
    {
        private readonly List<IDrawableAndSelectable> _objects = new();
        private IDrawableAndSelectable? _selectedObject = null;
        private readonly Random _random = new();
        private int _currentAction = (int)ActionType.Select;
        private PointF offset;

        private readonly Brush _brush = new SolidBrush(Color.Black);

        public Scene()
        {
            InitializeComponent();
        }

        override protected void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.TabIndex)
            {
                case (int)ActionType.Move:
                    if (_selectedObject != null)
                        _currentAction = (int)ActionType.Select;
                    break;

                case (int)ActionType.Select:
                    _selectedObject = null;
                    _currentAction = (int)ActionType.Select;
                    break;

                case (int)ActionType.Line:
                    _currentAction = (int)ActionType.Line;
                    break;

                case (int)ActionType.Rectangle:
                    _currentAction = (int)ActionType.Rectangle;
                    break;

                case (int)ActionType.Triangle:
                    _currentAction = (int)ActionType.Triangle;
                    break;

                case (int)ActionType.Circle:
                    _currentAction = (int)ActionType.Circle;
                    break;

                case (int)ActionType.Ellipse:
                    _currentAction = (int)ActionType.Ellipse;
                    break;
            }
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            foreach (var obj in _objects)
            {
                obj.Draw(graph, DrawType.Pen, 2f);
            }
        }

        protected void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void _btnEllipse_Click(object sender, EventArgs e)
        {

        }
    }
}