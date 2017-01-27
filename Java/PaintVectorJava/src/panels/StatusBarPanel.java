package panels;

import java.awt.Rectangle;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionListener;

import javax.swing.BoxLayout;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JSeparator;
import javax.swing.SwingConstants;
import javax.swing.border.BevelBorder;

public class StatusBarPanel extends JPanel implements MouseMotionListener, FocusListener {
	
	private JLabel coordinatesLabel, colorLabel, widthLabel, typeLabel, layerLabel; 
	
	public StatusBarPanel(Rectangle r){
		
		setBorder(new BevelBorder(BevelBorder.LOWERED));
		setBounds(r);
		
		setLayout(new BoxLayout(this, BoxLayout.X_AXIS));
		
		coordinatesLabel = new JLabel("Coordinates");
		colorLabel = new JLabel("Color |");
		widthLabel = new JLabel("Width |");
		typeLabel = new JLabel("Type |");
		layerLabel = new JLabel("Layer |");
		
		add(layerLabel);
		add(coordinatesLabel);
		add(colorLabel);
		add(widthLabel);
		add(typeLabel);
		
		setVisible(true);
	}
	
	private void getInfoFromData(FocusEvent arg0){
		
		Object obj = arg0.getSource();
		
		CanvasPanel panel = null;
		FigurePanel figure = null;
		if (obj.getClass() == (new CanvasPanel(null, null).getClass())){
			panel = (CanvasPanel) arg0.getSource();
		}
		else{
			figure = (FigurePanel)arg0.getSource();
		}
		
		if (panel != null){
			layerLabel.setText("Layer : Canvas  |");
			colorLabel.setText(panel.getData().getColor().toString() + "  |");
			widthLabel.setText(String.valueOf(panel.getData().getWidth()) + "  |");
			typeLabel.setText(panel.getData().getType().toString() + "  |");
		}
		else if (figure != null){
			layerLabel.setText("Layer : Figure  |");
			colorLabel.setText(figure.getData().getColor().toString() + "  |");
			widthLabel.setText(String.valueOf(figure.getData().getWidth()) + "  |");
			typeLabel.setText(figure.getData().getType().toString() + "  |");
		}
	}

	@Override
	public void mouseDragged(MouseEvent arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseMoved(MouseEvent arg0) {
		coordinatesLabel.setText("X : " + arg0.getX() + " Y : " + arg0.getY() + "  |");
	}

	@Override
	public void focusGained(FocusEvent arg0) {
		getInfoFromData(arg0);
	}

	@Override
	public void focusLost(FocusEvent arg0) {
		// TODO Auto-generated method stub
		
	}
	
}
