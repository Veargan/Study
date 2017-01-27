package dialogs;

import java.awt.BorderLayout;
import java.awt.Window;
import java.awt.Dialog.ModalityType;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JSlider;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import api.FigureType;

public class FigureTypeDialog  extends JDialog implements ActionListener {
	
	private JButton ok;
	private JPanel panel;
	private JComboBox combo;
	
	private FigureType[] figures;
	
	public FigureTypeDialog(Window owner){
		super(owner);
		
		figures = new FigureType[] {FigureType.MULTILINE, FigureType.LINE, FigureType.ELLIPSE,
				FigureType.RECTANGLE, FigureType.CRECTANGLE  };
		

		ok = new JButton("OK");
		combo = new JComboBox<>(figures);
		
		panel = new JPanel();
		
		ok.addActionListener(this);
		
		panel.add(ok, BorderLayout.SOUTH);
		panel.add(combo);
		add(panel, BorderLayout.CENTER);
		setBounds(400, 300, 260, 120);
	}
	
	public FigureType getValue(){
		return (FigureType) combo.getItemAt(combo.getSelectedIndex());
	}
	
	public void showDialog(){
		this.combo.setSelectedIndex(0);
		this.setModalityType(ModalityType.APPLICATION_MODAL);
		this.setVisible(true);
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		this.setVisible(false);
	}

}
