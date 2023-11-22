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
            DrawPanel = new Panel();
            _btnSelect = new Button();
            _btnCircle = new Button();
            _btnEllipse = new Button();
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
            // DrawPanel
            // 
            resources.ApplyResources(DrawPanel, "DrawPanel");
            DrawPanel.BackColor = SystemColors.ButtonShadow;
            DrawPanel.Name = "DrawPanel";
            DrawPanel.Paint += DrawPanel_Paint;
            DrawPanel.MouseDown += DrawPanel_MouseDown;
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
            // Scene
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_btnEllipse);
            Controls.Add(_btnCircle);
            Controls.Add(_btnSelect);
            Controls.Add(DrawPanel);
            Controls.Add(_btnTriangle);
            Controls.Add(_btnRectangle);
            Controls.Add(_btnLine);
            Controls.Add(_btnMove);
            Name = "Scene";
            ResumeLayout(false);
        }

        #endregion

        private Button _btnMove;
        private Button _btnDrawLine;
        private Button _btnDrawRectangle;
        private Button _btnDrawTriangle;
        private Panel panel1;
        private Panel DrawPanel;
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
    }
}