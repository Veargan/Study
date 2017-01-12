package XML_Parser;

import java.awt.Component;
import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;

import javax.swing.JPanel;
import javax.swing.JTabbedPane;


public class MarkupParser {
	
	private String path;
	public static ArrayList<Component> CurrentControl = new ArrayList<>();
	public static int depthLevel;
	
	public MarkupParser(String path){
		
		this.path = path;
		CurrentControl.add(null);
	}
	
	 public Component GetMemento()
     {
		 loop();
         return ControlHolder.Container;
     }
	
	public void loop(){
		
		try {
            FileReader fileReader = 
                new FileReader(path);

            BufferedReader bufferedReader = 
                new BufferedReader(fileReader);
            String readLine = null;
            
            while((readLine = bufferedReader.readLine()) != null) {
            	
            	String currentLine = readLine;
            	currentLine = currentLine.trim();
            	
            	  if (currentLine.isEmpty())
                  {
                      continue;
                  }

                  if (currentLine.charAt(currentLine.indexOf("<") + 1) != '/' && currentLine.indexOf("<") == currentLine.lastIndexOf("<") )
                  {
                      SAX_Parser_ElementStart(currentLine);
                  }
                  else if (currentLine.startsWith("</") && currentLine.indexOf("</") == currentLine.lastIndexOf("</"))
                  {
                      SAX_Parser_ElementEnd(currentLine);
                  }
                  else
                  {
                      SAX_Parser_ElementContext(currentLine);
                  }
            }   

            bufferedReader.close();         
        }
        catch(Exception ex) {
        	ex.printStackTrace();
        }
	}

	 static void SAX_Parser_ElementStart(String e)
     {
         String line = e.replace("<", "").replace(">", "");

         if (line.contains("list"))
         {
             depthLevel++;
             CurrentControl.add(null);
         }

         // fill log
     }

     static void SAX_Parser_ElementContext(String e)
     {
    	 String tag = e.substring(0, e.indexOf(">")).replace("<", "");
    	 String innerText = e.substring(e.indexOf(">") + 1);
    	 innerText = innerText.substring(0, innerText.indexOf("</"));

         if (tag == "")
         {
             return;
         }
         else if (tag.contains("type"))
         {
             CurrentControl.set(depthLevel, ControlSelector.ControlCreation(innerText));
         }
         else
         {
             ControlDataHandler.InsertData(tag, innerText);
         }
     }

     static void SAX_Parser_ElementEnd(String e)
     {
    	 String line = e.replace("<", "").replace(">", "");

         if (line.contains("velement") && depthLevel == 0)
         {
             ControlHolder.Container = CurrentControl.get(0);
             CurrentControl = null;
         }
         else if (line.contains("velement"))
         {   Component cmp = null;
             if (CurrentControl.get(depthLevel - 1) instanceof JTabbedPane)
             {
            	 Component currentComp = CurrentControl.get(depthLevel);
            	 cmp = CurrentControl.get(depthLevel - 1);
            	 JTabbedPane panel = (JTabbedPane) cmp;
            	 panel.addTab(currentComp.getName(), currentComp);
             }
             else
             {
            	 cmp = CurrentControl.get(depthLevel - 1);
            	 JPanel panel = (JPanel) cmp;
            	 panel.add(CurrentControl.get(depthLevel));
             }
             cmp= null;
         }
         else if (line.contains("list"))
         {
             depthLevel--;
         }
     }
}
