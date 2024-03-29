using System.Diagnostics.Eventing.Reader;
using TermPaper_OOP.Classes;
using TermPaper_OOP.Commands;
using TermLibrary.Interfaces;
using TermLibrary.Classes;

namespace TermPaper_OOP
{
    public partial class Scene : Form
    {
        private static readonly CommandManager _commandManager = new();

        public static List<IDrawableAndSelectable> Objects = new();
        public static IDrawableAndSelectable? _selectedObject = null;

        private ActionType _currentAction = ActionType.Select;
        private System.Windows.Forms.Timer _timer;
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

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawHandler drawHandler = new(e.Graphics);
            foreach (var obj in Objects)
            {
                obj.Draw(drawHandler);
            }
            if (_selectedObject != null)
                _selectedObject.Draw(drawHandler);
        }

        // MARK: Mouse Handeling
        protected void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _startingPosition = e.Location;
                if (!float.TryParse(_thicknessTextBox.Text, out float thickness))
                    thickness = 3.0f;

                switch (_currentAction)
                {
                    case ActionType.Move:
                        if (_selectedObject == null) return;
                        _offset = new PointF(e.X - _selectedObject!.X, e.Y - _selectedObject.Y);
                        _startingPosition = _startingPosition - new SizeF(_offset.X, _offset.Y);
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
                       TermLibrary.Classes.Rectangle rect = new(
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
                        Ellipse ellipse = new(
                            _startingPosition.X,
                            _startingPosition.Y,
                            MathF.Abs(e.Location.X - _startingPosition.X),
                            20,
                            _fillCheckBox.Checked, _colorPicker.Color, thickness);

                        _selectedObject = ellipse;
                        break;
                }
            }
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentAction)
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
                        if (_selectedObject is TermLibrary.Classes.Rectangle)
                        {
                            var rectangle = _selectedObject as TermLibrary.Classes.Rectangle;

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
                        if (_selectedObject is Ellipse)
                        {
                            var ellipse = _selectedObject as Ellipse;
                            
                            ellipse!.Width = MathF.Abs(e.Location.X - _startingPosition.X);
                            ellipse!.Height = MathF.Abs(e.Location.Y - _startingPosition.Y);

                            _selectedObject = ellipse;
                        }
                        DrawPanel.Invalidate();
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
                        _selectedObject = Objects.LastOrDefault(
                            obj => obj.PointIsInside(_startingPosition) == true);

                        break;

                    case ActionType.Move:
                        if (_selectedObject == null) return;

                        var mouseX = e.X - _offset.X;
                        var mouseY = e.Y - _offset.Y;

                        var moveCommand = new Move(_selectedObject, _startingPosition, new PointF(mouseX, mouseY));
                        _commandManager.ExecuteCommand(moveCommand);

                        break;

                    case ActionType.Copy:
                        if (_selectedObject == null) return;

                        mouseX = e.X - _offset.X;
                        mouseY = e.Y - _offset.Y;

                        var copyCommand = new Copy(_selectedObject, new PointF(mouseX, mouseY));
                        _commandManager.ExecuteCommand(copyCommand);

                        break;

                    case ActionType.Line:

                        if (_selectedObject == null) return;

                        var drawCommand = new Draw(_selectedObject);
                        _commandManager.ExecuteCommand(drawCommand);

                        break;

                    case ActionType.Rectangle:
                        if (_selectedObject == null) return;

                        drawCommand = new Draw(_selectedObject);
                        _commandManager.ExecuteCommand(drawCommand);

                        break;

                    case ActionType.Triangle:
                        if (_selectedObject == null) return;

                        drawCommand = new Draw(_selectedObject);
                        _commandManager.ExecuteCommand(drawCommand);

                        break;

                    case ActionType.Circle:
                        if (_selectedObject == null) return;

                        drawCommand = new Draw(_selectedObject);
                        _commandManager.ExecuteCommand(drawCommand);

                        break;

                    case ActionType.Ellipse:
                        if (_selectedObject == null) return;

                        drawCommand = new Draw(_selectedObject);
                        _commandManager.ExecuteCommand(drawCommand);

                        break;
                }
            }
            UpdateUI();
        }

        // MARK: - UI Inputs
        /// <summary>
        /// This function is called on any of the mode buttons, 
        /// it selects the current action we are trying to do
        /// </summary>
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

        private void BtnColorPicker_Click(object sender, EventArgs e)
        {
            if (_colorPicker.ShowDialog() == DialogResult.OK)
            {
                _btnColorPicker.BackColor = _colorPicker.Color;

                if (_selectedObject != null)
                {
                    var command = new ChangeColor(_selectedObject, _colorPicker.Color);
                    _commandManager.ExecuteCommand(command);
                    DrawPanel.Invalidate();
                }
            }
        }

        private void BtnBackgroundColor_Click(object sender, EventArgs e)
        {
            if (_colorPicker2.ShowDialog() == DialogResult.OK)
            {
                DrawPanel.BackColor = _colorPicker2.Color;
            }
        }

        private void Scene_KeyUp(object sender, KeyEventArgs e)
        {
            if (_selectedObject != null && e.KeyCode == Keys.Delete)
            {
                Objects.Remove(_selectedObject);
                _selectedObject = null;
                DrawPanel.Invalidate();
            }
        }

        private void FillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedObject != null && _selectedObject is IShape shape)
            {
                var command = new ChangeFilled(shape, _fillCheckBox.Checked);
                _commandManager.ExecuteCommand(command);
                DrawPanel.Invalidate();
            }
        }

        private void StartTimer(Action action)
        {
            if (_timer != null)
            {
                _timer.Stop();
            }

            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += (s, e) =>
            {
                if (_timer != null)
                {
                    _timer.Stop();
                    _timer = null;
                    action?.Invoke();
                }
            };

            _timer.Interval = 500;
            _timer.Start();
        }

        private void ThicknessTextBox_OnTextChanged(object sender, EventArgs e)
        {
            StartTimer(() =>
            {
                if (_selectedObject != null)
                {
                    if (float.TryParse(_thicknessTextBox.Text, out float thickness)) ;
                    var command = new ChangeThickness(_selectedObject, _selectedObject.Thickness, thickness);
                    _commandManager.ExecuteCommand(command);
                    DrawPanel.Invalidate();
                }
            });
        }

        private void XTextBox_TextChanged(object sender, EventArgs e)
        {
            StartTimer(() =>
            {
                if (_selectedObject != null && float.TryParse(_xTextBox.Text, out float x))
                {
                    var oldPosition = new PointF(_selectedObject.X, _selectedObject.Y);
                    var newPosition = new PointF(x, _selectedObject.Y);

                    var command = new Move(_selectedObject, oldPosition, newPosition);
                    _commandManager.ExecuteCommand(command);

                    DrawPanel.Invalidate();
                }
            });
        }

        private void YTextBox_TextChanged(object sender, EventArgs e)
        {
            StartTimer(() =>
            {
                if (_selectedObject != null && float.TryParse(_yTextBox.Text, out float y))
                {
                    var oldPosition = new PointF(_selectedObject.X, _selectedObject.Y);
                    var newPosition = new PointF(_selectedObject.X, y);

                    var command = new Move(_selectedObject, oldPosition, newPosition);
                    _commandManager.ExecuteCommand(command);

                    DrawPanel.Invalidate();
                }
            });
        }

        private void WTextBox_TextChanged(object sender, EventArgs e)
        {
            StartTimer(() =>
            {
                if (_selectedObject != null && float.TryParse(_wTextBox.Text, out float width))
                {
                    SizeF newSize;
                    if (_selectedObject is IShape shape)
                    {
                        newSize = new SizeF(width, shape.Height);
                    }
                    else if (_selectedObject is Line line)
                    {
                        newSize = new SizeF(width, line.EndY);
                    }
                    else return;

                    var command = new Resize(_selectedObject, newSize);
                    _commandManager.ExecuteCommand(command);

                    DrawPanel.Invalidate();
                }
            });
        }

        private void HTextBox_TextChanged(object sender, EventArgs e)
        {
            StartTimer(() =>
            {
                if (_selectedObject != null && float.TryParse(_hTextBox.Text, out float height))
                {
                    SizeF newSize;
                    if (_selectedObject is IShape shape)
                    {
                        newSize = new SizeF(shape.Width, height);
                    }
                    else if (_selectedObject is Line line)
                    {
                        newSize = new SizeF(line.EndX, height);
                    }
                    else return;

                    var command = new Resize(_selectedObject, newSize);
                    _commandManager.ExecuteCommand(command);

                    DrawPanel.Invalidate();
                }
            });
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            _commandManager.Undo();
            UpdateUI();
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            _commandManager.Redo();
            UpdateUI();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Objects.Clear();
            _commandManager.Clear();
            _selectedObject = null;
            UpdateUI();
        }


        // MARK: - UI Handeling 
        private void UpdateUI()
        {
            FreezeOnChange();

            if (_selectedObject == null)
                ResetUI();
            else
                DisplayObjectInfo();

            UnfreezeOnChange();
            DrawPanel.Invalidate();
        }

        private void FreezeOnChange()
        {
            _thicknessTextBox.TextChanged -= ThicknessTextBox_OnTextChanged;
            _fillCheckBox.CheckedChanged -= FillCheckBox_CheckedChanged;
            _xTextBox.TextChanged -= XTextBox_TextChanged;
            _yTextBox.TextChanged -= YTextBox_TextChanged;
            _wTextBox.TextChanged -= WTextBox_TextChanged;
            _hTextBox.TextChanged -= HTextBox_TextChanged;
        }

        private void UnfreezeOnChange()
        {
            _thicknessTextBox.TextChanged += ThicknessTextBox_OnTextChanged;
            _fillCheckBox.CheckedChanged += FillCheckBox_CheckedChanged;
            _xTextBox.TextChanged += XTextBox_TextChanged;
            _yTextBox.TextChanged += YTextBox_TextChanged;
            _wTextBox.TextChanged += WTextBox_TextChanged;
            _hTextBox.TextChanged += HTextBox_TextChanged;
        }

        private void ResetUI()
        {
            _labelCurrentSelection.Text = "Select an object";
            _fillCheckBox.Checked = false;
            _thicknessTextBox.Text = "3";
            ClearTextBoxes();
            SetDefaultLabels();
        }

        private void DisplayObjectInfo()
        {
            _labelCurrentSelection.Text = $"Current selection: {_selectedObject!.GetType().Name}";
            UpdatePositionTextBoxes();
            UpdateDimensionTextBoxes();

            _colorPicker.Color = _selectedObject.Color;
            _thicknessTextBox.Text = _selectedObject.Thickness.ToString();

            if (_selectedObject is IShape shape)
            {
                _fillCheckBox.Checked = shape.IsFilled;
                DisplayPerimeterAndArea(shape);
            }
        }

        private void ClearTextBoxes()
        {
            _xTextBox.Clear();
            _yTextBox.Clear();
            _wTextBox.Clear();
            _hTextBox.Clear();
        }

        private void SetDefaultLabels()
        {
            _wLabel.Text = "W:";
            _hLabel.Text = "H:";
            _hLabel.Visible = true;
            _hTextBox.Visible = true;
            _hPxLabel.Visible = true;
        }

        private void UpdatePositionTextBoxes()
        {
            _xTextBox.Text = _selectedObject!.X.ToString();
            _yTextBox.Text = _selectedObject!.Y.ToString();
        }

        private void UpdateDimensionTextBoxes()
        {
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
        }

        private void DisplayPerimeterAndArea(IShape shape)
        {
            _labelPerimetar.Text = $"The perimetar of the shape is: {shape.CalculatePerimeter():0.0} px.";
            _labelArea.Text = $"The area of the shape is: {shape.CalculateArea():0.0} sq. px.";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // TODO: Make it user selectable
            SVGHandler.SaveShapesToSVG(Objects, "test.svg");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // TODO: Make it user selectable
            Objects = SVGHandler.LoadShapesFromSVG("test.svg");
            DrawPanel.Invalidate();
        }
    }
}