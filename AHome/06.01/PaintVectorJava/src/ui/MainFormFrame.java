package ui;

import java.awt.Color;
import java.awt.Rectangle;

import javax.swing.BorderFactory;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;

import api.XCommand;
import panels.CanvasPanel;
import panels.MenuPanel;
import panels.StatusBarPanel;
import panels.TabbedPanel;
import panels.ToolbarPanel;
import panels.ToolboxPanel;

public class MainFormFrame extends JFrame {
	
	private CanvasPanel canvas;
	private MenuPanel menu;
	private ToolbarPanel toolbar;
	private ToolboxPanel toolbox;
	private StatusBarPanel statusBar;
	
	private XCommand cmd;
	private TabbedPanel tab;
	
	public MainFormFrame(String name, Rectangle r) {
		
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		
		setLayout(null);
		super.setBounds(r);
		super.setTitle(name);
		super.setVisible(true);
		
		statusBar = new StatusBarPanel(new Rectangle(0, r.height - r.y * 2, r.width, 20));
		tab = new TabbedPanel(new Rectangle(r.x, r.y - 15, r.width - 100, r.height - r.y * 3), statusBar);
		cmd = new XCommand(tab);
		
		canvas = new CanvasPanel(new Rectangle(r.x, r.y - 15, r.width, r.height - r.y * 3), cmd);
		canvas.setBorder(BorderFactory.createLineBorder(Color.BLACK));
		tab.addTab("Layer 1", canvas);
		
		menu = new MenuPanel(cmd);
		toolbar = new ToolbarPanel(new Rectangle(0, r.y - 15, r.x, r.height - r.y * 3), cmd);
		toolbox = new ToolboxPanel(new Rectangle(0, 0, r.width, r.y - 15), cmd);
		
		this.add(tab);
		this.setJMenuBar(menu);
		this.add(toolbar);
		this.add(toolbox);
		this.add(statusBar);
		
		repaint();
	}
}
