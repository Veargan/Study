package ghh0stex.persondao_php.database;

import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;

import com.google.gson.Gson;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import ghh0stex.persondao_php.model.Person;

/**
 * Created by GHhos on 25.01.2017.
 */

public class PersonDAO_Net_Http extends AsyncTask<Void, Void, String> {

    @Override
    protected String doInBackground(Void... params) {
        HttpURLConnection urlConnection = null;
        BufferedReader reader = null;

        try {
            URL url = new URL(urlString + query);
            urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");
            urlConnection.connect();

            InputStream inputStream = urlConnection.getInputStream();

            if (inputStream != null) {
                reader = new BufferedReader(new InputStreamReader(inputStream));

                String line;
                if ((line = reader.readLine()) != null) {
                    response = line;
                    return line;
                }
                else {
                    return null;
                }
            }
            else{
                return null;
            }
        }
        catch (IOException e) {
            Log.e("PlaceholderFragment", "Error ", e);
            return null;
        }
        finally{
            if (urlConnection != null) {
                urlConnection.disconnect();
            }
            if (reader != null) {
                try {
                    reader.close();
                } catch (final IOException e) {
                    Log.e("PlaceholderFragment", "Error closing stream", e);
                }
            }
        }
    }

    private String query;
    private String urlString;
    private String response;

    public String getResponse() {
        return response;
    }

    public PersonDAO_Net_Http() {
        response = "";
        query = "";
        urlString = "http://192.168.10.228/php.ort.loc/API/PersonDAO_API_AJAX_JSON.php";
    }

    public void Create(Person person){
        query = "?query=create&id=" + person.getId() + "&firstName=" + person.getFirstName()
                + "&lastName=" + person.getLastName() + "&age=" + person.getAge();
    }

    public void Read(){
        query = "?query=read";
    }

    public void Update(Person person){
        query = "?query=update&id=" + person.getId() + "&firstName=" + person.getFirstName()
                + "&lastName=" + person.getLastName() + "&age=" + person.getAge();
    }

    public void Delete(Person person){
        query = "?query=delete&id=" + person.getId();
    }
}
