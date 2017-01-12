package com.example.oleg.crud_sqlite.ui.activities;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListView;

import com.example.oleg.crud_sqlite.R;
import com.example.oleg.crud_sqlite.model.Person;
import com.example.oleg.crud_sqlite.ui.adapters.MyAdapter;

import java.util.ArrayList;

/**
 * Created by Oleg on 06.01.2017.
 */

public class SecondActivity extends AppCompatActivity {
    private ListView lvPerson;
    private ArrayList<Person> persons;
//    private CRUDSharedPreferences crudSharedPreferences;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second2);
        lvPerson = (ListView) findViewById(R.id.list_view_second_person);
        persons = new ArrayList<Person>();
//        crudSharedPreferences = new CRUDSharedPreferences();
//        persons = crudSharedPreferences.getPerson(this);
//        MyAdapter myAdapter = new MyAdapter(this, persons);
//        lvPerson.setAdapter(myAdapter);
    }

    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.second, menu);
        return true;
    }

    public boolean onOptionsItemSelected(MenuItem item){
        int id = item.getItemId();

        if (id == R.id.delete_all){
            return true;
        } else if (id == R.id.delete_person){
            return true;
        } else if (id == R.id.get_person){
            return true;
        } else if (id == R.id.update_person){
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
