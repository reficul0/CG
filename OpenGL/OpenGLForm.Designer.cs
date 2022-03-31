
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
            this.mHolst = new Tao.Platform.Windows.SimpleOpenGlControl();
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
            this.mHolst.Location = new System.Drawing.Point(0, -1);
            this.mHolst.Name = "mHolst";
            this.mHolst.Size = new System.Drawing.Size(1055, 718);
            this.mHolst.StencilBits = ((byte)(0));
            this.mHolst.TabIndex = 0;
            this.mHolst.Paint += new System.Windows.Forms.PaintEventHandler(this.mHolst_Paint);
            // 
            // OpenGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 713);
            this.Controls.Add(this.mHolst);
            this.Name = "OpenGLForm";
            this.Text = "OpenGLForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl mHolst;
    }
}

