/*
Copyright 2007 Indiana University Research and Technology Corporation Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

// Mitchell Lutz

using System;
using System.Windows.Forms;

namespace Install {
    public partial class BeginPage : Form {
        private Form myChild;

        /// <summary>
        ///  Constructor.
        /// </summary>
        public BeginPage() {
            InitializeComponent();
            this.myChild = new DirPage(this);
        }
        
        /// <summary>
        ///  Next Button Event.
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e) {
            this.Visible = false;
            this.myChild.ShowDialog();
        }

        /// <summary>
        ///  Cancel Button Event.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
            Application.Exit();
        }

        /// <summary>
        ///  Returns this form's child.
        /// </summary>
        public Form getChild() {
            return this.myChild;
        }

    }
}
