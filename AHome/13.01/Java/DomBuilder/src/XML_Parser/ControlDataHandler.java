package XML_Parser;

import java.awt.Component;
import java.awt.Rectangle;

import javax.swing.JButton;
import javax.swing.JLabel;

public class ControlDataHandler {
	
	 public static void InsertData(String tag, String innerText)
     {
         if (innerText == "")
         {
             return;
         }
         Rectangle r = null;
         switch (tag)
         {
             case "id":
            	 MarkupParser.CurrentControl.get(MarkupParser.depthLevel).setName(innerText);
                 break;
             case "value":
            	 Component cmp = MarkupParser.CurrentControl.get(MarkupParser.depthLevel);
            	 if (cmp instanceof JButton){
            		 
            		 ((JButton)cmp).setText(innerText);
            	 }else if (cmp instanceof JLabel)
            	 {

            		 ((JLabel)cmp).setText(innerText);
            	 }
                 break;
             case "x":
            	 r = MarkupParser.CurrentControl.get(MarkupParser.depthLevel).getBounds();
            	 MarkupParser.CurrentControl.get(MarkupParser.depthLevel).setBounds(Integer.parseInt(innerText), r.y, r.width, r.height);
                 break;
             case "y":
            	 r = MarkupParser.CurrentControl.get(MarkupParser.depthLevel).getBounds();
            	 MarkupParser.CurrentControl.get(MarkupParser.depthLevel).setBounds(r.x, Integer.parseInt(innerText), r.width, r.height);
                 break;
             case "width":
            	 r = MarkupParser.CurrentControl.get(MarkupParser.depthLevel).getBounds();
            	 MarkupParser.CurrentControl.get(MarkupParser.depthLevel).setBounds(r.x, r.y, Integer.parseInt(innerText), r.height);
                 break;
             case "height":
            	 r = MarkupParser.CurrentControl.get(MarkupParser.depthLevel).getBounds();
            	 MarkupParser.CurrentControl.get(MarkupParser.depthLevel).setBounds(r.x, r.y, r.width, Integer.parseInt(innerText));
                 break;
         }
     }

}
