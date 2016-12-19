package paint;

import java.awt.BasicStroke;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.awt.event.MouseEvent;

public class FigureCircle extends SelectFigure
{

	public FigureCircle(PanelDraw draw)
	{
		super(draw);
	}

	

	@Override
	public void mouseReleased(MouseEvent e)
	{
		lastX = e.getX();
		lastY = e.getY();
		Graphics2D g = (Graphics2D) panel.sets.image.getGraphics();
		g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		g.setColor(panel.sets.col);
		g.setStroke(new BasicStroke(panel.sets.width));

		int width = Math.abs(firstX - lastX);
		int height = Math.abs(firstY - lastY);

		if (firstX < lastX && firstY < lastY)
		{
			g.drawOval(firstX, firstY, width, height);
		} else if (firstX > lastX && firstY > lastY)
		{
			g.drawOval(lastX, lastY, width, height);
		} else if (firstX < lastX && firstY > lastY)
		{
			g.drawOval(firstX, lastY, width, height);
		} else if (firstX > lastX && firstY < lastY)
		{
			g.drawOval(lastX, firstY, width, height);
		}
		panel.repaint();
	}

}
