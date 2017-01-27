package FigureIO;

import java.util.regex.Pattern;

public class FigureIO_Impl {
	 public static IFigureIO GetI(String file)
     {
         IFigureIO ret = null;
         String[] str = file.split(Pattern.quote("."));
         String ext = str[str.length - 1];
         switch (ext)
         {
//             case "json": ret = new FigureIO_Json(file); break;
             //case "yaml": ret = new FigureIO_Yaml(file); break;
             case "xml": ret = new FigureIO_Xml(file); break;
         }
         return ret;
     }
}
