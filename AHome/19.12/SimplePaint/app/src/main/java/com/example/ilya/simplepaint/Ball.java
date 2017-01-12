package com.example.vladislav.simplepaint;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;

import java.util.Random;

public class Ball {
        public int width;
        public int posX;
        public int posY;

        public int dx;
        public int dy;

        private Random rnd;

        public Ball(int x, int y)
        {
            rnd = new Random();
            width = rnd.Next(30, 60);
            posX = x;
            posY = y;
            dx = rnd.Next(-10, 10);
            dy = rnd.Next(-10, 10);
        }

        public void MoveBubble(Canvas can)
        {
            ball.posX += ball.dx;
            ball.posY += ball.dy;

            if (ball.posX <= 0 || ball.posX + ball.width >= ClientSize.Width)
            {
                ball.dx = -ball.dx;
            }
            if (ball.posY <= 0 || ball.posY + ball.width >= ClientSize.Height)
            {
                ball.dy = -ball.dy;
            }
        }
    }