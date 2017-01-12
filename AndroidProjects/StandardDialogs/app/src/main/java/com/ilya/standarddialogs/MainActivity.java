package com.ilya.standarddialogs;

import android.annotation.TargetApi;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.icu.util.Calendar;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.TimePicker;

import java.sql.Time;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    private TextView tvTime;
    private Button btnTime;
    private Button btnDate;

    public static final int DIALOG_TIME = 1;
    public static final int HOUR = 0;
    public static final int MIN = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tvTime = (TextView) findViewById(R.id.tvTime);
        btnTime = (Button) findViewById(R.id.btnTime);
        btnDate = (Button) findViewById(R.id.btnDate);
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    public void onClick(View v) {
//        showDialog(DIALOG_TIME);
        onCreateTimeDialog(v.getId());
//        onCreateTimeDialogTest(v.getId());
    }

    private void onCreateTimeDialog(int id) {
        final Calendar c = Calendar.getInstance();
        final int hour = c.get(Calendar.HOUR_OF_DAY);
        final int min = c.get(Calendar.MINUTE);

        TimePickerDialog.OnTimeSetListener callBack = new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hour, int min) {
                tvTime.setText("Time is " + hour + " hours " + min+ " minutes");
            }
        };
        TimePickerDialog tpd = new TimePickerDialog(this, callBack, hour, min, true);
        tpd.show();
    }

    private void onCreateTimeDialogTest(int id) {
        TimePickerDialog.OnTimeSetListener callBack = new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hour, int min) {
                tvTime.setText("Time is " + hour + " hours " + min+ " minutes");
            }
        };
        TimePickerDialog tpd = new TimePickerDialog(this, callBack, HOUR, MIN, true);
        tpd.show();
    }

    @Override
    protected Dialog onCreateDialog(int id) {
        if (id == DIALOG_TIME) {
            TimePickerDialog.OnTimeSetListener callBack = new TimePickerDialog.OnTimeSetListener() {
                @Override
                public void onTimeSet(TimePicker view, int hour, int min) {
                    tvTime.setText("Time is " + hour + " hours " + min + " minutes");
                }
            };
            TimePickerDialog tpd = new TimePickerDialog(this, callBack, HOUR, MIN, true);
            return tpd;
        }
        return super.onCreateDialog(id);
    }
}
