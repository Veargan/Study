package com.example.sony.sharedpreferencescrud.ui.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.sony.sharedpreferencescrud.R;
import com.example.sony.sharedpreferencescrud.database.CRUDSharedPreferences;
import com.example.sony.sharedpreferencescrud.model.Person;

public class MainActivity extends AppCompatActivity implements View.OnClickListener{

    private CRUDSharedPreferences crudSharedPreferences;
    private Button btnSave;
    private EditText etId, etName, etSurname, etPhoneNumber, etMail, etSkype;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnSave=(Button) findViewById(R.id.btn_save);
        etId=(EditText) findViewById(R.id.edit_text_id);
        etName=(EditText) findViewById(R.id.edit_text_name);
        etSurname=(EditText) findViewById(R.id.edit_text_surname);
        etPhoneNumber=(EditText) findViewById(R.id.edit_text_phone_number);
        etMail=(EditText) findViewById(R.id.edit_text_mail);
        etSkype=(EditText) findViewById(R.id.edit_text_skype);
        btnSave.setOnClickListener(this);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id=item.getItemId();
        if(id==R.id.action_all_persons_list)
        {
            followToListActiviti();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onClick(View v) {
        crudSharedPreferences=new CRUDSharedPreferences();
        switch (v.getId())
        {
            case R.id.btn_save:
                Person personModel=new Person(Integer.valueOf( etId.getText().toString()), etName.getText().toString(),
                        etSurname.getText().toString(), etPhoneNumber.getText().toString(),
                        etMail.getText().toString(), etSkype.getText().toString());
                crudSharedPreferences.addPerson(this, personModel);
                clearText();
                followToListActiviti();
                break;
            default:
                break;
        }
    }
    private void followToListActiviti()
    {
        Intent intent=new Intent(MainActivity.this, SecondActivity.class);
        startActivity(intent);
    }
    private void clearText()
    {
        etId.setText("");
        etName.setText("");
        etSurname.setText("");
        etPhoneNumber.setText("");
        etMail.setText("");
        etSkype.setText("");
    }

}
