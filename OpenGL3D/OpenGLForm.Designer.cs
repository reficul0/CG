
namespace OpenGL
{
    partial class OpenGLForm
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
            this.components = new System.ComponentModel.Container();
            this.mHolst = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quadratToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trapeciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.isFogEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.isLightEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.isFlatShadeEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mHolst
            // 
            this.mHolst.AccumBits = ((byte)(0));
            this.mHolst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mHolst.AutoCheckErrors = false;
            this.mHolst.AutoFinish = false;
            this.mHolst.AutoMakeCurrent = true;
            this.mHolst.AutoSwapBuffers = true;
            this.mHolst.BackColor = System.Drawing.Color.Black;
            this.mHolst.ColorBits = ((byte)(32));
            this.mHolst.ContextMenuStrip = this.contextMenuStrip1;
            this.mHolst.DepthBits = ((byte)(16));
            this.mHolst.Location = new System.Drawing.Point(-1, -2);
            this.mHolst.Name = "mHolst";
            this.mHolst.Size = new System.Drawing.Size(1056, 719);
            this.mHolst.StencilBits = ((byte)(0));
            this.mHolst.TabIndex = 0;
            this.mHolst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mHolst_KeyPress);
            this.mHolst.MouseEnter += new System.EventHandler(this.mHolst_MouseEnter);
            this.mHolst.MouseLeave += new System.EventHandler(this.mHolst_MouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quadratToolStripMenuItem,
            this.trapeciaToolStripMenuItem,
            this.figuresToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 70);
            // 
            // quadratToolStripMenuItem
            // 
            this.quadratToolStripMenuItem.Name = "quadratToolStripMenuItem";
            this.quadratToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.quadratToolStripMenuItem.Text = "Quadrat";
            this.quadratToolStripMenuItem.Click += new System.EventHandler(this.quadratToolStripMenuItem_Click);
            // 
            // trapeciaToolStripMenuItem
            // 
            this.trapeciaToolStripMenuItem.Name = "trapeciaToolStripMenuItem";
            this.trapeciaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.trapeciaToolStripMenuItem.Text = "Trapecia";
            this.trapeciaToolStripMenuItem.Click += new System.EventHandler(this.trapeciaToolStripMenuItem_Click);
            // 
            // figuresToolStripMenuItem
            // 
            this.figuresToolStripMenuItem.Name = "figuresToolStripMenuItem";
            this.figuresToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.figuresToolStripMenuItem.Text = "2 figures";
            this.figuresToolStripMenuItem.Click += new System.EventHandler(this.figuresToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // isFogEnabledCheckBox
            // 
            this.isFogEnabledCheckBox.AutoSize = true;
            this.isFogEnabledCheckBox.Location = new System.Drawing.Point(7, 13);
            this.isFogEnabledCheckBox.Name = "isFogEnabledCheckBox";
            this.isFogEnabledCheckBox.Size = new System.Drawing.Size(44, 17);
            this.isFogEnabledCheckBox.TabIndex = 1;
            this.isFogEnabledCheckBox.Text = "Fog";
            this.isFogEnabledCheckBox.UseVisualStyleBackColor = true;
            this.isFogEnabledCheckBox.CheckedChanged += new System.EventHandler(this.isFogEnabledCheckBox_CheckedChanged);
            // 
            // isLightEnabledCheckBox
            // 
            this.isLightEnabledCheckBox.AutoSize = true;
            this.isLightEnabledCheckBox.Location = new System.Drawing.Point(7, 36);
            this.isLightEnabledCheckBox.Name = "isLightEnabledCheckBox";
            this.isLightEnabledCheckBox.Size = new System.Drawing.Size(49, 17);
            this.isLightEnabledCheckBox.TabIndex = 2;
            this.isLightEnabledCheckBox.Text = "Light";
            this.isLightEnabledCheckBox.UseVisualStyleBackColor = true;
            this.isLightEnabledCheckBox.CheckedChanged += new System.EventHandler(this.isLightEnabledCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.isFlatShadeEnabledCheckBox);
            this.panel1.Controls.Add(this.isFogEnabledCheckBox);
            this.panel1.Controls.Add(this.isLightEnabledCheckBox);
            this.panel1.Location = new System.Drawing.Point(957, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 100);
            this.panel1.TabIndex = 3;
            // 
            // isFlatShadeEnabledCheckBox
            // 
            this.isFlatShadeEnabledCheckBox.AutoSize = true;
            this.isFlatShadeEnabledCheckBox.Location = new System.Drawing.Point(7, 60);
            this.isFlatShadeEnabledCheckBox.Name = "isFlatShadeEnabledCheckBox";
            this.isFlatShadeEnabledCheckBox.Size = new System.Drawing.Size(75, 17);
            this.isFlatShadeEnabledCheckBox.TabIndex = 3;
            this.isFlatShadeEnabledCheckBox.Text = "Flat shade";
            this.isFlatShadeEnabledCheckBox.UseVisualStyleBackColor = true;
            this.isFlatShadeEnabledCheckBox.CheckedChanged += new System.EventHandler(this.isFlatShadeEnabledCheckBox_CheckedChanged);
            // 
            // OpenGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 713);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mHolst);
            this.Name = "OpenGLForm";
            this.Text = "OpenGLForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl mHolst;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quadratToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trapeciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuresToolStripMenuItem;
        private System.Windows.Forms.CheckBox isFogEnabledCheckBox;
        private System.Windows.Forms.CheckBox isLightEnabledCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox isFlatShadeEnabledCheckBox;
    }
}

