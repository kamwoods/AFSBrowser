/*
Copyright 2007 Indiana University Research and Technology Corporation Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

//=====================================
//_________ - Mitchell Lutz - _________
//            Summer 2009             
//=====================================

using System.Windows.Forms;
using System.IO;
using System;
using System.Diagnostics;

namespace AFSBrowser {
    public partial class ConfirmForm: Form {
        private string vmDesk = "C:\\Documents and Settings\\iucs\\Desktop";
        private string installScriptPath = "";
        private string isoID;
        private PathsForm myParent;

        //-------------------------------------------------------------
        // ConfirmForm Constructor
        //-------------------------------------------------------------
        public ConfirmForm(PathsForm parent) {
            InitializeComponent();

            this.myParent = parent;

            this.txtBoxISOpath.Text = this.getParent().getISOpath(); // Set file or image path in text box
            this.isoID = Path.GetFileNameWithoutExtension(this.txtBoxISOpath.Text); // isoID Example: 30000038669341

            // installScriptPath Example: \\afs\iu.edu\public\sudoc\volumes\04\30000038669341\30000038669341_install.exe
            this.installScriptPath = Path.Combine(Path.GetDirectoryName(this.txtBoxISOpath.Text), this.isoID + "_install.exe");

            if(this.myParent.getParent().getServiceProvider() == 1) {
                this.txtBoxProvider.Text = "Workstation";
            }
            else {
                this.txtBoxProvider.Text = "Server Console";
            }

            // Check to see if there is a help file.
            // If there is a button is added to the form so the user can view the help file.
            if(File.Exists(Path.Combine(Path.GetDirectoryName(installScriptPath), "index.html"))) {
                this.btnHelp.Visible = true;
                this.lblHelp.Visible = true;
            }
        }

        //-------------------------------------------------------------
        // Open button event
        //-------------------------------------------------------------
        private void btnOpen_Click(object sender, System.EventArgs e) {
            string[] configVars;
            string[] configVals;
            string vmxPath = this.getParent().getVMXpath();
            string userName = "iucs";
            string password = "vmware";

            int result = 0;

            // Create a VixWrapper to automate the VM.
            VixWrapper vix = new VixWrapper();

            // vix.Connect(hostname, username, password) You can use specific values for these,
            // however its not necessary. I figure null will be more compatible.
            this.txtStatusBar.Text = "Connecting with VMware. . .";

            // Begin the VMware automation
            if(vix.Connect(null, null, null, this.myParent.getParent().getServiceProvider())) {
                this.txtStatusBar.Text = "Opening the .VMX file. . ."; // Update status bar.
                vix.Open(vmxPath); // Open the .vmx file.

                this.txtStatusBar.Text = "Reverting to the most recent snapshot. . ."; // Update status bar.
                vix.RevertToLastSnapshot();  // Revert to most recent snapshot.

                this.txtStatusBar.Text = "Editing the virtual machine's configuration file. . ."; // Update status bar.

                // Check if we're mounting an .iso image (CD).
                if(this.txtBoxISOpath.Text.EndsWith(".iso")) {
                    // Create array for configuation (.vmx file) VARIABLES (to mount CD).
                    configVars = new string[5] { "ide1:0.fileName = ", "ide1:0.deviceType = ", "ide1:0.startConnected = ", "floppy0.fileName = ", "floppy0.startConnected = " };
                    // Create array for configuation (.vmx file) VALUES (to mount CD).
                    configVals = new string[5] { this.txtBoxISOpath.Text, "cdrom-image", "TRUE", "A:", "FALSE" }; 

                    // Edit VM configuration file so .ISO is mounted as the VM's D: drive.
                    editConfigFile(vmxPath, configVars, configVals);
                }
                // Check if we're mounting an .img file (Floppy Disc).
                else if(this.txtBoxISOpath.Text.EndsWith(".img")) {
                    // Create array for configuation (.vmx file) VARIABLES (to mount floppy).
                    configVars = new string[6] { "floppy0.fileName = ", "floppy0.fileType = ", "floppy0.clientDevice = ", "floppy0.startConnected = ", "ide1:0.fileName = ", "ide1:0.startConnected = " };
                    // Create array for configuation (.vmx file) VALUES (to mount floppy). 
                    configVals = new string[6] {this.txtBoxISOpath.Text, "file", "FALSE", "TRUE", "D:", "FALSE"}; 

                    // Edit VM configuration file so floppy is mounted as the VM's A: drive.
                    editConfigFile(vmxPath, configVars, configVals);
                }
                // We should never get here because of checks in pathForm.
                // Getting here would be the result of an invalid file format, shouldn't be possible.
                else {
                    // Error.
                }

                this.txtStatusBar.Text = "Powering on the virtual machine. . ."; // Update status bar.
                vix.PowerOn(); // Power on the virtual machine.

                this.txtStatusBar.Text = "Logging in to the virtual machine as " + userName + ". . ."; // Update status bar.
                vix.LogIn(userName, password); // Log in to the virtual machine.

                // Check to see if there is an install script for the file or image.
                this.txtStatusBar.Text = "Checking for an install script. . .";  // Update status bar.
                if(File.Exists(this.installScriptPath)) {
                    vix.LogIn(userName, password);  // CopyFileToVm does not work without this second log in, I am not sure why.

                    this.txtStatusBar.Text = "Copying install script to: " + this.vmDesk + " . . ."; // Update status bar.
                    // Copy the install script to the desktop of the VM.
                    vix.CopyFileToVm(this.installScriptPath, Path.Combine(this.vmDesk, Path.GetFileName(this.installScriptPath)));

                    vix.LogIn(userName, password); // Log-in to the VM.

                    this.txtStatusBar.Text = "Installing the programs that are required to utilize this .ISO image. . .";  // Update status bar.
                    vix.RunProgram(Path.Combine(this.vmDesk, Path.GetFileName(this.installScriptPath)), "", out result); // Run install script in the virtual machine.

                    this.txtStatusBar.Text = "Finishing up. . ."; // Update status bar.   
                    this.Close(); // Close this Confirm form
                    
                    // All of these ...Dispose()'s help ensure no memory leaks occur.
                    this.getParent().getParent().Dispose(); // Free resources VmForm is using (closes the form).
                    this.getParent().Dispose(); // Free resources PathsForm is using (closes the form).
                    this.Dispose(); // Free resources this form is using (closes the form).
                }
                else {
                    this.txtBoxISOpath.Text = "File or image does not have an install script.";
                    // Show Message if there is not an install script.
                    MessageBox.Show("This file or image does not have an install script! Program will exit.");
                }
                // Everything has finished, exit the program (terminate the application).
                Application.Exit();
            }
            else {
                /*
                 * NOTE: I ran into an error if the user tries to go back (in the GUI) to change the service 
                 *  provider. I have been unable to fix it, so the program terminates and the user can try again
                 *  with the correct sevice provider (and the program will work). The error has something to
                 *  do with VixCOM and its handles. I think that the handle is not being released when the user
                 *  changes service providers and tries again.
                 */
                // Show Message if we cannot connect to the VM.
                MessageBox.Show("Could not connect to VMware. \n\nDid you choose the correct service provider? (i.e. Workstation or Server)\n\nPlease try again with the correct service provider.\nProgram will exit.", "Error!");
                this.Dispose();
                this.Close();
                Application.Exit();
            }
        }

        //-------------------------------------------------------------
        // Edit VM config file (Mount .ISO image as the cd drive)
        //-------------------------------------------------------------
        private bool editConfigFile(string file, String[] configVars, String[] configVals) {
            StreamWriter sw = null;
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            string lineBuffer = "";

            bool lineFound = false; // lineFound is in case "ide1:0.fileName =" appears more than once so only 1 line is changed.

            // Read every line, one line at a time, until the EOF.
            while((line = sr.ReadLine()) != null) {
                // for each each variable in configVars check to see if matches line read
                for(int i = 0; i < configVars.Length; i++) {
                    if(!(configVars[i].Equals("")) && line.Contains(configVars[i])) {
                        lineBuffer += configVars[i] + "\"" + configVals[i] + "\"" + "\r\n";
                        configVars[i] = "";
                        lineFound = true;
                    }
                }
                // If have not found what the wanted line, line remains the same and is added to lineBuffer.
                if(lineFound == false) {
                    lineBuffer += (line + "\r\n");
                }
                // Else we did find the line
                // Set lineFound to false so we can look for remaining lines.
                else {
                    lineFound = false;
                }
            }

            for(int i = 0; i < configVars.Length; i++) {
                if(!(configVars[i].Equals(""))) {
                    lineBuffer += configVars[i] + configVals[i] + "\r\n";
                }
            }

            sr.Close(); // Close StreamReader
            fs.Close(); // Close FileStream so it can be used to create (replace) the config file

            fs = new FileStream(file, FileMode.Create);
            sw = new StreamWriter(fs);
            sw.Write(lineBuffer); // Write lineBuffer, which is the entire config file with our .ISO mounted, to the new config file.

            sw.Close();  // Close StreamWriter.
            fs.Close(); // Close FileStream.
            // Return lineFound (bool), this will tell whether "ide1:0.fileName =" was found or not. 
            return lineFound;
        }

        //---------------------------------------------------------------
        // Cancel button event
        //---------------------------------------------------------------
        // Closes this.ConfirmForm, goes back to PathsForm.
        private void btnCancel_Click(object sender, System.EventArgs e) {
            this.Dispose();
            this.Close();
        }

        //-------------------------------------------------------------
        //Returns the parent form (myParent)
        //-------------------------------------------------------------
        public PathsForm getParent() {
            return this.myParent;
        }

        private void btnHelp_Click(object sender, EventArgs e) {
            Process.Start(Path.Combine(Path.GetDirectoryName(installScriptPath), "index.html"));
        }

    }
}