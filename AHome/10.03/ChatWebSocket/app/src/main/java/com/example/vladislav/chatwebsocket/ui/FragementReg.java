package com.example.vladislav.chatwebsocket.ui;

import android.app.Fragment;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.vladislav.chatwebsocket.R;
import com.example.vladislav.chatwebsocket.ui.api.Request;
import com.google.gson.Gson;

import static com.example.vladislav.chatwebsocket.ui.MainActivity.context;
import static com.example.vladislav.chatwebsocket.ui.Websockets.mWebSocketClient;

/**
 * Created by Vladislav on 28.02.2017.
 */

public class FragementReg extends Fragment {

    final Gson gson = new Gson();

    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_reg, container, false);

        Button bConfirm = (Button) view.findViewById(R.id.fragment_reg_bConfirm);

        final EditText etUsername = (EditText) view.findViewById(R.id.fragment_reg_etUsername);
        final EditText etPassword = (EditText) view.findViewById(R.id.fragment_reg_etPassword);
        final EditText etMail = (EditText) view.findViewById(R.id.fragment_reg_etMail);

        bConfirm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(CheckName(etUsername.getText().toString(),etPassword.getText().toString(),etMail.getText().toString())) {
                    MainActivity.connectWebSocket(etUsername.getText().toString(), etPassword.getText().toString(), etMail.getText().toString(), "reg");
                    FragmentTransaction transaction = getFragmentManager().beginTransaction();
                    transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(1));
                    transaction.commit();
                }
            }
        });

        return view;
    }

    private  boolean CheckName(String name, String pass, String mail)
    {
        if (name.length() == 0)
        {
            Toast.makeText(context, "Please enter the username",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (name.length() > 10)
        {
            Toast.makeText(context, "Very long username! Enter username till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        if (pass.length() == 0)
        {
            Toast.makeText(context, "Please enter the password",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (pass.length() > 10)
        {
            Toast.makeText(context, "Very long password! Enter password till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        if (mail.length() == 0)
        {
            Toast.makeText(context, "Please enter the mail",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (!mail.matches("^([a-z0-9_-]+.)*[a-z0-9_-]+@[a-z0-9_-]+(.[a-z0-9_-]+)*.[a-z]{2,6}$"))
        {
            Toast.makeText(context, "Incorrect mail",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (!name.matches("[a-zA-Z0-9]+$"))
        {
            Toast.makeText(context, "Username contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (!pass.matches("[a-zA-Z0-9]+$"))
        {
            Toast.makeText(context, "Password contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (name.contains(" "))
        {
            Toast.makeText(context, "Username contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (pass.contains(" "))
        {
            Toast.makeText(context, "Password contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        return true;
    }
}
