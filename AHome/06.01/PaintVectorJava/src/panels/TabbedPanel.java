package panels;

import java.awt.Rectangle;
import javax.swing.JTabbedPane;

public class TabbedPanel extends JTabbedPane {
	
	private StatusBarPanel status;
	
	public StatusBarPanel getStatus() {
		return status;
	}

	public void setStatus(StatusBarPanel status) {
		this.status = status;
	}

	public TabbedPanel(Rectangle r, StatusBarPanel status){
		
		this.status = status;
		
		this.setBounds(r);
	}
	
	public CanvasPanel getActiveCanvas(){
		return (CanvasPanel) getSelectedComponent();
	}
	
	public void addCanvas(CanvasPanel canvas){
		this.addTab("Layer " + (getComponentCount() + 1), canvas);
		this.setSelectedComponent(canvas);
		canvas.requestFocus();
	}
}
