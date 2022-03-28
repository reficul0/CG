using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MatrixTransformForm : Form
    {
        private Pen mFigurePen = new Pen(Color.LightSeaGreen, 3f);
        private Pen mAxisPen = new Pen(Color.DimGray, 2.5f);
        private Brush mAxisBrush = Brushes.DimGray;
        
        private PointF[] mFigureMatrix;

        public MatrixTransformForm()
        {
            InitializeComponent();

            this.ResizeRedraw = true;
            Reset();
        }

        private void mDrawButton_Click(object sender, EventArgs e) => Redraw();
        private void mPicture_Resize(object sender, EventArgs e) => Redraw();
        
        private void Redraw()
        {
            Refresh();

            using (Graphics imageGraphics = m_picture.CreateGraphics())
            {
                Matrix center = new Matrix();
                center.Translate(m_picture.Width / 2, m_picture.Height / 2);

                imageGraphics.Transform = center;

                imageGraphics.DrawLine(mAxisPen, -m_picture.Width / 2, 0, m_picture.Width / 2, 0);
                imageGraphics.DrawLine(mAxisPen, 0, -m_picture.Height / 2, 0, m_picture.Height / 2);
                
                imageGraphics.DrawString("X", Font, mAxisBrush, m_picture.Width / 2 - 30, -30);
                imageGraphics.DrawString("Y", Font, mAxisBrush, 10, -m_picture.Height / 2 + 10);

                imageGraphics.DrawPolygon(mFigurePen, mFigureMatrix);
            }
        }

        private void mRotateButton_Click(object sender, EventArgs e)
        {
            int rotationAngle = (int)mRotationAngleUpDown.Value;
            
            TransformFigure(matrix => matrix.RotateAt(rotationAngle, new PointF(0, 0)));
            
            Redraw();
        }

        private void mScaleButton_Click(object sender, EventArgs e)
        {
            float scalarX = (float)mXScalarUpDown.Value;
            float scalarY = (float)mYScalarUpDown.Value;

            TransformFigure(matrix => matrix.Scale(scalarX, scalarY));
            
            Redraw();
        }

        private void mResetButton_Click(object sender, EventArgs e) => Reset();

        private void mTranslationButton_Click(object sender, EventArgs e)
        {
            float translateX = (float)mXTranslationUpDown.Value;
            float translateY = (float)mYTranslationUpDown.Value;

            for(int i = 0; i < mFigureMatrix.Length; ++i)
            {
                mFigureMatrix[i].X += translateX;
                mFigureMatrix[i].Y -= translateY;
            }

            Redraw();
        }

        private void mMirrorXButton_Click(object sender, EventArgs e)
        {
            Mirror(false, true);
            Redraw();
        }

        private void mMirrorYButton_Click(object sender, EventArgs e)
        {
            Mirror(true, false);
            Redraw();
        }

        private void Reset()
        {
            mFigureMatrix = new PointF[]
            {
                new PointF(0, 50),
                new PointF(50, 100),
                new PointF(50, -100),
                new PointF(-50, -40),
                new PointF(-50, 100),
            };

            Mirror(false, true);
            Redraw();
        }
        
        private void Mirror(bool mirrorX, bool mirrorY)
        {
            TransformFigure(matrix =>
                matrix.Scale(
                    mirrorX ? -1 : 1,
                    mirrorY ? -1 : 1));
        }

        private void TransformFigure(Action<Matrix> transformer)
        {
            Matrix matrix = new Matrix();
            matrix.Translate(m_picture.Width / 2, m_picture.Height / 2);

            transformer(matrix);

            matrix.TransformVectors(mFigureMatrix);
        }
    }
}
