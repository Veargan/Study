/**
 * Created by Vladislav on 13.12.2016.
 */

public class Ball {
    public float centerX;
    public float centerY;
    public float dx;
    public float dy;
    public Canvas canvas;

    private const float difference = 4;
    private const float radius = 20;
    //private Brush brush;

    public Bubble() { }
    public Bubble(float x, float y, Canvas can)
    {
        centerX = x;
        centerY = y;
        canvas = can;

        Random rand = new Random();
        int r = rand.Next();
        switch (r % 4)
        {
            case 1:
                dx = difference;
                dy = difference;
                break;
            case 2:
                dx = -difference;
                dy = difference;
                break;
            case 3:
                dx = -difference;
                dy = -difference;
                break;
            case 0:
                dx = difference;
                dy = -difference;
                break;
        }
        //brush = new SolidBrush(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255)));

    }
    public void DrawBubble()
    {
        Graphics graphics = panel.CreateGraphics();
        graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
    }

    public void EraseBubble()
    {
        canvas
                .FillEllipse(new SolidBrush(panel.BackColor), centerX - radius, centerY - radius, radius * 2, radius * 2);
    }

    public void MoveBubble(Panel panel)
    {
        if (dx > 0)
        {
            if (centerX + radius + dx >= panel.Size.Width)
            {
                dx = -dx;
            }

        }
        else if (dx < 0)
        {
            if (centerX - radius - dx <= 0)
            {
                dx = -dx;
            }
        }
        if (dy > 0)
        {
            if (centerY + radius + dy + 20 >= panel.Size.Height)
            {
                dy = -dy;
            }

        }
        else if (dy < 0)
        {
            if (centerY - radius - dy <= 0)
            {
                dy = -dy;
            }
        }
        EraseBubble(panel);
        centerX += dx;
        centerY += dy;
        DrawBubble(panel);
    }

    public void RunBubble()
    {
        while (true)
        {
            Thread.Sleep(50);
            MoveBubble();
        }
    }
}
