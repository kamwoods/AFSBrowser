/*
Copyright 2007 Indiana University Research and Technology Corporation Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

//=====================================
//_________ - Mitchell Lutz - _________
//            Summer 2009             
//=====================================

using System;
using System.Windows.Forms;

namespace AFSBrowser {
    public partial class VmForm : Form {
        private string webPath;
        // This is the form that is shown on "Next" button click.
        PathsForm pathsForm = null;

        //-------------------------------------------------------------
        // Constructor.
        //-------------------------------------------------------------
        public VmForm(string webPath) {
            InitializeComponent();
            this.webPath = webPath;
        }

        //-------------------------------------------------------------
        // Return if user chose: Workstation, Console or Nothing yet.
        //-------------------------------------------------------------
        public int getServiceProvider() {
            // 0 = none
            // 1 = Workstation
            // 2 = Server Console
            if(rBtnWStation.Checked == true) {
                return 1;
            }
            else if(rBtnServer.Checked == true) {
                return 2;
            }
            else {
                return 0;
            }
        }

        //-------------------------------------------------------------
        // Next button event.
        //-------------------------------------------------------------
        private void btnNext_Click(object sender, EventArgs e) {
            /*   If pathsForm == null, it has not been initiated yet so create one. The purpose of 
            * doing it this way (instead of just making one and showing it) is for going back 
            * and forth between forms. 
            *
            *    SCENARIO: A user clicks Next and procedes to pathsForm, they enter their .VMX and 
            * .ISO files but then realize they chose the wrong service provider so they click 
            * on "Previous". Now when they click "Next" again, their information will still be
            * there and they will not have to re-enter it. :) YAY! */
            if(this.pathsForm == null) {
                this.Visible = false;
                this.pathsForm = new PathsForm(this, this.webPath);
                this.pathsForm.ShowDialog();
            }
            else {
                this.Visible = false;
                this.pathsForm.ShowDialog();
            }
        }

        //-------------------------------------------------------------
        // Cancel button event.
        //-------------------------------------------------------------
        // Terminates application.
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
            Application.Exit();
        }

        //-------------------------------------------------------------
        // Returns the afsPath
        //-------------------------------------------------------------
        public string getAfsPath() {
            return this.webPath;
        }

    }
}
