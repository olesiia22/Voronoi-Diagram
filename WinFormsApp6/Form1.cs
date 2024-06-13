using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        private Bitmap bitmap;
        private bool multiThreaded = false;
        private bool splitRegions = false;
        private Random random = new Random();

        private long memoryUsed;
        private TimeSpan elapsedTime;
        private TimeSpan cpuTime;

        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseClick += PictureBox1_MouseClick;
            this.pictureBox1.Paint += PictureBox1_Paint;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                points.RemoveAll(p => Math.Abs(p.X - e.X) < 5 && Math.Abs(p.Y - e.Y) < 5);
            }
            DrawVoronoi();
        }

        private void DrawVoronoi()
        {
            if (points.Count == 0) return;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (multiThreaded)
            {
                if (splitRegions)
                {
                    int regionSize = 100;
                    int regionsX = (pictureBox1.Width + regionSize - 1) / regionSize;
                    int regionsY = (pictureBox1.Height + regionSize - 1) / regionSize;

                    Parallel.For(0, regionsX, rx =>
                    {
                        Parallel.For(0, regionsY, ry =>
                        {
                            int startX = rx * regionSize;
                            int startY = ry * regionSize;
                            int endX = Math.Min(startX + regionSize, pictureBox1.Width);
                            int endY = Math.Min(startY + regionSize, pictureBox1.Height);

                            for (int x = startX; x < endX; x++)
                            {
                                for (int y = startY; y < endY; y++)
                                {
                                    var closestPoint = GetClosestPoint(new Point(x, y));
                                    lock (bitmap)
                                    {
                                        bitmap.SetPixel(x, y, ColorFromPoint(closestPoint));
                                    }
                                }
                            }
                        });
                    });
                }
                else
                {
                    Parallel.For(0, pictureBox1.Width, x =>
                    {
                        for (int y = 0; y < pictureBox1.Height; y++)
                        {
                            var closestPoint = GetClosestPoint(new Point(x, y));
                            lock (bitmap)
                            {
                                bitmap.SetPixel(x, y, ColorFromPoint(closestPoint));
                            }
                        }
                    });
                }
            }
            else
            {
                for (int x = 0; x < pictureBox1.Width; x++)
                {
                    for (int y = 0; y < pictureBox1.Height; y++)
                    {
                        var closestPoint = GetClosestPoint(new Point(x, y));
                        bitmap.SetPixel(x, y, ColorFromPoint(closestPoint));
                    }
                }
            }

            stopwatch.Stop();

            var process = Process.GetCurrentProcess();
            memoryUsed = process.PrivateMemorySize64;
            elapsedTime = stopwatch.Elapsed;
            cpuTime = process.TotalProcessorTime;

            pictureBox1.Invalidate();
        }

        private Point GetClosestPoint(Point p)
        {
            Point closestPoint = points[0];
            double closestDistance = GetDistance(p, closestPoint);

            foreach (var point in points)
            {
                double distance = GetDistance(p, point);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private Color ColorFromPoint(Point point)
        {
            int index = points.IndexOf(point);
            return Color.FromArgb(255, (index * 50) % 255, (index * 80) % 255, (index * 110) % 255);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            points.Clear();
            int numPoints = 100;
            for (int i = 0; i < numPoints; i++)
            {
                points.Add(new Point(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height)));
            }
            DrawVoronoi();
        }

        private void buttonToggleMode_Click(object sender, EventArgs e)
        {
            multiThreaded = !multiThreaded;
        }

        private void buttonToggleSplitRegions_Click(object sender, EventArgs e)
        {
            splitRegions = !splitRegions;
        }

        private void buttonShowMemory_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Memory Used: {memoryUsed / 1024 / 1024} MB");
        }

        private void buttonShowElapsedTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Elapsed Time: {elapsedTime.TotalMilliseconds} ms");
        }

        private void buttonShowCpuTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"CPU Time: {cpuTime.TotalMilliseconds} ms");
        }
    }
}
