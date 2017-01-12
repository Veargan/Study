package com.example.oleg.sharedpreferencescrud.database;

import android.content.Context;
import android.content.SharedPreferences;

import com.example.oleg.sharedpreferencescrud.Model.Person;
import com.google.gson.Gson;

import java.sql.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by Oleg on 26.12.2016.
 */

public class CRUDSharedPreferences {
    public static final String PREFS_NAME = "CRUD_APP";
    public static final String PERSON_CONSTANT = "Person Constant"; // кладу данные и вынимаю (ключ)

    public CRUDSharedPreferences() {
        super();
    }

    public void addPerson(Context context, Person person) {
        List<Person> personList = getPerson(context);
        if (personList == null){
            personList = new ArrayList<Person>();
        }
        personList.add(person);
        savePerson(context, personList);
    }

    public void deletePerson(Context context, Person person) {
        ArrayList<Person> personList = getPerson(context);
        if (personList != null) {
            personList.remove(person);
            savePerson(context, personList);
        }
    }

    public void savePerson(Context  context, List<Person> persons){
        SharedPreferences preferences;
        SharedPreferences.Editor editor; // создание эдитора. Эдитор редактирует базу данных, именно он изменяет бд

        preferences = context.getSharedPreferences(PREFS_NAME, context.MODE_PRIVATE);
        editor = preferences.edit();

        Gson gson = new Gson();
        String jsonPerson = gson.toJson(persons);

        editor.putString(PERSON_CONSTANT,jsonPerson); // кладу по ключу-значению

        editor.commit();
    }

    public ArrayList<Person> getPerson(Context context){
        SharedPreferences preferences;
        List<Person> personList;

        preferences = context.getSharedPreferences(PREFS_NAME, Context.MODE_PRIVATE);

        if (preferences.contains(PERSON_CONSTANT)){
            String jsonPerson = preferences.getString(PERSON_CONSTANT,null);
            Gson gson = new Gson();
            Person[] personItems = gson.fromJson(jsonPerson, Person[].class);

            personList = Arrays.asList(personItems);
            personList = new ArrayList<Person>(personList);
        }
        else
            return null;

        return (ArrayList<Person>) personList;
        }
}