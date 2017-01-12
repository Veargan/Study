package com.example.oleg.crud_sqlite.ui.adapters;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.TextView;

import com.example.oleg.crud_sqlite.R;
import com.example.oleg.crud_sqlite.model.Person;

import java.util.ArrayList;

/**
 * Created by Oleg on 06.01.2017.
 */

public class MyAdapter extends BaseAdapter {Context mContext;
    LayoutInflater layoutInflater;
    ArrayList<Person> persons;

    public MyAdapter(Context context, ArrayList<Person> persons) {
        this.mContext = context;
        this.persons = persons;
        this.layoutInflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    public View getView(final int position, View convertView, ViewGroup parent){
        View view = convertView;
        if (view == null){
            view = layoutInflater.inflate(R.layout.item_person, parent, false);
        }
        final Person person = persons.get(position);

        TextView tvNamePerson = (TextView)view.findViewById(R.id.tv_name);
        TextView tvSurnamePerson = (TextView)view.findViewById(R.id.tv_surname);
        TextView tvPhoneNumberPerson = (TextView)view.findViewById(R.id.tv_phone);
        TextView tvMailPerson = (TextView)view.findViewById(R.id.tv_mMail);
        TextView tvSkypePerson = (TextView)view.findViewById(R.id.tv_skype);
        ImageButton imDelete = (ImageButton) view.findViewById(R.id.ibtn_item_delete);
        tvNamePerson.setText(person.getmName());
        tvSurnamePerson.setText(person.getmSurname());
        tvPhoneNumberPerson.setText(person.getmPhone());
        tvPhoneNumberPerson.setOnClickListener(new View.OnClickListener() {

            public void onClick (View view){
                Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("tel: " + person.getmPhone()));
                view.getContext().startActivity(intent);
            }
        });
        tvMailPerson.setText(person.getmMail());
        tvMailPerson.setOnClickListener(new View.OnClickListener() {
            public void onClick (View view){

            }
        });

        tvSkypePerson.setText(person.getmSkype());
        tvSkypePerson.setOnClickListener(new View.OnClickListener() {
            public void onClick (View view){

            }
        });

        return view;
    }
    public int getCount(){
        return persons.size();
    }
    public long getItemId(int position){
        return position;
    }
    public Object getItem(int position){
        return persons.get(position);
    }
}
