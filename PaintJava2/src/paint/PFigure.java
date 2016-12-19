package paint;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JPanel;

public class PFigure extends JPanel
{
	public PFigure(PCommands cmd)
	{
		setBackground(Color.green);
		setLayout(null);

		JButton rectangleButton = new JButton("Rectangle");
		JButton fRectangleButton = new JButton("Rounded Rectangle");
		JButton circleButton = new JButton("Oval");
		JButton freeButton = new JButton("Curved Line");

		rectangleButton.setBounds(10, 40, 180, 20);
		fRectangleButton.setBounds(10, 70, 180, 20);
		circleButton.setBounds(10, 100, 180, 20);
		freeButton.setBounds(10, 130, 180, 20);

		add(rectangleButton);
        add(fRectangleButton);
        add(circleButton);
		add(freeButton);

		rectangleButton.addActionListener(cmd.rect);
        fRectangleButton.addActionListener(cmd.fRectangle);
        circleButton.addActionListener(cmd.circle);
		freeButton.addActionListener(cmd.free);
	}
}
