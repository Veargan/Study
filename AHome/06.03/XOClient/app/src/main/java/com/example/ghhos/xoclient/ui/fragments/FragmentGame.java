package com.example.ghhos.xoclient.ui.fragments;

import android.app.AlertDialog;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.api.FragmentManager;
import com.example.ghhos.xoclient.api.TTTPacket;
import com.google.gson.Gson;

/**
 * Created by GHhos on 23.02.2017.
 */

public class FragmentGame extends Fragment implements View.OnClickListener {

    public static boolean init = false;
    private String playerTurn;
    private String unit;
    private Button[] buttons = null;
    private Button b1 = null;
    private Button b2 = null;
    private Button b3 = null;
    private Button b4 = null;
    private Button b5 = null;
    private Button b6 = null;
    private Button b7 = null;
    private Button b8 = null;
    private Button b9 = null;
    private TextView tvStatusBar = null;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_game, container, false);

        buttons = new Button[9];
        buttons[0] = (Button) view.findViewById(R.id.fragment_game_b1);
        buttons[1] = (Button) view.findViewById(R.id.fragment_game_b2);
        buttons[2] = (Button) view.findViewById(R.id.fragment_game_b3);
        buttons[3] = (Button) view.findViewById(R.id.fragment_game_b4);
        buttons[4] = (Button) view.findViewById(R.id.fragment_game_b5);
        buttons[5] = (Button) view.findViewById(R.id.fragment_game_b6);
        buttons[6] = (Button) view.findViewById(R.id.fragment_game_b7);
        buttons[7] = (Button) view.findViewById(R.id.fragment_game_b8);
        buttons[8] = (Button) view.findViewById(R.id.fragment_game_b9);
        Button bExit = (Button) view.findViewById(R.id.fragment_game_bExit);
        tvStatusBar = (TextView) view.findViewById(R.id.fragment_game_tvStatusBar);

        for (int i = 0; i < buttons.length; i++) {
            buttons[i].setOnClickListener(this);
        }
        bExit.setOnClickListener(this);

        return view;
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.fragment_game_b1:
            {
                OnTileClick(1);
                break;
            }
            case R.id.fragment_game_b2:
            {
                OnTileClick(2);
                break;
            }
            case R.id.fragment_game_b3:
            {
                OnTileClick(3);
                break;
            }
            case R.id.fragment_game_b4:
            {
                OnTileClick(4);
                break;
            }
            case R.id.fragment_game_b5:
            {
                OnTileClick(5);
                break;
            }
            case R.id.fragment_game_b6:
            {
                OnTileClick(6);
                break;
            }
            case R.id.fragment_game_b7:
            {
                OnTileClick(7);
                break;
            }
            case R.id.fragment_game_b8:
            {
                OnTileClick(8);
                break;
            }
            case R.id.fragment_game_b9:
            {
                OnTileClick(9);
                break;
            }
            case R.id.fragment_game_bExit:
            {
                ToLobby();
                break;
            }
            default:
                return;
        }
    }

    private void OnTileClick(int index) {
        if (!unit.equals("")) {
            if (playerTurn.equals("Turn")) {
                String json = new Gson().toJson(new TTTPacket(playerTurn, unit, index, null, null), TTTPacket.class);
                json = json.replaceAll(",", ";");
                FragmentManager.Send("game:" + FragmentManager.SessionKey + "," + json);
            }
        }
    }

    public void MessageBox(String message, String header){
        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(this.getContext());
        aDialogBuilder.setMessage(header);
        aDialogBuilder.setMessage(message);

        aDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                CleanUp();
                ToLobby();
                dialog.cancel();
            }
        });

        aDialogBuilder.setCancelable(false);
        aDialogBuilder.create();
        aDialogBuilder.show();
    }

    private void ToLobby() {
        FragmentTransaction transaction = getFragmentManager().beginTransaction();
        transaction.replace(R.id.main_activity_fragment_placeholder,
                FragmentManager.lobbyFrag);
        transaction.commit();
    }

    private void CleanUp() {
        for (int i = 0; i < buttons.length; i++) {
            buttons[i].setText("");
        }
        tvStatusBar.setText(R.string.textview_statusbar);
    }

    public void GameTurn(String message) {
        TTTPacket packet = new Gson().fromJson(message, TTTPacket.class);

        if (!init) {
            Init(packet);
            init = true;
        }
        else {
            if (packet.GameResult != null) {
//                win = true;
                init = false;
                RefreshGameField(packet);
                String str = packet.GameResult;
                MessageBox(str, "Game over");
            }
            else {
                RefreshGameField(packet);
            }
        }
    }

    private void Init(TTTPacket packet){
        playerTurn = packet.PlayerTurn;
        unit = packet.Unit;
        tvStatusBar.setText(unit + " | " + playerTurn);
    }

    private void RefreshGameField(TTTPacket packet) {
        String[] matrix = packet.Matrix;
        for (int i = 0; i < matrix.length; i += 1) {
            buttons[i].setText(matrix[i]);
        }
        playerTurn = packet.PlayerTurn;
        tvStatusBar.setText(unit + " | " + playerTurn);
    }
}
