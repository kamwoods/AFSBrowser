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
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// Example from command line: AFSBrowser.exe \\afs\iu.edu\public\sudoc\volumes\04\30000038669341\30000038669341.iso
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            // If length of args is not one, either none or too many arguments were passed through.
            if(args.Length != 1) {
                // If length of args > 1, too many arguments have been passed. A message is displayed.
                if(args.Length > 1) {
                    MessageBox.Show("Emulate assist only accepts one argument.\n\nThe program will discard any arguments and continue.", "Note!");
                }
                // Run the program without a web link passed through.
                VmForm vmForm = new VmForm("");
                vmForm.ShowDialog();
                vmForm.Dispose();
            }
            // If length of args = 1, we have a web link and need to pass it through to the forms so
            // that PathsForm can start with a path to an .ISO location.
            else if(args.Length == 1) {
                VmForm vmForm = new VmForm(args[0].ToString());
                vmForm.ShowDialog();
                vmForm.Dispose();
            }
            // If we get here, an unexpected error has occured. Message is displayed and prgram terminates.
            else {
                MessageBox.Show("An unknown error has occured.\n\nPlease check the arguments passed to Emulate Assist and try again.", "Error!");
            }
        }
      
    }
}