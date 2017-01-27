package com.example.sony.sharedpreferencescrud.database;

import android.content.Context;
import android.content.SharedPreferences;

import com.example.sony.sharedpreferencescrud.model.Person;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by Sony on 26.12.2016.
 */

public class CRUDSharedPreferences {
    public static final String PRESF_NAME="CRUD_APP";
    public static final String PERSON_CONSTANT="Person Constant";

    public CRUDSharedPreferences() {super();}
    public void savePerson(Context context, List<Person> persons)
    {
        SharedPreferences preferences;
        SharedPreferences.Editor editor;

        preferences = context.getSharedPreferences(PRESF_NAME, Context.MODE_PRIVATE);
        editor = preferences.edit();

        Gson gson=new Gson();
        String jsonPerson=gson.toJson(persons);

        editor.putString(PERSON_CONSTANT, jsonPerson);

        editor.commit();
    }
    public ArrayList<Person> getPersons(Context context)
    {
        SharedPreferences preferences;
        List<Person> personList;
        preferences =context.getSharedPreferences(PRESF_NAME, Context.MODE_PRIVATE);

        if(preferences.contains(PERSON_CONSTANT))
        {
            String jsonPerson=preferences.getString(PERSON_CONSTANT, null);
            Gson gson=new Gson();
            Person[] personsItems=gson.fromJson(jsonPerson, Person[].class);

            personList= Arrays.asList(personsItems);
            personList =new ArrayList<Person>(personList);
        }else
            return null;
        return (ArrayList<Person>) personList;
    }
    public void addPerson(Context context, Person person){
        List<Person> personList=getPersons(context);
        if(personList==null){
            personList = new ArrayList<Person>();
        }
        personList.add(person);
        savePerson(context, personList);
    }
    public void updatePerson(Context context, Person person)
    {
        ArrayList<Person> personList=getPersons(context);
        ArrayList<Person> ret=new ArrayList<>();
        for (Person p :personList)
        {
            if(p.getId()==person.getId())
                ret.add(person);
            else
            {
                ret.add(p);
            }
        }
        savePerson(context, ret);
    }
    public void dellPerson(Context context, Person person)
    {
        ArrayList<Person> personList=getPersons(context);
        if(personList!=null)
            personList.remove(person);
        savePerson(context, personList);
    }
    public ArrayList<Person> getPerson(Context context, int id)
    {
        List<Person> personList=getPersons(context);
        for (Person p:personList)
        {
            if(p.getId()==id)
            {
                personList=new ArrayList<>();
                personList.add(p);
                break;
            }
        }
        return (ArrayList<Person>) personList;
    }
    public void dellAllPersons(Context context)
    {
        ArrayList<Person> lst=new ArrayList<>();
        savePerson(context, lst);
    }
}
