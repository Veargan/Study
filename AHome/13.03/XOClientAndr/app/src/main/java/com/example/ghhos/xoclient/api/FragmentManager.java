package com.example.ghhos.xoclient.api;

import android.app.AlertDialog;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;

import com.example.ghhos.xoclient.R;
import com.example.ghhos.xoclient.ui.fragments.FragmentGame;
import com.example.ghhos.xoclient.ui.fragments.FragmentLobby;
import com.example.ghhos.xoclient.ui.fragments.FragmentRA;

import org.java_websocket.client.WebSocketClient;

/**
 * Created by GHhos on 25.02.2017.
 */

public class FragmentManager {

    public static WebSocketClient ws;
    public static FragmentLobby lobbyFrag;
    public static FragmentRA    regFrag;
    public static FragmentGame  gameFrag;
    public static String UserName = null;
    public static String SessionKey = null;
    public static Context lobbyContext = null;
    public static String[] nameList = new String[1];

    static {
        lobbyFrag = new FragmentLobby();
        regFrag = new FragmentRA();
        gameFrag = new FragmentGame();
        nameList[0] = null;
    }

    public static void ReInitialize() {
        lobbyFrag = new FragmentLobby();
        regFrag = new FragmentRA();
        gameFrag = new FragmentGame();
        UserName = null;
        SessionKey = null;
        lobbyContext = null;
        nameList = new String[1];
        nameList[0] = null;
    }

    public static void ShowLobby(FragmentTransaction transaction){
        transaction.replace(R.id.main_activity_fragment_placeholder,
                FragmentManager.lobbyFrag);
        transaction.commit();
    }

    public static void ShowGame(FragmentTransaction transaction){
        transaction.replace(R.id.main_activity_fragment_placeholder,
                FragmentManager.gameFrag);
        transaction.commit();
    }

    public static void ShowRegAuth(FragmentTransaction transaction){
        transaction.replace(R.id.main_activity_fragment_placeholder,
                FragmentManager.regFrag);
        transaction.commit();
    }

    public static void InitWebSocket(WebSocketClient webSocket) {
        ws = webSocket;
    }

    public static void Send(String message)
    {
        ws.send(message);
    }

    public static void Connect()
    {
        Send("connect");
    }

    public static void SendLogin(String login, String pass)
    {
        Send("login," + login + "," + pass);
    }

    public static void SendReg(String login, String pass)
    {
        Send("reg," + login + "," + pass);
    }

    public static void SendLogout()
    {
        Send("logout,");
    }

    public static void SendChangePassword(String login, String oldPas, String newPas) {
        Send("change," + login + "," + oldPas + "," + newPas);
    }

    public static void SendForgotPassword(String login, String email) {
        Send("forgot," + login + "," + email);
    }

    public static void SendInviteResponse(String response) {
        Send(response);
    }

    public static void SendInviteRequest(String name) {
        Send("lobby,invite," + FragmentManager.UserName + "," + name + ",XO");
    }

}
