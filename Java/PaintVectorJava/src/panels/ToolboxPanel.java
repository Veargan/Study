package panels;

import java.awt.Color;
import java.awt.Rectangle;

import javax.swing.JButton;
import javax.swing.JToolBar;

import api.XCommand;

public class ToolboxPanel extends JToolBar {
	
	private JButton colorButton, widthButton,
	figureButton, saveButton, loadButton;
	
	public ToolboxPanel(Rectangle r, XCommand cmd){
		
		setBackground(Color.YELLOW);
		setBounds(r);
		this.setVisible(true);
		
		initializeComponents();
		this.add(colorButton);
		this.add(widthButton);
		this.add(figureButton);
		this.add(saveButton);
		this.add(loadButton);
		
		colorButton.addActionListener(cmd.getColor());
		widthButton.addActionListener(cmd.getWidth());
		figureButton.addActionListener(cmd.getType());
		saveButton.addActionListener(cmd.getSave());
		loadButton.addActionListener(cmd.getLoad());
	}
	
	private void initializeComponents(){
		colorButton = new JButton("Color");
		widthButton = new JButton("Width");
		figureButton = new JButton("Figure Type");
		saveButton = new JButton("Save");
		loadButton = new JButton("Load");
	}

}
