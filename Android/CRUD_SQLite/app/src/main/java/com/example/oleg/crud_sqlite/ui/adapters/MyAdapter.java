package com.example.oleg.crud_sqlite.ui.adapters;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.example.oleg.crud_sqlite.R;
import com.example.oleg.crud_sqlite.model.Person;

import java.util.ArrayList;

import static android.content.Context.NOTIFICATION_SERVICE;

public class MyAdapter extends BaseAdapter {
    private Context mContext;
    private LayoutInflater layoutInflater;
    private ArrayList<Person> persons;

    private NotificationManager manager;
    private View view;

    private TextView tvNamePerson;
    private TextView tvSurnamePerson;
    private TextView tvPhoneNumberPerson;
    private TextView tvMailPerson;
    private TextView tvSkypePerson;
    private ImageButton imDelete;
    private Person person;

    public MyAdapter(Context context, ArrayList<Person> persons) {
        this.mContext = context;
        this.persons = persons;
        this.layoutInflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.manager = (NotificationManager) context.getSystemService(NOTIFICATION_SERVICE);
    }

    public View getView(final int position, View convertView, ViewGroup parent) {
        view = convertView;
        if (view == null) {
            view = layoutInflater.inflate(R.layout.item_person, parent, false);
        }
        person = persons.get(position);

        tvNamePerson = (TextView) view.findViewById(R.id.tv_name);
        tvSurnamePerson = (TextView) view.findViewById(R.id.tv_surname);
        tvPhoneNumberPerson = (TextView) view.findViewById(R.id.tv_phone);
        tvMailPerson = (TextView) view.findViewById(R.id.tv_mMail);
        tvSkypePerson = (TextView) view.findViewById(R.id.tv_skype);
        imDelete = (ImageButton) view.findViewById(R.id.ibtn_item_delete);

        tvNamePerson.setText(person.getmName());
        tvSurnamePerson.setText(person.getmSurname());
        tvPhoneNumberPerson.setText(person.getmPhone());

        tvPhoneNumberPerson.setOnClickListener(new View.OnClickListener() {
            public void onClick(View view) {
                Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("tel: " + person.getmPhone()));
                view.getContext().startActivity(intent);
            }
        });

        tvMailPerson.setText(person.getmMail());
        tvMailPerson.setOnClickListener(new View.OnClickListener() {
            public void onClick(View view) {

            }
        });

        tvSkypePerson.setText(person.getmSkype());
        tvSkypePerson.setOnClickListener(new View.OnClickListener() {
            public void onClick(View view) {

            }
        });

        imDelete.setOnClickListener(new View.OnClickListener() {
            public void onClick(View view) {
                onCreateDialog(persons.get(position).getId());
            }
        });

        return view;
    }



    @SuppressLint("InflateParams")
    private void onCreateDialog(int id) {
        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        adb.setTitle("Person");

        RelativeLayout rl = (RelativeLayout) layoutInflater.inflate(R.layout.dialog, null);

        adb.setPositiveButton("Create", myClickListener);
        adb.setNegativeButton("Delete", myClickListener);
        adb.setNeutralButton("Update", myClickListener);
        adb.setView(rl);
        //test
        TextView tvname1 = (TextView) rl.findViewById(R.id.tv_name1);
        TextView tvphone1 = (TextView) rl.findViewById(R.id.tv_phone1);

//        tvNamePerson = (TextView) view.findViewById(R.id.tv_name);
//        tvNamePerson.setText(persons.get(id).getmName());
//        tvPhoneNumberPerson = (TextView) view.findViewById(R.id.tv_phone);
//        tvPhoneNumberPerson.setText(persons.get(id).getmPhone());

        tvname1 = (TextView) rl.findViewById(R.id.tv_name1);
        tvname1.setText(persons.get(id-1).getmName());
        tvphone1 = (TextView) rl.findViewById(R.id.tv_phone1);
        tvphone1.setText(persons.get(id-1).getmPhone());

        adb.create();
        adb.show();
    }

    @SuppressLint("InflateParams")
    private void onCreateDialogAlert(int id) {
        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        view = layoutInflater.inflate(R.layout.dialog, null);

        adb.setTitle("Delete Person");
        adb.setView(view);
        tvNamePerson = (TextView) view.findViewById(R.id.tv_name);
        tvNamePerson.setText(person.getmName());
        tvPhoneNumberPerson = (TextView) view.findViewById(R.id.tv_phone);
        tvPhoneNumberPerson.setText(person.getmPhone());

//        adb.setMessage("Are you sure ?!");
        adb.setPositiveButton("DELETE", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
                DeletePersonAlertDialog();
            }
        });
        adb.setNegativeButton("CANCEL", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
            }
        });

        adb.create();
        adb.show();
    }

    private void DeletePersonAlertDialog() {
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
        builder.setSubText(person.getmName() + " "  + person.getmPhone());   //API level 16
        builder.setNumber(100);
        builder.build();

        Notification notification = builder.getNotification();
        manager.notify(11, notification);
    }

    private DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener() {
        public void onClick(DialogInterface dialog, int which) {
            switch (which) {
                case Dialog.BUTTON_POSITIVE:
                    break;

                case Dialog.BUTTON_NEGATIVE:
                    onCreateDialogAlert(person.getId());
                    break;

                case Dialog.BUTTON_NEUTRAL:
                    break;
            }
        }
    };

    public int getCount() {
        return persons.size();
    }

    public long getItemId(int position) {
    return position;
}

    public Object getItem(int position) {
        return persons.get(position);
    }
}