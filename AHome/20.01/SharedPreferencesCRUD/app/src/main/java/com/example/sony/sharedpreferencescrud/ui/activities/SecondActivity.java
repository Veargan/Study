package com.example.sony.sharedpreferencescrud.ui.activities;

import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;

import com.example.sony.sharedpreferencescrud.R;
import com.example.sony.sharedpreferencescrud.database.CRUDSharedPreferences;
import com.example.sony.sharedpreferencescrud.model.Person;
import com.example.sony.sharedpreferencescrud.ui.adapters.FilterAdapter;
import com.example.sony.sharedpreferencescrud.ui.adapters.MyAdapter;

import java.util.ArrayList;

/**
 * Created by Sony on 28.12.2016.
 */

public class SecondActivity extends AppCompatActivity{
    private ListView lvPerson;
    private ArrayList<Person> persons;
    private CRUDSharedPreferences crudSharedPreferences;
    private Context context;
    private MyAdapter adapter;
    private FilterAdapter filterAdapter;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);

        context = this;

        lvPerson = (ListView) findViewById(R.id.list_view_second_person);

        persons = new ArrayList<Person>();
        crudSharedPreferences = new CRUDSharedPreferences();
        persons = crudSharedPreferences.getPersons(this);

        adapter = new MyAdapter(this, persons);
        lvPerson.setAdapter(adapter);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.second, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id=item.getItemId();

        if(id==R.id.action_dell_all)
        {
            adapter.deleteAll();
            return true;
        }
        else if(id==R.id.action_dell_person)
        {
            return true;
        }
        else if(id==R.id.action_get_person)
        {
            LayoutInflater dialogInflater = (LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            final View root = dialogInflater.inflate(R.layout.person_id_dialog_view, null);

            final EditText et_id = (EditText) root.findViewById(R.id.edit_text_set_id);

            final AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.setView(root);
            builder.setTitle("Set ID");
            builder.setPositiveButton("Show", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which)
                {
                    persons=crudSharedPreferences.getPerson(context, Integer.parseInt(et_id.getText().toString()));
                    adapter.showPerson(persons);
                }
            });
            builder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            builder.setCancelable(false);
            builder.create();
            builder.show();
            return true;
        }
        else if(id==R.id.action_update_person)
        {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}