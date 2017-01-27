package api;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintStream;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.google.gson.Gson;

public class Client {
	URL url;
	URLConnection con; 
	PrintStream ps;
	public Client() {
	}
	private void Connection(){
		try{
			url = new URL("http://localhost/php.ort.loc/API/PersonDAO_API_JSON.php");
			con = url.openConnection();
			con.setDoOutput(true);
			con.setDoInput(true);
			ps = new PrintStream(con.getOutputStream());
		}
		catch(Exception e){
			e.getMessage();
		}
	}
	private void flush(){
		 try{
			    BufferedReader  reader = new BufferedReader(new InputStreamReader(con.getInputStream()));
		    }
		    catch(Exception e){
		    	e.printStackTrace();
		    }
	}
	
	public List<Person> Read() {
		Connection();
	    ps.print("query=read");
	    ps.close();
	    String jsonString = "";
	    try{
		    BufferedReader  reader = new BufferedReader(new InputStreamReader(con.getInputStream()));
	        jsonString = reader.readLine();
	    }
	    catch(Exception e){
	    	e.printStackTrace();
	    }
	    
	    Gson gson = new Gson();
	    List<Person> list;
	    Person[] personsItems = gson.fromJson(jsonString, Person[].class);

        list = Arrays.asList(personsItems);
        list = new ArrayList<Person>(list);
        System.out.println("Read");
        return list;
	}
	public void Create(Person p){
		Connection();
        String postData = "query=create&id=" + p.getId() + "&firstName=" +
            p.getFirstName() + "&lastName=" + p.getLastName() + "&age=" + p.getAge();
        ps.print(postData);
        ps.close();
        flush();
	    System.out.println("Create");
	}
	public void Update(Person p){
		Connection();
        String postData = "query=update&id=" + p.getId() + "&firstName=" +
            p.getFirstName() + "&lastName=" + p.getLastName() + "&age=" + p.getAge();
        ps.print(postData);
        ps.close();
        flush();
	    System.out.println("Create");
	}
	public void Delete(Person p){
		Connection();
        String postData = "query=delete&id=" + p.getId() + "&firstName=" +
            p.getFirstName() + "&lastName=" + p.getLastName() + "&age=" + p.getAge();
        ps.print(postData);
        ps.close();
        flush();
	    System.out.println("Create");
	}
	
	
}

