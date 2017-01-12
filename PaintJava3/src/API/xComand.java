package API;
import java.awt.event.*;
import java.io.IOException;
import java.awt.*;
import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.plaf.basic.BasicButtonUI;

import FigureIO.FigureIO_Impl;
import GUI.FigureType;
import GUI.PaintPanel;
import GUI.Panel;

public class xComand
{
	public Panel p=null;
	
	public ActionColor aColor=new ActionColor();
	public ActionWidth aWidth=new ActionWidth();
	public ActionType aType=new ActionType();
	public ActionSave  aSave = new ActionSave();
	public ActionLoad aLoad = new ActionLoad();
	public ActionNewPage aNewPage = new ActionNewPage();
	
	class ActionColor implements ActionListener
	{

		@Override
		public void actionPerformed(ActionEvent e) 
		{
			int i=p.tbp.getSelectedIndex();
			p.tbp.ppanels.get(i).data.color =JColorChooser.showDialog(p, "color", Color.BLACK).getRGB();
			p.sb.setData(p.tbp.ppanels.get(i).data);
			p.tbp.ppanels.get(i).repaint();
		}
	}
	class ActionWidth implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent e)
		{
			int i=p.tbp.getSelectedIndex();
			Object j= (Object)e.getSource();
			p.tbp.ppanels.get(i).data.width=Integer.parseInt((String) ((JComponent) j).getClientProperty("tag"));
			p.sb.setData(p.tbp.ppanels.get(i).data);
			p.tbp.ppanels.get(i).repaint();
		}
		
	}
	
	class ActionType implements ActionListener
	{

		@Override
		public void actionPerformed(ActionEvent e)
		{
			Object j= (Object)e.getSource();
			int i=p.tbp.getSelectedIndex();
			switch((String) ((JComponent) j).getClientProperty("tag"))
			{
			case "Line":
				p.tbp.ppanels.get(i).data.type= FigureType.line;
				break;
			case "Rectangle":
				p.tbp.ppanels.get(i).data.type= FigureType.rectangle;
				break;
			case "R_Rectangle":
				p.tbp.ppanels.get(i).data.type= FigureType.r_rectangle;
				break;
			case "Oval":
				p.tbp.ppanels.get(i).data.type= FigureType.oval;
				break;
			}
			p.sb.setData(p.tbp.ppanels.get(i).data);
			p.tbp.ppanels.get(i).repaint();
		}
	}
	class ActionSave implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{
			JFileChooser chooser = new JFileChooser();
			chooser.addChoosableFileFilter(new FileNameExtensionFilter("*.json", "json"));
			chooser.addChoosableFileFilter(new FileNameExtensionFilter("*.xml", "xml"));
			int returnVal = chooser.showSaveDialog(null);
			if(returnVal == JFileChooser.APPROVE_OPTION)
			{
				int i=p.tbp.getSelectedIndex();
				
				try {
					FigureIO_Impl.GetI(chooser.getSelectedFile().getAbsolutePath()).Save(p.tbp.ppanels.get(i).getMemento());
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		}
	}
	class ActionLoad implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent e) {
			JFileChooser chooser = new JFileChooser();
			chooser.addChoosableFileFilter(new FileNameExtensionFilter("*.json", "json"));
			chooser.addChoosableFileFilter(new FileNameExtensionFilter("*.xml", "xml"));
			int returnVal = chooser.showOpenDialog(null);
			if(returnVal == JFileChooser.APPROVE_OPTION)
			{
				int i=p.tbp.getSelectedIndex();
				try {
					p.tbp.ppanels.get(i).setMemento(FigureIO_Impl.GetI(chooser.getSelectedFile().getAbsolutePath()).Load());
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		}
		
	}
	class ActionNewPage implements ActionListener
	{

		@Override
		public void actionPerformed(ActionEvent e)
		{		
			PaintPanel pp = new PaintPanel(p.cmd);
			
			pp.setBounds(0, 0, p.tbp.getWidth(), p.tbp.getHeight());
			p.tbp.ppanels.add(pp);
			int i=p.tbp.ppanels.size();
			
			p.tbp.addTab("Page "+i, pp);
			
			p.tbp.setSelectedIndex(i-1);
			p.sb.setData(p.tbp.ppanels.get(i-1).data);
			
			JMenuItem newItem=new JMenuItem("Page"+i);
			p.mp.mPages.add(newItem);

			JButton button = new TabButton();
			p.mp.mPages.add(button);
			//add more space to the top of the component
			button.setBorder(BorderFactory.createEmptyBorder(2, 0, 0, 0));
			
			newItem.addActionListener(new ActionListener() {
				
				@Override
				public void actionPerformed(ActionEvent e)
				{
					p.tbp.setSelectedIndex(i-1);
				}
			});
		}
	}
	public class TabButton extends JButton implements ActionListener {
		public TabButton() {
			int size = 17;
			setPreferredSize(new Dimension(size, size));
			setToolTipText("close this tab");
			//Make the button looks the same for all Laf's
			setUI(new BasicButtonUI());
			//Make it transparent
			setContentAreaFilled(false);
			//No need to be focusable
			setFocusable(false);
			setBorder(BorderFactory.createEtchedBorder());
			setBorderPainted(false);
			//Making nice rollover effect
			//we use the same listener for all buttons
			addMouseListener(buttonMouseListener);
			setRolloverEnabled(true);
			//Close the proper tab by clicking the button
			addActionListener(this);
		}

		public void actionPerformed(ActionEvent e) {
			int i = p.tbp.indexOfTabComponent(this);
			if (i != -1) {
				p.tbp.remove(i);
			}
		}

		//we don't want to update UI for this button
		public void updateUI() {
		}

		//paint the cross
		protected void paintComponent(Graphics g) {
			super.paintComponent(g);
			Graphics2D g2 = (Graphics2D) g.create();
			//shift the image for pressed buttons
			if (getModel().isPressed()) {
				g2.translate(1, 1);
			}
			g2.setStroke(new BasicStroke(2));
			g2.setColor(Color.BLACK);
			if (getModel().isRollover()) {
				g2.setColor(Color.MAGENTA);
			}
			int delta = 6;
			g2.drawLine(delta, delta, getWidth() - delta - 1, getHeight() - delta - 1);
			g2.drawLine(getWidth() - delta - 1, delta, delta, getHeight() - delta - 1);
			g2.dispose();
		}
	}

	private final static MouseListener buttonMouseListener = new MouseAdapter() {
		public void mouseEntered(MouseEvent e) {
			Component component = e.getComponent();
			if (component instanceof AbstractButton) {
				AbstractButton button = (AbstractButton) component;
				button.setBorderPainted(true);
			}
		}

		public void mouseExited(MouseEvent e) {
			Component component = e.getComponent();
			if (component instanceof AbstractButton) {
				AbstractButton button = (AbstractButton) component;
				button.setBorderPainted(false);
			}
		}
	};
}
