package com.example.sony.sqlitecrud.db;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.sony.sqlitecrud.Config;

/**
 * Created by Sony on 06.01.2017.
 */

public class SQLiteDBHelper extends SQLiteOpenHelper
{

    public SQLiteDBHelper(Context context)
    {
        super(context, Config.DB_NAME, null, Config.DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase)
    {
        sqLiteDatabase.execSQL(Config.COMMAND_CREATE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int oldVersion, int newVersion)
    {
        sqLiteDatabase.execSQL(Config.COMMAND_DELETE);
        this.onCreate(sqLiteDatabase);
    }
}
