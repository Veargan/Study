package GUI;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JPanel;

import API.xComand;

public class WidthPanel extends JPanel
{
	public WidthPanel(xComand cmd)
	{
		setLayout(null);
		
		setBackground(Color.red);
		
		JButton btn_4 = new JButton("width 4");
		JButton btn_8 = new JButton("width 8");
		JButton btn_16 = new JButton("width 16");
		
		btn_4.putClientProperty("tag", "4");
		btn_8.putClientProperty("tag", "8");
		btn_16.putClientProperty("tag", "16");
		
		btn_4.setBounds(30, 10, 100, 30);
		btn_8.setBounds(30, 50, 100, 30);
		btn_16.setBounds(30, 90, 100, 30);
		
		add(btn_4);
		add(btn_8);
		add(btn_16);
		
		btn_4.addActionListener(cmd.aWidth);
		btn_8.addActionListener(cmd.aWidth);
		btn_16.addActionListener(cmd.aWidth);
	}
}
