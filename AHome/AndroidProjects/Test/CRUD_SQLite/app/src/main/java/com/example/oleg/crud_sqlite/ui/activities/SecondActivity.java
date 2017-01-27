package com.example.oleg.crud_sqlite.ui.activities;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RelativeLayout;

import com.example.oleg.crud_sqlite.R;
import com.example.oleg.crud_sqlite.database.CRUDSQLite;
import com.example.oleg.crud_sqlite.model.Person;
import com.example.oleg.crud_sqlite.ui.adapters.MyAdapter;

import java.util.ArrayList;

public class SecondActivity extends AppCompatActivity {
    private ListView lvPerson;
    private ArrayList<Person> persons;
    private CRUDSQLite crudsqLite;
    private MyAdapter myAdapter;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second2);
        lvPerson = (ListView) findViewById(R.id.list_view_second_person);
        persons = new ArrayList<Person>();
        crudsqLite = new CRUDSQLite(this);
        persons = crudsqLite.getAllPersons();

        myAdapter = new MyAdapter(this, persons);
        lvPerson.setAdapter(myAdapter);
    }

    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.second, menu);
        return true;
    }

    @SuppressLint("InflateParams")
    public boolean onOptionsItemSelected(MenuItem item){
        final int id = item.getItemId();

        if (id == R.id.delete_all){
            crudsqLite.deleteAllPerson();
            return true;
        } else if (id == R.id.delete_person){
            crudsqLite.deletePerson(id);
            return true;
        } else if (id == R.id.get_person){
            openFindDialog();
            return true;
        } else if (id == R.id.update_person){
//            crudsqLite.Update(id);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressLint("InflateParams")
    private void openFindDialog() {
        AlertDialog.Builder adb = new AlertDialog.Builder(this);
        adb.setTitle("Get person");

        RelativeLayout ds = (RelativeLayout) getLayoutInflater().inflate(R.layout.dialog_second_person_get, null);

        adb.setView(ds);

        final EditText etDId = (EditText) ds.findViewById(R.id.et_dsec_id);
        adb.setPositiveButton("FIND", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                persons = crudsqLite.getPerson(Integer.parseInt(etDId.getText().toString()));
                myAdapter.showPerson(persons);
            }
        });

        adb.setNegativeButton("CANCEL", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });

        adb.create();
        adb.show();
    }
}