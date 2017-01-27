package api;

import java.awt.Color;
import java.awt.Component;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JColorChooser;
import javax.swing.JFileChooser;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;

import dialogs.VectorDialogs;
import dialogs.WidthDialog;
import io.ISavable;
import io.IoCreator;
import panels.CanvasPanel;
import panels.FigurePanel;
import panels.TabbedPanel;

public class XCommand {
	
	private TabbedPanel tab;
	
	public TabbedPanel getTabbedPanel() {
		return tab;
	}

	public void setTabbedPanel(TabbedPanel tab) {
		this.tab = tab;
	}

	public XCommand(TabbedPanel tab) {
		super();
	
		this.tab = tab;
		color = new ActionColor();
		width = new ActionWidth();
		type = new ActionType();
		save = new ActionSave();
		load = new ActionLoad();
		_new = new ActionNew();
		window = new ActionWindow();
	}
	
	private ActionColor color;
	private ActionWidth width;
	private ActionType type;
	private ActionSave save;
	private ActionLoad load;
	private ActionNew _new;
	private ActionWindow window;
	
	public ActionWindow getWindow() {
		return window;
	}

	public void setWindow(ActionWindow window) {
		this.window = window;
	}

	public ActionColor getColor() {
		return color;
	}

	public void setColor(ActionColor color) {
		this.color = color;
	}

	public ActionWidth getWidth() {
		return width;
	}

	public void setWidth(ActionWidth width) {
		this.width = width;
	}

	public ActionType getType() {
		return type;
	}

	public void setType(ActionType type) {
		this.type = type;
	}
	
	public ActionSave getSave() {
		return save;
	}

	public void setSave(ActionSave save) {
		this.save = save;
	}

	public ActionLoad getLoad() {
		return load;
	}

	public void setLoad(ActionLoad load) {
		this.load = load;
	}
	
	public ActionNew getNew() {
		return this._new;
	}
	
	public void setNew(ActionNew _new){
		this._new = _new;
	}

	public class ActionColor implements ICommand {

		@Override
		public void actionPerformed(ActionEvent e) {
			Color color = JColorChooser.showDialog(null, "Color chooser", Color.BLACK);
			FigurePanel figure = tab.getActiveCanvas().getInFocusFigure();
			if (figure != null){
				figure.getData().setColor(color);
				figure.redraw();
			}
			else{
				tab.getActiveCanvas().getData().setColor(color);
			}
		}
	}
	
	public class ActionWidth implements ICommand {

		@Override
		public void actionPerformed(ActionEvent e) {
			VectorDialogs.getWidthDialog().showDialog(1.0f);
			float width = VectorDialogs.getWidthDialog().getValue();
			FigurePanel figure = tab.getActiveCanvas().getInFocusFigure();
			if (figure != null){
				figure.getData().setWidth(width);
				figure.redraw();
			}
			else{
				tab.getActiveCanvas().getData().setWidth(width);
			}
		}
	}
	
	public class ActionType	implements ICommand {

		@Override
		public void actionPerformed(ActionEvent e) {
			VectorDialogs.getFigureDialog().showDialog();
			FigureType type = VectorDialogs.getFigureDialog().getValue();
			FigurePanel figure = tab.getActiveCanvas().getInFocusFigure();
			if (figure != null){
				figure.getData().setType(type);
				figure.redraw();
			}
			else{
				tab.getActiveCanvas().getData().setType(type);
			}
		}
		
	}
	
	public class ActionSave implements ICommand {

		private ISavable ioSave;

		@Override
		public void actionPerformed(ActionEvent e) {
			VectorDialogs.getIODialog().showDialog();
			ioSave = IoCreator.createInstance(VectorDialogs.getIODialog().getValue(), "C:\\Users\\Admin\\Desktop\\123.json");
			ioSave.saveState(tab.getActiveCanvas().getMemento());
		}
	}
	
	public class ActionLoad implements ICommand {

		private ISavable ioLoad;

		@Override
		public void actionPerformed(ActionEvent e) {
			VectorDialogs.getIODialog().showDialog();
			ioLoad = IoCreator.createInstance(VectorDialogs.getIODialog().getValue(), "C:\\Users\\Admin\\Desktop\\123.json");
			tab.getActiveCanvas().setMemento(ioLoad.loadState());
		}
	}
	
	public class ActionNew implements ICommand {
		
		@Override
		public void actionPerformed(ActionEvent e) {
			
			CanvasPanel newCanvas = new CanvasPanel(tab.getSelectedComponent().getBounds(), XCommand.this);
			tab.addCanvas(newCanvas);
		}
	}
	
	public class ActionWindow implements ICommand {

		@Override
		public void actionPerformed(ActionEvent e) {
			
			JMenu window = (JMenu) e.getSource();
			window.removeAll();
			
			Component[] canvases = tab.getComponents();
			for (int i = 0;i < canvases.length; i ++){
				window.add(new JMenuItem("Canvas" + (i + 1)));
			}
			window.repaint();
		}

	}
}
