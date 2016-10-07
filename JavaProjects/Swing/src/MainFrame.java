import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * Created by Maika on 11/2/2015.
 */
public class MainFrame extends JFrame implements ActionListener{
    private final JTextArea textArea;
    private int numClicks = 0;
    private DetailsPanel detailsPanel;
    public MainFrame(String title){
        super(title);
        //layot manager
        setLayout(new BorderLayout());
        //create components
         textArea = new JTextArea();

        JButton button = new JButton("Click me!");
        detailsPanel = new DetailsPanel();
        //add components to content pane
        Container c = getContentPane();

        c.add(textArea, BorderLayout.CENTER);
        c.add(detailsPanel, BorderLayout.WEST);
        c.add(button, BorderLayout.SOUTH);

        //add behaviour
        button.addActionListener(this);



    }


    @Override
    public void actionPerformed(ActionEvent e) {
        textArea.append("Kris e gei\n");
    }
}
