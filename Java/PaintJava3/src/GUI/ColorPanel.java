package GUI;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JPanel;

import API.xComand;

public class ColorPanel extends JPanel
{
	public ColorPanel(xComand cmd ) 
	{
		setLayout(null);
		
		setBackground(Color.yellow);
		
		JButton btn_color = new JButton("COLOR");
		btn_color.setBounds(30, 10, 100, 30);
		add(btn_color);
		btn_color.addActionListener(cmd.aColor);
	}

}
