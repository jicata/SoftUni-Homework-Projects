package Game;

import Display.Display;
import sun.awt.image.BufferedImageGraphicsConfig;

import java.awt.*;
import java.awt.image.BufferStrategy;

/**
 * Created by Maika on 11/2/2015.
 */
public class Game implements Runnable{
    private Display display;
    private Thread thread;
    private boolean isRunning = false;
    private String name;
    private Graphics graphics;
    private BufferStrategy bs;
    public Game(String name) {
        this.name = name;
        run();
    }
    private void init(){
        this.display = new Display(this.name);
    }
    private void tick(){

    }
    private void render(){
        this.bs = this.display.getCanvas().getBufferStrategy();

        if(this.bs == null){
            this.display.getCanvas().createBufferStrategy(2);
            return;
        }
        this.graphics = this.bs.getDrawGraphics();

        graphics.fillRect(100,200,50,50);
        //

        //
        this.graphics.dispose();
        this.bs.show();

    }
    public void run(){
        this.init();
        while(isRunning) {

            tick();
            render();
        }
        this.stop();

    }
    public synchronized void start(){
        this.thread = new Thread(this);
        this.thread.start();
        this.isRunning = true;
    }
    public synchronized void stop(){
        try{
            this.isRunning = false;
            this.thread.join();
        }
        catch (InterruptedException e){
            e.printStackTrace();
        }
    }
}
