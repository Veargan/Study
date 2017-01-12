package GUI;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.util.ArrayList;

import javax.swing.JOptionPane;
import javax.swing.JPanel;

import API.Figure;
import API.xComand;
import API.xData;

public class PaintPanel extends JPanel implements MouseListener, MouseMotionListener
{
	int x = 0;
	int y = 0;
	Figure fig;
	public xData data=new xData();
	Figure fff= null;
	public PaintPanel(xComand cmd)
	{
		setLayout(null);
		setBackground(Color.lightGray);
		addMouseListener(this);
		addMouseMotionListener(this);
		ContextMenuPanel cmp=new ContextMenuPanel(cmd);
		this.setComponentPopupMenu(cmp);
	}
	@Override
	public void mousePressed(MouseEvent e)
	{
		requestFocus();
		x = e.getX();
		y = e.getY();
	}
	@Override
	public void mouseReleased(MouseEvent e)
	{
		Rectangle r  = new Rectangle(x, y, e.getX() - x, e.getY() - y);
		FigurePanel f = new FigurePanel(r, data);
		add(f);
		f.requestFocus();
		repaint();
	}
	@Override
	public void mouseClicked(MouseEvent arg0) {}
	@Override
	public void mouseEntered(MouseEvent arg0) {}
	@Override
	public void mouseExited(MouseEvent arg0) {}
	public ArrayList<Figure> getMemento()
	{
		ArrayList<Figure> lst = new ArrayList<Figure>();

		for(Component c : getComponents())
		{
			FigurePanel f = (FigurePanel) c;
			lst.add(f.getMemento());
		}
		return  lst;
	}
	public void setMemento(ArrayList<Figure> ff)
    {
		for (Figure figure : ff)
		{
			FigurePanel f=new FigurePanel();
			f.setMemento(figure);
			add(f);
			f.requestFocus();
			repaint();
		}
    }
	@Override
	public void mouseDragged(MouseEvent e) {}
	@Override
	public void mouseMoved(MouseEvent e) {
		TabPanel tbp=(TabPanel) getParent();
		Panel p=(Panel) tbp.getParent();
		p.sb.setCoords(e.getX(), e.getY());
	}
}
