package com.kalashnyk.denys.task_16_chat.service;

import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.BitmapFactory;
import android.os.IBinder;
import android.util.Log;

import com.kalashnyk.denys.task_16_chat.R;
import com.kalashnyk.denys.task_16_chat.ui.MainActivity;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
/**
 * Created by User on 03.02.2017.
 */

public class ChatService extends Service {

    String serverName = "";

    SQLiteDatabase chatDB;
    HttpURLConnection httpURLConnection;
    Cursor cursor;
    Thread thread;
    ContentValues newMessCV;
    Long lastTime;

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    public void onStart(Intent intent, int startId) {

        Log.i("chat", "+ ChatService start");

        chatDB = openOrCreateDatabase("chatDB.db",
                Context.MODE_PRIVATE, null);
        chatDB
                .execSQL("CREATE TABLE IF NOT EXISTS chat (_id integer primary key autoincrement, author, client, data, text)");

        Intent iN = new Intent(getApplicationContext(), MainActivity.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP
                | Intent.FLAG_ACTIVITY_SINGLE_TOP);
        PendingIntent pI = PendingIntent.getActivity(getApplicationContext(),
                0, iN, PendingIntent.FLAG_CANCEL_CURRENT);
        Notification.Builder bI = new Notification.Builder(
                getApplicationContext());

        bI.setContentIntent(pI)
                .setSmallIcon(R.mipmap.ic_launcher)
                .setLargeIcon(
                        BitmapFactory.decodeResource(getApplicationContext()
                                .getResources(), R.mipmap.ic_launcher))
                .setAutoCancel(true)
                .setContentTitle(getResources().getString(R.string.app_name))
                .setContentText("working...");

        Notification notification = bI.build();
        startForeground(101, notification);

        startLoop();
    }

    private void startLoop() {

        thread = new Thread(new Runnable() {

            String response, linkParams;

            public void run() {

                while (true) {
                    cursor = chatDB.rawQuery(
                            "SELECT * FROM chat ORDER BY data", null);

                    if (cursor.moveToLast()) {
                        lastTime = cursor.getLong(cursor
                                .getColumnIndex("data"));
                        linkParams = serverName + "/chat.php?action=select&data="
                                + lastTime.toString();
                    } else {
                        linkParams = serverName + "/chat.php?action=select";
                    }

                    cursor.close();
                    try {
                        Log.i("chat",
                                "+ ChatService start connection");

                        httpURLConnection = (HttpURLConnection) new URL(linkParams)
                                .openConnection();
                        httpURLConnection.setReadTimeout(10000);
                        httpURLConnection.setConnectTimeout(15000);
                        httpURLConnection.setRequestMethod("POST");
                        httpURLConnection.setRequestProperty("User-Agent", "Mozilla/5.0");
                        httpURLConnection.setDoInput(true);
                        httpURLConnection.connect();

                    } catch (Exception e) {
                        Log.i("chat", "+ ChatService error: " + e.getMessage());
                    }

                    try {
                        InputStream is = httpURLConnection.getInputStream();
                        BufferedReader br = new BufferedReader(
                                new InputStreamReader(is, "UTF-8"));
                        StringBuilder sb = new StringBuilder();
                        String bfr_st = null;
                        while ((bfr_st = br.readLine()) != null) {
                            sb.append(bfr_st);
                        }

                        Log.i("chat", "+ ChatService - full response from server:\n"
                                + sb.toString());
                        response = sb.toString();
                        response = response.substring(0, response.indexOf("]") + 1);

                        is.close();
                        br.close();

                    } catch (Exception e) {
                        Log.i("chat", "+ ChatService error: " + e.getMessage());
                    } finally {
                        httpURLConnection.disconnect();
                        Log.i("chat",
                                "+ ChatService close connection");
                    }

                    if (response != null && !response.trim().equals("")) {

                        Log.i("chat",
                                "+ ChatService have response in JSON:");

                        try {
                            JSONArray ja = new JSONArray(response);
                            JSONObject jo;

                            Integer i = 0;

                            while (i < ja.length()) {

                                jo = ja.getJSONObject(i);

                                Log.i("chat",
                                        "=================>>> "
                                                + jo.getString("author")
                                                + " | "
                                                + jo.getString("client")
                                                + " | " + jo.getLong("data")
                                                + " | " + jo.getString("text"));

                                newMessCV = new ContentValues();
                                newMessCV.put("author", jo.getString("author"));
                                newMessCV.put("client", jo.getString("client"));
                                newMessCV.put("data", jo.getLong("data"));
                                newMessCV.put("text", jo.getString("text"));

                                chatDB.insert("chat", null, newMessCV);
                                newMessCV.clear();

                                i++;

                                sendBroadcast(new Intent(
                                        "com.kalashnyk.denys.action.UPDATE_ListView"));
                            }
                        } catch (Exception e) {
                            Log.i("chat",
                                    "+ ChatService error inside server:\n"
                                            + e.getMessage());
                        }
                    } else {
                        Log.i("chat",
                                "+ ChatService response haven't JSON");
                    }

                    try {
                        Thread.sleep(15000);
                    } catch (Exception e) {
                        Log.i("chat",
                                "+ ChatService progress error: "
                                        + e.getMessage());
                    }
                }
            }
        });

        thread.setDaemon(true);
        thread.start();

    }
}