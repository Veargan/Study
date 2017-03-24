package com.example.ort.chatwebsocket.ui.api;

public class Request {
    public String modul;
    public String command;
    public String data;
    public String time;

    public Request(String modul, String command, String data, String time) {
        this.modul = modul;
        this.command = command;
        this.data = data;
        this.time = time;
    }
}
