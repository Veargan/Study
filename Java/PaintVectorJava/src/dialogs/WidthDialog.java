package dialogs;

import java.awt.BorderLayout;
import java.awt.Window;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JSlider;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

public class WidthDialog extends JDialog implements ActionListener, ChangeListener {
	
	private JButton ok;
	private JLabel widthLabel;
	private JSlider slider;
	private JPanel panel;
	
	private static final int MIN_WIDTH = 1;
	private static final int MAX_WIDTH = 20;
	
	public WidthDialog(Window owner){
		super(owner);

		ok = new JButton("OK");
		widthLabel = new JLabel();
		slider = new JSlider(JSlider.HORIZONTAL, MIN_WIDTH, MAX_WIDTH , 1);
		panel = new JPanel();
		
		ok.addActionListener(this);
		slider.addChangeListener(this);
		
		panel.add(ok, BorderLayout.SOUTH);
		panel.add(widthLabel, BorderLayout.NORTH);
		panel.add(slider, BorderLayout.CENTER);
		add(panel, BorderLayout.CENTER);
		setBounds(400, 300, 260, 120);
	}
	
	public int getValue(){
		return slider.getValue();
	}
	
	public void showDialog(float initValue){
		this.slider.setValue((int) initValue);
		this.setModalityType(ModalityType.APPLICATION_MODAL);
		this.setVisible(true);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		setVisible(false);
	}

	@Override
	public void stateChanged(ChangeEvent arg0) {
		widthLabel.setText(String.valueOf(slider.getValue()));
	}
}
