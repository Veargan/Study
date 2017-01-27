package com.example.sony.sharedpreferencescrud.ui.adapters;

import android.annotation.SuppressLint;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Filterable;
import android.widget.ImageButton;
import android.widget.TextView;

import com.example.sony.sharedpreferencescrud.R;
import com.example.sony.sharedpreferencescrud.database.CRUDSharedPreferences;
import com.example.sony.sharedpreferencescrud.model.Person;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Filter;

import static android.content.Context.NOTIFICATION_SERVICE;

/**
 * Created by student on 20.01.2017.
 */

public class FilterAdapter extends ArrayAdapter implements Filterable {
    private List<Person> originalPersonList;
    private List<Person> personList;
    private Context mContext;
    private Filter personFilter;
    private CRUDSharedPreferences crudSharedPreferences;
    private LayoutInflater layoutInflater;

    public FilterAdapter(Context c, ArrayList<Person> p) {
        super(c, R.layout.item_person, p);
        this.personList = p;
        this.mContext = c;
        this.originalPersonList = p;
    }

    @SuppressLint("InflateParams")
    public View getView(final int position, View convertView , ViewGroup parent) {
        View view = convertView;
        PersonHolder personHolder = new PersonHolder();

        if (convertView == null) {
            layoutInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = layoutInflater.inflate(R.layout.item_person, null);

            TextView tvName = (TextView) view.findViewById(R.id.text_view_item_name);
            TextView tvPhone = (TextView) view.findViewById(R.id.text_view_item_phone_number);
            ImageButton ibEdit = (ImageButton) view.findViewById(R.id.image_button_item_delete);

            personHolder.tvName = tvName;
            personHolder.tvPhone = tvPhone;
            personHolder.ibEdit = ibEdit;

            view.setTag(personHolder);
        } else {
            personHolder = (PersonHolder) view.getTag();
        }
        final Person person = personList.get(position);

        personHolder.tvName.setText(person.getmName());
        personHolder.tvName.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Person.selectedPerson = person;
                Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("tel: " + person.getmPhoneNumber()));
                v.getContext().startActivity(intent);
            }
        });

        personHolder.ibEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openEditDialog(person);
            }
        });

        return view;
    }

    @SuppressLint("InflateParams")
    private void openEditDialog(final Person personItem)
    {
        final View root = layoutInflater.inflate(R.layout.dialog_view, null);

        final EditText etId =(EditText) root.findViewById(R.id.dialog_edit_text_id);
        final EditText etName = (EditText) root.findViewById(R.id.dialog_edit_text_name);
        final EditText etSurname = (EditText) root.findViewById(R.id.dialog_edit_text_surname);
        final EditText etPhoneNumber = (EditText) root.findViewById(R.id.dialog_edit_text_phone_number);
        final EditText etMail = (EditText) root.findViewById(R.id.dialog_edit_text_mail);
        final EditText etSkype = (EditText) root.findViewById(R.id.dialog_edit_text_skype);

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
        adb.setTitle("DELETE");

        adb.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                crudSharedPreferences.dellPerson(mContext, p);
                personList.remove(p);
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
        personList = new ArrayList<>();
        notifyDataSetChanged();
    }

    public void showPerson(ArrayList<Person> p)
    {
        personList = p;
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

    private class PersonFilter extends Filter {
        @Override
        protected filterResults performFiltering(CharSequence constraints) {

        }

        @Override
        protected void publishResults(CharSequence constraints, FilterResults results) {
            if ()
        }
    }

    public int getCount() {
        return personList.size();
    }

    public Person getItem(int position) {
        return personList.get(position);
    }

    public long getItemId(int position) {
        return position;
    }

    public static class PersonHolder {
        private TextView tvName;
        private TextView tvPhone;
        private ImageButton ibEdit;
    }

    public void resetData() {
        this.personList = originalPersonList;
    }
}