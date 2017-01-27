package com.ilya.calculatorandroid;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {
    private Button button;
    private EditText aInput;
    private EditText op;
    private EditText bInput;
    private EditText result;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        aInput = (EditText) findViewById(R.id.aInput);
        op = (EditText) findViewById(R.id.op);
        bInput = (EditText) findViewById(R.id.bInput);
        result = (EditText) findViewById(R.id.result);
        button = (Button) findViewById(R.id.button);
    }

    public void onClickCalculate(View v) {
        String oper;
        int a;
        int b;
        String res;

        oper = op.getText().toString();
        a = Integer.parseInt(aInput.getText().toString());
        b = Integer.parseInt(bInput.getText().toString());
        res = Integer.toString(calculate(a, b, oper));
        result.setText(res);
    }

    private int calculate(int a, int b, String op) {
        int res = 0;

        switch (op){
            case "+":
                res = a + b;
                break;
            case "-":
                res = a - b;
                break;
            case "*":
                res = a * b;
                break;
            case "/":
                if ((a == 0) && (b == 0)) throw new ArithmeticException("NaN");
                if (b == 0) throw new ArithmeticException("Divide by zero");
                res = a / b;
                break;
            default:
                res = -1;
                break;
        }

        return res;
    }
}
