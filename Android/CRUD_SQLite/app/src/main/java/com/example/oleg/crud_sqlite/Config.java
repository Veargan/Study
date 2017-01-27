package com.example.oleg.crud_sqlite;

/**
 * Created by Oleg on 06.01.2017.
 */

public class Config {
    public static final String DB_NAME = "Person Data Base";

    public static final String TABLE_PERSON = "Person";

    public static final String KEY_ID = "Id";
    public static final String KEY_NAME = "Name";
    public static final String KEY_SURNAME = "Surname";
    public static final String KEY_PHONE = "Phone";
    public static final String KEY_MAIL = "Mail";
    public static final String KEY_SKYPE = "Skype";

    public static final String[] COLUMNS = {KEY_ID, KEY_NAME, KEY_SURNAME, KEY_PHONE, KEY_MAIL, KEY_SKYPE};

    public static final String COMMAND_CREATE = "CREATE TABLE "
            + TABLE_PERSON + " ("
            + KEY_ID + " INTEGER PRIMARY KEY, "
            + KEY_NAME + " TEXT, "
            + KEY_SURNAME + " TEXT, "
            + KEY_PHONE + " TEXT, "
            + KEY_MAIL + " TEXT, "
            + KEY_SKYPE + " TEXT"
            + ");";

    public static final String COMMAND_DELETE = "DROP TABLE IF EXISTS " + TABLE_PERSON;
    public static final String COMMAND_SELECT  = "SELECT * FROM PERSON " + TABLE_PERSON;
    public static final int DB_VERSION = 5012017;

}
