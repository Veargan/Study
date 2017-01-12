package GUI;

import java.awt.Color;
import java.awt.Cursor;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.JPanel;

public class ResizePanel extends JPanel implements MouseListener, MouseMotionListener
{
	private static final long serialVersionUID = 1L;
	
	String tag = "";
	
	int x;
	int y;
	
	
	public ResizePanel(int x, int y)
	{
		setBounds(x, y, 10, 10);
		setBackground(Color.black);
		
		addMouseListener(this);
		addMouseMotionListener(this);
		
		repaint();
	}
	
	public void setTag(String tag, Cursor c)
	{
		this.tag = tag;
		setCursor(c);
	}

	@Override
	public void mousePressed(MouseEvent e) 
	{
		x = e.getX();
		y = e.getY();
	}
	
	@Override
	public void mouseDragged(MouseEvent e) 
	{
		int dx = e.getX() - x;
		int dy = e.getY() - y;
		
		switch (tag)
		{
			case "TopLeft":
				resizePanelTopLeft_MouseMove(dx, dy);
				break;
			case "Top":
				resizePanelTop_MouseMove(dx, dy);
				break;
			case "TopRight":
				resizePanelTopRight_MouseMove(dx, dy);
				break;
			case "Right":
				resizePanelRight_MouseMove(dx, dy);
				break;
			case "BotRight":
				resizePanelBotRight_MouseMove(dx, dy);
				break;
			case "Bot":
				resizePanelBot_MouseMove(dx, dy);
				break;
			case "BotLeft":
				resizePanelBotLeft_MouseMove(dx, dy);
				break;
			case "Left":
				resizePanelLeft_MouseMove(dx, dy);
				break;
            default:
            	break;
		}
		
		x = e.getX();
		y = e.getY();
	}

	@Override
	public void mouseMoved(MouseEvent e) 
	{
		
	}
	
	private void resizePanelTopLeft_MouseMove(int dx, int dy)
    {
        resizePanelTop_MouseMove(dx, dy);
        resizePanelLeft_MouseMove(dx, dy);
    }

    private void resizePanelTop_MouseMove(int dx, int dy)
    {
    	FigurePanel pp=(FigurePanel) getParent();
    	pp.setLocation(pp.getX(), pp.getY() + dy);
    	pp.setSize(pp.getWidth(), pp.getHeight() - dy);
    	pp.refreshResizePanels();
    	pp.repaint();
    }

    private void resizePanelTopRight_MouseMove(int dx, int dy)
    {
        resizePanelTop_MouseMove(dx, dy);
        resizePanelRight_MouseMove(dx, dy);
    }

    private void resizePanelRight_MouseMove(int dx, int dy)
    {
    	FigurePanel pp=(FigurePanel) getParent();
    	setLocation(getX() + dx, getY());
    	pp.setSize(getX() + getWidth(), pp.getHeight());
    	pp.refreshResizePanels();
    	pp.repaint();
    }

    private void resizePanelBotRight_MouseMove(int dx, int dy)
    {
        resizePanelBot_MouseMove(dx, dy);
        resizePanelRight_MouseMove(dx, dy);
    }

    private void resizePanelBot_MouseMove(int dx, int dy)
    {
    	FigurePanel pp=(FigurePanel) getParent();
    	setLocation(getX(), getY() + dy);
    	pp.setSize(pp.getWidth(), getY() + getHeight());
    	pp.refreshResizePanels();
    	pp.repaint();
    }

    private void resizePanelBotLeft_MouseMove(int dx, int dy)
    {
        resizePanelBot_MouseMove(dx, dy);
        resizePanelLeft_MouseMove(dx, dy);
    }

    private void resizePanelLeft_MouseMove(int dx, int dy)
    {
    	FigurePanel pp=(FigurePanel) getParent();
    	pp.setLocation(pp.getX() + dx, pp.getY());
    	pp.setSize(pp.getWidth() - dx, pp.getHeight());
    	pp.refreshResizePanels();
    	pp.repaint();
    }

	@Override
	public void mouseClicked(MouseEvent e) 
	{
		
	}

	@Override
	public void mouseEntered(MouseEvent e) 
	{
		
	}

	@Override
	public void mouseExited(MouseEvent e) 
	{
		
	}

	@Override
	public void mouseReleased(MouseEvent e) 
	{
		
	}
}
