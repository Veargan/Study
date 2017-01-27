package paint;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

public abstract class SelectFigure implements MouseListener,
		MouseMotionListener
{
	PanelDraw panel;
	int firstX;
	int firstY;
	int lastX;
	int lastY;

	public SelectFigure(PanelDraw draw)
	{
		panel = draw;
	}

	@Override
	public void mouseDragged(MouseEvent e)
	{
	}

	@Override
	public void mouseMoved(MouseEvent e)
	{
	}

	@Override
	public void mouseReleased(MouseEvent e)
	{
	}

	@Override
	public void mousePressed(MouseEvent e)
	{
		firstX = e.getX();
		firstY = e.getY();
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
}
