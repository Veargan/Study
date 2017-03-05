package com.example.ghhos.xoclient.api;

import android.app.AlertDialog;
import android.content.DialogInterface;

/**
 * Created by GHhos on 25.02.2017.
 */
public class Commander {

    public static void listenLoop(String message) {

        if (message.startsWith("{")) {
            message = message.replaceAll(";", ",");
            FragmentManager.gameFrag.GameTurn(message);
            return;
        }

        String command = message.substring(0 ,message.indexOf(":"));
        message = message.replaceAll("\\r\\n", "");
        message = message.substring(message.indexOf(":") + 1);
        String args[] = message.split(",");

        switch (command) {
            case "broadcast": {
                FragmentManager.nameList = args;
                FragmentManager.lobbyFrag.AddToPlayerList();
                break;
            }
            case "invite": {
                FragmentManager.lobbyFrag.InvitationBox(args[0]);
                break;
            }
            case "success": {
                if (args[0].equals("yes")) {
                    FragmentManager.SessionKey = args[1];
                    FragmentManager.ShowGame(FragmentManager.lobbyFrag.getFragmentManager().beginTransaction());
                }
                else {
                    FragmentManager.lobbyFrag.MessageBox("Connection denied", "Invitation issue");
                }
                break;
            }
            case "auth": {
                if (args[0].equals("yes")) {
                    FragmentManager.lobbyFrag.Authorization(true);
                }
                else {
                    FragmentManager.lobbyFrag.Authorization(false);
                }
                break;
            }
            case "reg": {
                if (args[0].equals("yes")) {
                    FragmentManager.lobbyFrag.Registration(true);
                } else {
                    FragmentManager.lobbyFrag.Registration(false);
                }
                break;
            }
            case "game": {
                if (args[0].equals("quit")) {
                    FragmentManager.lobbyFrag.MessageBox("Player left the game. You win!", "Game over");
//                    win = true;
                    FragmentManager.gameFrag.init = false;
                }
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
