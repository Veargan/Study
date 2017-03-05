package com.example.ghhos.xoclient.ui.adapter;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.api.FragmentManager;

import java.util.ArrayList;

/**
 * Created by adm on 27.02.2017.
 */

public class AdapterXO extends BaseAdapter {

    private Context context;
    private LayoutInflater layoutInflater;
    private ArrayList<String> nameList;

    public AdapterXO(Context context, ArrayList<String> nameList) {
        if (context == null)
            this.context = FragmentManager.lobbyContext;
        else {
            FragmentManager.lobbyContext = context;
            this.context = context;
        }
        this.layoutInflater = (LayoutInflater) this.context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.nameList = nameList;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if (view == null) {
            view = layoutInflater.inflate(R.layout.lobby_list_item, parent, false);
        }

        final TextView tvName = (TextView) view.findViewById(R.id.lobby_list_item_tvName);
        tvName.setText(nameList.get(position));

        tvName.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                InvitationBox(tvName.getText().toString());
                return false;
            }
        });

        return view;
    }

    @Override
    public int getCount() {
        return nameList.size();
    }

    @Override
    public Object getItem(int position) {
        return nameList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    private void InvitationBox(final String playerName){
        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(context);
        aDialogBuilder.setMessage("Invitation");
        aDialogBuilder.setMessage("Do you want to play with " + playerName + "?");

        aDialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Invite(playerName);
                dialog.cancel();
            }
        });
        aDialogBuilder.setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        aDialogBuilder.setCancelable(false);
        aDialogBuilder.create();
        aDialogBuilder.show();
    }

    private void Invite(String playerName) {
        FragmentManager.SendInviteRequest(playerName);
    }

}
