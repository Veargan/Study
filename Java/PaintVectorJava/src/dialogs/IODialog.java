package dialogs;

import java.awt.BorderLayout;
import java.awt.Window;
import java.awt.Dialog.ModalityType;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JDialog;
import javax.swing.JPanel;

import api.FigureType;

public class IODialog  extends JDialog implements ActionListener {
	
	private JButton ok;
	private JPanel panel;
	private JComboBox combo;
	
	private String[] formats;
	
	public IODialog(Window owner){
		super(owner);
		
		formats = new String[] { "XML", "JSON", "CSV", "YAML" };
		

		ok = new JButton("OK");
		combo = new JComboBox<>(formats);
		
		panel = new JPanel();
		
		ok.addActionListener(this);
		
		panel.add(ok, BorderLayout.SOUTH);
		panel.add(combo);
		add(panel, BorderLayout.CENTER);
		setBounds(400, 300, 260, 120);
	}
	
	public String getValue(){
		return (String) combo.getItemAt(combo.getSelectedIndex());
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
