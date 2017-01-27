package com.example.sony.sharedpreferencescrud.model;

import java.io.Serializable;

/**
 * Created by Sony on 26.12.2016.
 */

public class Person implements Serializable{
    public static Person selectedPerson;
    private int id;
    private String mName;
    private String mSurname;
    private String mPhoneNumber;
    private String mMail;
    private String mSkype;

    public Person() {
        super();
    }

    public Person(int id, String mName, String mSurname, String mPhoneNumber, String mMail, String mSkype) {
        this.id = id;
        this.mName = mName;
        this.mSurname = mSurname;
        this.mPhoneNumber = mPhoneNumber;
        this.mMail = mMail;
        this.mSkype = mSkype;
    }

    public Person(String mName, String mSurname, String mPhoneNumber, String mMail, String mSkype) {
        this.mName = mName;
        this.mSurname = mSurname;
        this.mPhoneNumber = mPhoneNumber;
        this.mMail = mMail;
        this.mSkype = mSkype;
    }

    public String getmName() {
        return mName;
    }

    public void setmName(String mName) {
        this.mName = mName;
    }

    public String getmSkype() {
        return mSkype;
    }

    public void setmSkype(String mSkype) {
        this.mSkype = mSkype;
    }

    public String getmMail() {
        return mMail;
    }

    public void setmMail(String mMail) {
        this.mMail = mMail;
    }

    public String getmPhoneNumber() {
        return mPhoneNumber;
    }

    public void setmPhoneNumber(String mPhoneNumber) {
        this.mPhoneNumber = mPhoneNumber;
    }

    public String getmSurname() {
        return mSurname;
    }

    public void setmSurname(String mSurname) {
        this.mSurname = mSurname;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "Person{" +
                "id=" + id +
                ", mName='" + mName + '\'' +
                ", mSurname='" + mSurname + '\'' +
                ", mPhoneNumber='" + mPhoneNumber + '\'' +
                ", mMail='" + mMail + '\'' +
                ", mSkype='" + mSkype + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o)
            return true;
        if (o == null || getClass() != o.getClass())
            return false;

        Person person = (Person) o;

        if (id != person.id) {
            return false;
        }
        return true;
    }

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + id;
        return result;
    }
}
