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

        //String command = message.substring(0 ,message.indexOf(":"));
        message = message.replaceAll("\\r\\n", "");
        //message = message.substring(message.indexOf(":") + 1);
        String args[] = message.split(",");

        switch (args[0]) {
            case "list": {
                FragmentManager.nameList = args;
                FragmentManager.lobbyFrag.AddToPlayerList();
                break;
            }
            case "invite": {
                FragmentManager.lobbyFrag.InvitationBox(args[2]);
                break;
            }
            case "ask": {
                    FragmentManager.SessionKey = args[1];
                    FragmentManager.ShowGame(FragmentManager.lobbyFrag.getFragmentManager().beginTransaction());
                break;
            }
            case "login": {
                if (args[1].equals("Y")) {
                    FragmentManager.regFrag.Authorization(true);
                }
                else {
                    FragmentManager.regFrag.Authorization(false);
                }
                break;
            }
            case "reg": {
                if (args[1].equals("Y")) {
                    FragmentManager.regFrag.Registration(true);
                } else {
                    FragmentManager.regFrag.Registration(false);
                }
                break;
            }
            case "game": {
                if (args[1].equals("quit")) {
                    FragmentManager.lobbyFrag.MessageBox("Player left the game. You win!", "Game over");
//                    win = true;
                    FragmentManager.gameFrag.init = false;
                }
                break;
            }
            case "change": {
                if (args[1].equals("Y")) {
                    FragmentManager.regFrag.ChangePass(true);
                }
                else {
                    FragmentManager.regFrag.ChangePass(false);
                }
                break;
            }
            case "send": {
                if (args[1].equals("Y")) {
                    FragmentManager.regFrag.ForgotPass(true);
                }
                else {
                    FragmentManager.regFrag.ForgotPass(false);
                }
                break;
            }
        }
    }
}
