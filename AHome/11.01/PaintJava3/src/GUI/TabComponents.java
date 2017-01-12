package GUI;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;

/**
 * Created by Svyatoslav on 10.01.2017.
 */
public class TabComponents extends JTabbedPane {
    private final int tabNumber = 5;
    private final JTabbedPane pane = new JTabbedPane();
    private JMenuItem tabComponentsItem;
    private JMenuItem scrollLayoutItem;

    public TabComponents(String title) {
//        super(title);
//        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        initMenu();
        add(pane);
//        addTab(title, pane);
    }

    public void runTest() {
        pane.removeAll();
        for (int i = 0; i < tabNumber; i++) {
            String title = "Tab " + i;
            pane.add(title, new JLabel(title));
            initTabComponent(i);
        }
        tabComponentsItem.setSelected(true);
        pane.setTabLayoutPolicy(JTabbedPane.WRAP_TAB_LAYOUT);
        scrollLayoutItem.setSelected(false);
        setSize(new Dimension(400, 200));
//        setLocationRelativeTo(null);
        setVisible(true);
    }

    private void initTabComponent(int i) {
        pane.setTabComponentAt(i,
                new ButtonTabComponent(pane));
    }

    //Setting menu

    private void initMenu() {
        JMenuBar menuBar = new JMenuBar();
        //create Options menu
        tabComponentsItem = new JCheckBoxMenuItem("Use TabComponents", true);
        tabComponentsItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_T, InputEvent.ALT_MASK));
        tabComponentsItem.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                for (int i = 0; i < pane.getTabCount(); i++) {
                    if (tabComponentsItem.isSelected()) {
                        initTabComponent(i);
                    } else {
                        pane.setTabComponentAt(i, null);
                    }
                }
            }
        });
        scrollLayoutItem = new JCheckBoxMenuItem("Set ScrollLayout");
        scrollLayoutItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S, InputEvent.ALT_MASK));
        scrollLayoutItem.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                if (pane.getTabLayoutPolicy() == JTabbedPane.WRAP_TAB_LAYOUT) {
                    pane.setTabLayoutPolicy(JTabbedPane.SCROLL_TAB_LAYOUT);
                } else {
                    pane.setTabLayoutPolicy(JTabbedPane.WRAP_TAB_LAYOUT);
                }
            }
        });
        JMenuItem resetItem = new JMenuItem("Reset JTabbedPane");
        resetItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_R, InputEvent.ALT_MASK));
        resetItem.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                runTest();
            }
        });

        JMenu optionsMenu = new JMenu("Options");
        optionsMenu.add(tabComponentsItem);
        optionsMenu.add(scrollLayoutItem);
        optionsMenu.add(resetItem);
        menuBar.add(optionsMenu);
//        setJMenuBar(menuBar);
    }
}
