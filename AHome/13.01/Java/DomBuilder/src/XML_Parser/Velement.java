package XML_Parser;

import java.util.ArrayList;

public class Velement {
	
	private String type;
	private String id;
	private String value;
	private int x, y;
	private int width, height;
	private ArrayList<Velement> list;
	
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getValue() {
		return value;
	}
	public void setValue(String value) {
		this.value = value;
	}
	public int getX() {
		return x;
	}
	public void setX(int x) {
		this.x = x;
	}
	public int getY() {
		return y;
	}
	public void setY(int y) {
		this.y = y;
	}
	public int getWidth() {
		return width;
	}
	public void setWidth(int width) {
		this.width = width;
	}
	public int getHeight() {
		return height;
	}
	public void setHeight(int height) {
		this.height = height;
	}
	public ArrayList<Velement> getList() {
 	return list;
	}
	public void setList(ArrayList<Velement> list) {
		this.list = list;
	}
	
	public Velement(String type, String id, String value, int x, int y, int width, int height,
			ArrayList<Velement> list) {
		super();
		this.type = type;
		this.id = id;
		this.value = value;
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
		this.list = list;
	}
	
	public Velement(String type, String id, String value, int x, int y, int width, int height) {
		super();
		this.type = type;
		this.id = id;
		this.value = value;
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}
	
	public Velement(){
		
	}
	
}
