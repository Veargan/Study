package XML_Parser;

import java.awt.Color;
import java.awt.Component;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.JTextField;
import javax.swing.border.LineBorder;

public class ControlSelector {
	
	public static Component ControlCreation(String type)
    {
		Component control = null;

        switch (type)
        {
            case "Panel":
                control = new JPanel();
                ((JPanel)control).setLayout(null);
                break;
            case "Menu":
                control = new JPanel();
                ((JPanel)control).setLayout(null);
                break;
            case "ToolBar":
                control = new JPanel();
                ((JPanel)control).setLayout(null);
                break;
            case "ToolBox":
                control = new JPanel();
                ((JPanel)control).setLayout(null);
                break;
            case "StatusBar":
                control = new JPanel();
                ((JPanel)control).setLayout(null);
                break;
            case "TabControl":
                control = new JTabbedPane();
                break;
            case "TextBox":
                control = new JTextField();
                break;
            case "Button":
                control = new JButton();
                break;
            case "Label":
                control = new JLabel();
                break;
            case "TabPage":
            	control = new JPanel();
            	control.setBackground(Color.YELLOW);
            	break;
            default:
            	control = null;
            	break;
        }

        return control;
    }
	
}
