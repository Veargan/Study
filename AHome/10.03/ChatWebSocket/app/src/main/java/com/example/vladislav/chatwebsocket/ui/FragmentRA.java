package com.example.vladislav.chatwebsocket.ui;

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
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.example.vladislav.chatwebsocket.R;
import com.example.vladislav.chatwebsocket.ui.api.Request;
import com.google.gson.Gson;

import org.java_websocket.client.WebSocketClient;

import static com.example.vladislav.chatwebsocket.ui.MainActivity.context;
import static com.example.vladislav.chatwebsocket.ui.Websockets.mWebSocketClient;

/**
 * Created by Vladislav on 26.02.2017.
 */

public class FragmentRA extends Fragment {
    @Nullable
    AlertDialog.Builder ad;
    EditText input;
    final Gson gson = new Gson();
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_ra, container, false);

        input = new EditText(MainActivity.context);
        Button bAuth = (Button) view.findViewById(R.id.fragment_ra_bAuth);
        Button bReg = (Button) view.findViewById(R.id.fragment_ra_bReg);
        Button bForgotPass = (Button) view.findViewById(R.id.fragment_ra_bForgotPass);

        final EditText etUsername = (EditText) view.findViewById(R.id.fragment_ra_etUsername);
        final EditText etPassword = (EditText) view.findViewById(R.id.fragment_ra_etPassword);

        String title = "Forgot password";
        String button1String = "Send password";

        SetForgotDlg();

        final AlertDialog alertd = ad.create();

        bAuth.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(CheckName(etUsername.getText().toString(),etPassword.getText().toString())) {
                    MainActivity.connectWebSocket(etUsername.getText().toString(), etPassword.getText().toString(), "", "auth");
                }
                //FragmentTransaction transaction = getFragmentManager().beginTransaction();
               // transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(1));
                //transaction.commit();
            }
        });

        bReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(3));
                transaction.commit();
            }
        });

        bForgotPass.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ;alertd.show();
            }
        });


        return view;
    }

    private void SetForgotDlg()
    {
        String title = "Forgot password";
        String button1String = "Send password";

        ad = new AlertDialog.Builder(context);

        ad.setTitle(title);  // заголовок
        // ad.setMessage(message); // сообщение
        ad.setPositiveButton(button1String, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int arg1) {
                if(CheckForgot(input.getText().toString())) {
                    MainActivity.connectWebSocket("", "", input.getText().toString(), "forgot");
                    Toast.makeText(context, "Password has been sent",
                            Toast.LENGTH_LONG).show();
                }
                input.setText("");

            }
        });
        ad.setCancelable(true);
        ad.setOnCancelListener(new DialogInterface.OnCancelListener() {
            public void onCancel(DialogInterface dialog) {
                input.setText("");
            }
        });


        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.MATCH_PARENT,
                LinearLayout.LayoutParams.MATCH_PARENT);
        input.setLayoutParams(lp);
        ad.setView(input);
    }

    private boolean CheckForgot(String mail)
    {
        if(mail.length() == 0)
        {
            Toast.makeText(context, "Please enter the mail",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(!mail.matches("^([a-z0-9_-]+.)*[a-z0-9_-]+@[a-z0-9_-]+(.[a-z0-9_-]+)*.[a-z]{2,6}$"))
        {
            Toast.makeText(context, "Incorrect mail",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        return true;
    }

    private boolean CheckName(String name, String pass)
    {
        if(name.length() == 0)
        {
            Toast.makeText(context, "Please enter username",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(pass.length() == 0)
        {
            Toast.makeText(context, "Please enter password",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(name.length() > 10)
        {
            Toast.makeText(context, "Very long username! Enter username till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(pass.length() > 10)
        {
            Toast.makeText(context, "Very long password! Enter password till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(!(name.matches("^[a-zA-Z0-9]+$")))
        {
            Toast.makeText(context, "Username contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(!(pass.matches("[a-zA-Z0-9]+$")))
        {
            Toast.makeText(context, "Password contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(name.contains(" "))
        {
            Toast.makeText(context, "Username contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(pass.contains(" "))
        {
            Toast.makeText(context, "Password contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
            return true;
        }
}
