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

public class FragmentChange extends Fragment {
    final Gson gson = new Gson();
    String name;

    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_change, container, false);

        Button bConfirm = (Button) view.findViewById(R.id.fragment_change_bConfirm);

        final EditText etOldpassword = (EditText) view.findViewById(R.id.fragment_change_etOldpass);
        final EditText etNewpassword = (EditText) view.findViewById(R.id.fragment_change_etNewpass);
        final EditText etNewpasswordConfirm = (EditText) view.findViewById(R.id.fragment_change_etNewpassConfirm);

        bConfirm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(ChekName(etOldpassword.getText().toString(), etNewpassword.getText().toString(),etNewpasswordConfirm.getText().toString())) {
                    Request modelObject = new Request("auth", "change", name + "," + etOldpassword.getText().toString() + "," + etNewpassword.getText().toString(), "");
                    String json = gson.toJson(modelObject);
                    mWebSocketClient.send(json);
                    FragmentTransaction transaction = getFragmentManager().beginTransaction();
                    transaction.replace(R.id.main_activity_fragment_placeholder, MainActivity.fragments.get(1));
                    transaction.commit();
                }
            }
        });

        return view;
    }

    public void SetName(String name)
    {
        this.name = name;
    }

    private boolean ChekName(String oldpass, String newpass, String newpassconfirm)
    {
        if(oldpass.length() == 0)
        {
            Toast.makeText(context, "Please enter oldpassword",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(newpass.length() == 0)
        {
            Toast.makeText(context, "Please enter newpassword",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(newpassconfirm.length() == 0)
        {
            Toast.makeText(context, "Please enter newpassword",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(oldpass.length() > 10)
        {
            Toast.makeText(context, "Very long oldpassword! Enter oldpassword till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(newpass.length() > 10)
        {
            Toast.makeText(context, "Very long newpassword! Enter newpassword till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(newpassconfirm.length() > 10)
        {
            Toast.makeText(context, "Very long newpassword! Enter newpassword till 10 symbols.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (!oldpass.matches("[a-zA-Z0-9]+$"))
        {
            Toast.makeText(context, "Oldpassword contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (!newpass.matches("[a-zA-Z0-9]+$"))
        {
            Toast.makeText(context, "Newpassword contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if (!newpassconfirm.matches("[a-zA-Z0-9]+$"))
        {
            Toast.makeText(context, "Newpassword contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(oldpass.contains(" "))
        {
            Toast.makeText(context, "Oldpassword contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(newpass.contains(" "))
        {
            Toast.makeText(context, "Newpassword contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(newpassconfirm.contains(" "))
        {
            Toast.makeText(context, "Newpassword contains only english letters and numbers",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(oldpass.equals(newpass))
        {
            Toast.makeText(context, "Newpassword equals to oldpassword.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        else if(!(newpass.equals(newpassconfirm)))
        {
            Toast.makeText(context, "Newpasswords not equal.",
                    Toast.LENGTH_LONG).show();
            return false;
        }
        return true;
    }
}
