package api;

import java.awt.Color;
import java.util.ArrayList;

import containers.Point;

public class XData {

	private Color color;
	private float width;
	private FigureType type;
	private ArrayList<Point> path;
	private Point previousPoint;
	
	public XData(){
		
		color = Color.BLACK;
		width = 1.0f;
		type = FigureType.MULTILINE;
		path = new ArrayList<>();
	}
	
	public XData(Color color, float width, FigureType type, ArrayList<Point> path){
		
		this.color = color;
		this.width = width;
		this.type = type;
		this.path = path;
	}
	
	@SuppressWarnings("unchecked")
	@Override
	public Object clone(){
		XData object = new XData();
		object.setColor(color);
		object.setWidth(width);
		object.setType(type);
		object.setPath((ArrayList<Point>)path.clone());
		object.setPreviousPoint(previousPoint);
		return object;
	}
	
	public Point getUpperLeftCorner(){
		int minX = getPreviousPoint().getX(), minY = getPreviousPoint().getY();
		for (Point p : path){
			if (minX > p.getX()){
				minX = p.getX();
			}
			if (minY > p.getY()){
				minY = p.getY();
			}
		}
		return new Point(minX, minY);
	}
	
	public Point getBottomRightCorner(){
		int maxX = path.get(0).getX(), maxY = path.get(0).getY();
		for (Point p : path){
			if (maxX < p.getX()){
				maxX = p.getX();
			}
			if (maxY < p.getY()){
				maxY = p.getY();
			}
		}
		return new Point(maxX, maxY);
	}
	
	public void setPathOffset(){
		int minX = path.get(0).getX(), minY = path.get(0).getY();
		
		Point point = getUpperLeftCorner();
		minX = point.getX();
		minY = point.getY();
		
		for (int  i = 0; i < path.size(); i++){
			Point p = path.get(i);
			path.set(i, new Point(p.getX() - minX, p.getY() - minY));
		}
	}
	
	public void addPointToPath(Point point){
		if (type == FigureType.MULTILINE){
			this.path.add(point);
		}
		this.previousPoint = point;		
	}
	
	public void setColor(Color color){
		this.color = color;
	}
	
	public void setWidth(float width){
		this.width = width;
	}
	
	public void setType(FigureType type){
		this.type = type;
	}
	
	public void setPath(ArrayList<Point> path){
		this.path = path;
	}
	
	public void setPreviousPoint(Point prevPoint){
		previousPoint = prevPoint; 
	}
	
	public Color getColor(){
		return color;
	}
	
	public float getWidth(){
		return width;
	}
	
	public FigureType getType(){
		return type;
	}
	
	public ArrayList<Point> getPath(){
		return path;
	}
	
	public Point getPreviousPoint(){
		return previousPoint;
	}
}
