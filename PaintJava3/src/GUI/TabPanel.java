package GUI;

import javax.swing.*;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;
import javax.swing.plaf.basic.BasicButtonUI;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;


public class TabPanel extends JTabbedPane {
    public ArrayList<PaintPanel> ppanels = new ArrayList<PaintPanel>();

    public TabPanel() {
        setBackground(Color.white);

        addChangeListener(new ChangeListener() {
            @Override
            public void stateChanged(ChangeEvent arg0) {
                int i = getSelectedIndex() + 1;
                Panel p = (Panel) getParent();
                p.sb.setData(ppanels.get(p.tbp.getSelectedIndex()).data);
            }
        });
    }
}
