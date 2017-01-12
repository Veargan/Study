package GUI;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Cursor;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.Rectangle;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.JPanel;

import API.Figure;
import API.xData;

public class FigurePanel extends JPanel implements FocusListener, MouseMotionListener, MouseListener, KeyListener
{
	xData data=null;
	private int x;
    private int y;
    ResizePanel resizePanelTopLeft;
	ResizePanel resizePanelTop;
	ResizePanel resizePanelTopRight;
	ResizePanel resizePanelRight;
	ResizePanel resizePanelBotRight;
	ResizePanel resizePanelBot;
	ResizePanel resizePanelBotLeft;
	ResizePanel resizePanelLeft;
	private boolean isCopied=false;
	public FigurePanel()
	{
	}
	public FigurePanel(Rectangle r, xData data)
	{
		setOpaque(false);
		setLayout(null);
		this.data=data.getCopy();
		setBounds(r);
		
		addMouseListener(this);
        addFocusListener(this);
        addMouseMotionListener(this);
        addKeyListener(this);
        
        addResizePanels();
	}
	void addResizePanels()
	{
		resizePanelTopLeft 	= new ResizePanel(0, 				  0);
		resizePanelTop 		= new ResizePanel(getWidth() / 2 - 5, 0);
		resizePanelTopRight = new ResizePanel(getWidth() - 10, 	  0);
		resizePanelRight 	= new ResizePanel(getWidth() - 10, 	  getHeight() / 2 - 5);
		resizePanelBotRight = new ResizePanel(getWidth() - 10, 	  getHeight() - 10);
		resizePanelBot 		= new ResizePanel(getWidth() / 2 - 5, getHeight() - 10);
		resizePanelBotLeft 	= new ResizePanel(0, 				  getHeight() - 10);
		resizePanelLeft 	= new ResizePanel(0, 				  getHeight() / 2 - 5);
		
		resizePanelTopLeft .setTag("TopLeft", new Cursor(Cursor.NW_RESIZE_CURSOR));
		resizePanelTop	   .setTag("Top", new Cursor(Cursor.N_RESIZE_CURSOR));
		resizePanelTopRight.setTag("TopRight", new Cursor(Cursor.NE_RESIZE_CURSOR));
		resizePanelRight   .setTag("Right", new Cursor(Cursor.E_RESIZE_CURSOR));
		resizePanelBotRight.setTag("BotRight", new Cursor(Cursor.SE_RESIZE_CURSOR));
		resizePanelBot	   .setTag("Bot", new Cursor(Cursor.S_RESIZE_CURSOR));
		resizePanelBotLeft .setTag("BotLeft", new Cursor(Cursor.SW_RESIZE_CURSOR));
		resizePanelLeft	   .setTag("Left", new Cursor(Cursor.W_RESIZE_CURSOR));
		
		add(resizePanelTopLeft);
		add(resizePanelTop);
		add(resizePanelTopRight);
		add(resizePanelRight);
		add(resizePanelBotRight);
		add(resizePanelBot);
		add(resizePanelBotLeft);
		add(resizePanelLeft);
	}
	
	void refreshResizePanels()
	{
		resizePanelTopLeft .setLocation(0, 					0);
		resizePanelTop	   .setLocation(getWidth() / 2 - 5, 0);
		resizePanelTopRight.setLocation(getWidth() - 10, 	0);
		resizePanelRight   .setLocation(getWidth() - 10, 	getHeight() / 2 - 5);
		resizePanelBotRight.setLocation(getWidth() - 10, 	getHeight() - 10);
		resizePanelBot	   .setLocation(getWidth() / 2 - 5, getHeight() - 10);
		resizePanelBotLeft .setLocation(0, 				  	getHeight() - 10);
		resizePanelLeft	   .setLocation(0, 				  	getHeight() / 2 - 5);
	}
	
	void showResizePanels()
	{
		
		resizePanelTopLeft .setOpaque(true);
		resizePanelTop	   .setOpaque(true);
		resizePanelTopRight.setOpaque(true);
		resizePanelRight   .setOpaque(true);
		resizePanelBotRight.setOpaque(true);
		resizePanelBot	   .setOpaque(true);
		resizePanelBotLeft .setOpaque(true);
		resizePanelLeft	   .setOpaque(true);
	}
	
