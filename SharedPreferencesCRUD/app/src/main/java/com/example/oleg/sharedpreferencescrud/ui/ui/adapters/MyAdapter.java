package com.example.oleg.sharedpreferencescrud.ui.ui.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;

import com.example.oleg.sharedpreferencescrud.Model.Person;
import com.example.oleg.sharedpreferencescrud.R;

import java.util.ArrayList;

/**
 * Created by Oleg on 30.12.2016.
 */

public class MyAdapter extends BaseAdapter{
    Context mContext;
    LayoutInflater layoutInflater;
    ArrayList<Person> persons;

    public MyAdapter(Context context, ArrayList<Person> persons) {
        this.mContext = context;
        this.persons = persons;
        this.layoutInflater = (LayoutInflator)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    public View getView(final int position, View convertView, ViewGroup parent){
        View view = convertView;
        if (view == null){
            view = layoutInflater.inflate(R.layout.item_person, parent, false);
        }
        final Person person = persons.get(position);

        TextView tvNamePerson = (TextView)view.findViewById(R.id.text_view_item_name);
        TextView tvSurnamePerson = (TextView)view.findViewById(R.id.text_view_item_surname);
        TextView tvPhoneNumberPerson = (TextView)view.findViewById(R.id.text_view_item_phone_number);
        TextView tvMailPerson = (TextView)view.findViewById(R.id.text_view_item_mail);
        TextView tvSkypePerson = (TextView)view.findViewById(R.id.text_view_item_skype);
        ImageButton imDelete = (ImageButton)view.findViewById(R.id.image_button_item_delete);
        tvNamePerson.setText(person.getmName());
        tvSurnamePerson.setText(person.getmSurname());
        tvPhoneNumberPerson.setText(person.getmPhoneNumber());
        tvPhoneNumberPerson.setOnClickListener(new View.OnClickListener)() {

            public void onClick (View view){
                Intent intent = new Intent(Intene.ACTION_CALL, Uri.parse("tel: " + person.getmPhoneNumber()));
                view.getContext().startActivity(intent);
            }
        });
        tvMailPerson.setText(person.getmMail);
        tvMailPerson.setOnClickListener(new View.OnClickListener)() {
            public void onClick (View view){

            }
        });

        tvSkypePerson.setText(person.getmSkype);
        tvSkypePerson.setOnClickListener(new View.OnClickListener)() {
            public void onClick (View view){

            }
        });

        imDelete.setOnClickListener(new View.OnClickListener)() {

            public void onClick (View view){
                if (!persons.isEmpty()){
                    persons.remove(position);
                    CRUDSharedPreferences crudSharedPreferences = new CRUDSharedPreferences();
                    crudSharedPreferences.removePerson(view.getContext(),persons.get(position));
                }
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
}