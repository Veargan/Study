package com.example.oleg.crud_sqlite.ui.activities;

import android.content.ClipData;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.oleg.crud_sqlite.R;

public class MainActivity extends AppCompatActivity {

    private EditText etName;
    private EditText etId;
    private Button btnSave;
    private EditText etSurname;
    private EditText etPhone;
    private EditText etMail;
    private EditText etSkype;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        etName = (EditText) findViewById(R.id.et_name);
        etId = (EditText) findViewById(R.id.et_id);
        etSurname = (EditText) findViewById(R.id.et_surname);
        etPhone = (EditText) findViewById(R.id.et_phone1);
        etMail = (EditText) findViewById(R.id.et_mail);
        etSkype = (EditText) findViewById(R.id.et_skype);
        btnSave = (Button) findViewById(R.id.btn_save);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.persons) {
            followToListActivity();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }

    public void btn_save_click(View view) {

    }

    private void followToListActivity() {
//        Intent callIntent = new Intent(Intent.ACTION_CALL, person.getPhoneNumber().toString());
//        startActivity(callIntent);
        Intent intent = new Intent(MainActivity.this, SecondActivity.class);
//        intent.putExtra("txt", String text);
//        intent.get
        startActivity(intent);
    }

    private void clearText() {
        etName.setText("");
        etId.setText("");
        etSurname.setText("");
        etSkype.setText("");
        etMail.setText("");
        etPhone.setText("");
    }
}
