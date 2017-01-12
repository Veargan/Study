package panels;

import java.awt.Color;
import java.awt.Rectangle;

import javax.swing.JButton;
import javax.swing.JPanel;

import api.XCommand;

public class ToolbarPanel extends JPanel {
	
	private JButton colorButton, widthButton,
	figureButton, saveButton, loadButton;
	
	public ToolbarPanel(Rectangle r, XCommand cmd){

		setLayout(null);
		setBounds(r);
		setVisible(true);
		
		initializeComponents();
		this.setLayout(null);
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
		Rectangle area = this.getBounds();
		area.y = area.y - 40;
		int heightOffset = area.height / 5;
		colorButton.setBounds(area.x, area.y, area.width, heightOffset);
		widthButton.setBounds(area.x, area.y + heightOffset, area.width, heightOffset);
		figureButton.setBounds(area.x, area.y + heightOffset * 2, area.width, heightOffset);
		saveButton.setBounds(area.x, area.y + heightOffset * 3, area.width, heightOffset);
		loadButton.setBounds(area.x, area.y + heightOffset * 4, area.width, heightOffset);
	}
}