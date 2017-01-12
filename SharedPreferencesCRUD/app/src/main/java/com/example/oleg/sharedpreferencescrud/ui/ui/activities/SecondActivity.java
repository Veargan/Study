package com.example.oleg.sharedpreferencescrud.ui.ui.activities;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.example.oleg.sharedpreferencescrud.Model.Person;
import com.example.oleg.sharedpreferencescrud.R;
import com.example.oleg.sharedpreferencescrud.database.CRUDSharedPreferences;

import java.util.ArrayList;

/**
 * Created by Oleg on 28.12.2016.
 */

public class SecondActivity extends AppCompatActivity{
    private ListView lvPerson;
    private ArrayList<Person> persons;
    private CRUDSharedPreferences crudSharedPreferences;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second1);
        lvPerson = (ListView) findViewById(R.id.list_view_second_person);
        persons = new ArrayList<Person>();
        crudSharedPreferences = new CRUDSharedPreferences();
        persons = crudSharedPreferences.getPerson(this);
        ArrayAdapter<Person> adapter = new ArrayAdapter<Person>(this, android.R.layout.simple_list_item_1, persons);
        lvPerson.setAdapter(adapter);
    }
}