import GUI.Panel;

import javax.swing.JFrame;

import API.xComand;

public class FrameDraw extends JFrame
{
	
public FrameDraw()
	{
		setTitle("My Calc");
		setBounds(100, 0, 800, 700);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		
		
		add(new Panel());
	
		setVisible(true);
	}
}
