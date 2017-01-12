package io;

public final class IoCreator {

	public static ISavable createInstance(String fileFormat, String filePath){
		
		ISavable obj = null;
		switch (fileFormat){
		
		case "CSV":{
			
		break;
		}
		case "JSON":{
//			obj = new IoJson(filePath);
			break;
		}
		case "XML":{
			
			break;
		}
		case "YAML":{
			
			break;
		}
		}
		return obj;
	}
}
