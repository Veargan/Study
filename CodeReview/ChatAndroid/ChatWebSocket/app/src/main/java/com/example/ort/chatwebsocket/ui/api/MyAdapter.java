package com.example.ort.chatwebsocket.ui.api;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.ort.chatwebsocket.R;

import java.util.ArrayList;
import java.util.List;

public class MyAdapter extends ArrayAdapter<Rooms> {
    public MyAdapter(Context context, ArrayList<Rooms> users) {
        super(context, 0, users);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        Rooms user = getItem(position);

        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.rooms_layout, parent, false);
        }
        TextView tvName = (TextView) convertView.findViewById(R.id.tvRoom);
        tvName.setText(user.name);;

        return convertView;
    }
}