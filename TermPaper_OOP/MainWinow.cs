using TermPaper_OOP.Classes;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP
{
    public partial class Scene : Form
    {
        // TODO: - Implement undo/redo
        // TODO : - Implement save/load
        // Fix a bug whrere while shape is selected and you draw a line it stays selected on the shape

        private readonly List<IDrawableAndSelectable> _objects = new();
        private IDrawableAndSelectable? _selectedObject = null;
        private ActionType _currentAction = ActionType.Select;
        private PointF _startingPosition;
        private PointF _offset;

        public Scene()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        override protected void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _colorPicker.Color = System.Drawing.Color.Black;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            _currentAction = (ActionType)button.TabIndex;

            if (_currentAction == ActionType.Select && _selectedObject != null)
            {
                _selectedObject = null;
                updateUI();
            }

            if ((_currentAction == ActionType.Move || _currentAction == ActionType.Copy)
                && _selectedObject == null)
            {
                _currentAction = ActionType.Select;
            }
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            foreach (var obj in _objects)
            {
                obj.Draw(graph);
            }
        }

        protected void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                _startingPosition = e.Location;

                if (_currentAction == ActionType.Move)
                {
                    _offset = new PointF(e.X - _selectedObject!.X,
                                         e.Y - _selectedObject.Y);
                }
            }

        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // TODO: - Check if we need to parse or its filled
                switch (_currentAction)
                {
                    case ActionType.Select:
                        _selectedObject = _objects.LastOrDefault(
                            obj => obj.PointIsInside(_startingPosition) == true);

                        break;

                    case ActionType.Move:
                        if (_selectedObject == null) return;

                        // TODO: - Fix moving for lines
                        _selectedObject.X = e.X - _offset.X;
                        _selectedObject.Y = e.Y - _offset.Y;

                        break;

                    case ActionType.Copy:
                        if (_selectedObject == null) return;

                        IDrawableAndSelectable copy = _selectedObject.Copy();
                        copy.X = e.X - _offset.X;
                        copy.Y = e.Y - _offset.Y;
                        _objects.Add(copy);

                        _selectedObject = copy;

                        break;

                    case ActionType.Line:
                        float.TryParse(_thicknessTextBox.Text, out float thickness);
                        
                        Line line = new(_startingPosition, e.Location, _colorPicker.Color, thickness);
                        
                        _objects.Add(line);
                        _selectedObject = line;

                        break;

                    case ActionType.Rectangle:
                        float.TryParse(_thicknessTextBox.Text, out thickness);

                        Classes.Rectangle rect = new(
                            MathF.Min(_startingPosition.X, e.X),
                            MathF.Min(_startingPosition.Y, e.Y),
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            MathF.Abs(e.Location.Y - _startingPosition.Y),
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = rect;
                        _objects.Add(rect);
                        break;

                    case ActionType.Triangle:
                        float.TryParse(_thicknessTextBox.Text, out thickness);

                        Triangle triangle = new(
                            MathF.Min(_startingPosition.X, e.X),
                            MathF.Min(_startingPosition.Y, e.Y),
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            MathF.Abs(e.Location.Y - _startingPosition.Y),
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = triangle;
                        _objects.Add(triangle);
                        break;

                    case ActionType.Circle:
                        float.TryParse(_thicknessTextBox.Text, out thickness);

                        Circle circle = new(
                            MathF.Min(_startingPosition.X, e.X),
                            MathF.Min(_startingPosition.Y, e.Y),
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = circle;
                        _objects.Add(circle);
                        break;

                    case ActionType.Ellipse:
                        throw new NotImplementedException();
                        break;


                }
            }
            Refresh();
            updateUI();
        }

        // TODO: - Optimize the nesting, might not need all the casts
        // Fix H box showing when moving a line
        private void updateUI()
        {
            _hTextBox.Visible = true;
            _labelH.Visible = true;

            if (_selectedObject == null)
            {
                _labelCurrentSelection.Text = $"Select an object";

                _xTextBox.Clear();
                _yTextBox.Clear();
                _wTextBox.Clear();
                _hTextBox.Clear();
                _fillCheckBox.Checked = false;
                _thicknessTextBox.Text = "1";

                _labelPerimetar.Text = $"The perimetar of the shape is: px";
                _labelArea.Text = $"The area of the shape is: sq. px.";

                return;
            }

            _labelCurrentSelection.Text = $"Current selection: {_selectedObject.GetType().Name}";
            
            _xTextBox.Text = _selectedObject!.X.ToString();
            _yTextBox.Text = _selectedObject!.Y.ToString();

            if (_selectedObject is IResizable)
            {
                if (_selectedObject is Circle)
                {
                    _labelW.Text = "R:";

                    _hTextBox.Visible = false;
                    _labelH.Visible = false;
                } else
                {
                    _labelW.Text = "W:";
                }

                _wTextBox.Text = ((IResizable)_selectedObject).Width.ToString();
                _hTextBox.Text = ((IResizable)_selectedObject).Height.ToString();

            }
            else if (_selectedObject is Line line)
            {
                _labelW.Visible = false;
                _wTextBox.Visible = false;
                _labelH.Visible = false;
                _hTextBox.Visible = false;
            }

            _colorPicker.Color = _selectedObject.Color;
            _thicknessTextBox.Text = _selectedObject.Thickness.ToString();

            if (_selectedObject is IShape)
            {
                _fillCheckBox.Checked = ((IShape)_selectedObject).IsFilled;

                _labelPerimetar.Text = $"The perimetar of the shape is: " +
                                       $"{((IShape)_selectedObject).CalculatePerimeter().ToString("0.0")} px.";
                _labelArea.Text = $"The area of the shape is: " +
                                  $"{((IShape)_selectedObject).CalculateArea().ToString("0.0")} sq. px.";
            }

        }

        private void _btnColorPicker2_Click(object sender, EventArgs e)
        {
            if (_colorPicker2.ShowDialog() == DialogResult.OK)
            {
                DrawPanel.BackColor = _colorPicker2.Color;
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            if (_colorPicker.ShowDialog() == DialogResult.OK)
            {
                _btnColorPicker.BackColor = _colorPicker.Color;

                if (_selectedObject != null)
                {
                    _selectedObject.Color = _colorPicker.Color;
                    DrawPanel.Invalidate();
                }
            }
        }

        private void _btnClear_Click(object sender, EventArgs e)
        {
            _objects.Clear();
            _selectedObject = null;
            Refresh();
        }

        private void Scene_KeyUp(object sender, KeyEventArgs e)
        {
            if (_selectedObject != null && e.KeyCode == Keys.Delete)
            {
                _objects.Remove(_selectedObject);
                _selectedObject = null;
                DrawPanel.Invalidate();
            }
        }

        private void _thicknessTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                float.TryParse(_thicknessTextBox.Text, out float thickness);
                _selectedObject.Thickness = thickness;
                Refresh();
            }
        }

        private void _fillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null && _selectedObject is IShape)
            {
                ((IShape)_selectedObject).IsFilled = _fillCheckBox.Checked;
                Refresh();
            }
        }

        private void _xTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                float.TryParse(_xTextBox.Text, out float x);
                _selectedObject.X = x;
                Refresh();
            }
        }

        private void _yTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                float.TryParse(_yTextBox.Text, out float y);
                _selectedObject.Y = y;
                Refresh();
            }
        }

        private void _wTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null && _selectedObject is IResizable)
            {
                float.TryParse(_wTextBox.Text, out float width);
                ((IResizable)_selectedObject).Width = width;
                Refresh();
            }
        }

        private void _hTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null && _selectedObject is IResizable)
            {
                float.TryParse(_hTextBox.Text, out float height);
                ((IResizable)_selectedObject).Height = height;
                Refresh();
            }
        }
    }
}