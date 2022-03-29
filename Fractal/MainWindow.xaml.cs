using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Drawing;
using System.Threading;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Color = System.Drawing.Color;

namespace Fractal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap m_bitmap;

        private double m_zoom = 0.5;
        private double m_x0 = -1;
        private double m_y0 = -0.9;
        
        private double m_shiftX = 0;
        private double m_shiftY = 0;
        
        private double m_workerStep = 0.08;

        private UInt32 m_iterations = 100;

        private Thread m_worker;

        public MainWindow()
        {
            InitializeComponent();
            m_bitmap = new Bitmap((int)m_picture.Width, (int)m_picture.Height);
        }

        private void DataWindow_Closing(object sender, CancelEventArgs cancelEventArgs)
        {
            StopWorker();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        private void Render()
        {
            Bitmap bitmap;
            for (int x = 0; x < m_bitmap.Width; x++)
            {
                for (int y = 0; y < m_bitmap.Height; y++)
                {
                    double zx = 1.5 * (x - m_bitmap.Width / 2) / (0.5 * m_zoom * m_bitmap.Width) + m_shiftX;
                    double zy = 1.0 * (y - m_bitmap.Height / 2) / (0.5 * m_zoom * m_bitmap.Height) + m_shiftY;
                    int i = (int)m_iterations;
                    while (zx * zx + zy * zy < 4 && i > 1)
                    {
                        double tmp = zx * zx - zy * zy + m_x0;
                        zy = 2.0 * zx * zy + m_y0;
                        zx = tmp;
                        i -= 1;
                    }

                    m_bitmap.SetPixel(x, y, Color.FromArgb(10, (i * 9) % 127, (i * 9) % 255));
                }
            }

            bitmap = (Bitmap)m_bitmap.Clone();

            var handle = bitmap.GetHbitmap();
            ImageSource s;
            try
            {
                s = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }

            s.Freeze();
            var val = this.Dispatcher.Invoke(DispatcherPriority.Render, new Action(delegate ()
              {
                    m_picture.Source = s;
              }));
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            var multiplier = e.Delta > 0 ? 0.7 : 1.3;
            m_zoom *= multiplier;
            Render();

            base.OnMouseWheel(e);
        }

        private void m_resetButton_Click(object sender, RoutedEventArgs e)
        {
            m_zoom = 0.5;
            m_iterations = 255;

            m_re.Value = -1;
            m_im.Value = -0.9;
            m_shiftXSlider.Value = 0;
            m_shiftYSlider.Value = 0;

            Render();
        }
        private void m_drawButton_Click(object sender, RoutedEventArgs e)
        {
            Render();
        }

        private void m_re_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m_x0 = e.NewValue;
            Render();
        }
        private void m_im_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m_y0 = e.NewValue;
            Render();
        }

        private void m_shiftX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m_shiftX = e.NewValue;
            Render();
        }
        private void m_shiftY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m_shiftY = e.NewValue;
            Render();
        }

        private void m_iterationsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                m_iterations = UInt32.Parse(m_iterationsTextBox.Text);
            }
            catch (Exception)
            {
                m_iterationsTextBox.Undo();
            }
        }

        private void m_workerStepTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                m_workerStep = Double.Parse(m_workerStepTextBox.Text);
            }
            catch (Exception)
            {
                m_workerStepTextBox.Undo();
            }
        }

        private void m_startButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_worker == null)
            {
                m_worker = new Thread(() =>
                        {
                            try
                            {
                                double step = m_workerStep;
                                for (double i = -3; i < 3; i += m_workerStep)
                                {
                                    m_x0 += m_workerStep;
                                    m_y0 += m_workerStep;
                                    Render();

                                    Thread.Sleep(5);
                                    
                                    step = m_workerStep;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        });

                m_worker.Start(); 
            }
        }
        private void m_stopButton_Click(object sender, RoutedEventArgs e)
        {
            StopWorker();
        }

        private void StopWorker()
        {
            if (m_worker is { IsAlive: true })
            {
                m_worker.Interrupt();
                m_worker.Join();
                m_worker = null;
            }
        }
    }
}
