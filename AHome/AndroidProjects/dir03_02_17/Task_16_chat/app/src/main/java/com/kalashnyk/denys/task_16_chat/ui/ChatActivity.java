package com.kalashnyk.denys.task_16_chat.ui;

import android.annotation.SuppressLint;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import com.kalashnyk.denys.task_16_chat.R;

import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

/**
 * Created by User on 03.02.2017.
 */

public class ChatActivity extends AppCompatActivity {

    String serverName = "";

    ListView listView;
    EditText editText;
    Button button;
    SQLiteDatabase chatDB;
    String author, client;
    INSERTtoChat inserTtoChat;
    UpdateReceiver updateReceiver;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chat);

        Intent intent = getIntent();
        author = intent.getStringExtra("author");
        client = intent.getStringExtra("client");

        Log.i("chat", "+ ChatActivity - открыт author = " + author
                + " | client = " + client);

        listView = (ListView) findViewById(R.id.list_view_chat);
        editText = (EditText) findViewById(R.id.et_put_message);
        button = (Button) findViewById(R.id.btn_send_message);

        chatDB = openOrCreateDatabase("chatDB.db",
                Context.MODE_PRIVATE, null);
        chatDB
                .execSQL("CREATE TABLE IF NOT EXISTS chat (_id integer primary key autoincrement, author, client, data, text)");

        updateReceiver = new UpdateReceiver();
        registerReceiver(updateReceiver, new IntentFilter(
                "com.kalashnyk.denys.action.UPDATE_ListView"));

        createListView();
    }

    @SuppressLint("SimpleDateFormat")
    public void createListView() {

        Cursor cursor = chatDB.rawQuery(
                "SELECT * FROM chat WHERE author = '" + author
                        + "' OR author = '" + client + "' ORDER BY data", null);
        if (cursor.moveToFirst()) {

            ArrayList<HashMap<String, Object>> mList = new ArrayList<HashMap<String, Object>>();
            HashMap<String, Object> hm;

            do {
                if (cursor.getString(cursor.getColumnIndex("author")).equals(
                        author)
                        && cursor.getString(cursor.getColumnIndex("client"))
                        .equals(client)) {

                    hm = new HashMap<>();
                    hm.put("author", author);
                    hm.put("client", "");
                    hm.put("list_client", "");
                    hm.put("list_client_time", "");
                    hm.put("list_author",
                            cursor.getString(cursor.getColumnIndex("text")));
                    hm.put("list_author_time", new SimpleDateFormat(
                            "HH:mm - dd.MM.yyyy").format(new Date(cursor
                            .getLong(cursor.getColumnIndex("data")))));
                    mList.add(hm);

                }

                if (cursor.getString(cursor.getColumnIndex("author")).equals(
                        client)
                        && cursor.getString(cursor.getColumnIndex("client"))
                        .equals(author)) {

                    hm = new HashMap<>();
                    hm.put("author", "");
                    hm.put("client", client);
                    hm.put("list_author", "");
                    hm.put("list_author_time", "");
                    hm.put("list_client",
                            cursor.getString(cursor.getColumnIndex("text")));
                    hm.put("list_client_time", new SimpleDateFormat(
                            "HH:mm - dd.MM.yyyy").format(new Date(cursor
                            .getLong(cursor.getColumnIndex("data")))));
                    mList.add(hm);

                }

            } while (cursor.moveToNext());

            SimpleAdapter adapter = new SimpleAdapter(getApplicationContext(),
                    mList, R.layout.item_chat, new String[] { "list_author",
                    "list_author_time", "list_client",
                    "list_client_time", "author", "client" },
                    new int[] { R.id.list_author, R.id.list_author_time,
                            R.id.list_client, R.id.list_client_time,
                            R.id.author, R.id.client });

            listView.setAdapter(adapter);
            cursor.close();

        }

        Log.i("chat",
                "+ ChatActivity reload chat");

    }

    public void send(View v) {

        if (!editText.getText().toString().trim().equals("")) {

            button.setEnabled(false);

            inserTtoChat = new INSERTtoChat();
            inserTtoChat.execute();

        } else {
            editText.setText("");
        }
    }

    private class INSERTtoChat extends AsyncTask<Void, Void, Integer> {

        HttpURLConnection httpURLConnection;
        Integer res;

        protected Integer doInBackground(Void... params) {

            try {

                String post_url = serverName
                        + "/chat.php?action=insert&author="
                        + URLEncoder.encode(author, "UTF-8")
                        + "&client="
                        + URLEncoder.encode(client, "UTF-8")
                        + "&text="
                        + URLEncoder.encode(editText.getText().toString().trim(),
                        "UTF-8");

                Log.i("chat",
                        "+ ChatActivity send to server new message: "
                                + editText.getText().toString().trim());

                URL url = new URL(post_url);
                httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(10000);
                httpURLConnection.setRequestMethod("POST");
                httpURLConnection.setRequestProperty("User-Agent", "Mozilla/5.0");
                httpURLConnection.connect();

                res = httpURLConnection.getResponseCode();
                Log.i("chat", "+ ChatActivity response from server (200 - OK): "
                        + res.toString());

            } catch (Exception e) {
                Log.i("chat",
                        "+ ChatActivity connection exception: " + e.getMessage());

            } finally {
                httpURLConnection.disconnect();
            }
            return res;
        }

        protected void onPostExecute(Integer result) {

            try {
                if (result == 200) {
                    Log.i("chat", "+ ChatActivity message send successfully.");
                    editText.setText("");
                }
            } catch (Exception e) {
                Log.i("chat", "+ ChatActivity error sending message:\n"
                        + e.getMessage());
                Toast.makeText(getApplicationContext(),
                        "error sending message", Toast.LENGTH_SHORT).show();
            } finally {
                button.setEnabled(true);
            }
        }
    }

    public class UpdateReceiver extends BroadcastReceiver {
        @Override
        public void onReceive(Context context, Intent intent) {
            Log.i("chat",
                    "+ ChatActivity receiver get message, reload ListView");
            createListView();
        }
    }

    public void onBackPressed() {
        Log.i("chat", "+ ChatActivity close");
        unregisterReceiver(updateReceiver);
        finish();
    }
}
