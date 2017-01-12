package com.example.oleg.sharedpreferencescrud.ui.ui.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.oleg.sharedpreferencescrud.Model.Person;
import com.example.oleg.sharedpreferencescrud.R;
import com.example.oleg.sharedpreferencescrud.database.CRUDSharedPreferences;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    private EditText etName;
    private EditText etId;
    private Button btnSave;
    private EditText etSurname;
    private EditText etPhone;
    private EditText etMail;
    private EditText etSkype;

    private CRUDSharedPreferences crudSharedPreferences;

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
        btnSave.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        crudSharedPreferences = new CRUDSharedPreferences();
        switch (v.getId()) {
            case R.id.btn_save:
                Person p = new Person(Integer.valueOf(etId.getText().toString()), etName.getText().toString(), etSurname.getText().toString(), etPhone.getText().toString(), etMail.getText().toString(), etSkype.getText().toString());
                crudSharedPreferences.addPerson(this,p);
                clearText();
                followToListActivity();
                break;
            default:
                break;
        }
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
