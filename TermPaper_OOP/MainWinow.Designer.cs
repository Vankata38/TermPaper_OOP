namespace TermPaper_OOP
{
    partial class Scene
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scene));
            _btnMove = new Button();
            _btnLine = new Button();
            _btnRectangle = new Button();
            _btnTriangle = new Button();
            _btnSelect = new Button();
            _btnCircle = new Button();
            _btnEllipse = new Button();
            button4 = new Button();
            button5 = new Button();
            _saveFile = new SaveFileDialog();
            _colorPicker = new ColorDialog();
            _openFile = new OpenFileDialog();
            _xTextBox = new TextBox();
            _yTextBox = new TextBox();
            _labelX = new Label();
            _labelY = new Label();
            _wLabel = new Label();
            _hLabel = new Label();
            _wTextBox = new TextBox();
            _hTextBox = new TextBox();
            Color = new Label();
            Devider = new Label();
            _btnBGColorPicker = new Button();
            _colorPicker2 = new ColorDialog();
            Devider2 = new Label();
            _btnColorPicker = new Button();
            _btnClear = new Button();
            label1 = new Label();
            label2 = new Label();
            _btnCopy = new Button();
            _labelBorder = new Label();
            Devider4 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            _thicknessTextBox = new TextBox();
            _labelCurrentSelection = new Label();
            _fillCheckBox = new CheckBox();
            label3 = new Label();
            label5 = new Label();
            _labelPerimetar = new Label();
            _labelArea = new Label();
            label6 = new Label();
            _wPxLabel = new Label();
            label8 = new Label();
            _hPxLabel = new Label();
            DrawPanel = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DrawPanel).BeginInit();
            SuspendLayout();
            // 
            // _btnMove
            // 
            _btnMove.BackColor = SystemColors.Control;
            resources.ApplyResources(_btnMove, "_btnMove");
            _btnMove.ForeColor = SystemColors.ControlText;
            _btnMove.Image = Properties.Resources.Mouse;
            _btnMove.Name = "_btnMove";
            _btnMove.UseVisualStyleBackColor = false;
            _btnMove.Click += Btn_Click;
            // 
            // _btnLine
            // 
            _btnLine.BackColor = SystemColors.Control;
            resources.ApplyResources(_btnLine, "_btnLine");
            _btnLine.Cursor = Cursors.Hand;
            _btnLine.Image = Properties.Resources.Line;
            _btnLine.Name = "_btnLine";
            _btnLine.UseVisualStyleBackColor = false;
            _btnLine.Click += Btn_Click;
            // 
            // _btnRectangle
            // 
            _btnRectangle.BackColor = SystemColors.Control;
            resources.ApplyResources(_btnRectangle, "_btnRectangle");
            _btnRectangle.Cursor = Cursors.Hand;
            _btnRectangle.Image = Properties.Resources.Rectangle;
            _btnRectangle.Name = "_btnRectangle";
            _btnRectangle.UseVisualStyleBackColor = false;
            _btnRectangle.Click += Btn_Click;
            // 
            // _btnTriangle
            // 
            resources.ApplyResources(_btnTriangle, "_btnTriangle");
            _btnTriangle.Cursor = Cursors.Hand;
            _btnTriangle.Image = Properties.Resources.Triangle;
            _btnTriangle.Name = "_btnTriangle";
            _btnTriangle.UseVisualStyleBackColor = false;
            _btnTriangle.Click += Btn_Click;
            // 
            // _btnSelect
            // 
            resources.ApplyResources(_btnSelect, "_btnSelect");
            _btnSelect.Image = Properties.Resources.Select;
            _btnSelect.Name = "_btnSelect";
            _btnSelect.UseVisualStyleBackColor = false;
            _btnSelect.Click += Btn_Click;
            // 
            // _btnCircle
            // 
            resources.ApplyResources(_btnCircle, "_btnCircle");
            _btnCircle.Image = Properties.Resources.Circle;
            _btnCircle.Name = "_btnCircle";
            _btnCircle.UseVisualStyleBackColor = false;
            _btnCircle.Click += Btn_Click;
            // 
            // _btnEllipse
            // 
            resources.ApplyResources(_btnEllipse, "_btnEllipse");
            _btnEllipse.Image = Properties.Resources.Ellipse;
            _btnEllipse.Name = "_btnEllipse";
            _btnEllipse.UseVisualStyleBackColor = false;
            _btnEllipse.Click += Btn_Click;
            // 
            // button4
            // 
            resources.ApplyResources(button4, "button4");
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            resources.ApplyResources(button5, "button5");
            button5.Name = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // _openFile
            // 
            _openFile.FileName = "openFileDialog1";
            // 
            // _xTextBox
            // 
            resources.ApplyResources(_xTextBox, "_xTextBox");
            _xTextBox.Name = "_xTextBox";
            _xTextBox.TextChanged += XTextBox_TextChanged;
            // 
            // _yTextBox
            // 
            resources.ApplyResources(_yTextBox, "_yTextBox");
            _yTextBox.Name = "_yTextBox";
            _yTextBox.TextChanged += YTextBox_TextChanged;
            // 
            // _labelX
            // 
            resources.ApplyResources(_labelX, "_labelX");
            _labelX.Name = "_labelX";
            // 
            // _labelY
            // 
            resources.ApplyResources(_labelY, "_labelY");
            _labelY.Name = "_labelY";
            // 
            // _wLabel
            // 
            resources.ApplyResources(_wLabel, "_wLabel");
            _wLabel.Name = "_wLabel";
            // 
            // _hLabel
            // 
            resources.ApplyResources(_hLabel, "_hLabel");
            _hLabel.Name = "_hLabel";
            // 
            // _wTextBox
            // 
            resources.ApplyResources(_wTextBox, "_wTextBox");
            _wTextBox.Name = "_wTextBox";
            _wTextBox.TextChanged += WTextBox_TextChanged;
            // 
            // _hTextBox
            // 
            resources.ApplyResources(_hTextBox, "_hTextBox");
            _hTextBox.Name = "_hTextBox";
            _hTextBox.TextChanged += HTextBox_TextChanged;
            // 
            // Color
            // 
            resources.ApplyResources(Color, "Color");
            Color.Name = "Color";
            // 
            // Devider
            // 
            resources.ApplyResources(Devider, "Devider");
            Devider.BorderStyle = BorderStyle.FixedSingle;
            Devider.Name = "Devider";
            // 
            // _btnBGColorPicker
            // 
            resources.ApplyResources(_btnBGColorPicker, "_btnBGColorPicker");
            _btnBGColorPicker.Name = "_btnBGColorPicker";
            _btnBGColorPicker.UseVisualStyleBackColor = true;
            _btnBGColorPicker.Click += BtnColorPicker2_Click;
            // 
            // Devider2
            // 
            resources.ApplyResources(Devider2, "Devider2");
            Devider2.BorderStyle = BorderStyle.FixedSingle;
            Devider2.Name = "Devider2";
            // 
            // _btnColorPicker
            // 
            resources.ApplyResources(_btnColorPicker, "_btnColorPicker");
            _btnColorPicker.Name = "_btnColorPicker";
            _btnColorPicker.UseVisualStyleBackColor = true;
            _btnColorPicker.Click += BtnColorPicker_Click;
            // 
            // _btnClear
            // 
            resources.ApplyResources(_btnClear, "_btnClear");
            _btnClear.Name = "_btnClear";
            _btnClear.UseVisualStyleBackColor = true;
            _btnClear.Click += BtnClear_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Name = "label2";
            // 
            // _btnCopy
            // 
            resources.ApplyResources(_btnCopy, "_btnCopy");
            _btnCopy.Image = Properties.Resources.Copy1;
            _btnCopy.Name = "_btnCopy";
            _btnCopy.UseVisualStyleBackColor = true;
            _btnCopy.Click += Btn_Click;
            // 
            // _labelBorder
            // 
            resources.ApplyResources(_labelBorder, "_labelBorder");
            _labelBorder.Name = "_labelBorder";
            // 
            // Devider4
            // 
            resources.ApplyResources(Devider4, "Devider4");
            Devider4.BorderStyle = BorderStyle.FixedSingle;
            Devider4.Name = "Devider4";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Name = "label4";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Image = Properties.Resources.Undo;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnUndo_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Image = Properties.Resources.Redo;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnRedo_Click;
            // 
            // _thicknessTextBox
            // 
            resources.ApplyResources(_thicknessTextBox, "_thicknessTextBox");
            _thicknessTextBox.Name = "_thicknessTextBox";
            _thicknessTextBox.TextChanged += ThicknessTextBox_OnTextChanged;
            // 
            // _labelCurrentSelection
            // 
            resources.ApplyResources(_labelCurrentSelection, "_labelCurrentSelection");
            _labelCurrentSelection.Name = "_labelCurrentSelection";
            // 
            // _fillCheckBox
            // 
            resources.ApplyResources(_fillCheckBox, "_fillCheckBox");
            _fillCheckBox.Name = "_fillCheckBox";
            _fillCheckBox.UseVisualStyleBackColor = true;
            _fillCheckBox.CheckedChanged += FillCheckBox_CheckedChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Name = "label5";
            // 
            // _labelPerimetar
            // 
            resources.ApplyResources(_labelPerimetar, "_labelPerimetar");
            _labelPerimetar.Name = "_labelPerimetar";
            // 
            // _labelArea
            // 
            resources.ApplyResources(_labelArea, "_labelArea");
            _labelArea.Name = "_labelArea";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // _wPxLabel
            // 
            resources.ApplyResources(_wPxLabel, "_wPxLabel");
            _wPxLabel.Name = "_wPxLabel";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // _hPxLabel
            // 
            resources.ApplyResources(_hPxLabel, "_hPxLabel");
            _hPxLabel.Name = "_hPxLabel";
            // 
            // DrawPanel
            // 
            resources.ApplyResources(DrawPanel, "DrawPanel");
            DrawPanel.BackColor = SystemColors.AppWorkspace;
            DrawPanel.Name = "DrawPanel";
            DrawPanel.TabStop = false;
            DrawPanel.Paint += DrawPanel_Paint;
            DrawPanel.MouseDown += DrawPanel_MouseDown;
            DrawPanel.MouseMove += DrawPanel_MouseMove;
            DrawPanel.MouseUp += DrawPanel_MouseUp;
            // 
            // Scene
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DrawPanel);
            Controls.Add(_labelArea);
            Controls.Add(_labelPerimetar);
            Controls.Add(_wPxLabel);
            Controls.Add(_hPxLabel);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(_fillCheckBox);
            Controls.Add(_labelCurrentSelection);
            Controls.Add(_thicknessTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(_labelBorder);
            Controls.Add(_btnCopy);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(_btnClear);
            Controls.Add(_btnColorPicker);
            Controls.Add(_btnBGColorPicker);
            Controls.Add(Devider2);
            Controls.Add(label5);
            Controls.Add(Devider4);
            Controls.Add(Devider);
            Controls.Add(Color);
            Controls.Add(_hTextBox);
            Controls.Add(_wTextBox);
            Controls.Add(_hLabel);
            Controls.Add(_wLabel);
            Controls.Add(_labelY);
            Controls.Add(_labelX);
            Controls.Add(_yTextBox);
            Controls.Add(_xTextBox);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(_btnEllipse);
            Controls.Add(_btnCircle);
            Controls.Add(_btnSelect);
            Controls.Add(_btnTriangle);
            Controls.Add(_btnRectangle);
            Controls.Add(_btnLine);
            Controls.Add(_btnMove);
            DoubleBuffered = true;
            Name = "Scene";
            KeyUp += Scene_KeyUp;
            ((System.ComponentModel.ISupportInitialize)DrawPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button _btnMove;
        private Button _btnDrawLine;
        private Button _btnDrawRectangle;
        private Button _btnDrawTriangle;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button _btnLine;
        private Button _btnRectangle;
        private Button _btnTriangle;
        private Button Select;
        private Button _btnCircle;
        private Button _btnEllipse;
        private Button _btnSelect;
        private Button button4;
        private Button button5;
        private SaveFileDialog _saveFile;
        private ColorDialog _colorPicker;
        private OpenFileDialog _openFile;
        private TextBox _xTextBox;
        private TextBox _yTextBox;
        private Label _labelX;
        private Label _labelY;
        private Label _wLabel;
        private Label _hLabel;
        private TextBox _wTextBox;
        private TextBox _hTextBox;
        private Label Color;
        private Label Devider;
        private Button _btnBGColorPicker;
        private ColorDialog _colorPicker2;
        private Label Devider2;
        private Button _btnColorPicker;
        private Button _btnClear;
        private Label label1;
        private Label label2;
        private Button _btnCopy;
        private Label _labelBorder;
        private Label Devider4;
        private Label label4;
        private TextBox _thicknessTextBox;
        private Label _labelCurrentSelection;
        private CheckBox _fillCheckBox;
        private Label label3;
        private Label label5;
        private Label _labelPerimetar;
        private Label _labelArea;
        private Label label6;
        private Label _wPxLabel;
        private Label label8;
        private Label _hPxLabel;
        private PictureBox DrawPanel;
    }
}