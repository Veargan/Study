//package FigureIO;
//
//import java.io.FileWriter;
//import java.io.IOException;
//import java.nio.charset.StandardCharsets;
//import java.nio.file.Files;
//import java.nio.file.Paths;
//import java.util.ArrayList;
//import java.util.Arrays;
//import java.util.List;
//
//import lib.*;
//import com.google.gson.Gson;
//
//import API.Figure;
//
//public class FigureIO_Json implements IFigureIO {
//
//	String file;
//
//	public FigureIO_Json(String file) {
//		this.file = file;
//	}
//	@Override
//	public void Save(ArrayList<Figure> ff) {
//		Gson gson = new Gson();
//
//        String figur = gson.toJson(ff);
//        FileWriter writer = null;
//		try {
//			writer = new FileWriter(file);
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//        try {
//			writer.write(figur);
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//        try {
//			writer.close();
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//	}
//	@Override
//	public ArrayList<Figure> Load() {
//		List<Figure> figureList;
//		String jsonFigure = null;
//		try {
//			jsonFigure = new String(Files.readAllBytes(Paths.get(file)), StandardCharsets.UTF_8);
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//				Gson gson = new Gson();
//        Figure[] personsItems = gson.fromJson(jsonFigure, Figure[].class);
//
//        figureList = Arrays.asList(personsItems);
//        figureList = new ArrayList<Figure>(figureList);
//        return (ArrayList<Figure>)figureList;
//	}
//
//}
