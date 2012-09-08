// Mitchell Lutz
// Summer '09

/*
 * runExec source: http://www.webdeveloper.com/forum/archive/index.php/t-47728.html
 * Name and variables modified by Mitchell Lutz, in source it is named runprivate(...)
 */

import java.applet.Applet;
import java.awt.*;
import java.awt.event.*;
import java.lang.String;
import java.io.*;

public class RunExecutable extends Applet implements ActionListener {
    private String exePath = "";
    private String afsPath = "";
    private String error = "";

    public void init() {
	Button btnRun = new Button("Run AFS Browser");
	this.exePath = this.getParameter("exePath");
	// Error checking here to see if afsPath exists!!!
	this.afsPath = this.getParameter("afsPath");

	setLayout(new FlowLayout(FlowLayout.LEFT, 10, 10));

	this.add(btnRun);
	btnRun.addActionListener(this);
    }

    public void actionPerformed(ActionEvent e) {
	runExec(this.exePath);
    }

    private void runExec(String exePath) {
	try{
	    // orig path = c:\MyProgPath\MyExe.exe
	    // new cmd = c:\MyProgPath\MyExe.exe afsPath
	     FilePermission perm = new java.io.FilePermission(exePath, "execute");
	    System.out.println( "try: exePath = " + exePath + " || perm = " + perm );
	    Runtime rt = Runtime.getRuntime();
	    rt.exec(exePath + " " + afsPath);
	}
        catch ( SecurityException e ) {
            error = e.getMessage();
            System.out.println( "SE: exePath = " + exePath + " || Error = " + error );
        }
        catch ( IOException e ) {
            error = e.getMessage();
            System.out.println( "IO: exePath = " + exePath + " || Error = " + error );
        }

    }

}
