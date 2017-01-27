package com.example.oleg.crud_sqlite.database;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.oleg.crud_sqlite.Config;

/**
 * Created by Oleg on 06.01.2017.
 */

public class SQLiteDBHelper extends SQLiteOpenHelper {
    public SQLiteDBHelper (Context context){
        super(context, Config.DB_NAME, null, Config.DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase){
        sqLiteDatabase.execSQL(Config.COMMAND_CREATE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1){
        sqLiteDatabase.execSQL(Config.COMMAND_DELETE);
        this.onCreate(sqLiteDatabase);
    }
}
