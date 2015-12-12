namespace Land_of_Tanks
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.panelPlayer_1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tankRightHard = new System.Windows.Forms.PictureBox();
            this.tankLeftHard = new System.Windows.Forms.PictureBox();
            this.tankRightLight = new System.Windows.Forms.PictureBox();
            this.tankLeftLight = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tankRightHard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankLeftHard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankRightLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankLeftLight)).BeginInit();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1184, 462);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderWidth = 3;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 700;
            this.lineShape2.X2 = 700;
            this.lineShape2.Y1 = 0;
            this.lineShape2.Y2 = 500;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 500;
            this.lineShape1.X2 = 500;
            this.lineShape1.Y1 = 0;
            this.lineShape1.Y2 = 500;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(517, 334);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(168, 49);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(517, 389);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(168, 49);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelScore.Location = new System.Drawing.Point(576, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(51, 20);
            this.labelScore.TabIndex = 3;
            this.labelScore.Text = "Счет:";
            this.labelScore.Visible = false;
            // 
            // panelPlayer_1
            // 
            this.panelPlayer_1.Location = new System.Drawing.Point(3, 3);
            this.panelPlayer_1.Name = "panelPlayer_1";
            this.panelPlayer_1.Size = new System.Drawing.Size(450, 450);
            this.panelPlayer_1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(722, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 450);
            this.panel1.TabIndex = 5;
            // 
            // tankRightHard
            // 
            this.tankRightHard.Image = ((System.Drawing.Image)(resources.GetObject("tankRightHard.Image")));
            this.tankRightHard.Location = new System.Drawing.Point(634, 250);
            this.tankRightHard.Name = "tankRightHard";
            this.tankRightHard.Size = new System.Drawing.Size(51, 37);
            this.tankRightHard.TabIndex = 1;
            this.tankRightHard.TabStop = false;
            this.tankRightHard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tank_MouseDown);
            this.tankRightHard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tank_MouseMove);
            this.tankRightHard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tank_MouseUp);
            // 
            // tankLeftHard
            // 
            this.tankLeftHard.Image = ((System.Drawing.Image)(resources.GetObject("tankLeftHard.Image")));
            this.tankLeftHard.Location = new System.Drawing.Point(517, 250);
            this.tankLeftHard.Name = "tankLeftHard";
            this.tankLeftHard.Size = new System.Drawing.Size(51, 37);
            this.tankLeftHard.TabIndex = 0;
            this.tankLeftHard.TabStop = false;
            this.tankLeftHard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tank_MouseDown);
            this.tankLeftHard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tank_MouseMove);
            this.tankLeftHard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tank_MouseUp);
            // 
            // tankRightLight
            // 
            this.tankRightLight.Image = ((System.Drawing.Image)(resources.GetObject("tankRightLight.Image")));
            this.tankRightLight.InitialImage = null;
            this.tankRightLight.Location = new System.Drawing.Point(640, 293);
            this.tankRightLight.Name = "tankRightLight";
            this.tankRightLight.Size = new System.Drawing.Size(45, 35);
            this.tankRightLight.TabIndex = 1;
            this.tankRightLight.TabStop = false;
            this.tankRightLight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tank_MouseDown);
            this.tankRightLight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tank_MouseMove);
            this.tankRightLight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tank_MouseUp);
            // 
            // tankLeftLight
            // 
            this.tankLeftLight.Image = ((System.Drawing.Image)(resources.GetObject("tankLeftLight.Image")));
            this.tankLeftLight.InitialImage = null;
            this.tankLeftLight.Location = new System.Drawing.Point(517, 293);
            this.tankLeftLight.Name = "tankLeftLight";
            this.tankLeftLight.Size = new System.Drawing.Size(45, 35);
            this.tankLeftLight.TabIndex = 0;
            this.tankLeftLight.TabStop = false;
            this.tankLeftLight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tank_MouseDown);
            this.tankLeftLight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tank_MouseMove);
            this.tankLeftLight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tank_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 462);
            this.Controls.Add(this.tankRightLight);
            this.Controls.Add(this.tankRightHard);
            this.Controls.Add(this.tankLeftHard);
            this.Controls.Add(this.tankLeftLight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPlayer_1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Form1";
            this.Text = "Land of Tanks";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tankRightHard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankLeftHard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankRightLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankLeftLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Panel panelPlayer_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox tankLeftLight;
        private System.Windows.Forms.PictureBox tankRightHard;
        private System.Windows.Forms.PictureBox tankLeftHard;
        private System.Windows.Forms.PictureBox tankRightLight;
    }
}

