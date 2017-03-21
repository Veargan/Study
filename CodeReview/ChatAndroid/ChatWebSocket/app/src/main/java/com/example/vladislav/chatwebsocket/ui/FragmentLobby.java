package com.example.vladislav.chatwebsocket.ui;

import android.app.AlertDialog;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.Spannable;
import android.text.SpannableStringBuilder;
import android.text.style.ForegroundColorSpan;
import android.text.style.StyleSpan;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.vladislav.chatwebsocket.R;
import com.example.vladislav.chatwebsocket.ui.api.MyAdapter;
import com.example.vladislav.chatwebsocket.ui.api.Request;
import com.example.vladislav.chatwebsocket.ui.api.Rooms;
import com.google.gson.Gson;

import java.util.ArrayList;

import static com.example.vladislav.chatwebsocket.ui.MainActivity.context;
import static com.example.vladislav.chatwebsocket.ui.MainActivity.fragments;
import static com.example.vladislav.chatwebsocket.ui.Websockets.mWebSocketClient;

/**
 * Created by Vladislav on 26.02.2017.
 */

public class FragmentLobby extends Fragment {

    Button bLogout;
    Button bChange;
    Button bCreate;
    Button bEnter;
    Button bRefreshrooms;
    Button bRefreshclients;
    Button bPrivate;
    Button bBan;
    Button bUnban;

    TextView tvName;
    ListView lvRooms;
    ListView lvClients;

    EditText input;
    EditText inputban;

    boolean bban = false;
    boolean bunban = false;

    String roomname;
    String username;
    int lastposition;
    int lastpositionuser;
    String name = "";

    AlertDialog.Builder ad;
    AlertDialog.Builder ban;
    AlertDialog.Builder unban;

