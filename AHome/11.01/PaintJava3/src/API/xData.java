package API;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import GUI.FigureType;



public class xData implements ActionListener
{
	public int color;
	public int width;
	public FigureType type;
	public xData()
    {
        color=Color.BLACK.getRGB();
        width=4;
        type= FigureType.line;
        
    }
	public xData(int color, int width, FigureType type)
    {
        this.color = color;
        this.width=width;
        this.type=type;
    }
	public xData getCopy()
	{
		return new xData(color, width, type);
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		
	}
}
