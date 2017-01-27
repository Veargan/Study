package com.example.sony.sqlitecrud.ui.activities;

import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.*;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RelativeLayout;

import com.example.sony.sqlitecrud.R;
import com.example.sony.sqlitecrud.db.CRUDSQLite;
import com.example.sony.sqlitecrud.model.Person;
import com.example.sony.sqlitecrud.ui.adapter.MyAdapter;

import java.util.ArrayList;

/**
 * Created by Sony on 06.01.2017.
 */

public class SecondActivity extends AppCompatActivity
{
    private ListView lvPerson;
    private ArrayList<Person> persons;
    private CRUDSQLite crudsqLite;
    private MyAdapter adapter;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);
        lvPerson=(ListView) findViewById(R.id.list_view_second_person);
        persons=new ArrayList<Person>();

        crudsqLite = new CRUDSQLite(this);

        persons = crudsqLite.getAllPersons();

        adapter = new MyAdapter(this, persons);
        lvPerson.setAdapter(adapter);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        getMenuInflater().inflate(R.menu.second, menu);
        return true;
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
            final View root= dialogInflater.inflate(R.layout.person_id_dialog_view, null);


            final EditText et_id=(EditText) root.findViewById(R.id.edit_text_set_id);

            final AlertDialog.Builder builder=new AlertDialog.Builder(this);

            builder.setView(root);
            builder.setTitle("Set ID");
            builder.setPositiveButton("Show", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which)
                {
                    persons=crudsqLite.getPerson(Integer.parseInt(et_id.getText().toString()));
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
