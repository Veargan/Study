package com.kalashnyk.denys.task_16_chat.ui;

import android.content.Context;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import com.kalashnyk.denys.task_16_chat.R;
import com.kalashnyk.denys.task_16_chat.service.ChatService;

import java.net.HttpURLConnection;
import java.net.URL;

public class MainActivity extends AppCompatActivity {

    // ИМЯ СЕРВЕРА (url зарегистрированного нами сайта)
    // например http://l29340eb.bget.ru
    String server_name = "http://l29340eb.bget.ru";

    Spinner spinnerAuthor, spinnerClient;
    String author, client;
    Button openChatBtn, openChatReverceBtn, deleteServerChat;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Log.i("chat", "+ MainActivity - запуск приложения");

        openChatBtn = (Button) findViewById(R.id.btn_open_chat);
        openChatReverceBtn = (Button) findViewById(R.id.btn_open_chat_reverce);
        deleteServerChat = (Button) findViewById(R.id.delete_server_chat);

        this.startService(new Intent(this, ChatService.class));

        spinnerAuthor = (Spinner) findViewById(R.id.spinner_author);
        spinnerClient = (Spinner) findViewById(R.id.spinner_client);

        spinnerAuthor.setAdapter(new ArrayAdapter<String>(this,
                android.R.layout.simple_spinner_item, new String[] { "Петя",
                "Вася", "Коля", "Андрей", "Сергей", "Оля", "Лена",
                "Света", "Марина", "Наташа" }));
        spinnerClient.setAdapter(new ArrayAdapter<String>(this,
                android.R.layout.simple_spinner_item, new String[] { "Петя",
                "Вася", "Коля", "Андрей", "Сергей", "Оля", "Лена",
                "Света", "Марина", "Наташа" }));
        spinnerClient.setSelection(5);

        openChatBtn.setText("Open Chat: "
                + spinnerAuthor.getSelectedItem().toString() + " > "
                + spinnerClient.getSelectedItem().toString());
        openChatReverceBtn.setText("Open Chat: "
                + spinnerClient.getSelectedItem().toString() + " > "
                + spinnerAuthor.getSelectedItem().toString());

        spinnerAuthor
                .setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent,
                                               View itemSelected, int selectedItemPosition,
                                               long selectedId) {

                        author = spinnerAuthor.getSelectedItem().toString();

                        openChatBtn.setText("Open Chat: "
                                + spinnerAuthor.getSelectedItem().toString()
                                + " > "
                                + spinnerClient.getSelectedItem().toString());
                        openChatReverceBtn.setText("Open Chat: "
                                + spinnerClient.getSelectedItem().toString()
                                + " > "
                                + spinnerAuthor.getSelectedItem().toString());
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                    }
                });

        spinnerClient
                .setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent,
                                               View itemSelected, int selectedItemPosition,
                                               long selectedId) {

                        client = spinnerClient.getSelectedItem().toString();

                        openChatBtn.setText("Open Chat: "
                                + spinnerAuthor.getSelectedItem().toString()
                                + " > "
                                + spinnerClient.getSelectedItem().toString());
                        openChatReverceBtn.setText("Open Chat: "
                                + spinnerClient.getSelectedItem().toString()
                                + " > "
                                + spinnerAuthor.getSelectedItem().toString());
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                    }
                });
    }

    public void openChat(View v) {

        if (author.equals(client)) {
            Toast.makeText(this, "author = client !", Toast.LENGTH_SHORT)
                    .show();
        } else {
            Intent intent = new Intent(MainActivity.this, ChatActivity.class);
            intent.putExtra("author", author);
            intent.putExtra("client", client);
            startActivity(intent);
        }
    }

    public void openChatReverce(View v) {
        if (author.equals(client)) {
            Toast.makeText(this, "author = client !", Toast.LENGTH_SHORT)
                    .show();
        } else {
            Intent intent = new Intent(MainActivity.this, ChatActivity.class);
            intent.putExtra("author", client);
            intent.putExtra("client", author);
            startActivity(intent);
        }
    }

    public void deleteServerChats(View v) {

        Log.i("chat", "+ MainActivity request delete shat from server");

        deleteServerChat.setEnabled(false);
        deleteServerChat.setText("Request send. Wait...");

        DELETEfromChat delete_from_chat = new DELETEfromChat();
        delete_from_chat.execute();
    }

    public void deleteLocalChats(View v) {

        Log.i("chat", "+ MainActivity delete chat from device");

        SQLiteDatabase chatDB;
        chatDB = openOrCreateDatabase("chatDB.db",
                Context.MODE_PRIVATE, null);
        chatDB.execSQL("drop table chat");
        chatDB
                .execSQL("CREATE TABLE IF NOT EXISTS chat (_id integer primary key autoincrement, author, client, data, text)");

        Toast.makeText(getApplicationContext(),
                "chat has been deleted inside this device", Toast.LENGTH_SHORT).show();
    }

    private class DELETEfromChat extends AsyncTask<Void, Void, Integer> {

        Integer res;
        HttpURLConnection conn;

        protected Integer doInBackground(Void... params) {

            try {
                URL url = new URL(server_name + "/chat.php?action=delete");
                conn = (HttpURLConnection) url.openConnection();
                conn.setConnectTimeout(10000);
                conn.setRequestMethod("POST");
                conn.setRequestProperty("User-Agent", "Mozilla/5.0");
                conn.connect();
                res = conn.getResponseCode();
                Log.i("chat", "+ MainActivity response from server (200 = OK): "
                        + res.toString());

            } catch (Exception e) {
                Log.i("chat",
                        "+ MainActivity response from server, ERROR: "
                                + e.getMessage());
            } finally {
                conn.disconnect();
            }

            return res;
        }

        protected void onPostExecute(Integer result) {

            try {
                if (result == 200) {
                    Toast.makeText(getApplicationContext(),
                            "Chat has been deleted inside server!", Toast.LENGTH_SHORT)
                            .show();
                }
            } catch (Exception e) {
                Toast.makeText(getApplicationContext(),
                        "Request ERROR", Toast.LENGTH_SHORT)
                        .show();
            } finally {
                deleteServerChat.setEnabled(true);
                deleteServerChat.setText("Delete all chats inside server!");
            }
        }
    }

    public void onBackPressed() {
        Log.i("chat", "+ MainActivity app close");
        finish();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.action_list_person) {
            followToListActivity();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private void followToListActivity() {
        Intent intent = new Intent(MainActivity.this, ChatActivity.class);
        startActivity(intent);
    }
}
