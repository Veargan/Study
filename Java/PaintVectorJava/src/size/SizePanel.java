package size;

import java.awt.Color;
import java.awt.Rectangle;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.JPanel;

import containers.Point;
import panels.FigurePanel;

public class SizePanel extends JPanel implements MouseListener {
	
	private FigurePanel parent;
	private Point currentMousePoint;
	private SizePanelLocation location;
	
	public SizePanel(FigurePanel parent, Rectangle r, SizePanelLocation location){
		
		this.setBounds(r);
		this.setBackground(Color.BLACK);
		this.addMouseListener(this);
		
		this.parent = parent;
		this.location = location;
	}

	private void resizeParent(MouseEvent e){
		Rectangle r = parent.getBounds();
		int deltaX = e.getX() - currentMousePoint.getX();
		int deltaY = e.getY() - currentMousePoint.getY();
		
		switch (this.location){
		
		case EAST:{
			
			parent.setBounds(r.x, r.y, r.width + deltaX, r.height);
			this.setBounds(r.x, r.y, r.width + deltaX, r.height);
			break;
		}
		case WEAST:{
			this.setBounds(r.x  + deltaX, r.y , r.width - deltaX, r.height);
			parent.setBounds(r.x  + deltaX, r.y , r.width  - deltaX, r.height);
			break;
		}
		case NORTH:{
			this.setBounds(r.x, r.y  + deltaY, r.width, r.height  - deltaY);
			parent.setBounds(r.x, r.y  + deltaY, r.width, r.height  - deltaY);
			break;
		}
		case SOUTH:{
			this.setBounds(r.x, r.y, r.width, r.height  + deltaY);
			parent.setBounds(r.x, r.y, r.width, r.height  + deltaY);
			break;
		}
		}
		
		parent.repaint();
		parent.redraw();
	}

	@Override
	public void mouseClicked(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseEntered(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseExited(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mousePressed(MouseEvent e) {
		
		currentMousePoint = new Point(e.getX(), e.getY());
	}

	@Override
	public void mouseReleased(MouseEvent e) {
		
		resizeParent(e);
	}
}
