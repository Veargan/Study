package panels;

import java.awt.Color;
import java.awt.Component;
import java.awt.Rectangle;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.util.ArrayList;

import javax.swing.BorderFactory;
import javax.swing.JPanel;

import api.FigureType;
import api.RenderApi;
import api.XCommand;
import api.XData;
import containers.Point;
import memento.Figure;

public class CanvasPanel extends JPanel implements MouseListener, MouseMotionListener, FocusListener {
	
	private XData data;
	private XCommand cmd;

	private FigurePanel inFocusFigure;
	private Figure copyFigure;

	public Figure getCopyFigure() {
		return copyFigure;
	}

	public void setCopyFigure(Figure copyFig) {
		this.copyFigure = copyFig;
	}
	
	public void setData(XData data){
		this.data = data;
	}
	
	public XData getData(){
		return data;
	}
	
	public void setInFocusFigure(FigurePanel f){
		this.inFocusFigure = f;
	}
	
	public FigurePanel getInFocusFigure(){
		return this.inFocusFigure;
	}

	public CanvasPanel(Rectangle r, XCommand cmd){
		
		if (r == null) return;
		
		this.cmd = cmd;
		this.inFocusFigure = null;
		this.copyFigure = null;
		
		setBackground(Color.ORANGE);
		setLayout(null);
		
		addMouseListener(this);
		addMouseMotionListener(cmd.getTabbedPanel().getStatus());
		addMouseMotionListener(this);
		addFocusListener(cmd.getTabbedPanel().getStatus());
		addFocusListener(this);
		setBounds(r);
		setVisible(true);
		data = new XData();
	}

	private void addFigureToCanvas(MouseEvent e){
		
		int leftX = 0, topY = 0, rightX = 0, bottomY = 0;
		if (data.getType() == FigureType.MULTILINE){
		
			Point upperLeft = data.getUpperLeftCorner();
			Point bottomRight = data.getBottomRightCorner();
			data.setPathOffset();
			leftX = upperLeft.getX();
			topY = upperLeft.getY();
			rightX = bottomRight.getX();
			bottomY = bottomRight.getY();
		}
		else{
			
			Point p = data.getPreviousPoint();
			leftX = p.getX();
			topY = p.getY();
			rightX = e.getX();
			bottomY = e.getY();
		}
		
		FigurePanel figure = new FigurePanel(
				new Rectangle(leftX, topY, rightX - leftX, bottomY - topY), (XData)data.clone(), cmd);
		figure.addFocusListener(this);
		figure.addFocusListener(cmd.getTabbedPanel().getStatus());
		add(figure);
		figure.render(data.getType());
		figure.requestFocus();
		repaint();
		data.getPath().clear();	
	}

	@Override
	public void mouseClicked(MouseEvent e) {
		requestFocus();
	}


	@Override
	public void mousePressed(MouseEvent e) {
		
		data.addPointToPath(new Point(e.getX(), e.getY()));
	}


	@Override
	public void mouseReleased(MouseEvent e) {
		
		addFigureToCanvas(e);
	}


	@Override
	public void mouseDragged(MouseEvent e) {
		
		if (data.getType() == FigureType.MULTILINE){
			int x = e.getX();
			int y = e.getY();
			RenderApi.startLinePaintOnGraphics(getGraphics(), data,  x, y);
			data.addPointToPath(new Point(x, y));
		}
	}

	@Override
	public void focusGained(FocusEvent e) {
		focusOn(e);
	}

	@Override
	public void focusLost(FocusEvent e) {
		focusOff(e);
	}
	
	private void focusOff(FocusEvent arg0){
		Object obj = arg0.getSource();
		
		CanvasPanel panel = null;
		FigurePanel figure = null;
		if (obj.getClass() == (new CanvasPanel(null, null).getClass())){
			panel = (CanvasPanel) arg0.getSource();
		}
		else{
			figure = (FigurePanel)arg0.getSource();
		}
		
		if (figure != null){
			figure.setSizePanelsVisible(false);
		}
	}

	private void focusOn(FocusEvent arg0){
		
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
			this.inFocusFigure = null;
		}
		else{
			this.inFocusFigure = figure;
			inFocusFigure.setSizePanelsVisible(true);
		}
	}
	
	public void setMemento(Iterable<Figure> figures){
		
		removeAll();
		this.inFocusFigure = null;
		this.copyFigure = null;
		
		for (Figure f : figures){
			FigurePanel figure = new FigurePanel(f.getRect(),
					new XData(f.getColor(), f.getWidth(), f.getType(), f.getPath()), cmd);
			add(figure);
			figure.redraw();
		}
		repaint();
	}
	
	public Iterable<Figure> getMemento(){
		
		ArrayList<Figure> figures = new ArrayList<>();
		for(Component c : this.getComponents()){
			figures.add(new Figure((FigurePanel) c));
		}
		
		return figures;
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
	public void mouseMoved(MouseEvent e) {
		
	}
}
