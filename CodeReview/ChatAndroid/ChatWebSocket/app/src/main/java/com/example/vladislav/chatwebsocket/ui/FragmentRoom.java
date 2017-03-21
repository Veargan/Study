package com.example.vladislav.chatwebsocket.ui;

import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.text.method.ScrollingMovementMethod;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.example.vladislav.chatwebsocket.R;
import com.example.vladislav.chatwebsocket.ui.api.Request;
import com.google.gson.Gson;

import static com.example.vladislav.chatwebsocket.ui.Websockets.mWebSocketClient;

/**
 * Created by Vladislav on 26.02.2017.
 */

public class FragmentRoom extends Fragment {
    @Nullable
    Button bSend;
    Button bClose;
    Button bExit;
    EditText etSend;
    ListView lvMessages;
    TextView tvRoomName;

    String name;
    ArrayAdapter<String> adapter;
    String data = "";

    final Gson gson = new Gson();

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_room, container, false);

        bSend = (Button) view.findViewById(R.id.fragmen_room_bSend);
        bClose = (Button) view.findViewById(R.id.fragment_room_bClose);
        etSend = (EditText) view.findViewById(R.id.fragmen_room_etSend);
        lvMessages = (ListView) view.findViewById(R.id.lv_messages);
        bExit = (Button) view.findViewById(R.id.fragment_room_bExit);
        tvRoomName = (TextView) view.findViewById(R.id.fragment_room_roomname);

        tvRoomName.setText(name);

        lvMessages.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);

        etSend.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                for(int i = 0;i < lvMessages.getCount(); i++)
                {
                    lvMessages.setItemChecked(i, false);
                }
            }
        });

        bSend.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("rooms","message",etSend.getText().toString(),name);
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                etSend.setText("");
                for(int i = 0;i < lvMessages.getCount(); i++)
                {
                    lvMessages.setItemChecked(i, false);
                }
            }
        });

        bClose.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("rooms","leave",name,"");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                data = "";
            }
        });

        bExit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Request modelObject = new Request("rooms","exit",name,"");
                String json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                modelObject = new Request("rooms","message","User left the room",name);
                json = gson.toJson(modelObject);
                mWebSocketClient.send(json);
                data = "";
            }
        });

        String[] tmpadadapter = this.data.split("\\~");

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(MainActivity.context,android.R.layout.simple_list_item_activated_1,tmpadadapter);

        lvMessages.setAdapter(adapter);

        return view;
    }

    public void SetMessages(String data, String cmd, Context ctx)
    {
        String[] str = data.split("\\~");
        if (str[0].equals("missed"))
        {
            String[] tmp = str[1].split("\\.");
            for (int i = 0; i < tmp.length; i++)
            {
                this.data += tmp[i] + "~";
            }

           // String[] tmpadadapter = this.data.split("\\~");

            //ArrayAdapter<String> adapter = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,tmpadadapter);

           // lvMessages.setAdapter(adapter);

        }
    }

    public void CreateRoom(String data, String cmd, Context ctx) throws InterruptedException {
        FragmentTransaction transaction = MainActivity.fragments.get(1).getFragmentManager().beginTransaction();
        transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(2));
        transaction.commit();
        name = cmd;
        SetMessages(data, cmd, ctx);
    }

    public void SetMessage(String dat, Context ctx)
    {
        data += dat + "~";
        String[] tmpadadapter = data.split("\\~");

        adapter = new ArrayAdapter<String>(ctx,android.R.layout.simple_list_item_activated_1,tmpadadapter);

        lvMessages.setAdapter(adapter);
    }

    public void Leave()
    {
        FragmentTransaction transaction = MainActivity.fragments.get(2).getFragmentManager().beginTransaction();
        transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(1));
        transaction.commit();
    }
}
