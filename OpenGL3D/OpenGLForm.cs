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
            Glut.glutInit();
            mFigureDrawingFuc = DrawFigures;
        }

        private void Clear()
        {
            Gl.glViewport(0, 0, mHolst.Width, mHolst.Height);
            Gl.glClearColor(0.5f, 0.5f, 0.5f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            float[] flogColor = { 0.5f, 0.5f, 0.5f, 1f };

            Gl.glTranslatef(3.5f, 0.2f, 0f);
            Gl.glEnable(Gl.GL_FOG);
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP2);
            Gl.glFogfv(Gl.GL_FOG_COLOR, flogColor);
            Gl.glFogf(Gl.GL_FOG_DENSITY, 0.4f);
            Gl.glFogf(Gl.GL_FOG_START, -1000f);
            Gl.glFogf(Gl.GL_FOG_END, -500f);

            Gl.glTranslatef(0f, 0f, 0f);

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
                mAngleX = (mAngleX + 1) % 360;
                mAngleY = (mAngleY + 1) % 360;
                mAngleZ = (mAngleZ + 1) % 360;
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

        private void DrawTrap(bool isLines)
        {
            if (!isLines)
                Gl.glColor3f(0, 1.5f, 1.5f);

            Gl.glBegin(Gl.GL_QUADS);
            {
                // front
                {
                    if (isLines)
                        Gl.glColor3f(0.5f, 0, 0);
                    Gl.glVertex3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-1, -1, 1);
                    Gl.glVertex3f(1, -1, 1);
                }
                // back
                {
                    if (isLines)
                        Gl.glColor3f(0, 0.5f, 0);
                    Gl.glVertex3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0f, 0.5f, -0.5f);
                    Gl.glVertex3f(0, -1, -1);
                    Gl.glVertex3f(1, -1, 1);
                }
                // right
                {
                    if (isLines)
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
                    if (isLines)
                        Gl.glColor3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-0f, 0.5f, -0.5f);
                }
                Gl.glEnd();
                Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                // bottom
                {
                    if (isLines)
                        Gl.glColor3f(0.5f, 0.5f, 0.5f);
                    Gl.glVertex3f(-1, -1, 1);
                    Gl.glVertex3f(1, -1, 1);
                    Gl.glVertex3f(0, -1, -1);
                }
            }
            Gl.glEnd();
        }

        private void DrawQuads(bool isLines)
        {
            if (!isLines)
                Gl.glColor3f(0, 1.5f, 1.5f);

            Gl.glBegin(Gl.GL_QUADS);
            // front
            {
                if (isLines)
                    Gl.glColor3f(0.5f, 0, 0);
                Gl.glVertex3f(1, 1, 1);
                Gl.glVertex3f(-1, 1, 1);
                Gl.glVertex3f(-1, -1, 1);
                Gl.glVertex3f(1, -1, 1);
            }
            // back
            {
                if (isLines)
                    Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex3f(1, 1, -1);
                Gl.glVertex3f(-1, 1, -1);
                Gl.glVertex3f(-1, -1, -1);
                Gl.glVertex3f(1, -1, -1);
            }
            // right
            {
                if (isLines)
                    Gl.glColor3f(0.5f, 0.5f, 0);
                Gl.glVertex3f(1, 1, 1);
                Gl.glVertex3f(1, 1, -1);
                Gl.glVertex3f(1, -1, -1);
                Gl.glVertex3f(1, -1, 1);
            }
            // left
            {
                if (isLines)
                    Gl.glColor3f(0, 0.5f, 0.5f);
                Gl.glVertex3f(-1, 1, 1);
                Gl.glVertex3f(-1, 1, -1);
                Gl.glVertex3f(-1, -1, -1);
                Gl.glVertex3f(-1, -1, 1);
            }
            // top
            {
                if (isLines)
                    Gl.glColor3f(0.5f, 0.5f, 0.5f);
                Gl.glVertex3f(1, 1, 1);
                Gl.glVertex3f(1, 1, -1);
                Gl.glVertex3f(-1, 1, -1);
                Gl.glVertex3f(-1, 1, 1);
            }
            // bottom
            {
                if (isLines)
                    Gl.glColor3f(0.5f, 0.5f, 0.5f);
                Gl.glVertex3f(1, -1, 1);
                Gl.glVertex3f(1, -1, -1);
                Gl.glVertex3f(-1, -1, -1);
                Gl.glVertex3f(-1, -1, 1);
            }
            Gl.glEnd();
        }

        private void DrawFigures(bool isLines)
        {
            if (!isLines)
                Gl.glColor3f(0, 1.5f, 1.5f);

            // Piramida
            {
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                {
                    {
                        if (isLines)
                            Gl.glColor3f(0.2f, 0.5f, 0.5f);
                        Gl.glVertex3f(0.3f, 1.6f, 0.2f);

                        Gl.glVertex3f(-0f, -1f, 1.5f);
                        Gl.glVertex3f(1, -1, 1);

                        if (isLines)
                            Gl.glColor3f(0, 0.3f, 0.5f);
                        Gl.glVertex3f(1.3f, -1f, -0.2f);

                        if (isLines)
                            Gl.glColor3f(0f, 0.2f, 0.1f);
                        Gl.glVertex3f(0.5f, -1f, -1f);

                        if (isLines)
                            Gl.glColor3f(0.4f, 0.5f, 0);
                        Gl.glVertex3f(-0.7f, -1f, -0.5f);


                        if (isLines)
                            Gl.glColor3f(0, 0.9f, 0.2f);
                        Gl.glVertex3f(-1.2f, -1f, 0.5f);

                        if (isLines)
                            Gl.glColor3f(0, 0.6f, 0.5f);
                        Gl.glVertex3f(-0f, -1f, 1.5f);
                    }
                }
                Gl.glEnd();


                Gl.glBegin(Gl.GL_POLYGON);
                {
                    if (isLines)
                        Gl.glColor3f(0.2f, 0.5f, 0.5f);

                    Gl.glVertex3f(-0f, -1f, 1.5f);
                    Gl.glVertex3f(1, -1, 1);

                    if (isLines)
                        Gl.glColor3f(0, 0.3f, 0.5f);
                    Gl.glVertex3f(1.3f, -1f, -0.2f);

                    if (isLines)
                        Gl.glColor3f(0f, 0.2f, 0.1f);
                    Gl.glVertex3f(0.5f, -1f, -1f);

                    if (isLines)
                        Gl.glColor3f(0.4f, 0.5f, 0);
                    Gl.glVertex3f(-0.7f, -1f, -0.5f);


                    if (isLines)
                        Gl.glColor3f(0, 0.9f, 0.2f);
                    Gl.glVertex3f(-1.2f, -1f, 0.5f);

                    if (isLines)
                        Gl.glColor3f(0, 0.6f, 0.5f);
                    Gl.glVertex3f(-0f, -1f, 1.5f);
                }
                Gl.glEnd(); 
            }
            
            Gl.glPushMatrix();

            if (isAutoRotate)
            {
                Gl.glRotatef(-mAngleY, 1, 0, 0);
                Gl.glRotatef(-mAngleY, 0, 1, 0);
                Gl.glRotatef(-mAngleZ, 0, 0, 1);
            }

            Gl.glColor3d(0, 0.8f, 0.5f);
            Glut.glutWireCube(3);

            Gl.glPopMatrix();

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

        private void figuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mFigureDrawingFuc = DrawFigures;
        }
    }
}
