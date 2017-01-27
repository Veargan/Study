package GUI;

import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JPopupMenu;

import API.xComand;

public class ContextMenuPanel extends JPopupMenu
{
	public ContextMenuPanel(xComand cmd)
	{
		JMenuItem colotItem=new JMenuItem("Color");
		JMenu widthItem=new JMenu("Width");
		JMenu typeItem=new JMenu("Type");
		
		JMenuItem width_4=new JMenuItem("4");
		JMenuItem width_8=new JMenuItem("8");
		JMenuItem width_16=new JMenuItem("16");
		
		width_4.putClientProperty("tag", "4");
        width_8.putClientProperty("tag", "8");
        width_16.putClientProperty("tag", "16");
		
		widthItem.add(width_4);
		widthItem.add(width_8);
		widthItem.add(width_16);
		
		JMenuItem line=new JMenuItem("Line");
		JMenuItem rect=new JMenuItem("Rectangle");
		JMenuItem r_rect=new JMenuItem("R_Rectangle");
		JMenuItem oval=new JMenuItem("Oval");
		
		line.putClientProperty("tag", "Line");
        rect.putClientProperty("tag", "Rectangle");
        r_rect.putClientProperty("tag", "R_Rectangle");
        oval.putClientProperty("tag", "Oval");
		
		typeItem.add(line);
		typeItem.add(rect);
		typeItem.add(r_rect);
		typeItem.add(oval);
		
		add(colotItem);
		add(typeItem);
		add(widthItem);
		
		colotItem.addActionListener(cmd.aColor);
		
		width_4.addActionListener(cmd.aWidth);
		width_8.addActionListener(cmd.aWidth);
		width_16.addActionListener(cmd.aWidth);
		
		line.addActionListener(cmd.aType);
		rect.addActionListener(cmd.aType);
		r_rect.addActionListener(cmd.aType);
		oval.addActionListener(cmd.aType);
	}
}
