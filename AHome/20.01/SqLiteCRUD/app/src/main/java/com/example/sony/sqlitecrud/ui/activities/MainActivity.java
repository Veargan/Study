package com.example.sony.sqlitecrud.ui.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.sony.sqlitecrud.R;
import com.example.sony.sqlitecrud.db.CRUDSQLite;
import com.example.sony.sqlitecrud.model.Person;

public class MainActivity extends AppCompatActivity implements View.OnClickListener{

    private Button btnSave;
    private EditText etName, etSurname, etPhoneNumber, etMail, etSkype;
    private CRUDSQLite crudsqLite;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        crudsqLite=new CRUDSQLite(this);

        btnSave=(Button) findViewById(R.id.btn_save);
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
        switch (v.getId())
        {
            case R.id.btn_save:
                if(etName.getText().toString()=="")
                    return;
                Person personModel=new Person( etName.getText().toString(),
                        etSurname.getText().toString(), etPhoneNumber.getText().toString(),
                        etMail.getText().toString(), etSkype.getText().toString());
                crudsqLite.addperson(this,personModel);
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
        etName.setText("");
        etSurname.setText("");
        etPhoneNumber.setText("");
        etMail.setText("");
        etSkype.setText("");
    }
}
