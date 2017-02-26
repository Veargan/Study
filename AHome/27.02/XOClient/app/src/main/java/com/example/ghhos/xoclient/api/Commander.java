package com.example.ghhos.xoclient.api;

import android.app.AlertDialog;
import android.content.DialogInterface;

/**
 * Created by GHhos on 25.02.2017.
 */
public class Commander {

    public static void listenLoop(String message) {

        String command = message.substring(0 ,message.indexOf(":"));
        message = message.replaceAll("\\r\\n", "");
        message = message.substring(message.indexOf(":") + 1);
        String args[] = message.split(",");

        switch (command) {
            case "broadcast": {
                FragmentManager.lobbyFrag.AddToPlayerList(args);
                break;
            }
            case "invite": {
                FragmentManager.lobbyFrag.InvitationBox(args[0]);
                break;
            }
            case "success": {
                if (args[0].equals("yes")) {
                    FragmentManager.SessionKey = args[1];
                    FragmentManager.ShowGame();
                }
                else {
                    FragmentManager.lobbyFrag.MessageBox("Connection denied", "Invitation issue");
                }
                break;
            }
            case "auth": {
                if (args[0].equals("yes")) {
                    FragmentManager.lobbyFrag.Autherization(true);
                }
                else {
                    FragmentManager.lobbyFrag.Autherization(false);
                }
                break;
            }
            case "reg": {
                if (args[0].equals("yes")) {
                    FragmentManager.lobbyFrag.Registation(true);
                } else {
                    FragmentManager.lobbyFrag.Registation(false);
                }
                break;
            }
            case "game": {
                /*
                if (args[0] === "quit"){
                    MessageBox("Player left the game. You win!");
                    win = true;
                    init = false;
                    ShowMainPage();
                    ClearGameField();
                }
                */
                break;
            }
            case "changepass": {
                String msg;
                if (args[0].equals("yes")) {
                    msg = "Password successfully changed!";
                }
                else {
                    msg = "Invalid login or/and password";
                }
                FragmentManager.lobbyFrag.MessageBox(msg, "Password change");
                break;
            }
        }
    }
}
