package io;

import memento.Figure;

public interface ISavable {

	void saveState(Iterable<Figure> figures);
	Iterable<Figure> loadState();
	
}
