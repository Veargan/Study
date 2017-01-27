package paint;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JPanel;

public class PWidth extends JPanel
{

	public PWidth(PCommands cmd)
	{
		setLayout(null);
		setBackground(Color.red);

		JButton btnWidth1 = new JButton("Width 1");
        JButton btnWidth3 = new JButton("Width 3");
        JButton btnWidth5 = new JButton("Width 5");
		JButton btnWidth7 = new JButton("Width 7");
		JButton btnWidth10 = new JButton("Width 10");

        btnWidth1.setBounds(10, 30, 180, 20);
        btnWidth3.setBounds(10, 60, 180, 20);
        btnWidth5.setBounds(10, 90, 180, 20);
        btnWidth7.setBounds(10, 120, 180, 20);
        btnWidth10.setBounds(10, 150, 180, 20);

        add(btnWidth1);
        add(btnWidth3);
        add(btnWidth5);
        add(btnWidth7);
        add(btnWidth10);

        btnWidth1.addActionListener(cmd.wCmd1);
        btnWidth3.addActionListener(cmd.wCmd3);
		btnWidth5.addActionListener(cmd.wCmd5);
		btnWidth7.addActionListener(cmd.wCmd7);
		btnWidth10.addActionListener(cmd.wCmd10);
	}
}
