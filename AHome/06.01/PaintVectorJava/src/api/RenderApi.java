package api;

import java.awt.BasicStroke;
import java.awt.Graphics;
import java.awt.Graphics2D;

import containers.Point;

public class RenderApi {
	
	public static void startLinePaintOnGraphics(Graphics g, XData data, int x, int y){
		Graphics2D graph2D = (Graphics2D)g;
        graph2D.setColor(data.getColor());
        graph2D.setStroke(new BasicStroke(data.getWidth()));
        graph2D.drawLine(data.getPreviousPoint().getX(), data.getPreviousPoint().getY(), x, y);
	}
	
	public static void startLinePaintOnFigurePanel(Graphics g, XData data, int x1, int y1, int x2, int y2){
		Graphics2D graph2D = (Graphics2D)g;
        graph2D.setColor(data.getColor());
        graph2D.setStroke(new BasicStroke(data.getWidth()));
        graph2D.drawLine(x1, y1, x2, y2);
	}
	
	public static void startLinesPaintOnFigurePanel(Graphics g, XData data){
		Graphics2D graph2D = (Graphics2D)g;
        graph2D.setColor(data.getColor());
        graph2D.setStroke(new BasicStroke(data.getWidth()));
        
        int size = data.getPath().size();
        int[] xPoints = new int[size];
        int[] yPoints = new int[size];
        
        for (int i = 0;i < xPoints.length; i++){
        	Point p = data.getPath().get(i);
        	xPoints[i] = p.getX();
        	yPoints[i] = p.getY();
        }
        
        graph2D.drawPolyline(xPoints, yPoints, size);
	}
	
	public static void startEllipseOnFigurePanel(Graphics g, XData data, int x1, int y1, int width, int height){
		Graphics2D graph2D = (Graphics2D)g;
        graph2D.setColor(data.getColor());
        graph2D.setStroke(new BasicStroke(data.getWidth()));
        graph2D.drawOval(x1, y1,
        		width, height);
	}
	
	public static void startRectangleOnFigurePanel(Graphics g, XData data, int x1, int y1, int width, int height){
		
		Graphics2D graph2D = (Graphics2D)g;
        graph2D.setColor(data.getColor());
        graph2D.setStroke(new BasicStroke(data.getWidth()));
        graph2D.drawRect(x1 + 5, y1 + 5,
        		width - 10, height - 10);
	}
	
	public static void startCRectangleOnFigurePanel(Graphics g, XData data, int x1, int y1, int width, int height){
			
			Graphics2D graph2D = (Graphics2D)g;
	        graph2D.setColor(data.getColor());
	        graph2D.setStroke(new BasicStroke(data.getWidth()));
	        graph2D.drawRoundRect(x1 + 5, y1 + 5,
	        		width - 10, height - 10, 13, 13);
	}

}
