package API;

import java.awt.Rectangle;
import java.io.Serializable;

public class Figure implements Serializable
{
	public Rectangle r;
	public xData data;
	public Figure(){}
	public Figure(Rectangle r, xData data)
	{
		this.r=r;
		this.data=data;
	}

}
