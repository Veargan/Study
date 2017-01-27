package com.example.sony.sharedpreferencescrud.ui.adapters;

import java.util.ArrayList;

import android.Manifest;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
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
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;


import com.example.sony.sharedpreferencescrud.R;
import com.example.sony.sharedpreferencescrud.database.CRUDSharedPreferences;
import com.example.sony.sharedpreferencescrud.model.Person;

import java.util.ArrayList;

import static android.content.Context.NOTIFICATION_SERVICE;

/**
 * Created by Sony on 30.12.2016.
 */

public class MyAdapter extends BaseAdapter {
    Context mContext;
    LayoutInflater lInflater;
    ArrayList<Person> persons;
    CRUDSharedPreferences crudSharedPreferences;

    public MyAdapter(Context context, ArrayList<Person> people)
    {
        mContext = context;
        persons = people;
        lInflater = (LayoutInflater) mContext
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        crudSharedPreferences = new CRUDSharedPreferences();
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

        TextView tvName = (TextView) view.findViewById(R.id.text_view_item_name);
        TextView tvPhone = (TextView) view.findViewById(R.id.text_view_item_phone_number);
        ImageButton ibDelete = (ImageButton) view.findViewById(R.id.image_button_item_delete);

        tvName.setText(person.getmName());

        tvPhone.setText(person.getmPhoneNumber());
        tvPhone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("tel: " + person.getmPhoneNumber()));
                if (ActivityCompat.checkSelfPermission(v.getContext(), Manifest.permission.CALL_PHONE) != PackageManager.PERMISSION_GRANTED) {
                    return;
                }
                v.getContext().startActivity(intent);
            }
        });

        ibDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
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

        final AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        adb.setView(root);
        adb.setTitle("EDIT PERSON");

        adb.setPositiveButton("UPDATE", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which)
            {
                personItem.setmName(etName.getText().toString());
                personItem.setmSurname(etSurname.getText().toString());
                personItem.setmPhoneNumber(etPhoneNumber.getText().toString());
                personItem.setmMail(etMail.getText().toString());
                personItem.setmSkype(etSkype.getText().toString());

                crudSharedPreferences.updatePerson(mContext, personItem);
                notifyDataSetChanged();
            }
        });

        adb.setNeutralButton("CANCEL", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which)
            {
                dialog.dismiss();
            }
        });
        adb.setNegativeButton("DELETE", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                openDeleteDialog(personItem);
            }
        });

        adb.setCancelable(false);
        adb.create();
        adb.show();
    }
    private void openDeleteDialog(final Person p)
    {
        final AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        adb.setTitle("Delete");

        adb.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                crudSharedPreferences.dellPerson(mContext, p);
                persons.remove(p);
                sendNotification(p);
                notifyDataSetChanged();
            }
        });

        adb.setNegativeButton("CANCEL", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.dismiss();
            }
        });
        adb.setCancelable(false);
        adb.create();
        adb.show();
    }
    public void deleteAll()
    {
        crudSharedPreferences.dellAllPersons(mContext);
        persons = new ArrayList<>();
        notifyDataSetChanged();
    }

    public void showPerson(ArrayList<Person> p)
    {
        persons = p;
        notifyDataSetChanged();
    }

    private void sendNotification(final Person p) {
        Intent intent = new Intent("com.rj.notitfications.SECACTIVITY");
        PendingIntent pendingIntent = PendingIntent.getActivity(mContext, 1, intent, 0);
        Notification.Builder builder = new Notification.Builder(mContext);

        builder.setAutoCancel(false);
        builder.setTicker("Person was removed");
        builder.setContentTitle("SQLITE");
        builder.setContentText("You removed a person");
        builder.setSmallIcon(R.mipmap.ic_launcher);
        builder.setContentIntent(pendingIntent);
        builder.setOngoing(true);
        builder.setSubText(p.getmName() + " " + p.getmSurname());
        builder.setNumber(100);
        builder.build();

        Notification notification = builder.getNotification();
        NotificationManager manager = (NotificationManager) mContext.getSystemService(NOTIFICATION_SERVICE);
        manager.notify(11, notification);
    }
}