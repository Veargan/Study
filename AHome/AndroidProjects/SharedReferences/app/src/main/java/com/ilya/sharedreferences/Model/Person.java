package com.ilya.sharedreferences.Model;

/**
 * Created by user on 26.12.2016.
 */
public class Person {
    public int id;
    public String mName;

    public Person() { super(); }

    public Person(int id, String mName) {
        this.id = id;
        this.mName = mName;
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

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Person person = (Person) o;

        if (id != person.id) return false;
        return true;

    }

    @Override
    public int hashCode() {
        int result = id;
        result = 31 * result + mName.hashCode();
        return result;
    }

    @Override
    public String toString() {
        return "Person{" +
                "id=" + id +
                ", mName='" + mName + '\'' +
                '}';
    }
}