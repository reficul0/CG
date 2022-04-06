using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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

        //Параметры освещения
        private static float[] matSpecular = new float[] { 1f, 1f, 1f, 1f };
        private static float[] matAmbDiff = new float[] { 1f, 1f, 1f, 1f };
        private static float[] matShininess = new float[] { 9.0f };
        //Позиция источника освещения
        //static float[] lightPos = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        private static float[] lightPos = new float[] { 0f, 0f, 3.0f, 0f };

        private static float[] frontColor = new float[] { 1, 1, 1, 0.4f };
        private static float[] backColor = new float[] { 0, 0, 0, 1f };
        
        private bool isFogEnabled = false;

        public OpenGLForm()
        {
            InitializeComponent();
            mHolst.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA | Glut.GLUT_STENCIL);
            mFigureDrawingFuc = DrawFigures;

            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            
            //Gl.glTranslatef(3.5f, 0.2f, 0f);

            //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE, matAmbDiff);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, matSpecular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, matShininess);

            //Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, frontColor);
            Gl.glMaterialfv(Gl.GL_BACK, Gl.GL_DIFFUSE, backColor);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPos);
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, matSpecular);

            Gl.glLightModelf(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            //Gl.glLightModelf(Gl.GL_LIGHT_MODEL_AMBIENT, Gl.GL_TRUE);

            //Gl.glTranslatef(-3.5f, -0.2f, 0f);
        }

        private void Clear()
        {
            Gl.glViewport(0, 0, mHolst.Width, mHolst.Height);
            Gl.glClearColor(0.5f, 0.5f, 0.5f, 0.7f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glClearStencil(0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            float[] flogColor = { 0.5f, 0.5f, 0.5f, 0.7f };
            
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP2);
            Gl.glFogfv(Gl.GL_FOG_COLOR, flogColor);
            Gl.glFogf(Gl.GL_FOG_DENSITY, 0.34f);
            Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_DONT_CARE);
            Gl.glFogf(Gl.GL_FOG_START, 1f);
            Gl.glFogf(Gl.GL_FOG_END, 1.2f);
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


            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            mFigureDrawingFuc(true);
            Gl.glDepthFunc(Gl.GL_LESS);


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

        private void DrawFigures(bool isNotLines)
        {
            if (!isNotLines)
                Gl.glColor3f(0, 1.5f, 1.5f);


            Vector3[] piramidPoints = new Vector3[]
            {
                new Vector3(0.3f, 1.6f, 0.2f),
                new Vector3(-0f, -1f, 1.5f),
                new Vector3(1, -1, 1),
                new Vector3(1.3f, -1f, -0.2f),
                new Vector3(0.5f, -1f, -1f),
                new Vector3(-0.7f, -1f, -0.5f),
                new Vector3(-1.2f, -1f, 0.5f),
                new Vector3(-0f, -1f, 1.5f)
            };
            // Piramid
            {
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                {
                    {
                        if (isNotLines)
                            Gl.glColor3f(0.2f, 0.4f, 3f);
                        SetNormal(
                            piramidPoints[0],
                            piramidPoints[1],
                            piramidPoints[2]);
                        Gl.glVertex3f(piramidPoints[0].X, piramidPoints[0].Y, piramidPoints[0].Z);

                        if (isNotLines)
                            Gl.glColor3f(0.2f, 0.5f, 0.5f);
                        SetNormal(
                            piramidPoints[0],
                            piramidPoints[1],
                            piramidPoints[2]);
                        Gl.glVertex3f(piramidPoints[1].X, piramidPoints[1].Y, piramidPoints[1].Z);

                        for (int i = 1; i < piramidPoints.Length-1; i++)
                        {
                            if (isNotLines)
                                Gl.glColor3f(i % 2, i%3, i%3);
                            SetNormal(
                                piramidPoints[0],
                                piramidPoints[i],
                                piramidPoints[i+1]);
                            Gl.glVertex3f(piramidPoints[i + 1].X, piramidPoints[i + 1].Y, piramidPoints[i + 1].Z);
                        }
                    }
                }
                Gl.glEnd();

                // Piramid bottom
                Gl.glBegin(Gl.GL_POLYGON);
                {
                    if (isNotLines)
                        Gl.glColor3f(0.2f, 0.5f, 0.5f);
                    SetNormal(
                        piramidPoints[1],
                        piramidPoints[2],
                        piramidPoints[3]);
                    Gl.glVertex3f(piramidPoints[1].X, piramidPoints[1].Y, piramidPoints[1].Z);

                    if (isNotLines)
                        Gl.glColor3f(1f, 1f, 1f);
                    SetNormal(
                        piramidPoints[1],
                        piramidPoints[2],
                        piramidPoints[3]);
                    Gl.glVertex3f(piramidPoints[2].X, piramidPoints[2].Y, piramidPoints[2].Z);

                    for (int i = 3; i < piramidPoints.Length; i++)
                    {
                        if (isNotLines)
                            Gl.glColor3f((i-1) % 2, (i - 1) % 3, (i - 1) % 3);
                        SetNormal(
                            piramidPoints[i-2],
                            piramidPoints[i-1],
                            piramidPoints[i]);
                        Gl.glVertex3f(piramidPoints[i].X, piramidPoints[i].Y, piramidPoints[i].Z);
                    }
                }
                Gl.glEnd();
            }

            {
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
        }
        private void SetNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Plane plane = Plane.CreateFromVertices(a, b, c);
            Vector3 normal = plane.Normal;

            Gl.glNormal3f(normal.X, normal.Y, normal.Z);
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

        private void isFogEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isFogEnabledCheckBox.Checked)
            {
                Gl.glEnable(Gl.GL_FOG);
            }
            else
            {
                Gl.glDisable(Gl.GL_FOG);
            }
        }

        private void isLightEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLightEnabledCheckBox.Checked)
            {
                // Включить Light0
                Gl.glEnable(Gl.GL_LIGHT0);
                // Включить освещение
                Gl.glEnable(Gl.GL_LIGHTING);
                Gl.glEnable(Gl.GL_NORMALIZE);
                Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            }
            else
            {
                Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glDisable(Gl.GL_LIGHT0);
                Gl.glDisable(Gl.GL_NORMALIZE);
                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
            }
        }

        private void isFlatShadeEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isFlatShadeEnabledCheckBox.Checked)
            {
                Gl.glShadeModel(Gl.GL_FLAT);
            }
            else
            {
                Gl.glShadeModel(Gl.GL_SMOOTH);
            }
        }
    }
}
