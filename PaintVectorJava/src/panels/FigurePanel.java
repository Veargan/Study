package panels;

import java.awt.BorderLayout;
import java.awt.Rectangle;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JPopupMenu;

import api.FigureType;
import api.RenderApi;
import api.XCommand;
import api.XData;
import containers.Point;
import figure.Figure;
import size.SizePanel;
import size.SizePanelLocation;

public class FigurePanel extends JPanel implements MouseListener, MouseMotionListener, KeyListener{

	private static final int OFFSET_STEP = 1;
	private XData data;
	private Point currentMousePoint;
	private SizePanel east, west, south, north;
	private XCommand cmd;
	
	private JPopupMenu context;
	private JMenuItem saveItem;
	private JMenuItem openItem;
	private JMenuItem colorItem;
	private JMenuItem widthItem;
	private JMenuItem typeItem;
	
	public XData getData() {
		return data;
	}

	public void setData(XData data) {
		this.data = data;
	}
	
	public FigurePanel(Rectangle r, XData data, XCommand cmd) {
		
		this.data = data;
		this.cmd = cmd;
		
		this.addMouseListener(this);
		this.addMouseMotionListener(this);
		this.addKeyListener(this);
		
		setBounds(r);
		setVisible(true);
		
		initializeComponents();
		
		colorItem.addActionListener(cmd.getColor());
		widthItem.addActionListener(cmd.getWidth());
		typeItem.addActionListener(cmd.getType());
		saveItem.addActionListener(cmd.getSave());
		openItem.addActionListener(cmd.getLoad());
		
		this.setComponentPopupMenu(context);
	}
	
	private void initializeComponents(){
		
		east = new SizePanel(this, new Rectangle(), SizePanelLocation.EAST);
		west = new SizePanel(this, new Rectangle(), SizePanelLocation.WEAST);
		south = new SizePanel(this, new Rectangle(), SizePanelLocation.SOUTH);
		north = new SizePanel(this, new Rectangle(), SizePanelLocation.NORTH);
		context = new JPopupMenu();
		
		saveItem = new JMenuItem("Save as");
		openItem = new JMenuItem("Open");
		colorItem = new JMenuItem("Select color");
		widthItem = new JMenuItem("Select line width");
		typeItem = new JMenuItem("Select figure shape");
		
		setLayout(new BorderLayout()); 
		add(east, BorderLayout.EAST);
		add(west, BorderLayout.WEST);
		add(south, BorderLayout.SOUTH);
		add(north, BorderLayout.NORTH);
		
		context.add(saveItem);
		context.addSeparator();
		context.add(openItem);
		context.addSeparator();
		context.add(colorItem);
		context.addSeparator();
		context.add(widthItem);
		context.addSeparator();
		context.add(typeItem);
	}
	
	public void setSizePanelsVisible(boolean result){
		
		this.east.setVisible(result);
		this.west.setVisible(result);
		this.south.setVisible(result);
		this.north.setVisible(result);
	}
	
	public void redraw(){
		
		render(data.getType());
	}
	
	public void render(FigureType type){
		Rectangle r = getBounds();
		switch(type){
			case MULTILINE:{
				RenderApi.startLinesPaintOnFigurePanel(this.getGraphics(), data);
				break;
			}
			case LINE:{
				RenderApi.startLinePaintOnFigurePanel(getGraphics(), data, 0, 0, r.width, r.height);
				break;
			}
			case ELLIPSE:{
				RenderApi.startEllipseOnFigurePanel(getGraphics(), data, 0, 0 , r.width, r.height);
				break;
			}
			case RECTANGLE:{
				RenderApi.startRectangleOnFigurePanel(getGraphics(), data, 0, 0, r.width, r.height);
				break;
			}
			case CRECTANGLE:{
				RenderApi.startCRectangleOnFigurePanel(getGraphics(), data, 0, 0 , r.width, r.height);
				break;
			}
		}
	}
	
	@Override
	public void mouseClicked(MouseEvent e) {
		
		this.requestFocus();
	}

	@Override
	public void mouseDragged(MouseEvent e) {
		
		Rectangle r = this.getBounds();
		int deltaX = e.getX() - currentMousePoint.getX();
		int deltaY = e.getY() - currentMousePoint.getY();
		changeBounds(this, r.x  + deltaX, r.y  + deltaY, r.width, r.height);
	}

	@Override
	public void mouseMoved(MouseEvent e) {
		
		currentMousePoint = new Point(e.getX(), e.getY());
	}

	@Override
	public void keyPressed(KeyEvent arg0) {
		
		arrowKeysDown(arg0);
		copyKey(arg0);
		pasteKey(arg0);
	}
	
	private void changeBounds(JPanel owner, int x0, int y0, int width, int height){
		FigurePanel o = (FigurePanel) owner;
		o.setBounds(x0, y0, width, height);
		o.repaint();
		o.redraw();
	}
	
	private void arrowKeysDown(KeyEvent arg0){
		
		Rectangle r = this.getBounds();
		int x0 = r.x, y0 = r.y, width = r.width, height = r.height;
		
		switch (arg0.getKeyCode()){
		case KeyEvent.VK_UP: {
			y0 -= OFFSET_STEP;
			if (arg0.isShiftDown()){
				
				height += OFFSET_STEP;
			}
			break;
		}
		case KeyEvent.VK_DOWN: {
			
			if (arg0.isShiftDown()){
				height += OFFSET_STEP;
			}else{
				y0 += OFFSET_STEP;
			}
			break;
		}
		case KeyEvent.VK_LEFT: {
			x0 -= OFFSET_STEP;
			if (arg0.isShiftDown()){

				width += OFFSET_STEP;
			}
			break;
		}
		case KeyEvent.VK_RIGHT: {
		
			if (arg0.isShiftDown()){
				width += OFFSET_STEP;
			}else{
				x0 += OFFSET_STEP;
			}
			break;
		}
		}
		
		changeBounds(this, x0 , y0, width, height);
	}
	
	private void copyKey(KeyEvent e){
		
		if (e.getKeyCode() == KeyEvent.VK_C && e.isControlDown()){
			
			Figure figure = new Figure(this, 0, 0);
			cmd.getTabbedPanel().getActiveCanvas().setCopyFigure(figure);
		}
	}
	
	private void pasteKey(KeyEvent e){
		
		if (e.getKeyCode() == KeyEvent.VK_V && e.isControlDown()){
			
			Figure figure = cmd.getTabbedPanel().getActiveCanvas().getCopyFigure();
			FigurePanel copyFigure = 
					new FigurePanel(figure.getRect(), new XData(figure.getColor(),
							figure.getWidth(), figure.getType(), figure.getPath()), cmd);
			
			copyFigure.addFocusListener(cmd.getTabbedPanel().getActiveCanvas());
			copyFigure.addFocusListener(cmd.getTabbedPanel().getStatus());
			
			cmd.getTabbedPanel().getActiveCanvas().add(copyFigure);
			copyFigure.requestFocus();
			cmd.getTabbedPanel().getActiveCanvas().repaint();
		}
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
		
		
		
	}

	@Override
	public void mouseReleased(MouseEvent e) {
	
	}
	
	@Override
	public void keyReleased(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void keyTyped(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}

}
