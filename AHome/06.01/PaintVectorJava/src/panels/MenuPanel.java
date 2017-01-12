package panels;

import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JSeparator;

import api.XCommand;

public class MenuPanel extends JMenuBar{

	private JMenu fileMenu;
	private JMenu colorMenu;
	private JMenu widthMenu;
	private JMenu typeMenu;
	private JMenu windowMenu;
	
	private JMenuItem saveItem;
	private JMenuItem openItem;
	private JMenuItem newItem;
	
	private JMenuItem colorItem;
	private JMenuItem widthItem;
	private JMenuItem typeItem;
	private JMenuItem windowItem;
	
	public MenuPanel(){
		
		initializeComponents();
	}
	
	public MenuPanel(XCommand cmd){
		
		this();
		
		colorItem.addActionListener(cmd.getColor());
		widthItem.addActionListener(cmd.getWidth());
		typeItem.addActionListener(cmd.getType());
		saveItem.addActionListener(cmd.getSave());
		openItem.addActionListener(cmd.getLoad());
		newItem.addActionListener(cmd.getNew());
		windowMenu.addActionListener(cmd.getWindow());
	}
	
	private void initializeComponents(){
		
		fileMenu = new JMenu("File");
		colorMenu = new JMenu("Color");
		widthMenu = new JMenu("Width");
		typeMenu = new JMenu("Figure Type");
		windowMenu = new JMenu("Windows");
		
		saveItem = new JMenuItem("Save as");
		openItem = new JMenuItem("Open");
		newItem = new JMenuItem("New");
		colorItem = new JMenuItem("Select color");
		widthItem = new JMenuItem("Select line width");
		typeItem = new JMenuItem("Select figure shape");
				
		fileMenu.add(newItem);
		fileMenu.addSeparator();
		fileMenu.add(saveItem);
		fileMenu.addSeparator();
		fileMenu.add(openItem);
				
		colorMenu.add(colorItem);
		widthMenu.add(widthItem);
		typeMenu.add(typeItem);
		
		add(fileMenu);
		add(colorMenu);
		add(widthMenu);
		add(typeMenu);
		add(windowMenu);
	}
}
