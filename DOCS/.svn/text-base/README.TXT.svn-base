:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::     ___________________ - Mitchell Lutz -  _______________________     ::
::                                              Summer 2009	                                                      ::
:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

-------------------------------------------------------------------------------------------------------------------------------------------------------------
Copyright 2007 Indiana University Research and Technology Corporation Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
-------------------------------------------------------------------------------------------------------------------------------------------------------------

====================================================================================
 VIRTUAL MACHINE DETAILS
====================================================================================
  - SERVICE PROVIDER: VMware Server Console
  - VIRTUAL MACHINE: Windows XP Professional
  - USERNAME: iucs
  - PASSWORD: vmware
  - LOCATION ON MY COMPUTER: C:\Virtual Machines\Windows XP Pro\Windows XP Professional.vmx
  - LOCATION OF VM DESKTOP: C:\Documents and Settings\iucs\Desktop (This is where the install script is copied)
 -> AFSBrowser was written on Microsoft Windows Vista Home Premium, Service Pack 2


 -> IMPORTANT: Auto Log-in MUST be enabled or else installScript will not finish. 
		   - See: http://www.microsoft.com/windowsxp/using/setup/learnmore/tips/knox2.mspx
 
 -> IMPORTANT: Make sure to read the snapshot details or else AFSBrowser may not funtion 100% properly!

============================================================================================
NOTES   
============================================================================================
 -> To make this run from Internet Explorer, add this code to the desired html page (in the body). You will have to change the
     value="..." to the path where AFSBrowser.exe is.

         <applet code="RunExecutable.class" archive="RunExecutable.jar" width="120" height="35">
         <param name="exePath" value="C:\Legacy Emulation Assistant\Legacy Emulation Assistant.exe">
         <param name="afsPath" value="\\afs\iu.edu\public\sudoc\volumes\04\30000038669341\30000038669341.iso">
         </applet>

- param "exePath" is the path to where Install.exe will put Legacy Emulation Assistant.exe
- param "afsPath" will be the path to an .ISO image from a web page.
       Example: A user clicks a button, from a web page, to open an .ISO, "afsPath" should be the path to that .ISO

  -> A good .ISO image to test with is: \\afs\iu.edu\public\sudoc\volumes\04\30000038669341\30000038669341.iso
  
  -> My VM desktop location is: C:\Documents and Settings\iucs\Desktop. This is currently hardcoded into the
	  AFSBrowser. Unless the final project release includes the same VM image as mine, this will have 
	  to be changed. This might be a good idea to do anyway. All it would take is an extra text box on PathsForm.cs
	  where a user may enter the path to their VM desktop.
	  
  -> The user must have access to the AFS or else they will not be able to view/open an any .ISO's from the AFS.
  
  -> If you look at the VM automation in btnOpen_Click(...) inside ConfirmForm.cs, you will see that I log into
	the VM multiple times. This is because a log in is required for every action with the VM. Its kind of tricky,
	sometimes it seems to work without SOME of them, but sometimes it does not. It always works with them and does
	not interfere with anything else, even if the VM is not at the log-in screen, so its better to have them.

============================================================================================
 IMPORTANT DETAILS ABOUT SNAPSHOT
============================================================================================
	-> AFSBrowser works using a snapshot of a virtual machine.
	
!	-> CRUCIAL: The STATE of this virtual machine IS CRITICAL in order for AFSBrower to function properly!!

!	-> CRUCIAL: The snapshot MUST MUST MUST be of a virtual machine whose state is POWERED OFF!!!
	   To do this, take a snapshot of the machine BEFORE you turn it on.
		- If the machine is already powered on, turn it off, then take a snapshot.
!			--> The snapshot CANNOT be of a virtual machine that is logged in.
					- If the snapshot is of a VM that is logged in, AFSBrowser will
					  not be able to mount the .ISO as the CD-DRIVE. As a result,
					  the install script will not find the .ISO image it needs and
					  will not work.					  
!			--> The snapshot CANNOT be of a virtual machine that is at the log-in screen.

============================================================================================
 REFERENCES  
============================================================================================
->	In this project, I had to add a reference to VixCOM in order for VixWrapper.cs to work.
	 To do this, I went to the 'Solution Explorer', right-clicked 'References', then clicked 
	 'Add Reference' and found VixCom.
	 
->	This should never be an issue, however if you get a "VixCOM not found error" 
	 (or something to that extent) first check that the reference is still there. Like I said,
	 this should never be an issue. 
________________________________________________________________________________________________[THE END]