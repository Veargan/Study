package GUI;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JPanel;

import API.xComand;

public class TypePanel extends JPanel
{
	public TypePanel(xComand cmd)
	{
		setLayout(null);
		
		setBackground(Color.green);
		
		JButton btn_line = new JButton("Line");
		JButton btn_rect = new JButton("Rectangle");
		JButton btn_r_rect = new JButton("R_Rectangle");
		JButton btn_oval = new JButton("Oval");
		
		btn_line.putClientProperty("tag", "Line");
		btn_rect.putClientProperty("tag", "Rectangle");
		btn_r_rect.putClientProperty("tag", "R_Rectangle");
		btn_oval.putClientProperty("tag", "Oval");
		
		btn_line.setBounds(30, 10, 100, 30);
		btn_rect.setBounds(30, 50, 100, 30);
		btn_r_rect.setBounds(30, 90, 100, 30);
		btn_oval.setBounds(30, 130, 100, 30);
		
		add(btn_line);
		add(btn_rect);
		add(btn_r_rect);
		add(btn_oval);
		
		btn_line.addActionListener(cmd.aType);
		btn_rect.addActionListener(cmd.aType);
		btn_r_rect.addActionListener(cmd.aType);
		btn_oval.addActionListener(cmd.aType);
	}
}
