package ghh0stex.persondao_php.ui.adapter;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import ghh0stex.persondao_php.R;
import ghh0stex.persondao_php.database.PersonDAO_Net_Http;
import ghh0stex.persondao_php.model.Person;

/**
 * Created by GHhos on 25.01.2017.
 */

public class PersonAdapter extends BaseAdapter {

    public PersonAdapter(Context context, ArrayList<Person> personList) {
        this.personList = personList;
        this.context = context;
        this.layoutInflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    private List<Person> personList;
    private Context context;
    private LayoutInflater layoutInflater;

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        View view = convertView;
        if (view == null) {
            view = layoutInflater.inflate(R.layout.item_person, parent, false);
        }
        final Person person = (Person) getItem(position);

        TextView tvPersonId = (TextView) view.findViewById(R.id.item_text_view_id);
        TextView tvPersonName = (TextView) view.findViewById(R.id.item_text_view_name);
        TextView tvPersonSurname = (TextView) view.findViewById(R.id.item_text_view_surname);
        TextView tvPersonAge = (TextView) view.findViewById(R.id.item_text_view_age);
        ImageButton ibDelete = (ImageButton) view.findViewById(R.id.image_button_item_delete);

        tvPersonId.setText(String.valueOf(person.getId()));
        tvPersonName.setText(person.getFirstName());
        tvPersonSurname.setText(person.getLastName());
        tvPersonAge.setText(String.valueOf(person.getAge()));

        ibDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openEditDialog(person);
            }
        });

        return view;
    }

    @Override
    public int getCount() {
        return personList.size();
    }

    @Override
    public Object getItem(int position) {
        return personList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return personList.get(position).getId();
    }


    private void openDeleteDialog(final Person person){
        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(context);
        aDialogBuilder.setMessage("Delete Contact");
        aDialogBuilder.setMessage("Are you sure you want to delete "
                + person.getFirstName() + " "
                + person.getLastName() + " from person list?"
        );

        aDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                PersonDAO_Net_Http personDAO_net_http = new PersonDAO_Net_Http();
                personDAO_net_http.Delete(person);
                personDAO_net_http.execute();
                Toast.makeText(context, "Person Deleted!", Toast.LENGTH_LONG);
            }
        });
        aDialogBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });
        aDialogBuilder.setCancelable(false);
        aDialogBuilder.create();
        aDialogBuilder.show();
    }

    private void openEditDialog(final Person person) {

        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View root = inflater.inflate(R.layout.dialog_item, null);

        final EditText id = (EditText) root.findViewById(R.id.et_dialog_id);
        final EditText name = (EditText) root.findViewById(R.id.et_dialog_fName);
        final EditText surname = (EditText) root.findViewById(R.id.et_dialog_lName);
        final EditText age = (EditText) root.findViewById(R.id.et_dialog_age);

        id.setText(String.valueOf(person.getId()));
        name.setText(person.getFirstName());
        surname.setText(person.getLastName());
        age.setText(String.valueOf(person.getAge()));

        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(context);
        aDialogBuilder.setView(root);
        aDialogBuilder.setMessage("Edit Person");

        aDialogBuilder.setPositiveButton("Update", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                person.setId(Integer.parseInt(id.getText().toString()));
                person.setFirstName(name.getText().toString());
                person.setLastName(surname.getText().toString());
                person.setAge(Integer.parseInt(age.getText().toString()));

                PersonDAO_Net_Http personDAO_net_http = new PersonDAO_Net_Http();
                personDAO_net_http.Update(person);
                personDAO_net_http.execute();

                notifyDataSetChanged();
            }
        });
        aDialogBuilder.setNeutralButton("Delete", new DialogInterface.OnClickListener(){
            @Override
            public void onClick(DialogInterface dialog, int which) {
                openDeleteDialog(person);
            }
        });
        aDialogBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        aDialogBuilder.show();
    }

    public void openCreateDialog() {

        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View root = inflater.inflate(R.layout.dialog_item, null);

        final EditText id = (EditText) root.findViewById(R.id.et_dialog_id);
        final EditText name = (EditText) root.findViewById(R.id.et_dialog_fName);
        final EditText surname = (EditText) root.findViewById(R.id.et_dialog_lName);
        final EditText age = (EditText) root.findViewById(R.id.et_dialog_age);

        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(context);
        aDialogBuilder.setView(root);
        aDialogBuilder.setMessage("Create Person");

        aDialogBuilder.setPositiveButton("Create", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Person person = new Person();
                person.setId(Integer.parseInt(id.getText().toString()));
                person.setFirstName(name.getText().toString());
                person.setLastName(surname.getText().toString());
                person.setAge(Integer.parseInt(age.getText().toString()));

                PersonDAO_Net_Http personDAO_net_http = new PersonDAO_Net_Http();
                personDAO_net_http.Create(person);
                personDAO_net_http.execute();

                notifyDataSetChanged();
            }
        });
        aDialogBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        aDialogBuilder.show();
    }

}
