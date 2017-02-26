package com.example.ghhos.xoclient.ui.fragments;

import android.app.Fragment;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.api.FragmentManager;

/**
 * Created by GHhos on 23.02.2017.
 */

public class FragmentGame extends Fragment implements View.OnClickListener {
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_game, container, false);

        TextView tvStatusBar = (TextView) view.findViewById(R.id.fragment_game_tvStatusBar);

        Button b1 = (Button) view.findViewById(R.id.fragment_game_b1);
        Button b2 = (Button) view.findViewById(R.id.fragment_game_b2);
        Button b3 = (Button) view.findViewById(R.id.fragment_game_b3);
        Button b4 = (Button) view.findViewById(R.id.fragment_game_b4);
        Button b5 = (Button) view.findViewById(R.id.fragment_game_b5);
        Button b6 = (Button) view.findViewById(R.id.fragment_game_b6);
        Button b7 = (Button) view.findViewById(R.id.fragment_game_b7);
        Button b8 = (Button) view.findViewById(R.id.fragment_game_b8);
        Button b9 = (Button) view.findViewById(R.id.fragment_game_b9);
        Button bExit = (Button) view.findViewById(R.id.fragment_game_bExit);

        b1.setOnClickListener(this);
        b2.setOnClickListener(this);
        b3.setOnClickListener(this);
        b4.setOnClickListener(this);
        b5.setOnClickListener(this);
        b6.setOnClickListener(this);
        b7.setOnClickListener(this);
        b8.setOnClickListener(this);
        b9.setOnClickListener(this);
        bExit.setOnClickListener(this);

        return view;
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.fragment_game_b1:
            {
                break;
            }
            case R.id.fragment_game_b2:
            {
                break;
            }
            case R.id.fragment_game_b3:
            {
                break;
            }
            case R.id.fragment_game_b4:
            {
                break;
            }
            case R.id.fragment_game_b5:
            {
                break;
            }
            case R.id.fragment_game_b6:
            {
                break;
            }
            case R.id.fragment_game_b7:
            {
                break;
            }
            case R.id.fragment_game_b8:
            {
                break;
            }
            case R.id.fragment_game_b9:
            {
                break;
            }
            case R.id.fragment_game_bExit:
            {
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder,
                        FragmentManager.lobbyFrag);
                transaction.commit();
                break;
            }
        }
    }
}
