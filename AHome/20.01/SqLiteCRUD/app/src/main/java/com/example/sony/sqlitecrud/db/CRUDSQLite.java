package com.example.sony.sqlitecrud.db;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.sony.sqlitecrud.Config;
import com.example.sony.sqlitecrud.model.Person;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Sony on 06.01.2017.
 */

public class CRUDSQLite
{
    SQLiteDBHelper sqLiteDBHelper;
    public CRUDSQLite(Context context)
    {
        this.sqLiteDBHelper=new SQLiteDBHelper(context);
    }

    public ArrayList<Person> getAllPersons()
    {
        ArrayList<Person> persons =new ArrayList<>();
        SQLiteDatabase db = sqLiteDBHelper.getWritableDatabase();
        Cursor cursor=db.rawQuery(Config.COMMAND_SELECTED, null);
        Person person =null;
        if(cursor.moveToFirst())
        {
            do {
                person = new Person();
                person.setId(Integer.parseInt(cursor.getString(0)));
                person.setmName(cursor.getString(1));
                person.setmSurname(cursor.getString(2));
                person.setmPhoneNumber(cursor.getString(3));
                person.setmMail(cursor.getString(4));
                person.setmSkype(cursor.getString(5));
                persons.add(person);
            } while (cursor.moveToNext());
        }
        return persons;
    }
    public ArrayList<Person> getPerson(int id)
    {
        ArrayList<Person> persons=new ArrayList<>();
        SQLiteDatabase db = sqLiteDBHelper.getWritableDatabase();
        Cursor cursor=db.query(Config.TABLE_PERSON,
        null,
        Config.KEY_ID + " = "+id,
        null,
        null,
        null,
        null,
        null);
        if(cursor!=null)

            cursor.moveToFirst();
        Person person = new Person();
        person.setId(Integer.parseInt(cursor.getString(0)));
        person.setmName(cursor.getString(1));
        person.setmSurname(cursor.getString(2));
        person.setmPhoneNumber(cursor.getString(3));
        person.setmMail(cursor.getString(4));
        person.setmSkype(cursor.getString(5));
        persons.add(person);
        db.close();
        return persons;
    }
    public void addperson (Context context,Person person)
    {
        SQLiteDatabase db = sqLiteDBHelper.getWritableDatabase();
        ContentValues values = new ContentValues();

        //values.put(Config.KEY_ID,person.getId());
        values.put(Config.KEY_NAME,person.getmName());
        values.put(Config.KEY_SURNAME,person.getmSurname());
        values.put(Config.KEY_PHONE,person.getmPhoneNumber());
        values.put(Config.KEY_MAIL,person.getmMail());
        values.put(Config.KEY_SKYPE,person.getmSkype());
        db.insert(Config.TABLE_PERSON, null, values);
        db.close();
    }
    public void deleteAllPerson()
    {
        SQLiteDatabase db=sqLiteDBHelper.getWritableDatabase();
        db.delete(Config.TABLE_PERSON, null, null);
        db.close();
    }
    public void deletePerson(int id)
    {
        SQLiteDatabase db=sqLiteDBHelper.getWritableDatabase();
        db.delete(Config.TABLE_PERSON, Config.KEY_ID+" = "+id, null);
        db.close();
    }
    public void updatePerson(Person p)
    {
        SQLiteDatabase db=sqLiteDBHelper.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(Config.KEY_NAME,p.getmName());
        values.put(Config.KEY_SURNAME,p.getmSurname());
        values.put(Config.KEY_PHONE,p.getmPhoneNumber());
        values.put(Config.KEY_MAIL,p.getmMail());
        values.put(Config.KEY_SKYPE,p.getmSkype());
        db.update(Config.TABLE_PERSON, values, Config.KEY_ID+" = "+p.getId(), null);
    }
}
