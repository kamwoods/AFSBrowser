/*
Copyright 2007 Indiana University Research and Technology Corporation Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

// Mitchell Lutz

using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Install {
    public partial class DirPage : Form {
        private Form myParent;
        /// <summary>
        ///  Constructor.
        /// </summary>
        public DirPage(Form parent) {
            InitializeComponent();
            this.myParent = parent; // Set parent.
            this.txtBoxPath.Text = @"C:\Legacy Emulation Assistant"; // Set default install path.
        }

        /// <summary>
        ///  Previous Button Event.
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e) {
            this.Visible = false;
            this.myParent.Visible = true;
        }

        /// <summary>
        ///  Browse Button Event.
        ///  Gives option to open folder dialog and choose new install path.
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e) {
            string prompt = "Changing this path will ruin Legacy Emulation Assistant's\ncompatibility with the associated .JAR file.\n\nAre you sure you want to procede?";
            if(MessageBox.Show(prompt, "Notice", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                // If the user is ok with disabling IE functionality, show the folder browsing dialog.
                browseDialog.ShowDialog();
                // Check to make sure they chose a path.
                if(browseDialog.SelectedPath != "") {
                    this.txtBoxPath.Text = browseDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        ///  Next Button Event.
        ///  Creates a new directory and installs Legacy Emulation Assistant.
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e) {
            // Check the the user has specified a path to install.
            if(this.txtBoxPath.Text != "") {
                // Check to see if the directory already exists.
                if(!Directory.Exists(this.txtBoxPath.Text)) {
                    copyFile(this.txtBoxPath.Text + "\\Legacy Emulation Assistant.exe", "AFSBrowser.exe");
                    copyFile(this.txtBoxPath.Text + "\\Interop.VixCOM.dll", "Interop.VixCOM.dll");
                }
                else if(MessageBox.Show("Directory already exists. \n\nDo you still want to install here? \n\n*Clicking yes will overwrite any previously installed \nversions of Legacy Emulation Assistant, if they exist.", "Note!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    copyFile(this.txtBoxPath.Text + "\\Legacy Emulation Assistant.exe", "AFSBrowser.exe");
                    copyFile(this.txtBoxPath.Text + "\\Interop.VixCOM.dll", "Interop.VixCOM.dll");
                    Application.Exit();
                }
            }
            else {
                MessageBox.Show("Please enter an install path.");
            }
        }

        private bool copyFile(string path, string fileToCopy) {
            Directory.CreateDirectory(this.txtBoxPath.Text); // Create new directory.
            File.Copy(fileToCopy, path, true); // Copy .EXE to the new directory.
            if(File.Exists(path)) {
                if(path.EndsWith(".exe") && MessageBox.Show("The installation has successfully completed. \n\nWould you like to launch Legacy Emulation Assistant?", "Success!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    // If the user chooses 'yes', run Legacy Emulation Assistant.
                    Process.Start(path);
                }
                return true;
            }
            else {
                MessageBox.Show("Sorry, an error occured during the installation process. \n\nDo you have the privileges required  to install in this directory?");
                return false;
            }
        }
        
        /// <summary>
        ///  Cancel button event.
        ///  Terminates Application.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.getParent().Dispose();
            this.Dispose();
            Application.Exit();
        }

        /// <summary>
        ///  Return this form's parent.
        /// </summary>
        public Form getParent() {
            return this.myParent;
        }

    }
}
