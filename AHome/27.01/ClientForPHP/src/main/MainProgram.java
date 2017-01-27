package main;

import api.Client;
import api.Person;

public class MainProgram {

	public static void main(String[] args) {
		Client cl = new Client();
		for (Person p : cl.Read()){
			
			System.out.println(p.toString());
		}
	}
}