	void hideResizePanels()
	{
		resizePanelTopLeft .setOpaque(false);
		resizePanelTop	   .setOpaque(false);
		resizePanelTopRight.setOpaque(false);
		resizePanelRight   .setOpaque(false);
		resizePanelBotRight.setOpaque(false);
		resizePanelBot	   .setOpaque(false);
		resizePanelBotLeft .setOpaque(false);
		resizePanelLeft	   .setOpaque(false);
	}
	public Figure getMemento()
    {
        return new Figure(new Rectangle(getLocation().x, getLocation().y, getWidth(), getHeight()), data);
    }
	public void setMemento(Figure fi)
	{
		setOpaque(false);
		setLayout(null);
		setBounds(fi.r);
		this.data=fi.data.getCopy();
		
		addMouseListener(this);
        addFocusListener(this);
        addMouseMotionListener(this);
        addKeyListener(this);
        
        addResizePanels();
	}
	@Override
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		Graphics2D g2 = (Graphics2D) g;
		g2.setStroke(new BasicStroke(data.width));
		g.setColor(Color.getColor("", data.color));
		switch(data.type)
		{
		case line:
			g.drawLine(0, 0, getWidth(), getHeight());
			break;
		case rectangle:
			g.drawRect(0, 0, getWidth(), getHeight());
			break;
		case r_rectangle:
			g.drawRoundRect(0, 0, getWidth(), getHeight(), getWidth() / 5, getHeight() / 5);
			break;
		case oval:
			g.drawOval(0, 0, getWidth(), getHeight());
		}
		
	}
	@Override
	public void mousePressed(MouseEvent e)
	{
		
		if (e.getButton() == e.BUTTON1)
        {
			requestFocus();
		    x = e.getX();
            y = e.getY();
        }
	}
	@Override
	public void mouseReleased(MouseEvent e){}
	@Override
	public void focusGained(FocusEvent e)
	{
		showResizePanels();
		PaintPanel pp=(PaintPanel) getParent();
		pp.data=data;
		TabPanel tbp=(TabPanel) pp.getParent();
		Panel p = (Panel) tbp.getParent();
		p.sb.setData(data);;
		repaint();
	}

	@Override
	public void focusLost(FocusEvent e)
	{
		hideResizePanels();
		repaint();
	}
	@Override
	public void mouseClicked(MouseEvent e) {}

	@Override
	public void mouseEntered(MouseEvent e) {}

	@Override
	public void mouseExited(MouseEvent e) {}
	
	@Override
	public void mouseDragged(MouseEvent e)
	{
		int dx = e.getX() - x; 
		int dy = e.getY() - y; 

		setLocation(getX() + dx, getY() + dy); 
		e.consume();
		
	}
	@Override
	public void mouseMoved(MouseEvent e)
	{
		PaintPanel pp=(PaintPanel) getParent();
		TabPanel tbp=(TabPanel) pp.getParent();
		Panel p = (Panel) tbp.getParent();
		p.sb.setCoords(getLocation().x+e.getX(), getLocation().y+e.getY());
	}
	@Override
	public void keyPressed(KeyEvent e)
	{
		Point p = new Point();
		p=getLocation();
		if (e.getKeyCode() == KeyEvent.VK_UP&& !e.isShiftDown()) {
		    setLocation((int)p.getX(), (int)p.getY()-5);
        }
		if (e.getKeyCode() == KeyEvent.VK_DOWN && !e.isControlDown() && !e.isShiftDown()) {
		    setLocation((int)p.getX(), (int)p.getY()+5);
        }
		if (e.getKeyCode() == KeyEvent.VK_LEFT&&!e.isShiftDown()) {
		    setLocation((int)p.getX()-5, (int)p.getY());
        }
		if (e.getKeyCode() == KeyEvent.VK_RIGHT && !e.isControlDown()&& !e.isShiftDown()) {
		    setLocation((int)p.getX()+5, (int)p.getY());
        }
		if (e.getKeyCode() == KeyEvent.VK_RIGHT && e.isControlDown()) {
		    setSize(getWidth()+5, getHeight());
		    refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_UP && e.isControlDown()) {
			setSize(getWidth(), getHeight()+5);
			refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_DOWN && e.isControlDown() ) {
			setSize(getWidth(), getHeight()+5);
			refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_LEFT  && e.isControlDown() ) {
			setSize(getWidth()+5, getHeight());
			refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_RIGHT && e.isShiftDown()) {
		    setSize(getWidth()-5, getHeight());
		    refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_UP && e.isShiftDown()&& !e.isControlDown()) {
			setSize(getWidth(), getHeight()-5);
			refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_DOWN && e.isShiftDown() ) {
			setSize(getWidth(), getHeight()-5);
			refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_LEFT  && e.isShiftDown() ) {
			setSize(getWidth()-5, getHeight());
			refreshResizePanels();
        }
		if (e.getKeyCode() == KeyEvent.VK_C && e.isControlDown())
		{
			if(isFocusOwner())
				isCopied=true;
		}
		if (e.getKeyCode() == KeyEvent.VK_V && e.isControlDown() )
		{
			if(isCopied)
			{
				PaintPanel pp=(PaintPanel) getParent();
				Rectangle r  = new Rectangle(this.getLocation().x+15, this.getLocation().y+15, getWidth(), getHeight());
				FigurePanel f = new FigurePanel(r, data);
				pp.add(f);
				f.requestFocus();
			}
		}
	}
	@Override
	public void keyReleased(KeyEvent arg0) {}
	@Override
	public void keyTyped(KeyEvent arg0) {}

}
