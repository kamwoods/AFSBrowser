/*
Copyright 2007 Indiana University Research and Technology Corporation Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

//=====================================
//_________ - Mitchell Lutz - _________
//            Summer 2009             
//=====================================

using System;
using System.Windows.Forms;
using System.IO;

namespace AFSBrowser {
    public partial class PathsForm : Form {
        private VmForm myParent;
        private string isoPath;
        private string vmxPath;

        //-------------------------------------------------------------
        // First Page Constructor
        //-------------------------------------------------------------
        public PathsForm(VmForm parent, string webPath) {
            InitializeComponent();
            this.myParent = parent;
            if(webPath != "") {
                this.txtBxISOpath.Text = webPath;
            }
            else {
                this.txtBxISOpath.Text = "";
            }
        }

        //-------------------------------------------------------------
        // Next button Event
        //-------------------------------------------------------------
        private void btnNext_Click(object sender, EventArgs e) {
            string pathError = ""; // Error from isFileValid. Is empty if not error.
            
            // Set vmxPath and isoPath for ConfirmForm to use
            this.vmxPath = this.txtBxConfig.Text; 
            this.isoPath = this.txtBxISOpath.Text;

            // pathError equals the error for vmxPath, if there is one.
            // If there is no error, pathError should = ""
            pathError = isFileValid(this.vmxPath, ".vmx");

            // Check to see if there was a problem with vmxPath
            if(pathError.Equals("")) {
                // If there is no error with vmxPath, now do the same error check with isoPath.
                if (this.isoPath.EndsWith(".iso")) {
                    pathError = isFileValid(this.isoPath, ".iso");
                }
                else if (this.isoPath.EndsWith(".img")) {
                    pathError = isFileValid(this.isoPath, ".img");
                }
                else {
                    pathError = "The file: \n\n " + this.isoPath + "\n\nis not a supported file format (.iso or .img)";
                }
                // Check to see if there was an error with isoPath.
                if(pathError.Equals("")) { 
                    //If there was not an error, make a confirmation page and show it.
                    ConfirmForm confirmForm = new ConfirmForm(this);
                    confirmForm.ShowDialog();
                }
                // Else there was an error from isoPath, Message is displayed.
                else { 
                    MessageBox.Show(pathError, "Error!");
                }
            }
            // Else there was an error from vmxPath, Message is displayed.
            else {
                MessageBox.Show(pathError, "Error!");
            }
        }
        
        // ifFileValid(...) takes path and ext (extension), and returns an error string. If the file located 
        // at 'path' is valid and of the file type 'ext', no error is thrown, and isFileValid returns the empty 
        // string. If the file is invalid, isFileValid return a string which tells why the error is thrown. This 
        // allows the caller of isFileValid can display the error string in a MessageBox.
        private string isFileValid(string path, string ext) {
            string error;
            if(path != "") {
                // If file in string 'path' ends with ext, file is still valid. (Just validates the string path with string ext, no files checked yet)
                if(path.EndsWith(ext)) {
                    // If File located at path exists, file is still valid.
                    if(File.Exists(path)) {
                        // If we get here, file ends with ext and does exist at the location provided. No error thrown.
                        error = "";
                    }
                    // Else file does not exist.
                    else {
                        error = "The file: \n\n  " + path + "\n\ndoes not exist.";
                    }
                }
                // Else file is not of the proper extension
                else {
                    error = "The file: \n " + path + "\n\nis not of the proper file type (" + ext + ").";
                }
            }
            // Else the path for this file is empty.
            else {
                error = "The field for the " + ext + " file is blank, please enter a valid path.";
            }
            return error;
        }

        //-------------------------------------------------------------
        // Browse button Event
        //-------------------------------------------------------------
        private void btnBrowse_Click(object sender, EventArgs e) {
            this.openAfsFD.FileName = ""; // Make the file textBox initially empty

            if(Directory.Exists("\\\\afs\\iu.edu\\public\\sudoc\\volumes")) {
                // Set the directory for the OpenFileDialog to start at
                this.openAfsFD.InitialDirectory = "\\\\afs\\iu.edu\\public\\sudoc\\volumes";
                this.openAfsFD.Filter = ".ISO|*.iso|.IMG|*.img";//Only allow .ISO and .IMG files to be opened/mounted.
            }
            else {
                MessageBox.Show("Could not access the AFS. \n\nPlease make sure that you are allowed access to the AFS.", "Note!");
                this.openAfsFD.InitialDirectory = "C:\\";
            }
            this.openAfsFD.ShowDialog(); //Show the OpenFileDialog.
        
            // This check makes it so the text box is not reset if the user has not selected anything.
            // Example: The user types something in then clicks browse button but does not find what
            // they are looking for, so they click cancel. This check makes it so what they typed
            // is not cleared.
            if(this.openAfsFD.FileName != "") {
                this.txtBxISOpath.Text = this.openAfsFD.FileName; // Set texbox's text to the ISO the user has chose to open.
            }
        }

        //--------------------------------------------------------------
        // Config Browse button Event
        //--------------------------------------------------------------
        private void btnConfigBrowse_Click(object sender, EventArgs e) {
            this.openConfigFD.FileName = "";

            // Check if a Virtual Machines Directory exists.
            if(Directory.Exists("C:\\Virtual Machines\\")) {
                this.openConfigFD.InitialDirectory = "C:\\Virtual Machines\\";
            }
            else {
                openConfigFD.InitialDirectory = "C:\\";
            }

            this.openConfigFD.Filter = ".vmx|*.vmx";
            this.openConfigFD.ShowDialog();

            // This check makes it so the text box is not reset if the user has not selected anything.
            // Example: The user types something in then clicks browse button but does not find what
            // they are looking for, so they click cancel. This check makes it so what they typed
            // is not cleared.
            if(this.openConfigFD.FileName != "") {
                this.txtBxConfig.Text = this.openConfigFD.FileName; // Set texbox's text to the .VMX the user has specified.
            }
        }

        //------------------------------------------------------
        // Previous button event
        //------------------------------------------------------
        private void btnPrev_Click(object sender, EventArgs e) {
            this.Visible = false;
            this.myParent.Visible = true;
        }

        //--------------------------------------------------------
        // Cancel button Event
        //--------------------------------------------------------
        // Terminates application
        private void btnCancel_Click(object sender, EventArgs e) {
            this.getParent().Dispose();
            this.Dispose();
            // Close the application.
            Application.Exit();
        }


        //---------------------------------------------------------
        //Returns the parent form (myParent)
        //---------------------------------------------------------
        public VmForm getParent() {
            return this.myParent;
        }

        //---------------------------------------------------------
        // Returns isoPath
        //---------------------------------------------------------
        public string getISOpath() {
            return this.isoPath;
        }

        //---------------------------------------------------------
        // Returns vmxPath
        //---------------------------------------------------------
        public string getVMXpath() {
            return this.vmxPath;
        }
    }
}