using cwc;
using cwc.Utilities;
using CwcGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static cwc.LauchTool;

namespace VM_Viewer {
    public partial class VM_GUI : Form {

          LauchTool oConvert = null;
          LauchTool oLauch = null;
          LauchTool oLDrive = null;
          LauchTool oLoadedDrive = null;
          LauchTool oInstallDriver = null;
          LauchTool oKvmAction = null;

        string sConvertToFile = "";
        string sVM_Path = "";
        string sLauched_Path = "";

        LauchTool oLFolder = null;
        ConfigMng oConfig;
        string sMountDirectory = "";

       //string sFilePath =  @"D:\Data\autre\_CpcD\[PUBLIC] CpcdosOS2.1 BETA1.1 [JUIL.2019]\VM\PUBLIC Cpcdos OSx.vmx";
        internal bool bCreated =false;

    //    string sFilePath =  @"E:/MyVM/CpcDos/My_Cpcdos OSx.vmx";
        

        public VM_GUI() {
            InitializeComponent();
           // cbPath.Text = sFilePath;
            
        }

        private void fSetBtnLauch(string _sText)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                if (bLauching)
                {
                    btnLauch.Text = _sText;
                }
            });
        }

        public bool bLauching = false;
        public Color oOriColor;
        public string sOriText;
       
        private void fStartLaodingLauch(){
            if(bLauching) {return; }
            btnLauch.Enabled = false;
            btnEdit.Enabled = false;
            oOriColor = btnLauch.BackColor;
            sOriText = btnLauch.Text;
            btnLauch.Text = "";
            btnLauch.BackColor = Color.DarkKhaki;
            int _nDotCount = 0;

            btnLauch.TextAlign = ContentAlignment.MiddleLeft;
            bLauching = true;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {
                while (bLauching)
                    {
                        Thread.Sleep(200);
                        _nDotCount++;
                        if (_nDotCount > 9)
                        {
                            _nDotCount = 1;
                        }
                        string _sDot = "";
                        for(int i = 0; i < _nDotCount; i++) {
                            _sDot += ">";
                        }
                        fSetBtnLauch(_sDot);

                    }

            });
            bw.RunWorkerAsync();

            
            btConfig.Enabled = false;
            btPause.Enabled =true;
            btStop.Enabled =true;
            btnReset.Enabled = true;


        }
        private void fStopLaodingLauch()
        {
            this.BeginInvoke((MethodInvoker)delegate {
                bLauching = false;
                btnLauch.Enabled = true;
                btnEdit.Enabled = true;
                btnLauch.BackColor = oOriColor;
                btnLauch.Text = sOriText;

                btConfig.Enabled =true;
                btPause.Enabled =false;
                btStop.Enabled =false;
                btnReset.Enabled = false;

            });
        }

        private void fConvertFinish(LauchTool _oTool){

            if(File.Exists(sConvertToFile) ) {
                fLauchVMX(sConvertToFile);
            }else{
                fStopLaodingLauch();
            }

        }


        private void fLauchVMX(string _sPath) {
            if(!File.Exists(_sPath))
            {
                fOut(null, "Error >> File not exist: "+  _sPath);
            }

              fStartLaodingLauch();
              sLauched_Path = _sPath;


            if(!cbFullScreen.Checked) { //Normal Mode
                bFullScreenMode = false;
                oLauch = new LauchTool();
           
                //oLauch.dOut = new LauchTool.dIOut(fOut);
           	    oLauch.dExit = new LauchTool.dIExit(fLauchClose);
                oLauch.oFromWindow = this;
                oLauch.bOutput = false;
                oLauch.bStartMinimised  =true;

                if(ckbAdmin.Checked) {
                    // oLauch.bRunAsAdmin = true;
                }
                 fOut(null, "Lauch[vmplayer]: "+  _sPath);
                oLauch.fLauchExe(sVM_Path + "vmplayer.exe", " " + "\""  +_sPath + "\"");

            }else { //FULLSceen Mode
                bFullScreenMode = true;
                oLauch = new LauchTool();
           
                //oLauch.dOut = new LauchTool.dIOut(fOut);
           	    oLauch.dExit = new LauchTool.dIExit(fLauchClose);
               // oLauch.oFromWindow = this;
                oLauch.bOutput = false;
               // oLauch.bStartMinimised  =true;

                if(ckbAdmin.Checked) {
                    // oLauch.bRunAsAdmin = true;
                }

                fOut(null, "Lauch[vmplayer-kvm]: "+  _sPath);
                oLauch.fLauchExe(sVM_Path + "vmware-kvm.exe", " " + "\""  +_sPath + "\"");
            }

            //oLauch.fLauchExe(sVM_Path + "vmplayer-kvm.exe", " " + "\""  +_sPath + "\"");
            //ovftool.exe --lax source.ova destination.vmx

        }

        public void fFound_VM_Ware(bool _bDialog = true) {
                 string _sVM_Path = "";
            if(File.Exists(@"C:\Program Files (x86)\VMware\VMware Player\vmplayer.exe")) {
                _sVM_Path= @"C:\Program Files (x86)\VMware\VMware Player\vmplayer.exe";
            }
              if(File.Exists(@"C:\Program Files\VMware\VMware Player\vmplayer.exe")) {
                _sVM_Path=   @"C:\Program Files\VMware\VMware Player\vmplayer.exe";
            }

            if(_sVM_Path == "" && _bDialog) {
               fOut(null, "Please install VMware Workstation player (free)");

               DialogResult dr = MessageBox.Show("Please install VMware Workstation player (free)",  "Install Player", MessageBoxButtons.YesNo);
                switch(dr)
                {
                    case DialogResult.Yes:
                           System.Diagnostics.Process.Start("https://www.vmware.com/go/downloadworkstationplayer");
                        break;
                    case DialogResult.No:
                         fOut(null, "Error: The vmplayer.exe is not found");
                        break;
                }

                return;
            }

             sVM_Path = Path.GetDirectoryName(_sVM_Path) + "\\";

        }

        public void fLauch()
        {

            this.BeginInvoke((MethodInvoker)delegate  {
           

            fOut(null, "Lauch: "+  cbPath.Text);
            if(File.Exists(cbPath.Text)) {
                 ConfigMng.oConfig.fAddRecent(cbPath.Text);
            }
            string _sType = Path.GetFileName(cbPath.Text);
            _sType = _sType.Substring(_sType.LastIndexOf('.')+1);
            Console.WriteLine("_sType :" +  _sType);
            switch (_sType) {
                case "vmx":
                   fLauchVMX(cbPath.Text);
                break;

                case "ova":
                case "ovf":
                    string  _sSource =  cbPath.Text;
                    string _sSrcDir = Path.GetDirectoryName(_sSource);
                    string _sName =  Path.GetFileNameWithoutExtension(_sSource);
                    string _sDest =  _sSrcDir + "\\" + _sName + ".vmx";
                    sConvertToFile = _sDest;

                    if(!File.Exists(_sDest) ) {
                        fStartLaodingLauch();
                        //!!!!Generate .vmx!!!!!

                        oConvert = new LauchTool();
                   	    oConvert.dOut = new LauchTool.dIOut(fOut);
                   	    oConvert.dError = new LauchTool.dIError(fOut);
           	            oConvert.dExit = new LauchTool.dIExit(fConvertFinish);
                        oConvert.bHidden = true;

                        oConvert.bOutput = true;
                        //oConvert.bStartMinimised  =true;
                       // oLauch.UseShellExecute = true;
                        //oLauch.fLauchExe(@"C:\Program Files (x86)\VMware\VMware Player\vmplayer.exe", "-X " + "\"E:/MyVM/CpcDos/My_Cpcdos OSx.vmx\"");

                        if(ckbAdmin.Checked) {
                           // oLauch.bRunAsAdmin = true;
                        }

                        ConfigMng.oConfig.fAddRecent(cbPath.Text);
                        fOut(null, "Convert: "+  cbPath.Text);
                        oConvert.fLauchExe(sVM_Path + @"OVFTool\ovftool.exe", "--lax " + "\""  + cbPath.Text + "\" \"" + _sDest + "\"");

                    } else{
                       fLauchVMX(_sDest);
                    }
                break;

            }

            });
        }

        private void btnLauch_Click(object sender, EventArgs e) {
            btnLauch.Enabled = false;
           fFound_VM_Ware();

            /*
              Console.WriteLine("Path :  "  +  cbPath.Text);
            Console.WriteLine(WinApi.GetFullPathFromWindows(cbPath.Text));
            Console.WriteLine(WinApi.GetFullPathFromWindows("vmplayer.exe"));
            return;
            */
          // if(WinApi.GetFullPathFromWindows("imdisk.exe") != null) {

           // }


            fUnMount(sMountDirectory);
            //!!!TODO wait to completly unmont!!!!!

             try {
                    /////// Delete directory  ///////////
                    BackgroundWorker bw = new BackgroundWorker();
					bw.DoWork += new DoWorkEventHandler(
					delegate(object o, DoWorkEventArgs args) {

                        int _nTimeOut = 0;
                        while(!bIsUnMount)
                        {
                            _nTimeOut++;
                            Thread.Sleep(1);
                            if(_nTimeOut > 3000)
                            {
                                break;
                            }
                        }

                         if(_nTimeOut > 3000){
                             fOut(null, "TimeOut, Unable to unmount drive!");
                         }else{
                             fLauch();
                        }

                       
                    });
                 bw.RunWorkerAsync();

            }catch(Exception _e){}

            


        }
       public void 	fOut(LauchTool _oTool, string _sOut){
         //   Debug.fTrace("O: " + _sOut);
           this.BeginInvoke((MethodInvoker)delegate  {
               rtOutput.AppendText(_sOut + "\n");
               rtOutput.SelectionStart = rtOutput.Text.Length;
               rtOutput.ScrollToCaret();
           });
        }

        public  void fLauchClose(LauchTool _oTool){
                /*
             this.BeginInvoke((MethodInvoker)delegate  {
                      Activate();
                    //...
                    TopMost = true;
                    Show();
                    BringToFront();
                    TopMost = false;
           
             });*/
        }

          Point rtStartPos;
          Size rtStartSize;
         private void VM_GUI_Load(object sender, EventArgs e) {
             ///////Ini State///

             oOriColor = btnLauch.BackColor;
             sOriText = btnLauch.Text;
             fStopLaodingLauch();
             fUpdateRtState();
            /////////////////////

            oConfig = new ConfigMng();
            oConfig.LoadConfig(this);
            if (ConfigMng.bLoadFailed)
            {
                    ConfigMng.oConfig.vStartSize = Size;
                    ConfigMng.oConfig.vStartPos = Location;
            }

            if (ConfigMng.oConfig.bMaximize)
            {
                WindowState = FormWindowState.Maximized;
                fMaximizedState();
            }

            fLoadRecent();
            bCreated = true;
            
        }

       public  void fToHide() {
             this.BeginInvoke((MethodInvoker)delegate  {
            Hide();
             });
        }

        internal void fSetPos(LauchTool.Rect vmRect) {
            //Console.WriteLine("fSetPos!!");
            this.BeginInvoke((MethodInvoker)delegate  {
            
                    Left = vmRect.Left;
                    Top = vmRect.Top;
                  //  Width = vmRect.Right - vmRect.Left;
                  //  Height = vmRect.Bottom - vmRect.Top;
             });
        }

        internal void fLoadRecent()
        {
            this.BeginInvoke((MethodInvoker)delegate {


                /*
                List<ToolStripItem> aToRem = new List<ToolStripItem>();

                ///// Clear ///
                foreach (ToolStripItem _oItem in cbPath.Items)
                {
                    //Console.WriteLine("aa" + _oItem.Tag);
                  //  if (!(_oItem is ToolStripSeparator)) {
                        if (_oItem.Tag != null)
                        {
                            aToRem.Add(_oItem);
                        }
                   // }
                }
                foreach (ToolStripItem _oItem in aToRem)
                {
                    lauchToolStripMenuItem.DropDownItems.Remove(_oItem);
                }
                //////
                */
                cbPath.Items.Clear();

                try
                {
                  int _nCount = 0;
                    foreach (string _sRecent in ConfigMng.oConfig.aRecent)
                    {
                        if(File.Exists(_sRecent)) {
                            _nCount++;
                            cbPath.Items.Add(_sRecent);
                        }

                        /*
                            * 
                        ToolStripMenuItem _oNew = new ToolStripMenuItem(_sRecent);
                        _oNew.Tag = _sRecent;

                        string _sName = _sRecent;
                        string _sPath = _sRecent;
                        int _nLastIndex = _sName.LastIndexOf("/");
                        if (_nLastIndex != -1)
                        {
                            _sPath = _sName.Substring(0, _nLastIndex);
                            _sName = _sName.Substring(_nLastIndex);
                        }
                        _nLastIndex = _sPath.LastIndexOf("/");
                        if (_nLastIndex != -1)
                        {
                            _sName = _sPath.Substring(_nLastIndex + 1) + _sName;
                        }

                        _oNew.Text = _sName;
                        lauchToolStripMenuItem.DropDownItems.Add(_oNew);
                        
                        _oNew.Click += fRecentClick;
                        */
                    }
                    if(_nCount != 0) {
                         cbPath.SelectedIndex = 0;
                    }
                    

                }
                catch (Exception e) { Console.WriteLine(e.Message); };


            });


        }

        private void btnLocatePath_Click(object sender, EventArgs e)
        {
           // cbPath.Text = FileUtils.fOpenFolderBrowsing(cbPath.Text);
            cbPath.Text = FileUtils.fDialogExeFile(cbPath.Text, "");

        }

        public IntPtr nVM_Handle = IntPtr.Zero;
        internal void fSetParent(IntPtr _nHandle)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                nVM_Handle = _nHandle;
                //WinApi.ShowWindow(nVM_Handle, WinApi.SW_RESTORE);
                ///   Thread.Sleep(1000);
                ///   WinApi.ShowWindow(_nHandle, LauchTool.SW_MAXIMIZE);
                //  Thread.Sleep(1000);
                // ResizeConsole(true);
                //WinApi.SetForegroundWindow(nVM_Handle);
               

                WinApi.SetParent(_nHandle, Handle);
                WinApi.SetForegroundWindow(nVM_Handle);

                int style = WinApi.GetWindowLong(_nHandle, WinApi.GWL_STYLE);
                WinApi.SetWindowLong(_nHandle, WinApi.GWL_STYLE, (style & ~WinApi.WS_CAPTION));



                WinApi.ShowWindow(_nHandle, LauchTool.SW_MAXIMIZE);
                ResizeConsole();

                WinApi.SetForegroundWindow(Handle);
                /*
                                WinApi.keybd_event(VK_CONTROL, VK_CONTROL, 0, 0); // Control Down
                                PostMessage(nVM_Handle, WinApi.WM_KEYDOWN, WinApi.VK_G, 0); // G
                                WinApi.keybd_event(VK_CONTROL, VK_CONTROL, 2, 0); // Control Up

                */

            });

            fStopLaodingLauch();
            return;

            /*

    BackgroundWorker bw2 = new BackgroundWorker();
            bw2.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {
                Thread.Sleep(3000);
                this.BeginInvoke((MethodInvoker)delegate {
                    WinApi.SetForegroundWindow(Handle);
                    WinApi.SetForegroundWindow(nVM_Handle);
                    WinApi.keybd_event(VK_CONTROL, (byte)WinApi.MapVirtualKey(VK_CONTROL, 0), 0, 0); // Control Down
                    PostMessage(nVM_Handle, WinApi.WM_KEYDOWN, WinApi.VK_G, 0); // G
                    WinApi.keybd_event(VK_CONTROL, (byte)WinApi.MapVirtualKey(VK_CONTROL, 0), 2, 0); // Control Up
                });

            });
            bw2.RunWorkerAsync();



            //BUG remover
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {

                Thread.Sleep(2000);
                int i = 2;
                while (i > 0)
                {
                    i--;
                    this.BeginInvoke((MethodInvoker)delegate {
                        ResizeConsole(true);
                        ResizeConsole();
                    });
                    Thread.Sleep(1000);
                }
            });
            bw.RunWorkerAsync();
            */
        }


        public void ResizeConsole(bool _bZero = false)
        {

            this.BeginInvoke((MethodInvoker)delegate {
                int _nBorder = 2;

            Rectangle clientRect = WinApi.GetClientRect(Handle);
         


            //  this.BeginInvoke((MethodInvoker)delegate {
            //   WinApi.ShowWindow(cmdHandle, WinApi.SW_SHOWMAXIMIZED);
            if (nVM_Handle != IntPtr.Zero) {
                    if (_bZero) {
                        //WinApi.ResizeClientRectTo(nVM_Handle, new Rectangle(new Point(_nBorder, _nBorder), new Size(_nBorder, _nBorder)));
                        WinApi.ResizeClientRectTo(nVM_Handle, new Rectangle(new Point(clientRect.Left + _nBorder, clientRect.Top), new Size(new Point(clientRect.Right - _nBorder * 2 + 1, clientRect.Bottom - _nBorder * 1 ))));

                    }
                    else
                    {
                        WinApi.ResizeClientRectTo(nVM_Handle, new Rectangle(new Point(clientRect.Left + _nBorder, clientRect.Top ), new Size(new Point(clientRect.Right - _nBorder*2, clientRect.Bottom - _nBorder*1))));
                       // WinApi.ResizeClientRectTo(nVM_Handle, clientRect);
                    }
                }
          
            //    Refresh();
             //   Invalidate();
            });
        }

        private void VM_GUI_SizeChanged(object sender, EventArgs e)
        {

        }

        private void VM_GUI_Resize(object sender, EventArgs e)
        {
            ResizeConsole();
            if (bCreated)
            {

                if (!fIsMaximizeChange())
                {
                    ConfigMng.oConfig.vStartSize = Size;

                }

            }
        }
        public bool NeedRestore = false;
        FormWindowState LastWindowState = FormWindowState.Minimized;
        private bool bFullScreenMode;

        public bool fIsMaximizeChange()
        {


            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;

                if (WindowState == FormWindowState.Maximized)
                {
                    fMaximizedState();

                }
                if (WindowState == FormWindowState.Normal)
                {
                    // Restored!

                   // msMenu.Top = nInitialPosTop;
                   // msMenu.Left = Width - nInitialPosLeft;
                    //    Console.WriteLine("Restored " +    ConfigMng.oConfig.vStartPos);

                    Location = new Point(-999999, -999999);//Why??
                    Location = ConfigMng.oConfig.vStartPos; //Restore previous loc

                    return false;
                }
                return true;
            }
            return false;

        }
        public void fMaximizedState()
        {
            // Maximized!
           // msMenu.Top = nInitialPosTop + 9;
           // msMenu.Left = Width - nInitialPosLeft - 10;
        }



        private void VM_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (oLauch != null)
            {
                oLauch.bExeLauched = false;
                if (!oLauch.ExeProcess.HasExited) {
                    if(bFullScreenMode) {
                        fCloseFullScreen();
                    }else{
                        oLauch.ExeProcess.CloseMainWindow();
                    }
                    //  oLauch.ExeProcess.WaitForExit(10);
                    e.Cancel = true;
                }
            }

            ConfigMng.oConfig.bMaximize = (WindowState == FormWindowState.Maximized);
            oConfig.SaveConfig();
            fUnMount(sMountDirectory);
        }

    
        internal void fRefresh()
        {
            /*
            this.BeginInvoke((MethodInvoker)delegate {
              // Focus();
                WinApi.SetForegroundWindow(Handle);
                WinApi.SetForegroundWindow(nVM_Handle);
            WinApi.keybd_event(VK_CONTROL, (byte)WinApi.MapVirtualKey(VK_CONTROL, 0), 0, 0); // Control Down
            PostMessage(nVM_Handle, WinApi.WM_KEYDOWN, VK_G, 0); // G
            WinApi.keybd_event(VK_CONTROL, (byte)WinApi.MapVirtualKey(VK_CONTROL, 0), 2, 0); // Control Up
                                                                                             //Thread.Sleep(2000);
               // WinApi.SetForegroundWindow(Handle);
            });
            */

            /*
            Thread.Sleep(10);
            ResizeConsole(true);
            Thread.Sleep(10);
            ResizeConsole();
            Thread.Sleep(10);

            this.BeginInvoke((MethodInvoker)delegate {
                Invalidate();
                Refresh();
            });
            */

            /*
            this.BeginInvoke((MethodInvoker)delegate {
                // WinApi.SetForegroundWindow(nVM_Handle);

                WinApi.keybd_event(VK_CONTROL, (byte)WinApi.MapVirtualKey(VK_CONTROL, 0), 0, 0); // Control Down
            PostMessage(nVM_Handle, WinApi.WM_KEYDOWN, VK_G, 0); // G
            WinApi.keybd_event(VK_CONTROL, (byte)WinApi.MapVirtualKey(VK_CONTROL, 0), 2, 0); // Control Up

            Thread.Sleep(2000);
                // ResizeConsole(true);
                //   ResizeConsole();

            });*/
        }

        private void VM_GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void VM_GUI_Move(object sender, EventArgs e)
        {
            fRefresh();
        }

        private void VM_GUI_ResizeEnd(object sender, EventArgs e)
        {
            if (bCreated)
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    ConfigMng.oConfig.vStartPos = Location;
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e) {


   
           if(WinApi.GetFullPathFromWindows("imdisk.exe") != null) {

                    string _sPath = cbDrive.Text;
               
                    if (File.Exists(_sPath))
                    {
                
                        if (btnEdit.Text != "UnMount")
                        {
                            fOut(null, "Mount[DiscUtilsDevio] ");

                           //  btPause_Click(null,null);
                            string _sDirectory = Path.GetDirectoryName(_sPath) + "\\" + Path.GetFileNameWithoutExtension(_sPath) + "_Mount";
                            if (!Directory.Exists(_sDirectory)){
                                Directory.CreateDirectory(_sDirectory);
                            }else{
                      
                                if (Directory.GetFileSystemEntries(_sDirectory, "*.*").Length != 0) { //Use a new directory if already in use
                                    string _sNewPath = _sDirectory;
                                    int _nCount = 1;
                                    try { 

                                        do {
                                            if( Directory.GetFileSystemEntries(_sNewPath, "*.*").Length != 0 ){
                                                fUnMount(_sNewPath, true); //TODO check if attribute is mounted
                                                if(!Directory.Exists(_sNewPath)){ // Able to unmount
                                                    break;
                                                }
                                            }else{
                                                break;
                                            }
                                            _nCount++;
                                             _sNewPath = _sDirectory + "_" + _nCount.ToString();
                                        } while (Directory.Exists(_sNewPath));

                                    }catch(Exception ex)  { //If is already mounted and crash
                                        fUnMount(_sNewPath);
                                    }

                                    _sDirectory = _sNewPath;
                                    Directory.CreateDirectory(_sDirectory);
                                }
                            }

                            oLDrive = new LauchTool();
                            oLDrive.dOut = new LauchTool.dIOut(fOut);
                            oLDrive.bRunAsAdmin = true;
                            oLDrive.bOutput = false;
                            oLDrive.bStartHidden = true;


                            sMountDirectory = _sDirectory;
                            oLoadedDrive = oLDrive;
                            fOut(null, "Mount[DiscUtilsDevio]: " + sMountDirectory);
                            // oLauch.bRunInThread = false;
                            // oLDrive.fLauchExe(PathHelper.GetExeDirectory() + @"ImDiskTk/DiscUtilsDevio.exe", "/filename=" + "\"" + _sPath + "\"" + " /mount=Z:");
                            oLDrive.fLauchExe(PathHelper.GetExeDirectory() + @"ImDiskTk/DiscUtilsDevio.exe", "/filename=" + "\"" + _sPath + "\"" + " /mount=\"" + sMountDirectory + "\"");

                  
                           //System.Diagnostics.Process.Start(sMountDirectory);


                    
                         //   oLFolder = new LauchTool();
                         // oLFolder.bOutput = false;
                         //  oLFolder.fLauchExe("explorer.exe", "\"" + sMountDirectory + "\"");
                  
                            if(cbOpen.Checked) {
                                System.Diagnostics.Process.Start("explorer.exe", "\"" + sMountDirectory + "\"");
                            }

                            btnEdit.Text = "UnMount";
                        }else{
                            fUnMount(sMountDirectory);
                        }
                    }else {
                        fOut(null, "Error: Drive not exist: \"" + _sPath  + "\"");

                    }

            }else {
               fOut(null, "Driver is required to 'Edit Drive'");
                btnEdit.Enabled =  false;
                DialogResult dr = MessageBox.Show("Driver 'imdisk' is required to 'Edit Drive', install?",  "Install Driver", MessageBoxButtons.YesNo);
                switch(dr)
                {

                    case DialogResult.Yes:
                     
                        oInstallDriver = new LauchTool();
                   	    oInstallDriver.dOut = new LauchTool.dIOut(fOut);
                   	    oInstallDriver.dError = new LauchTool.dIError(fOut);
           	            oInstallDriver.dExit = new LauchTool.dIExit(fDriverFinish);
                      //  oInstallDriver.bHidden = true;

                        oInstallDriver.bOutput = false;
                        //oConvert.bStartMinimised  =true;
                       // oLauch.UseShellExecute = true;
                        //oLauch.fLauchExe(@"C:\Program Files (x86)\VMware\VMware Player\vmplayer.exe", "-X " + "\"E:/MyVM/CpcDos/My_Cpcdos OSx.vmx\"");

                        if(ckbAdmin.Checked) {
                            oInstallDriver.bRunAsAdmin = true;
                         //    oInstallDriver.bOutput = false;
                        }
                        string _sPath = PathHelper.GetCurrentDirectory() + "ImDiskTk/driver/install.cmd";
                      //  string _sPath = PathHelper.GetCurrentDirectory() + "ImDiskTk/config.exe";
                       
                        fOut(null, "Install Driver: "+ _sPath);
                        oInstallDriver.fLauchExe(_sPath,"");

                        break;
                    case DialogResult.No:
                         fOut(null, "Error: Driver not installed!");
                          btnEdit.Enabled =  true;
                        break;
                }
             }
        }

        private void fDriverFinish(LauchTool _oTool){
          this.BeginInvoke((MethodInvoker)delegate {
              btnEdit.Enabled =  true;
            if(WinApi.GetFullPathFromWindows("imdisk.exe") != null) {
                  fOut(null, "Driver Installation SUCCESS! ");
            }else{
                 fOut(null, "ERROR: Driver Installation FAIL");
            }
          });
        }


        public bool bIsUnMount = false;
        private void fUnMount(string _sPath, bool _bForce =false)
        {
            bIsUnMount = false;
            Console.WriteLine("Try to unmount: " + _sPath);
            if (btnEdit.Text == "UnMount" || _bForce)
            {
                oLDrive = new LauchTool();
                oLDrive.dOut = new LauchTool.dIOut(fOut);
                oLDrive.bRunAsAdmin = true;
                oLDrive.bOutput = false;
                oLDrive.bStartHidden = true;

         
                oLDrive.fLauchExe(PathHelper.GetExeDirectory() + @"ImDiskTk/ImDisk-Dlg.exe", "RM \"" + _sPath + "\"");


                try {
                    /////// Delete directory  ///////////
                    BackgroundWorker bw = new BackgroundWorker();
					bw.DoWork += new DoWorkEventHandler(
					delegate(object o, DoWorkEventArgs args) {

                            while (oLDrive.bExeLauch || oLoadedDrive.bExeLauch)
                            {
                                Thread.Sleep(1);
                            }
                            if(_bForce)
                            {
                                Thread.Sleep(500);
                            }
                            if(File.Exists(_sPath)) {
                              Directory.Delete(_sPath);
                            }
                            fFinishUnmount();
					});
					bw.RunWorkerAsync();
                    //////////////////////////////////////
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

               
              //  btnEdit.Text = "Edit Drive";
            }
        }



        public void fFinishUnmount() {
            bIsUnMount = true;
             this.BeginInvoke((MethodInvoker)delegate {
               btnEdit.Text = "Edit Drive";
                 btnEdit.Enabled = true;
             });
        }

        private void cbPath_TextChanged(object sender, EventArgs e)
        {
            string _sLastItem = cbDrive.Text;
            cbDrive.Items.Clear();
            cbDrive.Text = "";
            try {
           string _sDir = Path.GetDirectoryName(  cbPath.Text) ;
            if (Directory.Exists(_sDir))
            {

                int _nIndex = 0;
                int _nFoundIndex = 0;


                    
                foreach (string _sFile in Directory.GetFiles(_sDir, "*.*", SearchOption.TopDirectoryOnly))  {
                 
                //string supportedExtensions = "*.vmdk,*.vhd,*.vdi,*.img,*.ima,*.raw,*.vfd";
               // foreach (string _sFile in Directory.GetFiles(_sDir, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()))) {
                   string _sExtention = Str.fGetExtention(_sFile);
                   switch(_sExtention){
                            case "vmdk":
                            case "vhd":
                            case "vdi":
                            case "img":
                            case "raw":
                            case "vfd":
                                
                            cbDrive.Items.Add(_sFile);
                            if (_sLastItem == _sFile)
                            {
                                _nFoundIndex = _nIndex;
                            }
                            _nIndex++;

                         break;
                    }
                }
                if (cbDrive.Items.Count > 0)
                {
                    cbDrive.SelectedIndex = _nFoundIndex;
                }
            }
            }catch(Exception ex)
            {

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/VLiance");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            oKvmAction = new LauchTool();
            oKvmAction.bOutput = false;
            oKvmAction.fLauchExe(sVM_Path + "vmware-kvm.exe", "--power-off " + "\""  +sLauched_Path + "\"");
            fStopLaodingLauch();

        }

        private void btPause_Click(object sender, EventArgs e)
        {
            //fFound_VM_Ware(false);
            oKvmAction = new LauchTool();
            oKvmAction.bOutput = false;
           oKvmAction.fLauchExe(sVM_Path + "vmware-kvm.exe", "--suspend " + "\""  +sLauched_Path + "\"");
            fStopLaodingLauch();
        }

        private void btConfig_Click(object sender, EventArgs e)
        {
             fFound_VM_Ware();
           // fStopLaodingLauch();
            oKvmAction = new LauchTool();
            oKvmAction.bOutput = false;
           oKvmAction.fLauchExe(sVM_Path + "vmware-kvm.exe", "--preferences " + "\""  +sLauched_Path + "\"");
            //--detach ??
            //--reset
            //--exit
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
           oKvmAction = new LauchTool();
           oKvmAction.bOutput = false;
           oKvmAction.fLauchExe(sVM_Path + "vmware-kvm.exe", "--reset " + "\""  +sLauched_Path + "\"");
          //--exit can cause problem

        }

        private void fCloseFullScreen(){
            btStop_Click(null, null); //Maybe click?
        }

        private void cbFullScreen_CheckedChanged(object sender, EventArgs e) {
            fUpdateRtState();
        }


        void fUpdateRtState() {
            rtStartPos =  rtOutput.Location;
            rtStartSize =  rtOutput.Size;
            int _nSize = 75;
            if(cbFullScreen.Checked) {
                 gbFullScreen.Visible = true;
                rtOutput.Size = new Size( rtStartSize.Width , rtStartSize.Height - _nSize);
                rtOutput.Location = new Point(rtStartPos.X, rtStartPos.Y         + _nSize);
            }else{
                gbFullScreen.Visible = false;
                rtOutput.Size = new Size( rtStartSize.Width , rtStartSize.Height + _nSize);
                rtOutput.Location = new Point(rtStartPos.X, rtStartPos.Y          - _nSize);
            }
        }

    }
}
