using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace OpenGL
{
    public partial class OpenGLForm : Form
    {
        
        public OpenGLForm()
        {
            InitializeComponent();
            mHolst.InitializeContexts();
        }

        private void mHolst_Paint(object sender, PaintEventArgs e)
        {
            Gl.glViewport(0,0, mHolst.Width, mHolst.Height);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glEnable(Gl.GL_POLYGON_SMOOTH);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);

            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                Gl.glColor3f(0, 0, 0);
                Gl.glVertex2f(-0.5f, 0.5f);

                Gl.glColor3f(0, 0, 1);
                Gl.glVertex2f(0.5f, 0.5f);

                Gl.glColor3f(0, 1, 1);
                Gl.glVertex2f(0, -0.5f);
                
                Gl.glColor3f(1, 1, 1);
                Gl.glVertex2f(-0.5f, 0.5f);
            }
            Gl.glEnd();

            mHolst.Invalidate();
        }
    }
}
