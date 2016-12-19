package paint;

import java.awt.BasicStroke;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.awt.event.MouseEvent;

public class FigureFree extends SelectFigure
{

	public FigureFree(PanelDraw draw)
	{
		super(draw);
	}

	
	@Override
	public void mouseDragged(MouseEvent e)
	{
		Graphics2D g = (Graphics2D) panel.sets.image.getGraphics();
		g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		g.setColor(panel.sets.col);
		g.setStroke(new BasicStroke(panel.sets.width));
		g.drawLine(firstX, firstY, e.getX(), e.getY());
		firstX = e.getX();
		firstY = e.getY();
		panel.repaint();
	}
}
