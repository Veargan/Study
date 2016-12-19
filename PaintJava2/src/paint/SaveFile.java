package paint;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

public class SaveFile {

    protected void SaveFileJPG(BufferedImage draw, File selectedFile) {
        try {
            ImageIO.write(draw, "jpg", selectedFile);
        } catch (IOException io) {
            io.printStackTrace();
        }
    }

    protected void SaveFilePNG(BufferedImage draw, File selectedFile) {
        try {
            ImageIO.write(draw, "png", selectedFile);
        } catch (IOException io) {
            io.printStackTrace();
        }
    }

    protected void SaveFileGIF(BufferedImage draw, File selectedFile) {
        try {
            ImageIO.write(draw, "gif", selectedFile);
        } catch (IOException io) {
            io.printStackTrace();
        }
    }

    protected void SaveFileJPEG(BufferedImage draw, File selectedFile) {
        try {
            ImageIO.write(draw, "jpeg", selectedFile);
        } catch (IOException io) {
            io.printStackTrace();
        }
    }

    protected void SaveFileBMP(BufferedImage draw, File selectedFile) {
        try {
            ImageIO.write(draw, "bmp", selectedFile);
        } catch (IOException io) {
            io.printStackTrace();
        }
    }
}