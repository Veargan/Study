package paint;

import java.awt.Graphics2D;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

public class OpenFile {

	public OpenFile(PanelDraw draw, File file) {
		BufferedImage image = setImage(file);
		if(image != null){
			Graphics2D g = (Graphics2D) draw.sets.image.getGraphics();
			g.drawImage(image,0,0,400,600,null);
			draw.repaint();
		}
	}

	private BufferedImage setImage(File file) {
		BufferedImage resImage = null;
			try {
				resImage = ImageIO.read(file);
			} catch (IOException e) {
				System.out.println("Error was raised");
				e.printStackTrace();
			}
		return resImage;
	}
}
