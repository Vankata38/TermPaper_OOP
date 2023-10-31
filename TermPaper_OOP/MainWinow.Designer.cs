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
            _btnDrawLine = new Button();
            _btnDrawRectangle = new Button();
            _btnDrawTriangle = new Button();
            SuspendLayout();
            // 
            // _btnMove
            // 
            _btnMove.BackColor = SystemColors.Control;
            _btnMove.BackgroundImage = Properties.Resources.Mouse;
            resources.ApplyResources(_btnMove, "_btnMove");
            _btnMove.Cursor = Cursors.Hand;
            _btnMove.ForeColor = SystemColors.ControlText;
            _btnMove.Name = "_btnMove";
            _btnMove.UseVisualStyleBackColor = false;
            _btnMove.Click += BtnMove_Click;
            // 
            // _btnDrawLine
            // 
            _btnDrawLine.BackColor = SystemColors.Control;
            _btnDrawLine.BackgroundImage = Properties.Resources.Line;
            resources.ApplyResources(_btnDrawLine, "_btnDrawLine");
            _btnDrawLine.Cursor = Cursors.Hand;
            _btnDrawLine.Name = "_btnDrawLine";
            _btnDrawLine.UseVisualStyleBackColor = false;
            // 
            // _btnDrawRectangle
            // 
            _btnDrawRectangle.BackColor = SystemColors.Control;
            _btnDrawRectangle.BackgroundImage = Properties.Resources.Rectangle;
            resources.ApplyResources(_btnDrawRectangle, "_btnDrawRectangle");
            _btnDrawRectangle.Cursor = Cursors.Hand;
            _btnDrawRectangle.Name = "_btnDrawRectangle";
            _btnDrawRectangle.UseVisualStyleBackColor = false;
            // 
            // _btnDrawTriangle
            // 
            _btnDrawTriangle.BackgroundImage = Properties.Resources.Triangle;
            resources.ApplyResources(_btnDrawTriangle, "_btnDrawTriangle");
            _btnDrawTriangle.Cursor = Cursors.Hand;
            _btnDrawTriangle.Name = "_btnDrawTriangle";
            _btnDrawTriangle.UseVisualStyleBackColor = true;
            // 
            // Scene
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_btnDrawTriangle);
            Controls.Add(_btnDrawRectangle);
            Controls.Add(_btnDrawLine);
            Controls.Add(_btnMove);
            Name = "Scene";
            Load += MainWindow_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button _btnMove;
        private Button _btnDrawLine;
        private Button _btnDrawRectangle;
        private Button _btnDrawTriangle;
    }
}