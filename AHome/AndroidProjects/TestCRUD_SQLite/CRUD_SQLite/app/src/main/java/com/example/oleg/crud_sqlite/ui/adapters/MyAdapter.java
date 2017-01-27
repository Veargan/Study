package com.example.oleg.crud_sqlite.ui.adapters;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
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
import android.widget.EditText;
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

    public MyAdapter(Context context, ArrayList<Person> persons) {
        this.mContext = context;
        this.persons = persons;
        this.layoutInflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.manager = (NotificationManager) context.getSystemService(NOTIFICATION_SERVICE);
    }

    public View getView(final int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if (view == null) {
            view = layoutInflater.inflate(R.layout.item_person, parent, false);
        }
        final Person person = persons.get(position);

        TextView tvNamePerson = (TextView) view.findViewById(R.id.tv_name);
        TextView tvSurnamePerson = (TextView) view.findViewById(R.id.tv_surname);
        TextView tvPhoneNumberPerson = (TextView) view.findViewById(R.id.tv_phone);
        TextView tvMailPerson = (TextView) view.findViewById(R.id.tv_mMail);
        TextView tvSkypePerson = (TextView) view.findViewById(R.id.tv_skype);
        ImageButton imDelete = (ImageButton) view.findViewById(R.id.ibtn_item_delete);

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
                //onCreateDialog(persons.get(position).getId());
                openEditDialog(persons.get(position));
            }
        });

        return view;
    }

    public int getCount() {
        return persons.size();
    }

    public long getItemId(int position) {
    return position;
}

    public Object getItem(int position) {
        return persons.get(position);
    }


    @SuppressLint("InflateParams")
    private void openEditDialog(final Person p) {
        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        adb.setTitle("Person");

        RelativeLayout dm = (RelativeLayout) layoutInflater.inflate(R.layout.dialog_main_person_edit, null);

        adb.setPositiveButton("Create", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });
        adb.setNegativeButton("Delete", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                openDeleteDialog(p);
            }
        });
        adb.setNeutralButton("Update", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });

        adb.setView(dm);

        EditText etDId = (EditText) dm.findViewById(R.id.et_d_id);
        EditText etDName = (EditText) dm.findViewById(R.id.et_d_name);
        EditText etDSurname = (EditText) dm.findViewById(R.id.et_d_surname);
        EditText etDPhone = (EditText) dm.findViewById(R.id.et_d_phone1);
        EditText etDMail = (EditText) dm.findViewById(R.id.et_d_mail);
        EditText etDSkype = (EditText) dm.findViewById(R.id.et_d_skype);

        etDId.setText(String.valueOf(p.getId()));
        etDName.setText(String.valueOf(p.getmName()));
        etDSurname.setText(String.valueOf(p.getmSurname()));
        etDPhone.setText(String.valueOf(p.getmPhone()));
        etDMail.setText(String.valueOf(p.getmMail()));
        etDSkype.setText(String.valueOf(p.getmSkype()));

        adb.create();
        adb.show();
    }

    @SuppressLint("InflateParams")
    private void openDeleteDialog(final Person p) {
        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);

        adb.setTitle("Person");
        adb.setMessage(p.getId() + " " + p.getmName());

        adb.setPositiveButton("DELETE", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
                sendNotification(p);
            }
        });
        adb.setNegativeButton("CANCEL", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
            }
        });

        adb.create();
        adb.show();
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
        manager.notify(11, notification);
    }

    //dialoglistperson
}





















//    @SuppressLint("InflateParams")
//    private void onCreateDialog(int id) {
//        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
//        adb.setTitle("Person");
//
//        rl = (RelativeLayout) layoutInflater.inflate(R.layout.dialog, null);
//
//        adb.setPositiveButton("Create", myClickListener);
//        adb.setNegativeButton("Delete", myClickListener);
//        adb.setNeutralButton("Update", myClickListener);
//
//        adb.setView(rl);
//        //test
//        tvname1 = (TextView) rl.findViewById(R.id.tv_name1);
//        tvphone1 = (TextView) rl.findViewById(R.id.tv_phone1);
//
////        tvNamePerson = (TextView) view.findViewById(R.id.tv_name);
////        tvNamePerson.setText(persons.get(id).getmName());
////        tvPhoneNumberPerson = (TextView) view.findViewById(R.id.tv_phone);
////        tvPhoneNumberPerson.setText(persons.get(id).getmPhone());
//
//        tvname1.setText(person.getmName());
//        tvphone1.setText(person.getmPhone());
//
//        adb.create();
//        adb.show();
//    }
//
//    @SuppressLint("InflateParams")
//    private void onCreateDialogAlert(int id) {
//        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
//
//        rl = (RelativeLayout) layoutInflater.inflate(R.layout.dialog, null);
//
//        adb.setTitle("Delete Person");
//        adb.setView(rl);
//
//        tvname1 = (TextView) rl.findViewById(R.id.tv_name1);
//        tvphone1 = (TextView) rl.findViewById(R.id.tv_phone1);
//
//        tvname1.setText(person.getmName());
//        tvphone1.setText(person.getmPhone());
//
////        adb.setMessage("Are you sure ?!");
//        adb.setPositiveButton("DELETE", new DialogInterface.OnClickListener() {
//            public void onClick(DialogInterface dialog, int id) {
//                DeletePersonAlertDialog();
//            }
//        });
//        adb.setNegativeButton("CANCEL", new DialogInterface.OnClickListener() {
//            public void onClick(DialogInterface dialog, int id) {
//            }
//        });
//
//        adb.create();
//        adb.show();
//    }
//
//    private void DeletePersonAlertDialog() {
//        Intent intent = new Intent("com.rj.notitfications.SECACTIVITY");
//        PendingIntent pendingIntent = PendingIntent.getActivity(mContext, 1, intent, 0);
//        Notification.Builder builder = new Notification.Builder(mContext);
//
//        builder.setAutoCancel(false);
//        builder.setTicker("Person was removed");
//        builder.setContentTitle("SQLITE");
//        builder.setContentText("You removed a person");
//        builder.setSmallIcon(R.mipmap.ic_launcher);
//        builder.setContentIntent(pendingIntent);
//        builder.setOngoing(true);
//        builder.setSubText(person.getmName() + " "  + person.getmPhone());   //API level 16
//        builder.setNumber(100);
//        builder.build();
//
//        Notification notification = builder.getNotification();
//        manager.notify(11, notification);
//    }
//
//    private DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener() {
//        public void onClick(DialogInterface dialog, int which) {
//            switch (which) {
//                case Dialog.BUTTON_POSITIVE:
//                    break;
//
//                case Dialog.BUTTON_NEGATIVE:
//                    onCreateDialogAlert(person.getId());
//                    break;
//
//                case Dialog.BUTTON_NEUTRAL:
//                    break;
//            }
//        }
//    };
