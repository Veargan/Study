package com.example.vladislav.simplepaint;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.graphics.Canvas;
import android.graphics.Path;

import java.util.ArrayList;
import java.util.List;


public class MainActivity extends AppCompatActivity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(new DrawingView(this));
    }

    public class DrawingView extends View {

        Paint mPaint = new Paint();
        Context context;
        List<Ball> myBalls;
        private Handler h;
        private final int FRAME_RATE = 15;

        public DrawingView(Context c) {
            super(c);
            context = c;
            mPaint.setColor(Color.GREEN);
            myBalls = new ArrayList<>();
            h = new Handler();
        }

        @Override
        protected void onDraw(Canvas canvas) {
            for(int i=0; i<myBalls.size(); i++){
                Ball b = myBalls.get(i);
                b.MoveBubble(canvas);
                canvas.drawCircle((float)b.centerX, (float)b.centerY, b.radius, mPaint);
            }
            h.postDelayed(r, FRAME_RATE);
        }

        @Override
        public boolean onTouchEvent(MotionEvent event) {
            int actionMask = event.getActionMasked();
            switch (actionMask) {
                case MotionEvent.ACTION_DOWN:
                    Ball b = new Ball(event.getX(), event.getY());
                    myBalls.add(b);
                    break;
            }
            return true;
        }

        private Runnable r = new Runnable() {
            @Override
            public void run() {
                invalidate();
            }
        };
    }
}
