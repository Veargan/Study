package paint;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JPanel;

public class PColor extends JPanel
{
	public PColor(PCommands cmd)
	{
		setLayout(null);

		setBackground(Color.BLUE);
		JButton btnColor = new JButton("Color");
		JButton btnRad = new JButton("Red");
		JButton btnGreen = new JButton("Green");
		JButton btnBlue = new JButton("Blue");

		btnColor.setBounds(10, 40, 180, 20);
		btnRad.setBounds(10, 70, 180, 20);
		btnGreen.setBounds(10, 100, 180, 20);
		btnBlue.setBounds(10, 130, 180, 20);

		add(btnColor);
		add(btnRad);
		add(btnGreen);
		add(btnBlue);

		btnColor.addActionListener(cmd.colCmd);
		btnRad.addActionListener(cmd.colCmdRed);
		btnGreen.addActionListener(cmd.colCmdGreen);
		btnBlue.addActionListener(cmd.colCmdBlue);
	}
}
