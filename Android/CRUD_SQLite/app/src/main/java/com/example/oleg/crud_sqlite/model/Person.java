package com.example.oleg.crud_sqlite.model;

import java.io.Serializable;

/**
 * Created by Oleg on 06.01.2017.
 */

public class Person implements Serializable{
    private int id;
    private String mName;
    private String mSurname;
    private String mPhone;
    private String mMail;
    private String mSkype;

    public Person() {
        super();
    }

    public Person(int id, String mName, String mSurname, String mPhone, String mMail, String mSkype) {
        this.id = id;
        this.mName = mName;
        this.mSurname = mSurname;
        this.mPhone = mPhone;
        this.mMail = mMail;
        this.mSkype = mSkype;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getmName() {
        return mName;
    }

    public void setmName(String mName) {
        this.mName = mName;
    }

    public String getmSurname() {
        return mSurname;
    }

    public void setmSurname(String mSurname) {
        this.mSurname = mSurname;
    }

    public String getmPhone() {
        return mPhone;
    }

    public void setmPhone(String mPhone) {
        this.mPhone = mPhone;
    }

    public String getmMail() {
        return mMail;
    }

    public void setmMail(String mMail) {
        this.mMail = mMail;
    }

    public String getmSkype() {
        return mSkype;
    }

    public void setmSkype(String mSkype) {
        this.mSkype = mSkype;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Person person = (Person) o;

        if (id != person.id) return false;
        if (mName != null ? !mName.equals(person.mName) : person.mName != null) return false;
        if (mSurname != null ? !mSurname.equals(person.mSurname) : person.mSurname != null)
            return false;
        if (mPhone != null ? !mPhone.equals(person.mPhone) : person.mPhone != null) return false;
        if (mMail != null ? !mMail.equals(person.mMail) : person.mMail != null) return false;
        return mSkype != null ? mSkype.equals(person.mSkype) : person.mSkype == null;

    }

    @Override
    public int hashCode() {
        int result = id;
        result = 31 * result + (mName != null ? mName.hashCode() : 0);
        result = 31 * result + (mSurname != null ? mSurname.hashCode() : 0);
        result = 31 * result + (mPhone != null ? mPhone.hashCode() : 0);
        result = 31 * result + (mMail != null ? mMail.hashCode() : 0);
        result = 31 * result + (mSkype != null ? mSkype.hashCode() : 0);
        return result;
    }

    @Override
    public String toString() {
        return "Person{" +
                "id=" + id +
                ", mName='" + mName + '\'' +
                ", mSurname='" + mSurname + '\'' +
                ", mPhone='" + mPhone + '\'' +
                ", mMail='" + mMail + '\'' +
                ", mSkype='" + mSkype + '\'' +
                '}';
    }
}
