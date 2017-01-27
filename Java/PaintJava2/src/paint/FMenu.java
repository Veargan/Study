package paint;

import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;

public class FMenu extends JMenuBar {
	public FMenu(PCommands cmd) {
		JMenu mnuFile = new JMenu("File");
		add(mnuFile);
		JMenuItem mnuOpen = new JMenuItem("Open");
		JMenuItem mnuSave = new JMenuItem("Save");

		mnuOpen.addActionListener(cmd.openFile);
		mnuSave.addActionListener(cmd.saveFile);

		mnuFile.add(mnuOpen);
		mnuFile.add(mnuSave);
	}
}
