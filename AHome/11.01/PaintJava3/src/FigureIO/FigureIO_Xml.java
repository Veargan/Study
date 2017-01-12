package FigureIO;

import java.beans.XMLEncoder;
import java.beans.XMLDecoder;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FilterInputStream;
import java.io.IOException;
import java.util.ArrayList;

import API.Figure;

public class FigureIO_Xml implements IFigureIO  {

	String file;
	
	public FigureIO_Xml(String file) {
		this.file = file;
	}
	
	@Override
	public void Save(ArrayList<Figure> ff) throws IOException {
		XMLEncoder e = new XMLEncoder(
                new BufferedOutputStream(
                    new FileOutputStream(file)));
		e.writeObject(ff);
		e.close();
	}

	@Override
	public ArrayList<Figure> Load() throws IOException {
		ArrayList<Figure> f = new ArrayList<Figure>();
		XMLDecoder d = new XMLDecoder(
				new BufferedInputStream(
						new FileInputStream(file)));
		f = (ArrayList<Figure>)d.readObject();
		return f;
	}

}
