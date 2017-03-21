package com.example.ghhos.xoclient.ui.fragments;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.DialogInterface;
import android.content.Intent;
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
import com.example.ghhos.xoclient.ui.activity.MainActivity;
import com.example.ghhos.xoclient.ui.adapter.AdapterXO;

import java.util.ArrayList;

/**
 * Created by GHhos on 23.02.2017.
 */

public class FragmentLobby extends Fragment {

    Button bLogin = null;
    Button bLogout = null;
    TextView tvName = null;
    TextView tvStatus = null;
    ListView lvFreePlayersList = null;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_lobby, container, false);

        bLogin = (Button) view.findViewById(R.id.fragment_lobby_bLogin);
        bLogout = (Button) view.findViewById(R.id.fragment_lobby_bLogout);
        tvName = (TextView) view.findViewById(R.id.fragment_lobby_tvStatusBar_name);
        tvStatus = (TextView) view.findViewById(R.id.fragment_lobby_tvStatusBar);

        lvFreePlayersList = (ListView) view.findViewById(R.id.fragment_lobby_lvFreePlayersList);

        AddToPlayerList();

        if (FragmentManager.UserName != null){
            if (!FragmentManager.UserName.equals("")) {
                SetStatusBarData(FragmentManager.UserName, "Connected to the server");
            }
        }

        bLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (FragmentManager.UserName != null) return;
                if (!FragmentManager.UserName.equals("")) return;
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder,
                        new FragmentRA());
                transaction.commit();
            }
        });

        bLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (FragmentManager.UserName == null) return;
                if (FragmentManager.UserName.equals("")) return;
                FragmentManager.SendLogout();
                FragmentManager.ReInitialize();
                Intent intent = new Intent(getActivity(), MainActivity.class);
                startActivity(intent);
            }
        });

        return view;
    }

    public void AddToPlayerList() {
        ArrayList<String> nameList = new ArrayList<String>();
        for (int i = 1; i < FragmentManager.nameList.length; i++){
            if (FragmentManager.nameList[i] != null) {
                if (!FragmentManager.nameList[i].equals(FragmentManager.UserName)) {
                    String args[] = FragmentManager.nameList[i].split("#");
                    if (!args[1].equals("1")) {
                        nameList.add(FragmentManager.nameList[i]);
                    }
                }
            }
        }

        AdapterXO adapter = new AdapterXO(this.getContext(), nameList);
        lvFreePlayersList.setAdapter(adapter);
    }

    public void Authorization(boolean state){
        if (state) {
            SetStatusBarData(FragmentManager.UserName, "Connected to the server");
        }
        else {
            FragmentManager.UserName = "";
            SetStatusBarData(FragmentManager.UserName, "Waiting for connection to the server...");
        }
    }

    public void Registration(boolean state){
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
        aDialogBuilder.setMessage("Player " + playerName + " invites you to play XO game. Accept an invitation?");

        aDialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                InvitationFeedBack(playerName, true);
                dialog.cancel();
            }
        });
        aDialogBuilder.setNegativeButton("No", new DialogInterface.OnClickListener() {
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
            msg = "games,ask,Yes,";
        }
        else {
            msg = "games,ask,No,";
        }
        msg += FragmentManager.UserName + "," + playerName + ",XO";
        FragmentManager.SendInviteResponse(msg);
    }

}
