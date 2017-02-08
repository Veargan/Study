package com.example.adm.calculator_http_php.ui;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.adm.calculator_http_php.R;
import com.example.adm.calculator_http_php.api.Http_Connection;

public class MainActivity extends AppCompatActivity {

    EditText etValue1;
    EditText etValue2;
    EditText etOperation;
    Button bCalc;
    Http_Connection httpConnection;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        etValue1 = (EditText)findViewById(R.id.et_value1);
        etValue2 = (EditText)findViewById(R.id.et_value2);
        etOperation = (EditText)findViewById(R.id.et_operation);
        bCalc = (Button)findViewById(R.id.button_calculate);

        httpConnection = new Http_Connection(findViewById(android.R.id.content), "192.168.0.166");

        bCalc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                httpConnection.Send(
                        Integer.valueOf(etValue1.getText().toString()),
                        Integer.valueOf(etValue2.getText().toString()),
                        etOperation.getText().toString()
                );
            }
        });
    }
}
