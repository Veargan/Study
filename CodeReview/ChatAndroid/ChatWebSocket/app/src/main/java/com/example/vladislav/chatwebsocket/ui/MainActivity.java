package com.example.vladislav.chatwebsocket.ui;



import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.example.vladislav.chatwebsocket.R;
import com.example.vladislav.chatwebsocket.ui.api.Request;
import com.google.gson.Gson;

import org.java_websocket.client.WebSocketClient;
import org.java_websocket.handshake.ServerHandshake;

import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;

import static com.example.vladislav.chatwebsocket.ui.MainActivity.context;
import static com.example.vladislav.chatwebsocket.ui.Websockets.mWebSocketClient;

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
            uri = new URI("ws://192.168.7.101:1488/");
//            uri = new URI("ws://192.168.1.69:1488/");
        } catch (URISyntaxException e) {
            e.printStackTrace();
            return;
        }

        mWebSocketClient = new WebSocketClient(uri) {
            @Override
            public void onOpen(ServerHandshake serverHandshake) {
                Log.i("Websocket", "Opened");
                String message = name + "^" + password + "^0^auth";
//                Request modelObject = new Request("auth","",name + "," + password + "," + mail +"," + param,"");
//                String json = gson.toJson(modelObject);
                mWebSocketClient.send(message);
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

    private static void Listener(String output, Context context) throws InterruptedException {
//        Request req = new Gson().fromJson(message, Request.class);
        String[] message = output.split("^");
        switch(message[0])
        {
            case "success":
                FragmentLobby g = (FragmentLobby)fragments.get(1);
//                String[] str = req.data.split(",");
                g.CreateLobby();
                break;
            case "authfail":
                Toast.makeText(context, "Invalid login or password", Toast.LENGTH_LONG).show();
                break;
            case "regfail":
                Toast.makeText(context, "This username already exists. Choose another name!", Toast.LENGTH_LONG).show();
                break;
            case "refresh":
                FragmentLobby er = (FragmentLobby)fragments.get(1);
//                String[] splitrooms = req.data.split("\\.");
                ArrayList<String> splitrooms = new ArrayList<String>();
                for (int i = 1; i < message.length; i++) {
                    if (message[i] != "") {
                        int j = 0;
//                        splitrooms[j] = message[i];
                        splitrooms.add(j, message[i]);
                    }
                }
                er.SetRooms((String[]) splitrooms.toArray(), context);
                break;
            case "refreshclients":
                FragmentLobby erc = (FragmentLobby)fragments.get(1);
//                String[] splitclients = req.data.split("\\.");
                ArrayList<String> splitclients = new ArrayList<String>();
                for (int i = 1; i < message.length; i++) {
                    if (message[i] != "") {
                        int j = 0;
//                        splitrooms[j] = message[i];
                        splitclients.add(j, message[i]);
                    }
                }
                erc.SetClients((String[]) splitclients.toArray(), context);
                break;
//            case "enter":
//                FragmentRoom rf = (FragmentRoom)fragments.get(2);
//                rf.CreateRoom(req.data, req.command, context);
//                break;
//            case "message":
//                FragmentRoom ms = (FragmentRoom)fragments.get(2);
//                ms.SetMessage(req.data, context);
//                break;
//            case "leave":
//                FragmentRoom lv = (FragmentRoom)fragments.get(2);
//                lv.Leave();
//                break;
//            case "wrongroom":
//                Toast.makeText(context, "Error, room " + req.data + " has already been created.", Toast.LENGTH_LONG)
//                        .show();
//                break;
//            case "youbanned":
//                FragmentRoom yb = (FragmentRoom)fragments.get(2);
//                yb.SetMessage(req.data, context);
//                break;
            case "alreadyenter":
                Toast.makeText(context, "You are already logged into this room.", Toast.LENGTH_LONG)
                        .show();
                break;
//            case "bancreate":
//                Toast.makeText(context, "You have been banned for " + req.data, Toast.LENGTH_LONG)
//                        .show();
//                break;
//            case "passive":
//                FragmentLobby ps = (FragmentLobby)fragments.get(1);
//                ps.Passive(req.command, req.data, req.time, context);
//                break;
//            case "newpass":
//                Toast.makeText(context, "Password changed", Toast.LENGTH_LONG)
//                        .show();
//                break;
            case "wrongnewpass":
                Toast.makeText(context, "Incorrect old password", Toast.LENGTH_LONG)
                        .show();
                break;
        }

    }
}
