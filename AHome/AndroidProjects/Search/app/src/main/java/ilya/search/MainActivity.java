package ilya.search;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.EditText;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity implements TextWatcher{
    private AutoCompleteTextView ac_tv;
    private TextView tv;

    final private String[] NAME_CUSTOM = { "Ilya", "Oleg", "Misha" };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ac_tv = (AutoCompleteTextView) findViewById(R.id.ac_text_view);
        tv = (TextView) findViewById(R.id.text_view);

        ac_tv.addTextChangedListener(this);
        ac_tv.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_dropdown_item_1line, NAME_CUSTOM));
    }


    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {

    }

    @Override
    public void onTextChanged(CharSequence s, int start, int before, int count) {
        tv.setText(ac_tv.getText());
    }

    @Override
    public void afterTextChanged(Editable s) {

    }
}
