package com.example.sony.sqlitecrud.ui.adapter;

import android.Manifest;
import android.content.ClipData;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import com.example.sony.sqlitecrud.R;
import com.example.sony.sqlitecrud.db.CRUDSQLite;
import com.example.sony.sqlitecrud.model.Person;

import java.util.ArrayList;

/**
 * Created by Sony on 06.01.2017.
 */

public class MyAdapter extends BaseAdapter
{
    Context mContext;
    LayoutInflater lInflater;
    ArrayList<Person> persons;
    CRUDSQLite crudsqLite=null;


    public MyAdapter(Context context, ArrayList<Person> people)
    {
        mContext = context;
        persons = people;
        lInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        crudsqLite = new CRUDSQLite(mContext);
    }

    @Override
    public int getCount() {
        return persons.size();
    }

    @Override
    public Object getItem(int position) {
        return persons.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if (view == null) {
            view = lInflater.inflate(R.layout.item_person, parent, false);
        }

        final Person person = getPerson(position);

        final TextView tvName = (TextView) view.findViewById(R.id.text_view_item_name);
        TextView tvPhone = (TextView) view.findViewById(R.id.text_view_item_phone_number);
        final ImageButton ibDelete = (ImageButton) view.findViewById(R.id.image_button_item_delete);

        tvName.setText(person.getmName());

        tvPhone.setText(person.getmPhoneNumber());
        tvPhone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("tel: " + person.getmPhoneNumber()));
                v.getContext().startActivity(intent);
            }
        });

        ibDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openEditDialog(person);
            }
        });

        return view;
    }

    Person getPerson(int position)
    {
        return ((Person) getItem(position));
    }

    private void openEditDialog(final Person personItem)
    {
        final View root= lInflater.inflate(R.layout.dialog_view, null);

        final EditText etId =(EditText) root.findViewById(R.id.dialog_edit_text_id);
        final EditText etName=(EditText) root.findViewById(R.id.dialog_edit_text_name);
        final EditText etSurname=(EditText) root.findViewById(R.id.dialog_edit_text_surname);
        final EditText etPhoneNumber=(EditText) root.findViewById(R.id.dialog_edit_text_phone_number);
        final EditText etMail=(EditText) root.findViewById(R.id.dialog_edit_text_mail);
        final EditText etSkype=(EditText) root.findViewById(R.id.dialog_edit_text_skype);

        etId.setText(String.valueOf(personItem.getId()));
        etName.setText(personItem.getmName());
        etSurname.setText(personItem.getmSurname());
        etPhoneNumber.setText(personItem.getmPhoneNumber());
        etMail.setText(personItem.getmMail());
        etSkype.setText(personItem.getmSkype());

        final AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(mContext);
        alertDialogBuilder.setView(root);
        alertDialogBuilder.setTitle("Edit Contact");


        alertDialogBuilder.setPositiveButton("Update", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which)
            {
                personItem.setmName(etName.getText().toString());
                personItem.setmSurname(etSurname.getText().toString());
                personItem.setmPhoneNumber(etPhoneNumber.getText().toString());
                personItem.setmMail(etMail.getText().toString());
                personItem.setmSkype(etSkype.getText().toString());

                crudsqLite.updatePerson(personItem);
                notifyDataSetChanged();
            }
        });
        alertDialogBuilder.setNeutralButton("Cancle", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which)
            {
                dialog.dismiss();
            }
        });
        alertDialogBuilder.setNegativeButton("Delete", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                openDeleteDialog(personItem);
            }
        });
        alertDialogBuilder.setCancelable(false);
        alertDialogBuilder.create();
        alertDialogBuilder.show();
    }
    private void openDeleteDialog(final Person p)
    {
        final AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(mContext);
        alertDialogBuilder.setTitle("Delete");

        alertDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                crudsqLite.deletePerson(p.getId());
                persons.remove(p);
                notifyDataSetChanged();
            }
        });
        alertDialogBuilder.setNegativeButton("Cancle", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.dismiss();
            }
        });
        alertDialogBuilder.setCancelable(false);
        alertDialogBuilder.create();
        alertDialogBuilder.show();
    }
    public void deleteAll()
    {
        crudsqLite.deleteAllPerson();
        persons=new ArrayList<>();
        notifyDataSetChanged();
    }

    public void showPerson(ArrayList<Person> p)
    {
        persons=p;
        notifyDataSetChanged();
    }
}