    final Gson gson = new Gson();

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_lobby, container, false);



        lastposition = -1;
        lastpositionuser = -1;
        input = new EditText(MainActivity.context);
        inputban = new EditText(MainActivity.context);
        bLogout = (Button) view.findViewById(R.id.fragment_lobby_bLogout);
        bChange = (Button) view.findViewById(R.id.fragment_lobby_bChange);
        bCreate = (Button) view.findViewById(R.id.fragment_lobby_bCreate);
        bEnter = (Button) view.findViewById(R.id.fragment_lobby_bEnter);
        bRefreshrooms = (Button) view.findViewById(R.id.fragment_lobby_bRefreshrooms);
        bRefreshclients = (Button) view.findViewById(R.id.fragment_lobby_bRefreshclients);
        bPrivate = (Button) view.findViewById(R.id.fragment_lobby_bPrivate);
        bBan = (Button) view.findViewById(R.id.fragment_lobby_bBan);
        bUnban = (Button) view.findViewById(R.id.fragment_lobby_bUnban);
        tvName = (TextView) view.findViewById(R.id.fragment_lobby_name);

        tvName.setText(name);

        if(bban == true && bunban == true)
        {
            bBan.setVisibility(View.VISIBLE);
            bUnban.setVisibility(View.VISIBLE);
        }
        else
        {
            bBan.setVisibility(View.INVISIBLE);
            bUnban.setVisibility(View.INVISIBLE);
        }


        SetCreateDlg();
        SetBanDlg();
        SetUnbanDlg();

        final AlertDialog alertd = ad.create();
        final AlertDialog alertdban = ban.create();
        final AlertDialog alertdunban = unban.create();

        lvRooms = (ListView) view.findViewById(R.id.fragment_lobby_lvRoomsList);
        lvClients = (ListView) view.findViewById(R.id.fragment_lobby_lvUsersList);

        lvRooms.setChoiceMode(ListView.CHOICE_MODE_SINGLE);
        lvClients.setChoiceMode(ListView.CHOICE_MODE_SINGLE);


        bLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("auth","exit","","");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder, fragments.get(0));
                transaction.commit();
                bban = false;
                bunban = false;
            }
        });

        bChange.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentChange change = new FragmentChange();
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder, change);
                transaction.commit();
                change.SetName(tvName.getText().toString());
            }
        });
        bEnter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(lastposition == -1)
                {
                    Toast.makeText(context, "Please select room",
                            Toast.LENGTH_LONG).show();
                }
                else {
                    Request modelObject = new Request("rooms", "enter", roomname, "");
                    String json = gson.toJson(modelObject);
                    mWebSocketClient.send(json);
                }
            }
        });

        bRefreshrooms.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("lobby","refresh","","");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
            }
        });

        bRefreshclients.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("lobby","refreshclients","","");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
            }
        });

        bPrivate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("rooms","privateroom",username,"");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
            }
        });

        bBan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(lastpositionuser == -1)
                {
                    Toast.makeText(context, "Please select user",
                            Toast.LENGTH_LONG).show();
                }
                else {
                    alertdban.show();
                }
            }
        });

        bUnban.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(lastpositionuser == -1)
                {
                    Toast.makeText(context, "Please select user",
                            Toast.LENGTH_LONG).show();
                }
                else {
                    alertdunban.show();
                }
            }
        });

        bCreate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                alertd.show();
            }
        });

        lvRooms.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            public void onItemClick(AdapterView<?> adapter, View v, int position, long id) {

               // TextView textview1 = (TextView) v.findViewById(R.id.tvRoom);
                String[] splitrooms = lvRooms.getItemAtPosition(position).toString().split(" ");;
                roomname = splitrooms[0];
                lvRooms.setItemChecked(position,true);
                if(lastposition != -1 && lastposition != position) {
                    lvRooms.setItemChecked(lastposition, false);
                }
                lastposition = position;
            }
        });

        lvClients.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            public void onItemClick(AdapterView<?> adapter, View v, int position, long id) {

                username = lvClients.getItemAtPosition(position).toString();
                lvClients.setItemChecked(position,true);
                if(lastpositionuser != -1 && lastpositionuser != position) {
                    lvClients.setItemChecked(lastpositionuser, false);
                }
                lastpositionuser = position;
            }
        });

        return view;
    }

    private void SetCreateDlg()
    {
        String title = "Create room";
        String button1String = "Create";
        String button2String = "Cancel";

        ad = new AlertDialog.Builder(context);

        ad.setTitle(title);  // заголовок
        // ad.setMessage(message); // сообщение
        ad.setPositiveButton(button1String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                Request modelObject = new Request("rooms","createroom",input.getText().toString(),"");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                Toast.makeText(context, "Room created",
                        Toast.LENGTH_LONG).show();
                input.setText("");

            }
        });
        ad.setNegativeButton(button2String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                Toast.makeText(context, "Cancel", Toast.LENGTH_LONG)
                        .show();
            }
        });
        ad.setCancelable(true);
        ad.setOnCancelListener(new DialogInterface.OnCancelListener() {
            public void onCancel(DialogInterface dialog) {
                input.setText("");
            }
        });


        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.MATCH_PARENT,
                LinearLayout.LayoutParams.MATCH_PARENT);
        input.setLayoutParams(lp);
        ad.setView(input);
    }

    private void SetBanDlg()
    {
        String title = "Do you want to ban " + username + " ?";
        String button1String = "Permanent";
        String button2String = "For time";

        ban = new AlertDialog.Builder(context);

        ban.setTitle(title);  // заголовок
        // ad.setMessage(message); // сообщение
        ban.setPositiveButton(button1String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                Request modelObject = new Request("lobby","ban",username,"permanent");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                Toast.makeText(context, "User has been banned",
                        Toast.LENGTH_LONG).show();
                inputban.setText("");

            }
        });
        ban.setNegativeButton(button2String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                if(CheckBan(inputban.getText().toString())) {
                    Request modelObject = new Request("lobby", "ban", username, inputban.getText().toString());
                    String json = gson.toJson(modelObject);
                    mWebSocketClient.send(json);
                    Toast.makeText(context, "User has been banned", Toast.LENGTH_LONG)
                            .show();
                }
                inputban.setText("");
            }
        });
        ban.setCancelable(true);
        ban.setOnCancelListener(new DialogInterface.OnCancelListener() {
            public void onCancel(DialogInterface dialog) {
                inputban.setText("");
            }
        });


        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.MATCH_PARENT,
                LinearLayout.LayoutParams.MATCH_PARENT);
        inputban.setLayoutParams(lp);
        ban.setView(inputban);
    }

    private boolean CheckBan(String bantime)
    {
        if(bantime.length() < 60)
        {
            Toast.makeText(context, "Minimum ban time 60",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(bantime.length() > 9999)
        {
            Toast.makeText(context, "Maximum ban time 9999",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(!(bantime.matches("^[0-9]+$")))
        {
            Toast.makeText(context, "Please enter only numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        return true;
    }

    private void SetUnbanDlg()
    {
        String title = "Do you want to unban " + username + " ?";
        String button1String = "Unban";
        String button2String = "Cancel";

        unban = new AlertDialog.Builder(context);

        unban.setTitle(title);  // заголовок
        // ad.setMessage(message); // сообщение
        unban.setPositiveButton(button1String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                Request modelObject = new Request("lobby","unban",username,"");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                Toast.makeText(context, "User has been unbanned",
                        Toast.LENGTH_LONG).show();

            }
        });
        unban.setNegativeButton(button2String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                Toast.makeText(context, "Cancel", Toast.LENGTH_LONG)
                        .show();
            }
        });
        unban.setCancelable(true);
        unban.setOnCancelListener(new DialogInterface.OnCancelListener() {
            public void onCancel(DialogInterface dialog) {

            }
        });

    }

//    public void CreateLobby(String data) throws InterruptedException {
//        //Thread.sleep(500);
//        try {
//            FragmentTransaction transaction = MainActivity.fragments.get(0).getFragmentManager().beginTransaction();
//            transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(1));
//            transaction.commit();
//            if (data.equals("admin")) {
//                bban = true;
//                bunban = true;
//            }
//        }
//        catch(Exception ex)
//        {
//
//        }
//        //tvName.setText(data);
//    }

    public void CreateLobby() throws InterruptedException {
        //Thread.sleep(500);
        try {
            FragmentTransaction transaction = MainActivity.fragments.get(0).getFragmentManager().beginTransaction();
            transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(1));
            transaction.commit();

            if (tvName.getText().toString().equals("admin")) {
                bban = true;
                bunban = true;
            }
        }
        catch(Exception ex)
        {

        }
        //tvName.setText(data);
    }

    public void SetRooms(String[] data, Context ctx)
    {
        //ArrayList<Rooms> arrayOfUsers = new ArrayList<Rooms>();
       // for(int i = 0; i < data.length; i++) {
       //     arrayOfUsers.add(new Rooms(data[i]));
       // }
// Create the adapter to convert the array to views
       // MyAdapter adapter = new MyAdapter(MainActivity.context, arrayOfUsers);
// Attach the adapter to a ListView
       // lvRooms.setAdapter(adapter);

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,data);

        lvRooms.setAdapter(adapter);
    }

    public void SetClients(String[] data, Context ctx)
    {

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,data);

        lvClients.setAdapter(adapter);
    }

    public void Passive(String cmd, String dat, String tm, Context ctx)
    {
        ArrayAdapter<String> adapter;
        int a = -1;
        String[] data = new String[lvRooms.getCount()];
        for (int i = 0; i < lvRooms.getCount(); i++)
        {

            String[] str1 =  lvRooms.getItemAtPosition(i).toString().split(" ");
            data[i] = lvRooms.getItemAtPosition(i).toString();
            if (str1[0].equals(cmd))
                a = i;
        }
        if (a != -1)
        {


            if (dat.equals("0") && !(tm.equals("True"))) {
                data[a] = cmd + " ";

              //  ArrayList<Rooms> arrayOfUsers = new ArrayList<Rooms>();
               // for(int i = 0; i < data.length; i++) {
              //      arrayOfUsers.add(new Rooms(data[i]));
              //  }
// Create the adapter to convert the array to views
             //   MyAdapter adapter1 = new MyAdapter(MainActivity.context, arrayOfUsers);
// Attach the adapter to a ListView
               // lvRooms.setAdapter(adapter1);


                adapter = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,data);

                lvRooms.setAdapter(adapter);
            }
            else if (!(dat.equals("0"))) {
                data[a] = cmd + "   +" + dat;


              //  ArrayList<Rooms> arrayOfUsers = new ArrayList<Rooms>();
              //  for(int i = 0; i < data.length; i++) {
              //      arrayOfUsers.add(new Rooms(data[i]));
              //  }
// Create the adapter to convert the array to views
               // MyAdapter adapter2 = new MyAdapter(MainActivity.context, arrayOfUsers);
// Attach the adapter to a ListView
               // lvRooms.setAdapter(adapter2);
                adapter = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,data);

                lvRooms.setAdapter(adapter);

//                ((TextView) lvRooms.getChildAt(0).findViewById(R.id.tv_item)).setTypeface(null, Typeface.BOLD);
            }
        }
        else
        if (!(dat.equals("0"))) {
            String[] newdata = new String[data.length + 1];
            for (int i = 0; i < data.length; i++)
            {
                newdata[i] = data[i];
            }
            newdata[data.length] = cmd + "   +" + dat;


            //ArrayList<Rooms> arrayOfUsers = new ArrayList<Rooms>();
           // for(int i = 0; i < newdata.length; i++) {
            //    arrayOfUsers.add(new Rooms(newdata[i]));
           // }
// Create the adapter to convert the array to views
           // MyAdapter adapter3 = new MyAdapter(MainActivity.context, arrayOfUsers);
// Attach the adapter to a ListView
           // lvRooms.setAdapter(adapter3);
            ArrayAdapter<String> adapter1 = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,newdata);

            lvRooms.setAdapter(adapter1);
        }
    }
    public void SetName(String name)
    {
        this.name = name;
    }
}
