package io;

import figure.Figure;

public interface ISavable {

	void saveState(Iterable<Figure> figures);
	Iterable<Figure> loadState();
	
}
