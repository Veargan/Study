package GUI;

import javax.swing.JButton;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JToolBar;
import javax.swing.JToolTip;

import API.xComand;

public class ToolBarPanel extends JToolBar
{
    public  ToolBarPanel(xComand cmd)
    {
    	 JButton Color = new JButton("Color");
    	 
    	 JButton newb  = new JButton("New");
         JButton openb = new JButton("Open");
         JButton saveb = new JButton("Save");
         
         JButton width_4  = new JButton("width 4");
         JButton width_8  = new JButton("width 8");
         JButton width_16 = new JButton("width 16");
         
         width_4.putClientProperty("tag", "4");
         width_8.putClientProperty("tag", "8");
         width_16.putClientProperty("tag", "16");
         
         JButton btn_line   = new JButton("Line");
 		 JButton btn_rect   = new JButton("Rectangle");
 		 JButton btn_r_rect = new JButton("R_Rectangle");
 		 JButton btn_oval   = new JButton("Oval");
         
 		 btn_line.putClientProperty("tag", "Line");
		 btn_rect.putClientProperty("tag", "Rectangle");
		 btn_r_rect.putClientProperty("tag", "R_Rectangle");
		 btn_oval.putClientProperty("tag", "Oval");
		 
		 
		 add(newb);
         add(openb);
         add(saveb);
         
         add(Color);
         
         add(width_4);
         add(width_8);
         add(width_16);
         
         add(btn_line);
 		 add(btn_rect);
 		 add(btn_r_rect);
 		 add(btn_oval);
         
         Color.addActionListener(cmd.aColor);
         
         newb.addActionListener(cmd.aNewPage);
         openb.addActionListener(cmd.aLoad);
         saveb.addActionListener(cmd.aSave);
         
         width_4.addActionListener(cmd.aWidth);
         width_8.addActionListener(cmd.aWidth);
         width_16.addActionListener(cmd.aWidth);
         
         btn_line.addActionListener(cmd.aType);
 		 btn_rect.addActionListener(cmd.aType);
 		 btn_r_rect.addActionListener(cmd.aType);
 		 btn_oval.addActionListener(cmd.aType);
    }

}
