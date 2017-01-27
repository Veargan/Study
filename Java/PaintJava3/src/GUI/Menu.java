package GUI;
import javax.swing.*;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import API.xComand;

public class Menu extends JMenuBar
{
	public JMenu mPages=null;
    public  Menu(xComand cmd)
    {
        JMenu mFile = new JMenu("File");
        JMenuItem mOpen = new JMenuItem("Open");
        JMenuItem mSave = new JMenuItem("Save");
        JMenuItem mNew=new JMenuItem("New");
        
        mFile.add(mNew);
        mFile.add(mOpen);
        mFile.add(mSave);
        
        JMenu mColor = new JMenu("Color");
        JMenuItem mColorc = new JMenuItem("Chooooose color");
        
        mColor.add(mColorc);
        
        
        JMenu mWidth = new JMenu("Width");
        
        JMenuItem width_4 = new JMenuItem("4");
        JMenuItem width_8 = new JMenuItem("8");
        JMenuItem width_16 = new JMenuItem("16");
        
        width_4.putClientProperty("tag", "4");
        width_8.putClientProperty("tag", "8");
        width_16.putClientProperty("tag", "16");
        
        mWidth.add(width_4);
        mWidth.add(width_8);
        mWidth.add(width_16);
        
        JMenu mType = new JMenu("Type");
        
        JMenuItem mLine = new JMenuItem("Line");
        JMenuItem mRect = new JMenuItem("Rectangle");
        JMenuItem mR_rect = new JMenuItem("R_Rectangle");
        JMenuItem mOval = new JMenuItem("Oval");
        
        mLine.putClientProperty("tag", "Line");
        mRect.putClientProperty("tag", "Rectangle");
        mR_rect.putClientProperty("tag", "R_Rectangle");
        mOval.putClientProperty("tag", "Oval");
        
        mType.add(mLine);
        mType.add(mRect);
        mType.add(mR_rect);
        mType.add(mOval);
        
        mPages = new JMenu("Pages");

        add(mFile);
        add(mWidth);
        add(mColor);
        add(mType);
        add(mPages);
        
        mColorc.addActionListener(cmd.aColor);
        
        width_4.addActionListener(cmd.aWidth);
        width_8.addActionListener(cmd.aWidth);
        width_16.addActionListener(cmd.aWidth);
        
        mLine.addActionListener(cmd.aType);
        mRect.addActionListener(cmd.aType);
        mR_rect.addActionListener(cmd.aType);
        mOval.addActionListener(cmd.aType);
		
        mNew.addActionListener(cmd.aNewPage);
        mOpen.addActionListener(cmd.aLoad);
        mSave.addActionListener(cmd.aSave); 
        
    }
}
