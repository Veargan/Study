package com.ilya.sharedreferences.Database;

import android.content.Context;
import android.content.SharedPreferences;

import com.google.gson.Gson;
import com.ilya.sharedreferences.Model.Person;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by user on 26.12.2016.
 */
public class CRUDSharedPreferences {
    public static final String PREFS_NAME = "CRUD_APP";
    public static final String PERSON_CONSTANT = "Person Constant";

    public CRUDSharedPreferences() { super(); }

    public void savePerson(Context context, List<Person> persons) {
        SharedPreferences preferences;
        SharedPreferences.Editor editor;

        preferences = context.getSharedPreferences(PREFS_NAME, context.MODE_PRIVATE);
        editor = preferences.edit();

        Gson gson = new Gson();
        String jsonperson = gson.toJson(persons);

        editor.putString(PERSON_CONSTANT, jsonperson);

        editor.commit();
    }

    public ArrayList<Person> getPerson(Context context) { // должны sharedoreferences, взять json запулить , привести массик к листу и привести к arraylist
        SharedPreferences preferences;
        List<Person> personList;

        preferences = context.getSharedPreferences(PREFS_NAME, context.MODE_PRIVATE); // название базы данных

        if (preferences.contains(PERSON_CONSTANT)) { // эта строка, содержит ли константу ключ по которому хочу получить значений
            String jsonPerson = preferences.getString(PERSON_CONSTANT, null); // если да, создаю строку и свой преференс и забираю по ключу значение
            Gson gson = new Gson();
            Person[] personsItems = gson.fromJson(jsonPerson, Person[].class); // оборачиваю строку json в массив по типу Person. хочу получить согласно Person array

            personList = Arrays.asList(personsItems); // привожу массив к листу
            personList = new ArrayList<Person>(personList); // привожу List к ArrayList
        } else
            return null;

        return (ArrayList<Person>) personList;
    }
}