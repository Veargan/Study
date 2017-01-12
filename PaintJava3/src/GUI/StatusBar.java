package GUI;

import javax.swing.JLabel;
import javax.swing.JPanel;

import API.xData;

public class StatusBar extends JPanel
{
	public static JLabel xLabel;
    public static JLabel yLabel;
    private JLabel colorLabel;
    private JLabel widthLabel;
    private JLabel typeLabel;public StatusBar()
    {
    	setLayout(null);

        xLabel = new JLabel("X: ");
        yLabel = new JLabel("Y: ");
        colorLabel = new JLabel("Color: ");
        widthLabel = new JLabel("Width: ");
        typeLabel = new JLabel("Type: ");
        
        xLabel.setBounds(0, 0, 60, 20);
        yLabel.setBounds(60, 0, 60, 20);
        colorLabel.setBounds(120, 0, 200, 20);
        widthLabel.setBounds(320, 0, 120, 20);
        typeLabel.setBounds(440, 0, 120, 20);

        add(xLabel);
        add(yLabel);
        add(colorLabel);
        add(widthLabel);
        add(typeLabel);
	}
    public void setCoords(int x, int y)
    {
    	xLabel.setText("X: "+x);
    	yLabel.setText("Y: "+y);
    }
    public void setData(xData data)
    {
    	colorLabel.setText("Color: "+data.color);
    	widthLabel.setText("Width: "+data.width);
    	typeLabel.setText("Type: "+data.type);
    }
}
