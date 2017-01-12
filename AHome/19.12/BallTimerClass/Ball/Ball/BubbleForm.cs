using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ball
{
    public partial class BubbleForm : Form
    {
        private Timer _timer;
        private BufferedGraphics _bufGraphics;
        private List<Ball> balls = new List<Ball>();
        private bool _ballAdded = false;

        public BubbleForm()
        {
            InitializeComponent();
            InitializeAndStartTimer();
            InitializeGraphics();
        }

        #region Inits
        private void InitializeAndStartTimer()
        {
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 1;
            _timer.Start();
        }

        private void InitializeGraphics()
        {
            BufferedGraphicsContext context = new BufferedGraphicsContext();
            _bufGraphics = context.Allocate(CreateGraphics(), this.ClientRectangle);
            _bufGraphics.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            context.MaximumBuffer = ClientRectangle.Size;
        }
        #endregion

        #region Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            if (balls.Count > 0)
            {
                _bufGraphics.Graphics.Clear(BackColor);

                int size = balls.Count;
                if (!_ballAdded)
                {
                    size--;
                }

                for (int i = 0; i < size; ++i)
                {
                    balls[i].posX += balls[i].dx;
                    balls[i].posY += balls[i].dy;

                    if (balls[i].posX <= 0 || balls[i].posX + balls[i].width >= ClientSize.Width)
                    {
                        balls[i].dx = -balls[i].dx;
                    }
                    if (balls[i].posY <= 0 || balls[i].posY + balls[i].width >= ClientSize.Height)
                    {
                        balls[i].dy = -balls[i].dy;
                    }

                    _bufGraphics.Graphics.DrawEllipse(new Pen(Color.Red, 5), balls[i].posX, balls[i].posY, 30, 30);
                    _bufGraphics.Render();
                }
            }
        }
        #endregion

        #region Resize
        private void BubbleForm_Resize(object sender, EventArgs e)
        {
            _timer.Stop();

            InitializeGraphics();

            _timer.Start();

            ResetPositions();
        }

        private void ResetPositions()
        {
            foreach (var val in balls)
            {
                if (val.posX + val.width >= ClientSize.Width)
                {
                    val.posX = ClientSize.Width - val.width;
                }

                if (val.posY + val.width >= ClientSize.Height)
                {
                    val.posY = ClientSize.Height - val.width;
                }
            }
        }
        #endregion

        #region Mouse Events
        private void BubbleForm_MouseDown(object sender, MouseEventArgs e)
        {
            _ballAdded = false;
            balls.Add(new Ball(e.X, e.Y));
        }

        private void BubbleForm_MouseUp(object sender, MouseEventArgs e)
        {
            balls[balls.Count - 1].SetDirectionVector(e.X, e.Y);
            _bufGraphics.Graphics.DrawEllipse(new Pen(Color.Red, 5), e.X, e.Y, 30, 30);
            _ballAdded = true;
        }
        #endregion

    }
}