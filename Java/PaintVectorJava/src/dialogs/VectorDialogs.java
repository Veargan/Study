package dialogs;

public final class VectorDialogs {

	private static WidthDialog width;
	private static FigureTypeDialog figure;
	private static IODialog io;
	
	public static WidthDialog getWidthDialog(){
		if (width == null){
			width = new WidthDialog(null);
		}
		return  width;
	}
	
	public static FigureTypeDialog getFigureDialog(){
		if (figure == null){
			figure = new FigureTypeDialog(null);
		}
		return  figure;
	}

	public static IODialog getIODialog() {
		if (io == null){
			io = new IODialog(null);
		}
		return  io;
	}
	
}
