package com.example.ort.chatwebsocket.ui;

import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.example.ort.chatwebsocket.R;
import com.example.ort.chatwebsocket.ui.api.Request;
import com.google.gson.Gson;

import org.java_websocket.client.WebSocketClient;
import org.java_websocket.handshake.ServerHandshake;

import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;

import static com.example.ort.chatwebsocket.ui.MainActivity.context;
import static com.example.ort.chatwebsocket.ui.Websockets.mWebSocketClient;

public class MainActivity extends AppCompatActivity {

    public static ArrayList<Fragment> fragments;
    static Context context;


    public static Handler UIHandler;

    static
    {
        UIHandler = new Handler(Looper.getMainLooper());
    }
    public static void runOnUI(Runnable runnable) {
        UIHandler.post(runnable);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        fragments = new ArrayList<Fragment>();
        context = this;
        FragmentRA fragmentRA = new FragmentRA();
        FragmentLobby fragmentLobby = new FragmentLobby();
        FragmentRoom fragmentRoom = new FragmentRoom();
        FragementReg fragmentReg = new FragementReg();
        fragments.add(fragmentRA);
        fragments.add(fragmentLobby);
        fragments.add(fragmentRoom);
        fragments.add(fragmentReg);

        //FragmentLobby fragLobby = new FragmentLobby();
        FragmentTransaction transaction = getFragmentManager().beginTransaction();
        transaction.replace(R.id.main_activity_fragment_placeholder, fragments.get(0));
        transaction.commit();
    }

    public static void connectWebSocket(final String name, final String password, final String mail, final String param) {
        URI uri;
        final Gson gson = new Gson();

        try {
            uri = new URI("ws://10.0.2.2:8888/");
        } catch (URISyntaxException e) {
            e.printStackTrace();
            return;
        }

        mWebSocketClient = new WebSocketClient(uri) {
            @Override
            public void onOpen(ServerHandshake serverHandshake) {
                Log.i("Websocket", "Opened");
                Request modelObject = new Request("auth","",name + "," + password + "," + mail +"," + param,"");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
            }

            @Override
            public void onMessage(String s) {
                final String message = s;
                runOnUI(new Runnable() {
                    @Override
                    public void run() {
                        Log.i("Websocket", message);
                        try {
                            Listener(message,context);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
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
        mWebSocketClient.connect();
    }

    private static void Listener(String message, Context context) throws InterruptedException {
        Request req = new Gson().fromJson(message, Request.class);
        switch(req.modul)
        {
            case "ok":
                FragmentLobby g = (FragmentLobby)fragments.get(1);
                String[] str = req.data.split(",");
                g.CreateLobby(str[0]);
                break;
            case "notok":
                if(req.data.equals("reg"))
                {
                    Toast.makeText(context, "User already exist",
                            Toast.LENGTH_LONG).show();
                }
                if(req.data.equals("auth"))
                {
                    Toast.makeText(context, "Incorrect name or password",
                            Toast.LENGTH_LONG).show();
                }
                break;
            case "refresh":
                FragmentLobby er = (FragmentLobby)fragments.get(1);
                String[] splitrooms = req.data.split("\\.");
                er.SetRooms(splitrooms, context);
                break;
            case "refreshclients":
                FragmentLobby erc = (FragmentLobby)fragments.get(1);
                String[] splitclients = req.data.split("\\.");
                erc.SetClients(splitclients, context);
                break;
            case "enter":
                FragmentRoom rf = (FragmentRoom)fragments.get(2);
                rf.CreateRoom(req.data, req.command, context);
                break;
            case "message":
                FragmentRoom ms = (FragmentRoom)fragments.get(2);
                ms.SetMessage(req.data, context);
                break;
            case "leave":
                FragmentRoom lv = (FragmentRoom)fragments.get(2);
                lv.Leave();
                break;
            case "wrongroom":
                Toast.makeText(context, "Error, room " + req.data + " has already been created.", Toast.LENGTH_LONG)
                        .show();
                break;
            case "youbanned":
                FragmentRoom yb = (FragmentRoom)fragments.get(2);
                yb.SetMessage(req.data, context);
                break;
            case "alreadyenter":
                Toast.makeText(context, "You are already logged into this room.", Toast.LENGTH_LONG)
                        .show();
                break;
            case "bancreate":
                Toast.makeText(context, "You have been banned for " + req.data, Toast.LENGTH_LONG)
                        .show();
                break;
            case "passive":
                FragmentLobby ps = (FragmentLobby)fragments.get(1);
                ps.Passive(req.command, req.data, req.time, context);
                break;
            case "newpass":
                Toast.makeText(context, "Password changed", Toast.LENGTH_LONG)
                        .show();
                break;
            case "wrongnewpass":
                Toast.makeText(context, "Incorrect old password", Toast.LENGTH_LONG)
                        .show();
                break;
        }

    }
}
