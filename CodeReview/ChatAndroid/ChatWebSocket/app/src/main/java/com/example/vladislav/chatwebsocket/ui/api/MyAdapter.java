package com.example.vladislav.chatwebsocket.ui.api;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.vladislav.chatwebsocket.R;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Vladislav on 28.02.2017.
 */

public class MyAdapter extends ArrayAdapter<Rooms> {
    public MyAdapter(Context context, ArrayList<Rooms> users) {
        super(context, 0, users);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Get the data item for this position
        Rooms user = getItem(position);
        // Check if an existing view is being reused, otherwise inflate the view
        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.rooms_layout, parent, false);
        }
        // Lookup view for data population
        TextView tvName = (TextView) convertView.findViewById(R.id.tvRoom);
        // Populate the data into the template view using the data object
        tvName.setText(user.name);;
        // Return the completed view to render on screen
        return convertView;
    }
}