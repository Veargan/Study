package GUI;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JPanel;

import API.xComand;

public class SaveLoadPanel extends JPanel
{
	public SaveLoadPanel(xComand cmd)
	{
		setLayout(null);
		
		setBackground(Color.yellow);
		
		JButton btn_save = new JButton("Save");
		JButton btn_open = new JButton("Open");
		
		btn_save.setBounds(30, 10, 100, 30);
		btn_open.setBounds(30, 50, 100, 30);
		add(btn_save);
		add(btn_open);
		
		btn_save.addActionListener(cmd.aSave);
		btn_open.addActionListener(cmd.aLoad);
	}
}
