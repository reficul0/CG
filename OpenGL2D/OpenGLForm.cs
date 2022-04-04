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

        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glPointSize(10);
            Gl.glColor3f(0, 1, 1);

            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2f(ToCoordPoints(1), 0);

                Gl.glVertex2f(ToCoordPoints(-1), ToCoordPoints(3));
                Gl.glVertex2f(ToCoordPoints(-1), ToCoordPoints(-3));


                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(1));
                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(-1));


                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(3));
                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(-3));

            }
            Gl.glEnd();

            mHolst.Invalidate();
        }
        
        private void Clear()
        {
            Gl.glViewport(0, 0, mHolst.Width, mHolst.Height);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
        }
        

        private float ToCoordPoints(float points)
        {
            return 0.1f * points;
        }

        private void lines_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);

            Gl.glColor3f(0, 1, 1);

            Gl.glBegin(Gl.GL_LINES);
            {
                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(3));
                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(-3));


                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(-3));
                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(3));

                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(3));
                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(3));


                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(3));
                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(-3));


                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(-3));
                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(-3));

            }
            Gl.glEnd();

            mHolst.Invalidate();
        }

        private void lineStrip_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);

            Gl.glColor3f(0, 1, 1);

            // Ромб
            Gl.glBegin(Gl.GL_LINE_STRIP);
            {
                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(0));
                Gl.glVertex2f(ToCoordPoints(0), ToCoordPoints(4));

                
                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(0));
                
                Gl.glVertex2f(ToCoordPoints(0), ToCoordPoints(-4));

                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(0));
            }
            Gl.glEnd();

            // куб
            Gl.glBegin(Gl.GL_LINE_STRIP);
            {
                Gl.glVertex2f(ToCoordPoints(-4), ToCoordPoints(5));
                Gl.glVertex2f(ToCoordPoints(4), ToCoordPoints(5));
                
                Gl.glVertex2f(ToCoordPoints(4), ToCoordPoints(-5));
                
                Gl.glVertex2f(ToCoordPoints(-4), ToCoordPoints(-5));

                Gl.glVertex2f(ToCoordPoints(-4), ToCoordPoints(5));
            }
            Gl.glEnd();

            mHolst.Invalidate();
        }

        private void lineLoop_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);

            Gl.glColor3f(0, 1, 1);

            // Ромб
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glVertex2f(ToCoordPoints(0), ToCoordPoints(0));
                Gl.glVertex2f(ToCoordPoints(2), ToCoordPoints(2));
                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(3));
                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(-3));
                Gl.glVertex2f(ToCoordPoints(2), ToCoordPoints(-2));
            }
            Gl.glEnd();

            // куб
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(4));
                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(4));

                Gl.glVertex2f(ToCoordPoints(3), ToCoordPoints(-4));

                Gl.glVertex2f(ToCoordPoints(-3), ToCoordPoints(-4));
            }
            Gl.glEnd();

            mHolst.Invalidate();
        }

        private void triangles_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                Gl.glColor3f(0, 0, 1);
                Gl.glVertex2f(0.5f, 0.5f);

                Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex2f(-0.5f, 0.5f);

                Gl.glColor3f(0, 1, 1);
                Gl.glVertex2f(0, -0.5f);

            }
            Gl.glEnd();
            mHolst.Invalidate();
        }

        private void triangleStrip_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
            {
                Gl.glColor3f(0, 0, 1);
                Gl.glVertex2f(-0.5f, 00);

                Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex2f(0, -0.7f);

                Gl.glColor3f(0, 1, 1);
                Gl.glVertex2f(0, 0.7f);
                
                Gl.glColor3f(1, 1, 1);
                Gl.glVertex2f(0.5f, 0);
            }
            Gl.glEnd();
            mHolst.Invalidate();

        }

        private void trianglesFan_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            {
                Gl.glColor3f(0, 0, 1);
                Gl.glVertex2f(0, 0);

                Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex2f(0.5f, 0.5f);

                Gl.glColor3f(0, 1, 1);
                Gl.glVertex2f(-0.5f, 0.5f);
                
                Gl.glColor3f(1, 1, 1);
                Gl.glVertex2f(0.5f, -0.5f);

                Gl.glColor3f(1, 0, 1);
                Gl.glVertex2f(-0.5f, -0.5f);
            }
            Gl.glEnd();
            mHolst.Invalidate();
        }

        private void quadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_QUADS);
            {
                Gl.glColor3f(0, 0, 1);
                Gl.glVertex2f(-0.5f, 0.5f);

                Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex2f(-0.5f, -0.5f);

                Gl.glColor3f(0, 1, 1);
                Gl.glVertex2f(0.5f, -0.5f);

                Gl.glColor3f(1, 1, 1);
                Gl.glVertex2f(0.5f, 0.5f);
            }
            Gl.glEnd();
            mHolst.Invalidate();
        }

        private void quadStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            {
                Gl.glColor3f(1, 0, 0);
                Gl.glVertex2f(-0.5f, 0.5f);

                Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex2f(-0.5f, -0.5f);

                Gl.glColor3f(1, 1, 1);
                Gl.glVertex2f(0.5f, 0.5f);

                Gl.glColor3f(1, 1, 0);
                Gl.glVertex2f(0.5f, -0.3f);
            }
            Gl.glEnd();
            mHolst.Invalidate();
        }

        private void polygon_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_POLYGON);
            {
                Gl.glColor3f(1, 0, 0);
                Gl.glVertex2f(-0.3f, 0.5f);

                Gl.glColor3f(0, 0.5f, 0);
                Gl.glVertex2f(0.3f, 0.5f);

                Gl.glColor3f(0, 0.5f, 1);
                Gl.glVertex2f(0.6f, 0);

                Gl.glColor3f(1, 0, 0.5f);
                Gl.glVertex2f(0.3f, -0.5f);
                
                Gl.glColor3f(0, 0, 0.5f);
                Gl.glVertex2f(-0.3f, -0.5f);
                
                Gl.glColor3f(0, 0.5f, 0);
                
                Gl.glVertex2f(-0.6f, 0);
            }
            Gl.glEnd();
            mHolst.Invalidate();
        }

        private void task_Click(object sender, EventArgs e)
        {
            Clear();
            Gl.glLineWidth(5);

            Gl.glColor3f(0, 1, 1);
            
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glVertex2f(ToCoordPoints(2), ToCoordPoints(-4));
                Gl.glVertex2f(ToCoordPoints(2), ToCoordPoints(4));
                Gl.glVertex2f(ToCoordPoints(0), ToCoordPoints(2));
                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(4));
                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(-2));
            }
            Gl.glEnd();
            
            Gl.glBegin(Gl.GL_LINES);
            {
                Gl.glVertex2f(ToCoordPoints(-2), ToCoordPoints(2));
                Gl.glVertex2f(ToCoordPoints(2), ToCoordPoints(2));
            }
            Gl.glEnd();

            mHolst.Invalidate();
        }
    }
}
