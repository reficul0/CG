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
        private float mCoordinateMultiplier = 0.1f;
        private float mAngleX = 1;
        private float mAngleY = 0;
        private float mAngleZ = 0;
        
        private bool isAutoRotate = false;

        private Action<bool> mFigureDrawingFuc;

        public OpenGLForm()
        {
            InitializeComponent();
            mHolst.InitializeContexts();
            mFigureDrawingFuc = DrawTrap;
        }

        private void Clear()
        {
            Gl.glViewport(0, 0, mHolst.Width, mHolst.Height);
            Gl.glClearColor(0, 0.5f, 0.3f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
        }
        
        private float ToCoordPoints(float points)
        {
            return mCoordinateMultiplier * points;
        }

        private void mHolst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                mAngleX = (mAngleX - 5) % 360;
            }
            else if (e.KeyChar == 's')
            {
                mAngleX = (mAngleX + 5) % 360;
            }

            if(e.KeyChar == 'a')
            {
                mAngleY = (mAngleY - 5) % 360;
            }
            else if (e.KeyChar == 'd')
            {
                mAngleY = (mAngleY + 5) % 360;
            }

            if (e.KeyChar == 'r')
            {
                mAngleZ = (mAngleZ - 5) % 360;
            }
            else if (e.KeyChar == 'f')
            {
                mAngleZ = (mAngleZ + 5) % 360;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Clear();

            if (isAutoRotate)
            {
                mAngleX = (mAngleX - 3) % 360;
                mAngleY = (mAngleY + 3) % 360;
                mAngleZ = (mAngleZ - 3) % 360;
            }
            DrawFigure();
        }

        private void DrawFigure()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Gl.glFrustum(-1, 1, -1, 1, 1, 10);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0, 0, -4);

            Gl.glRotatef(mAngleX, 1, 0, 0);
            Gl.glRotatef(mAngleY, 0, 1, 0);
            Gl.glRotatef(mAngleZ, 0, 0, 1);

            Gl.glLineWidth(5);

            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
            mFigureDrawingFuc(false);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            mFigureDrawingFuc(true);

            mHolst.Invalidate();
        }
        private void DrawTrap(bool customColor)
        {
            if (!customColor)
                Gl.glColor3f(0, 1.5f, 1.5f);

            Gl.glBegin(Gl.GL_QUADS);
            {
                // front
                {
                    if (customColor)
                        Gl.glColor3f(0.5f, 0, 0);
                    Gl.glVertex3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-1, -1, 1);
                    Gl.glVertex3f(1, -1, 1);
                }
                // back
                {
                    if (customColor)
                        Gl.glColor3f(0, 0.5f, 0);
                    Gl.glVertex3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0f, 0.5f, -0.5f);
                    Gl.glVertex3f(0, -1, -1);
                    Gl.glVertex3f(1, -1, 1);
                }
                // right
                {
                    if (customColor)
                        Gl.glColor3f(0.5f, 0.5f, 0);
                    Gl.glVertex3f(-0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-1, -1, 1);
                    Gl.glVertex3f(0, -1, -1);
                    Gl.glVertex3f(-0f, 0.5f, -0.5f);
                }
            }
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
            {
                // top
                {
                    if (customColor)
                        Gl.glColor3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0f, 0.5f, -0.5f);
                }
                Gl.glEnd();
                Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                // bottom
                {
                    if (customColor)
                        Gl.glColor3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-1, -1, 1);
                    Gl.glVertex3f(1, -1, 1);
                    Gl.glVertex3f(0, -1, -1);
                }
            }
            Gl.glEnd();
        }
        private void DrawQuads(bool customColor)
        {
            if (!customColor)
                Gl.glColor3f(0, 1.5f, 1.5f);

            Gl.glBegin(Gl.GL_QUADS);
            // front
            {
                if (customColor)
                    Gl.glColor3f(0.5f, 0, 0);
                Gl.glVertex3f(1, 1, 1);
                Gl.glVertex3f(-1, 1, 1);
                Gl.glVertex3f(-1, -1, 1);
                Gl.glVertex3f(1, -1, 1);
            }
            // back
            {
                if (customColor)
                    Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex3f(1, 1, -1);
                Gl.glVertex3f(-1, 1, -1);
                Gl.glVertex3f(-1, -1, -1);
                Gl.glVertex3f(1, -1, -1);
            }
            // right
            {
                if (customColor)
                    Gl.glColor3f(0.5f, 0.5f, 0);
                Gl.glVertex3f(1, 1, 1);
                Gl.glVertex3f(1, 1, -1);
                Gl.glVertex3f(1, -1, -1);
                Gl.glVertex3f(1, -1, 1);
            }
            // left
            {
                if (customColor)
                    Gl.glColor3f(0, 0.5f, 0.5f);
                Gl.glVertex3f(-1, 1, 1);
                Gl.glVertex3f(-1, 1, -1);
                Gl.glVertex3f(-1, -1, -1);
                Gl.glVertex3f(-1, -1, 1);
            }
            // top
            {
                if (customColor)
                    Gl.glColor3f(0.5f, 0.5f, 0.5f);
                Gl.glVertex3f(1, 1, 1);
                Gl.glVertex3f(1, 1, -1);
                Gl.glVertex3f(-1, 1, -1);
                Gl.glVertex3f(-1, 1, 1);
            }
            // bottom
            {
                if (customColor)
                    Gl.glColor3f(0.5f, 0.5f, 0.5f);
                Gl.glVertex3f(1, -1, 1);
                Gl.glVertex3f(1, -1, -1);
                Gl.glVertex3f(-1, -1, -1);
                Gl.glVertex3f(-1, -1, 1);
            }
            Gl.glEnd();
        }

        private void mHolst_MouseEnter(object sender, EventArgs e)
        {
            isAutoRotate = false;
        }

        private void mHolst_MouseLeave(object sender, EventArgs e)
        {
            isAutoRotate = true;
        }

        private void quadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mFigureDrawingFuc = DrawQuads;
        }

        private void trapeciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mFigureDrawingFuc = DrawTrap;
        }
    }
}
