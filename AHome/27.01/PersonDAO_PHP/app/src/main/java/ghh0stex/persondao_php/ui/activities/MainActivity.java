package ghh0stex.persondao_php.ui.activities;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.internal.Excluder;

import java.io.IOException;
import java.io.PrintStream;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import ghh0stex.persondao_php.R;
import ghh0stex.persondao_php.database.PersonDAO_Net_Http;
import ghh0stex.persondao_php.model.Person;
import ghh0stex.persondao_php.ui.adapter.PersonAdapter;

public class MainActivity extends AppCompatActivity {

    private ArrayList<Person> personList;
    private ListView lvPersons;
    private PersonAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lvPersons = (ListView)findViewById(R.id.activity_main_list_view_persons);

        personList = new ArrayList<Person>();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.main_menu_create){
            adapter.openCreateDialog();
        }
        else if (id == R.id.main_menu_read){
            PersonDAO_Net_Http personDAO_net_http = new PersonDAO_Net_Http();
            personDAO_net_http.Read();
            personDAO_net_http.execute();

            String resp = "";
            while(resp == ""){
                resp = personDAO_net_http.getResponse();
            }

            try{
                Gson gson = new Gson();
                List<Person> list;
                Person[] personsItems = gson.fromJson(resp, Person[].class);

                list = Arrays.asList(personsItems);
                personList = new ArrayList<Person>(list);

                adapter = new PersonAdapter(this, personList);
                lvPersons.setAdapter(adapter);
                //lvPersons.invalidateViews();
            }
            catch (Exception e) { }
        }

        return true;
    }
}
