package com.example.oleg.crud_sqlite.database;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.oleg.crud_sqlite.Config;
import com.example.oleg.crud_sqlite.model.Person;

import java.util.ArrayList;

/**
 * Created by Oleg on 06.01.2017.
 */

public class CRUDSQLite {

    SQLiteDBHelper sqLiteDBHelper;

    public CRUDSQLite(Context context){

        this.sqLiteDBHelper = new SQLiteDBHelper(context);
    }

    public ArrayList<Person> getAllPersons(){

        ArrayList<Person> persons = new ArrayList<>();
        SQLiteDatabase db = sqLiteDBHelper.getWritableDatabase();
        Cursor cursor = db.rawQuery(Config.COMMAND_SELECT, null);
        Person person = null;

    if (cursor.moveToFirst())
    {
        do{
            person = new Person();
            person.setId(Integer.parseInt(cursor.getString(0)));
            person.setmName(cursor.getString(1));
            person.setmSurname(cursor.getString(2));
            person.setmPhone(cursor.getString(3));
            person.setmMail(cursor.getString(4));
            person.setmSkype(cursor.getString(5));
            persons.add(person);}
            while (cursor.moveToNext());
        }
        return persons;
    }
}
