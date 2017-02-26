package com.example.ghhos.xoclient.ui.fragments;

import android.app.AlertDialog;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.content.res.TypedArrayUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.api.FragmentManager;

import java.util.ArrayList;

/**
 * Created by GHhos on 23.02.2017.
 */

public class FragmentLobby extends Fragment {

    Button bLogin = null;
    Button bLogout = null;
    Button bInvite = null;
    TextView tvName = null;
    TextView tvStatus = null;
    ListView lvFreePlayersList = null;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_lobby, container, false);

        bLogin = (Button) view.findViewById(R.id.fragment_lobby_bLogin);
        bLogout = (Button) view.findViewById(R.id.fragment_lobby_bLogout);
        bInvite = (Button) view.findViewById(R.id.fragment_lobby_bInvite);
        tvName = (TextView) view.findViewById(R.id.fragment_lobby_tvStatusBar_name);
        tvStatus = (TextView) view.findViewById(R.id.fragment_lobby_tvStatusBar);

        lvFreePlayersList = (ListView) view.findViewById(R.id.fragment_lobby_lvFreePlayersList);

        bLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder,
                        new FragmentRA());
                transaction.commit();
            }
        });

        bLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ;
            }
        });

        bInvite.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentManager.SendInviteRequest("");
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder, FragmentManager.gameFrag);
                transaction.commit();
            }
        });

        return view;
    }

    public void AddToPlayerList(String[] names) {
        ArrayList<String> nameList = new ArrayList<String>();
        for (int i = 0; i < names.length; i++){
            if (!names[i].equals(FragmentManager.UserName)){
                nameList.add(names[i]);
            }
        }
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this.getContext(), android.R.layout.simple_list_item_1, nameList);
        lvFreePlayersList.setAdapter(adapter);
    }

    public void Autherization(boolean state){
        if (state) {
            SetStatusBarData(FragmentManager.UserName, "Connected to the server");
        }
        else {
            FragmentManager.UserName = "";
            SetStatusBarData(FragmentManager.UserName, "Waiting for connection to the server...");
        }
    }

    public void Registation(boolean state){
        if (state) {
            SetStatusBarData(FragmentManager.UserName, "Connected to the server");
        }
        else {
            FragmentManager.UserName = "";
            SetStatusBarData(FragmentManager.UserName, "Waiting for connection to the server...");
        }
    }

    private void SetStatusBarData(String name, String status) {
        tvName.setText("Your name: " + name);
        tvStatus.setText(status);
    }

    public void MessageBox(String message, String header){
        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(this.getContext());
        aDialogBuilder.setMessage(header);
        aDialogBuilder.setMessage(message);

        aDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        aDialogBuilder.setCancelable(false);
        aDialogBuilder.create();
        aDialogBuilder.show();
    }

    public void InvitationBox(final String playerName){
        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(this.getContext());
        aDialogBuilder.setMessage("Invitation");
        aDialogBuilder.setMessage("Player " + playerName + " wants to play with you!");

        aDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                InvitationFeedBack(playerName, true);
                dialog.cancel();
            }
        });
        aDialogBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                InvitationFeedBack(playerName, false);
                dialog.cancel();
            }
        });

        aDialogBuilder.setCancelable(false);
        aDialogBuilder.create();
        aDialogBuilder.show();
    }

    private void InvitationFeedBack(String playerName, boolean result) {
        String msg;
        if (result) {
            msg = "inviteYes:";
        }
        else {
            msg = "inviteNo:";
        }
        msg += FragmentManager.UserName + "," + playerName;
        FragmentManager.SendInviteResponse(msg);
    }

}
