using System.Diagnostics.Eventing.Reader;
using TermPaper_OOP.Classes;
using TermPaper_OOP.Interfaces;
using static System.Windows.Forms.LinkLabel;

namespace TermPaper_OOP
{
    public partial class Scene : Form
    {
        // TODO: - Implement undo/redo
        // TODO : - Implement save/load

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
                UpdateUI();
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
            _selectedObject?.Draw(graph);
        }

        protected void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _startingPosition = e.Location;
                if(!float.TryParse(_thicknessTextBox.Text, out float thickness)) 
                    thickness = 3.0f;

                switch (_currentAction)
                {
                    case ActionType.Move:
                        if (_selectedObject != null)
                            _offset = new PointF(e.X - _selectedObject!.X, e.Y - _selectedObject.Y);
                        break;

                    case ActionType.Copy:
                        if (_selectedObject == null) return;
                        _offset = new PointF(e.X - _selectedObject!.X, e.Y - _selectedObject.Y);

                        IDrawableAndSelectable copy = _selectedObject.Copy();
                        _selectedObject = copy;
                        break;
                    case ActionType.Line:
                        Line line = new(_startingPosition, e.Location, _colorPicker.Color, thickness);

                        _selectedObject = line;
                        break;
                    case ActionType.Rectangle:
                        Classes.Rectangle rect = new(
                            MathF.Min(_startingPosition.X, e.X),
                            MathF.Min(_startingPosition.Y, e.Y),
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            MathF.Abs(e.Location.Y - _startingPosition.Y),
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = rect;
                        break;
                    case ActionType.Triangle:
                        if (!float.TryParse(_thicknessTextBox.Text, out thickness)) 
                            thickness = 3.0f;

                        Triangle triangle = new(
                            MathF.Min(_startingPosition.X, e.X),
                            MathF.Min(_startingPosition.Y, e.Y),
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            MathF.Abs(e.Location.Y - _startingPosition.Y),
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = triangle;
                        break;
                    case ActionType.Circle:
                        Circle circle = new(
                            MathF.Min(_startingPosition.X, e.X),
                            MathF.Min(_startingPosition.Y, e.Y),
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = circle;
                        break;
                    case ActionType.Ellipse:
                        break;
                }
            }
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch(_currentAction)
                {
                    case ActionType.Move:

                        if (_selectedObject == null) return;
                        if (_selectedObject is IPositionable)
                        {
                            var shape = _selectedObject as IPositionable;
                            if (_selectedObject is Line)
                            {
                                var line = _selectedObject as Line;

                                line!.EndX = line.EndX - (line.X - e.X + _offset.X);
                                line!.EndY = line.EndY - (line.Y - e.Y + _offset.Y);

                                _selectedObject = line;
                            }

                            shape.X = e.X - _offset.X;
                            shape.Y = e.Y - _offset.Y;

                            _selectedObject = shape as IDrawableAndSelectable;
                        }

                        DrawPanel.Invalidate();
                        break;
                    case ActionType.Copy:
                        if (_selectedObject == null) return;
                        if (_selectedObject is IPositionable)
                        {
                            var shape = _selectedObject as IPositionable;

                            if (_selectedObject is Line)
                            {
                                var line = _selectedObject as Line;

                                line!.EndX = line.EndX - (line.X - e.X + _offset.X);
                                line!.EndY = line.EndY - (line.Y - e.Y + _offset.Y);

                                _selectedObject = line;
                            }

                            shape.X = e.X - _offset.X;
                            shape.Y = e.Y - _offset.Y;

                            _selectedObject = shape as IDrawableAndSelectable;
                        }

                        DrawPanel.Invalidate();
                        break;
                    case ActionType.Line:

                        if (_selectedObject is Line)
                        {
                            var line = _selectedObject as Line;

                            line!.EndX = e.X;
                            line!.EndY = e.Y;

                            _selectedObject = line;
                        }
                        
                        DrawPanel.Invalidate();

                        break;
                    case ActionType.Rectangle:
                        if (_selectedObject is Classes.Rectangle)
                        {
                            var rectangle = _selectedObject as Classes.Rectangle;

                            rectangle!.X = MathF.Min(_startingPosition.X, e.X);
                            rectangle!.Y = MathF.Min(_startingPosition.Y, e.Y);
                            rectangle!.Width = MathF.Abs(e.Location.X - _startingPosition.X);
                            rectangle!.Height = MathF.Abs(e.Location.Y - _startingPosition.Y);

                            _selectedObject = rectangle;
                        }

                        DrawPanel.Invalidate();
                        break;
                    case ActionType.Triangle:
                        if (_selectedObject is Triangle)
                        {
                            var triangle = _selectedObject as Triangle;

                            triangle!.X = MathF.Min(_startingPosition.X, e.X);
                            triangle!.Width = MathF.Abs(e.Location.X - _startingPosition.X);
                            triangle!.Height = MathF.Abs(e.Location.Y - _startingPosition.Y);

                            _selectedObject = triangle;
                        }
                        DrawPanel.Invalidate();
                        break;
                    case ActionType.Circle:
                        if (_selectedObject is Circle)
                        {
                            var circle = _selectedObject as Circle;

                            circle!.X = MathF.Min(_startingPosition.X, e.X);
                            circle!.Radius = MathF.Abs(e.Location.X - _startingPosition.X);

                            _selectedObject = circle;
                        }
                        DrawPanel.Invalidate();
                        break;
                    case ActionType.Ellipse:
                        break;
                }
            }
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentAction)
                {
                    case ActionType.Select:
                        _selectedObject = _objects.LastOrDefault(
                            obj => obj.PointIsInside(_startingPosition) == true);

                        break;

                    case ActionType.Move:
                        if (_selectedObject == null) return;

                        if (_selectedObject is Line)
                        {
                            var line = _selectedObject as Line;

                            line!.EndX = line.EndX - (line.X - e.X + _offset.X);
                            line!.EndY = line.EndY - (line.Y - e.Y + _offset.Y);

                            _selectedObject = line;
                        }

                        _selectedObject.X = e.X - _offset.X;
                        _selectedObject.Y = e.Y - _offset.Y;

                        break;

                    case ActionType.Copy:
                        if (_selectedObject == null) return;

                        if (_selectedObject is Line)
                        {
                            var line = _selectedObject as Line;

                            line!.EndX = line.EndX - (line.X - e.X + _offset.X);
                            line!.EndY = line.EndY - (line.Y - e.Y + _offset.Y);

                            _selectedObject = line;
                        }

                        _selectedObject.X = e.X - _offset.X;
                        _selectedObject.Y = e.Y - _offset.Y;

                        _objects.Add(_selectedObject);

                        break;

                    case ActionType.Line:
                        
                        if (_selectedObject != null)
                            _objects.Add(_selectedObject);

                        break;

                    case ActionType.Rectangle:
                        if (_selectedObject != null)
                            _objects.Add(_selectedObject);

                        break;

                    case ActionType.Triangle:
                        if (_selectedObject != null)
                            _objects.Add(_selectedObject);

                        break;

                    case ActionType.Circle:
                        if (_selectedObject != null)
                            _objects.Add(_selectedObject);
                        break;

                    case ActionType.Ellipse:
                        throw new NotImplementedException();
                }
            }
            UpdateUI();
        }

        // TODO: - Optimize the nesting, might not need all the casts
        private void UpdateUI()
        {
            _wLabel.Visible = true;
            _hLabel.Visible = true;
            _wTextBox.Visible = true;
            _hTextBox.Visible = true;
            _wPxLabel.Visible = true;
            _hPxLabel.Visible = true;

            if (_selectedObject == null)
            {
                _labelCurrentSelection.Text = $"Select an object";

                _xTextBox.Clear();
                _yTextBox.Clear();
                _wTextBox.Clear();
                _hTextBox.Clear();
                _fillCheckBox.Checked = false;
                _thicknessTextBox.Text = "3";

                _labelPerimetar.Text = $"The perimetar of the shape is: px";
                _labelArea.Text = $"The area of the shape is: sq. px.";

                DrawPanel.Invalidate();
                return;
            }

            _labelCurrentSelection.Text = $"Current selection: {_selectedObject.GetType().Name}";

            _xTextBox.Text = _selectedObject!.X.ToString();
            _yTextBox.Text = _selectedObject!.Y.ToString();

            if (_selectedObject is IResizable)
            {
                var currentObject = _selectedObject as IResizable;

                if (_selectedObject is Circle)
                {
                    _wLabel.Text = "R:";

                    _hLabel.Visible = false;
                    _hTextBox.Visible = false;
                    _hPxLabel.Visible = false;
                }
                else
                {
                    _hLabel.Text = "H:";
                    _wLabel.Text = "W:";
                }

                _wTextBox.Text = currentObject!.Width.ToString();
                _hTextBox.Text = currentObject!.Height.ToString();

            }
            else if (_selectedObject is Line line)
            {
                _wLabel.Text = "eX:";
                _hLabel.Text = "eY:";
                _wTextBox.Text = line.EndX.ToString();
                _hTextBox.Text = line.EndY.ToString();
            }

            _colorPicker.Color = _selectedObject.Color;
            _thicknessTextBox.Text = _selectedObject.Thickness.ToString();

            if (_selectedObject is IShape shape)
            {
                _fillCheckBox.Checked = shape.IsFilled;

                _labelPerimetar.Text = $"The perimetar of the shape is: " +
                                       $"{shape.CalculatePerimeter():0.0} px.";
                _labelArea.Text = $"The area of the shape is: " +
                                  $"{shape.CalculateArea():0.0} sq. px.";
            }

            DrawPanel.Invalidate();
        }

        private void BtnColorPicker2_Click(object sender, EventArgs e)
        {
            if (_colorPicker2.ShowDialog() == DialogResult.OK)
            {
                DrawPanel.BackColor = _colorPicker2.Color;
            }
        }

        private void BtnColorPicker_Click(object sender, EventArgs e)
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _objects.Clear();
            _selectedObject = null;
            UpdateUI();
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

        private void ThicknessTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                if(float.TryParse(_thicknessTextBox.Text, out float thickness))
                _selectedObject.Thickness = thickness;
                DrawPanel.Invalidate();
            }
        }

        private void FillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null && _selectedObject is IShape shape)
            {
                shape.IsFilled = _fillCheckBox.Checked;
                DrawPanel.Invalidate();
            }
        }

        private void XTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                if(float.TryParse(_xTextBox.Text, out float x))
                _selectedObject.X = x;
                DrawPanel.Invalidate();
            }
        }

        private void YTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                if(float.TryParse(_yTextBox.Text, out float y))
                _selectedObject.Y = y;
                DrawPanel.Invalidate();
            }
        }

        private void WTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                if(float.TryParse(_wTextBox.Text, out float width))
                
                if (_selectedObject is IShape)
                {
                    var currentObject = _selectedObject as IShape;
                    currentObject!.Width = width;

                    _selectedObject = currentObject;
                }

                if (_selectedObject is Line)
                {
                    var line = _selectedObject as Line;
                    line!.EndX = width;

                    _selectedObject = line;
                }
                DrawPanel.Invalidate();
            }
        }

        private void HTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null)
            {
                if(float.TryParse(_hTextBox.Text, out float height))

                if (_selectedObject is IShape)
                {
                    var currentObject = _selectedObject as IShape;
                    currentObject!.Height = height;

                    _selectedObject = currentObject;
                }

                if (_selectedObject is Line)
                {
                    var line = _selectedObject as Line;
                    line!.EndY = height;

                    _selectedObject = line;
                }


                DrawPanel.Invalidate();
            }
        }
    }
}