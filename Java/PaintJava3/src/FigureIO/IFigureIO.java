package FigureIO;

import java.io.IOException;
import java.util.ArrayList;

import API.Figure;

public interface IFigureIO {
	void Save(ArrayList<Figure> ff) throws IOException ;
	ArrayList<Figure> Load() throws IOException ;
}
