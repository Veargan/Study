package com.ilya.paintandroid;

import android.content.Context;
import android.graphics.Color;
import android.graphics.Paint;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Path;

public class MainActivity extends AppCompatActivity {

    DrawingView dv;
    private Paint p;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(new DrawingView(this));
        dv = new DrawingView(this);
        setContentView(dv);
        p = new Paint();
        p.setAntiAlias(true);
        p.setDither(true);
        p.setColor(Color.BLACK);
        p.setStyle(Paint.Style.STROKE);
        p.setStrokeJoin(Paint.Join.ROUND);
        p.setStrokeCap(Paint.Cap.ROUND);
        p.setStrokeWidth(10);
    }

    public class DrawingView extends View {
        private Bitmap bitmap = Bitmap.createBitmap(768, 1280, Bitmap.Config.ARGB_8888);
        private Canvas canvas = new Canvas(bitmap);
        private Path path;
        private Paint bitmapPaint;
        Context context;

        public DrawingView(Context c) {
            super(c);
            context = c;
            path = new Path();
            bitmapPaint = new Paint(Paint.DITHER_FLAG);
        }

        @Override
        protected void onDraw(Canvas canvas) {
            super.onDraw(canvas);
            canvas.drawBitmap(bitmap, 0, 0, bitmapPaint);
            canvas.drawPath(path, p);
        }

        @Override
        public boolean onTouchEvent(MotionEvent event) {
            float x = event.getX();
            float y = event.getY();

            switch (event.getAction()) {
                case MotionEvent.ACTION_DOWN:
                    path.moveTo(x, y);
                    invalidate();
                    break;
                case MotionEvent.ACTION_MOVE:
                    path.lineTo(x, y);
                    invalidate();
                    break;
                case MotionEvent.ACTION_UP:
                    canvas.drawPath(path, p);
                    path.reset();
                    invalidate();
                    break;
            }
            return true;
        }
    }
}
