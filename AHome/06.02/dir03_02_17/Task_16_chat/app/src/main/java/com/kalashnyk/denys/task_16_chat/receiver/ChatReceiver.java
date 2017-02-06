package com.kalashnyk.denys.task_16_chat.receiver;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

import com.kalashnyk.denys.task_16_chat.service.ChatService;

/**
 * Created by User on 03.02.2017.
 */

public class ChatReceiver extends BroadcastReceiver {

    @Override
    public void onReceive(Context context, Intent intent) {
        if (intent.getAction().equals("android.intent.action.BOOT_COMPLETED")) {

            context.startService(new Intent(context, ChatService.class));
            Log.i("chat", "+ ChatReceiver done");
        }
    }

}
