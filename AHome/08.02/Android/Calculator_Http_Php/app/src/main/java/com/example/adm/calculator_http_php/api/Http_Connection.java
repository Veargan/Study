package com.example.adm.calculator_http_php.api;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

import com.example.adm.calculator_http_php.R;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

/**
 * Created by adm on 07.02.2017.
 */

public class Http_Connection {

    private String urlString;
    private String urlQuery;
    private View view;

    public Http_Connection(View view, String hostIp){
        this.view = view;
        urlString = "http://" + hostIp + "/calcApi/calculatorAPI.php";
    }

    public void Send(int value1, int value2, String operation){
        urlQuery = "?value1=" + value1 + "&value2=" + value2 + "&operation=" + operation;
        HttpRequest req = new HttpRequest();
        req.execute();
    }

    private class HttpRequest extends AsyncTask<Void, Void, String>{
        @Override
        protected String doInBackground(Void... params) {
            HttpURLConnection urlConnection = null;
            BufferedReader reader = null;
            String line = null;

            try {
                URL url = new URL(urlString + urlQuery);
                urlConnection = (HttpURLConnection) url.openConnection();
                urlConnection.setRequestMethod("GET");
                urlConnection.connect();

                InputStream inputStream = urlConnection.getInputStream();

                if (inputStream != null) {
                    reader = new BufferedReader(new InputStreamReader(inputStream));
                    line = reader.readLine();
                }
            }
            catch (IOException e) {
                Log.e("PlaceholderFragment", "Error ", e);
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

            return line;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            EditText result = (EditText)view.findViewById(R.id.et_result);
            result.setText(s);
        }
    }

}
