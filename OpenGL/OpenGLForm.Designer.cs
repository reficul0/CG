
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
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesP = new System.Windows.Forms.ToolStripMenuItem();
            this.lines = new System.Windows.Forms.ToolStripMenuItem();
            this.linesStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.linesLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.trianglesP = new System.Windows.Forms.ToolStripMenuItem();
            this.triangles = new System.Windows.Forms.ToolStripMenuItem();
            this.trianglesFan = new System.Windows.Forms.ToolStripMenuItem();
            this.trianglesStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.quads = new System.Windows.Forms.ToolStripMenuItem();
            this.quadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.polygon = new System.Windows.Forms.ToolStripMenuItem();
            this.task = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
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
            this.mHolst.DepthBits = ((byte)(16));
            this.mHolst.Location = new System.Drawing.Point(-1, -2);
            this.mHolst.Name = "mHolst";
            this.mHolst.Size = new System.Drawing.Size(1056, 719);
            this.mHolst.StencilBits = ((byte)(0));
            this.mHolst.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointsToolStripMenuItem,
            this.linesP,
            this.trianglesP,
            this.quads,
            this.polygon,
            this.task});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 158);
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pointsToolStripMenuItem.Text = "Point";
            this.pointsToolStripMenuItem.Click += new System.EventHandler(this.pointsToolStripMenuItem_Click);
            // 
            // linesP
            // 
            this.linesP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lines,
            this.linesStrip,
            this.linesLoop});
            this.linesP.Name = "linesP";
            this.linesP.Size = new System.Drawing.Size(180, 22);
            this.linesP.Text = "Lines";
            // 
            // lines
            // 
            this.lines.Name = "lines";
            this.lines.Size = new System.Drawing.Size(180, 22);
            this.lines.Text = "Lines";
            this.lines.Click += new System.EventHandler(this.lines_Click);
            // 
            // linesStrip
            // 
            this.linesStrip.Name = "linesStrip";
            this.linesStrip.Size = new System.Drawing.Size(180, 22);
            this.linesStrip.Text = "Strip";
            this.linesStrip.Click += new System.EventHandler(this.lineStrip_Click);
            // 
            // linesLoop
            // 
            this.linesLoop.Name = "linesLoop";
            this.linesLoop.Size = new System.Drawing.Size(180, 22);
            this.linesLoop.Text = "Loop";
            this.linesLoop.Click += new System.EventHandler(this.lineLoop_Click);
            // 
            // trianglesP
            // 
            this.trianglesP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triangles,
            this.trianglesFan,
            this.trianglesStrip});
            this.trianglesP.Name = "trianglesP";
            this.trianglesP.Size = new System.Drawing.Size(180, 22);
            this.trianglesP.Text = "Triangles";
            // 
            // triangles
            // 
            this.triangles.Name = "triangles";
            this.triangles.Size = new System.Drawing.Size(180, 22);
            this.triangles.Text = "Triangles";
            this.triangles.Click += new System.EventHandler(this.triangles_Click);
            // 
            // trianglesFan
            // 
            this.trianglesFan.Name = "trianglesFan";
            this.trianglesFan.Size = new System.Drawing.Size(180, 22);
            this.trianglesFan.Text = "Fan";
            this.trianglesFan.Click += new System.EventHandler(this.trianglesFan_Click);
            // 
            // trianglesStrip
            // 
            this.trianglesStrip.Name = "trianglesStrip";
            this.trianglesStrip.Size = new System.Drawing.Size(180, 22);
            this.trianglesStrip.Text = "Strip";
            this.trianglesStrip.Click += new System.EventHandler(this.triangleStrip_Click);
            // 
            // quads
            // 
            this.quads.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quadsToolStripMenuItem,
            this.quadStripToolStripMenuItem});
            this.quads.Name = "quads";
            this.quads.Size = new System.Drawing.Size(180, 22);
            this.quads.Text = "Quads";
            // 
            // quadsToolStripMenuItem
            // 
            this.quadsToolStripMenuItem.Name = "quadsToolStripMenuItem";
            this.quadsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quadsToolStripMenuItem.Text = "Quads";
            this.quadsToolStripMenuItem.Click += new System.EventHandler(this.quadsToolStripMenuItem_Click);
            // 
            // quadStripToolStripMenuItem
            // 
            this.quadStripToolStripMenuItem.Name = "quadStripToolStripMenuItem";
            this.quadStripToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quadStripToolStripMenuItem.Text = "QuadStrip";
            this.quadStripToolStripMenuItem.Click += new System.EventHandler(this.quadStripToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // polygon
            // 
            this.polygon.Name = "polygon";
            this.polygon.Size = new System.Drawing.Size(180, 22);
            this.polygon.Text = "Polygon";
            this.polygon.Click += new System.EventHandler(this.polygon_Click);
            // 
            // task
            // 
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(180, 22);
            this.task.Text = "Task";
            this.task.Click += new System.EventHandler(this.task_Click);
            // 
            // OpenGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 713);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.mHolst);
            this.Name = "OpenGLForm";
            this.Text = "OpenGLForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl mHolst;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quads;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem linesP;
        private System.Windows.Forms.ToolStripMenuItem lines;
        private System.Windows.Forms.ToolStripMenuItem linesStrip;
        private System.Windows.Forms.ToolStripMenuItem linesLoop;
        private System.Windows.Forms.ToolStripMenuItem trianglesP;
        private System.Windows.Forms.ToolStripMenuItem triangles;
        private System.Windows.Forms.ToolStripMenuItem trianglesStrip;
        private System.Windows.Forms.ToolStripMenuItem trianglesFan;
        private System.Windows.Forms.ToolStripMenuItem quadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygon;
        private System.Windows.Forms.ToolStripMenuItem task;
    }
}

