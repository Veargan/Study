package com.example.ghhos.xoclient.ui.fragments;

import android.app.AlertDialog;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.api.FragmentManager;

import java.util.regex.Pattern;

/**
 * Created by GHhos on 23.02.2017.
 */

public class FragmentRA extends Fragment {

    private String email;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_ra, container, false);

        Button bAuth = (Button) view.findViewById(R.id.fragment_ra_bAuth);
        Button bReg = (Button) view.findViewById(R.id.fragment_ra_bReg);
        Button bForgotPass = (Button) view.findViewById(R.id.fragment_ra_bForgotPass);
        Button bChangePass = (Button) view.findViewById(R.id.fragment_ra_bChangePass);

        final EditText etUsername = (EditText) view.findViewById(R.id.fragment_ra_etUsername);
        final EditText etPassword = (EditText) view.findViewById(R.id.fragment_ra_etPassword);

        bAuth.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentManager.UserName = etUsername.getText().toString();
                FragmentManager.SendLogin(etUsername.getText().toString(),
                        etPassword.getText().toString());
                ToLobby();
            }
        });

        bReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                FragmentManager.UserName = etUsername.getText().toString();
                FragmentManager.SendReg(etUsername.getText().toString(),
                        etPassword.getText().toString());
                ToLobby();
            }
        });

        bForgotPass.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentManager.UserName = etUsername.getText().toString();
                OnForgotPass();
            }
        });

        bChangePass.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OpenChangePassDialog();
                ToLobby();
            }
        });

        return view;
    }

    private void MessageBox(String message, String header){
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

    private void ToLobby() {
        FragmentTransaction transaction = getFragmentManager().beginTransaction();
        transaction.replace(R.id.main_activity_fragment_placeholder,FragmentManager.lobbyFrag);
        transaction.commit();
    }

    private void OnForgotPass() {
        if (!FragmentManager.UserName.equals("")) {
            OpenPassRetrievalDialog();
        }
        else {
            MessageBox("You should insert your login first!", "Password retrieval issue");
            ToLobby();
        }
    }

    private void OpenPassRetrievalDialog(){
        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(this.getContext());

        final EditText etEmail = new EditText(this.getContext());
        aDialogBuilder.setView(etEmail);

        aDialogBuilder.setMessage("Password retrival");
        aDialogBuilder.setMessage("Enter email to retrieve your password:");

        aDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                email = etEmail.getText().toString();
                if (Pattern.matches("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$", email)) {
                    FragmentManager.SendForgotPassword(FragmentManager.UserName, email);
                }
                else {
                    MessageBox("Incorrect e-mail address!", "Password retrieval issue");
                }
                ToLobby();
                dialog.cancel();
            }
        });

        aDialogBuilder.setCancelable(false);
        aDialogBuilder.create();
        aDialogBuilder.show();
    }

    private void OpenChangePassDialog() {

        LayoutInflater inflater = (LayoutInflater) this.getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View v = inflater.inflate(R.layout.dialog_change_password, null);

        final EditText username = (EditText) v.findViewById(R.id.dialog_changePass_etUsername);
        final EditText pass = (EditText) v.findViewById(R.id.dialog_changePass_etPassword);
        final EditText newPass = (EditText) v.findViewById(R.id.dialog_changePass_etNewPassword);

        final AlertDialog.Builder aDialogBuilder = new AlertDialog.Builder(this.getContext());
        aDialogBuilder.setView(v);
        aDialogBuilder.setMessage("Change password");

        aDialogBuilder.setPositiveButton("Confirm", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                FragmentManager.SendChangePassword(username.getText().toString(),
                        pass.getText().toString(), newPass.getText().toString());
                dialog.cancel();
            }
        });
        aDialogBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        aDialogBuilder.show();
    }

}
