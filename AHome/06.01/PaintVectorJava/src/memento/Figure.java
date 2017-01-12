package memento;

import java.awt.Color;
import java.awt.Rectangle;
import java.util.ArrayList;

import api.FigureType;
import containers.Point;
import panels.FigurePanel;

public class Figure {
	
	private int r;
	private int g;
	private int b;
	
	public int getR() {
		return r;
	}

	public void setR(int r) {
		this.r = r;
	}

	public int getG() {
		return g;
	}

	public void setG(int g) {
		this.g = g;
	}

	public int getB() {
		return b;
	}

	public void setB(int b) {
		this.b = b;
	}
	
	private float width;
	private FigureType type;
	private ArrayList<Point> path;
	private Rectangle rect;
	
	public Color getColor()
	{
		return new Color(r, g, b);
	}

	public void setColor(int r, int g, int b){
		this.r = r;
		this.g = g;
		this.b = b;
	}
	
	private void setColor(Color color) {
		this.r = color.getRed();
		this.g = color.getGreen();
		this.b = color.getBlue();
	}


	public float getWidth() {
		return width;
	}

	public void setWidth(float width) {
		this.width = width;
	}

	public FigureType getType() {
		return type;
	}

	public void setType(FigureType type) {
		this.type = type;
	}

	public ArrayList<Point> getPath() {
		return path;
	}

	public void setPath(ArrayList<Point> path) {
		this.path = path;
	}

	public Rectangle getRect() {
		return rect;
	}

	public void setRect(Rectangle rect) {
		this.rect = rect;
	}
	
	public Figure(FigurePanel panel){
		
		rect = panel.getBounds();
		setColor(panel.getData().getColor());
		width = panel.getData().getWidth();
		type = panel.getData().getType();
		path = panel.getData().getPath();
	}
	
	public Figure(FigurePanel panel, int x0, int y0){
		
		this(panel);
		this.rect.setLocation(x0, y0);
	}
	
	public Figure(){
		
		rect = new Rectangle(0, 0 , 10, 10);
		setColor(Color.black);
		width = 1.0f;
		type = FigureType.MULTILINE;
		path = new ArrayList<>();
	}
	
}
