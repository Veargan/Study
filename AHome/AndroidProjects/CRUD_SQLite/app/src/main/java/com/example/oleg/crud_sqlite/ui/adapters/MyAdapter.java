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

    private final int DIALOG = 1;
    private RelativeLayout dialogView;
    private NotificationManager manager;
    private TextView tvname1;
    private TextView tvphone1;

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
                onCreateDialog(DIALOG);
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
    private void onCreateDialog(int id) {
        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        adb.setTitle("Person");

        dialogView = (RelativeLayout) layoutInflater.inflate(R.layout.dialog, null);

        adb.setPositiveButton("Create", myClickListener);
        adb.setNegativeButton("Delete", myClickListener);
        adb.setNeutralButton("Update", myClickListener);
        adb.setView(dialogView);

        tvname1 = (TextView) dialogView.findViewById(R.id.tv_name1);
        tvname1.setText("ilya");
        tvphone1 = (TextView) dialogView.findViewById(R.id.tv_phone1);
        tvphone1.setText("3809689845");

        adb.create();
        adb.show();
    }

    @SuppressLint("InflateParams")
    private void onCreateDialogAlert(int id) {
        AlertDialog.Builder adb = new AlertDialog.Builder(mContext);
        dialogView = (RelativeLayout) layoutInflater.inflate(R.layout.dialog, null);

        adb.setTitle("Delete Person");
        adb.setView(dialogView);
        tvname1 = (TextView) dialogView.findViewById(R.id.tv_name1);
        tvname1.setText("ILYA");
        tvphone1 = (TextView) dialogView.findViewById(R.id.tv_phone1);
        tvphone1.setText("+3809689845");

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
        builder.setSubText("1(id) Ilya(p)");   //API level 16
        builder.setNumber(100);
        builder.build();

        Notification notification = builder.getNotification();
        manager.notify(11, notification);
    }

    DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener() {
        public void onClick(DialogInterface dialog, int which) {
            switch (which) {
                case Dialog.BUTTON_POSITIVE:
                    break;

                case Dialog.BUTTON_NEGATIVE:
                    onCreateDialogAlert(DIALOG);
                    break;

                case Dialog.BUTTON_NEUTRAL:
                    break;
            }
        }
    };
}