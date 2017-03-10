package com.example.ghhos.xoclient.api;

/**
 * Created by adm on 27.02.2017.
 */

public class TTTPacket {

    public TTTPacket() {
        Matrix = null;
    }

    public TTTPacket(String playerTurn, String unit, int buttonNumber, String[] matrix, String gameResult) {
        PlayerTurn = playerTurn;
        Unit = unit;
        ButtonNumber = buttonNumber;
        Matrix = matrix;
        GameResult = gameResult;
    }

    public String PlayerTurn;
    public String Unit;
    public int ButtonNumber;
    public String[] Matrix;
    public String GameResult;
}
