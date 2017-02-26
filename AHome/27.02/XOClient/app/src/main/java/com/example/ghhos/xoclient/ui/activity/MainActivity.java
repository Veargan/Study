package com.example.ghhos.xoclient.ui.activity;

import android.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.api.Commander;
import com.example.ghhos.xoclient.api.FragmentManager;
import com.example.ghhos.xoclient.ui.fragments.FragmentLobby;

import org.java_websocket.client.WebSocketClient;
import org.java_websocket.handshake.ServerHandshake;

import java.net.URI;
import java.net.URISyntaxException;

public class MainActivity extends AppCompatActivity {

    private WebSocketClient webSocket;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        InitWebSocket();
        FragmentManager.InitWebSocket(webSocket);


        FragmentTransaction transaction = getFragmentManager().beginTransaction();
        FragmentManager.SetFragmentTransaction(transaction);
        transaction.replace(R.id.main_activity_fragment_placeholder,
                FragmentManager.lobbyFrag);
        transaction.commit();
    }

    public void InitWebSocket(){
        URI uri;
        try {
            uri = new URI("ws://192.168.10.228:8080/");/*10.0.2.2*/
        } catch (URISyntaxException e) {
            e.printStackTrace();
            return;
        }

        webSocket = new WebSocketClient(uri) {
            @Override
            public void onOpen(ServerHandshake serverHandshake) {
                Log.i("Websocket", "Opened");
            }

            @Override
            public void onMessage(String s) {
                final String message = s;
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Commander.listenLoop(message);
                        Log.i("Websocket", message);
                    }
                });
            }

            @Override
            public void onClose(int i, String s, boolean b) {
                Log.i("Websocket", "Closed " + s);
            }

            @Override
            public void onError(Exception e) {
                Log.i("Websocket", "Error " + e.getMessage());
            }
        };
        webSocket.connect();
    }

}
