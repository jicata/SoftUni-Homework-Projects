package Display;

import javax.swing.*;
import java.awt.*;

public class Display {
    private final int WIDTH= 800;
    private final int HEIGHT = 599;
    private JFrame frame;
    private String name;
    private Canvas canvas;

    public Canvas getCanvas() {
        return canvas;
    }

    public Display(String name){
        init(name);
    }
    private void init(String name){

        this.name = name;
        this.frame = new JFrame(name);
        this.frame.setVisible(true);
        this.frame.setMinimumSize(new Dimension(WIDTH, HEIGHT));
        this.frame.setPreferredSize(new Dimension(WIDTH, HEIGHT));
        this.frame.setMaximumSize(new Dimension(WIDTH, HEIGHT));
        this.frame.setFocusable(true);
        this.frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        this.frame.setResizable(false);
        this.frame.setLocationRelativeTo(null);

        this.canvas = new Canvas();
        this.canvas.setMinimumSize(new Dimension(WIDTH, HEIGHT));
        this.canvas.setPreferredSize(new Dimension(WIDTH, HEIGHT));
        this.canvas.setMaximumSize(new Dimension(WIDTH, HEIGHT));
        this.canvas.setVisible(true);

        this.frame.add(canvas);
        this.frame.pack();

    }
}
