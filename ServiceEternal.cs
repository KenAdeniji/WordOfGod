using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Timers;
using System.IO;

namespace WordEngineering
{
 /// <summary>ServiceEternal</summary>
 /// <remarks>
 /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnhcvs04/html/vs04a1.asp  Leon Zhang: Automating Routine Jobs Creating a Windows Service to Leverage Advanced .NET Components
 /// </remarks>
 public class ServiceEternal : System.ServiceProcess.ServiceBase
 {
  /// <summary>container</summary>
  public System.ComponentModel.Container     components  =  null;

  /// <summary>eventLog</summary>
  public static System.Diagnostics.EventLog  eventLog;
  
  /// <summary>timer</summary>  
  public System.Timers.Timer                 timer;
  
  /// <summary>Constructor.</summary>
  public ServiceEternal()
  {
   // This call is required by the Windows.Forms Component Designer.
   InitializeComponent();
   eventLog = new EventLog
   (
    "Application",
    ".",
    this.ServiceName
   );
   // TODO: Add any initialization after the InitComponent call
  }//public ServiceEternal()

  ///<summary>The entry point for the application.</summary>
  public static void Main
  (
   string[] argv
  )
  {
   System.ServiceProcess.ServiceBase[]  serviceBase;
	
   serviceBase = new System.ServiceProcess.ServiceBase[] 
   { 
   	new ServiceEternal()
   };

   System.ServiceProcess.ServiceBase.Run( serviceBase );
  }//public static void Main( string[] argv )

  /// <summary> 
  /// Required method for Designer support - do not modify 
  /// the contents of this method with the code editor.
  /// </summary>
  public void InitializeComponent()
  {
   components                =  new System.ComponentModel.Container();
   this.ServiceName          =  "ServiceEternal";
   this.CanPauseAndContinue  =  true;
   this.CanStop              =  true;
   this.AutoLog              =  false;
  }//public void InitializeComponent()

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  protected override void Dispose
  ( 
   bool disposing 
  )
  {
   if ( disposing )
   {
    if ( components != null )
    {
     components.Dispose();
    }//if ( components != null )
   }//if ( disposing )
   
   base.Dispose( disposing );
  }//public override void Dispose( bool disposing )

  /// <summary>
  /// OnStart
  /// </summary>
  protected override void OnStart
  (
   string[] argv
  )
  {
   if ( timer == null )
   {
    timer           =  new System.Timers.Timer();
    timer.Elapsed  +=  new ElapsedEventHandler( OnTimer );
    timer.Interval  =  1000 * 60 * 60 * 24; //Let the timer trigger once a day
    timer.Enabled   =  true;
   }//if ( timer == null ) 
   else 
   {
    timer.Start();
   }
   eventLog.WriteEntry( this.ServiceName + " start." );
  }//protected override void OnStart(string[] argv)	

  /// <summary>Stop service.</summary>
  protected override void OnStop()
  {
   if ( timer != null ) 
   {
   	 timer.Stop();
   }	 
   eventLog.WriteEntry( this.ServiceName + " stop." );
  }//protected override void OnStop()

  /// <summary>Pause service.</summary>
  protected override void OnPause()
  {
   if ( timer != null) 
   {
   	timer.Stop();
   }	
   eventLog.WriteEntry( this.ServiceName + " pause." );
  }//protected override void OnPause()

  /// <summary>Continue service.</summary>
  protected override void OnContinue()
  {
   if ( timer != null) 
   {
   	timer.Start();
   }	
   eventLog.WriteEntry( this.ServiceName + " resume." );
  }//protected override void OnContinue()
  
  /// <summary>OnTimer()</summary>
  public static void OnTimer
  (
   Object            source, 
   ElapsedEventArgs  elapsedEventArgs
  )
  {
   string   processStatus  =  null;
   Process  process;	
   try
   {
    process = new Process();
    process.StartInfo.FileName = @"D:\WordOfGod\20041013EternalURI.bat";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    process.PriorityClass = ProcessPriorityClass.High;
    process.Start();
    processStatus = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    eventLog.WriteEntry( "ServiceEternal " + processStatus );
   }//try
   catch ( Exception exception )
   {
    eventLog.WriteEntry( "Exception: " + exception.Message );       	
   }//catch ( Exception exception )   	
  }//public static void OnTimer(Object source, ElapsedEventArgs elapsedEventArgs)

 }//public class ServiceEternal : System.ServiceProcess.ServiceBase
 
 /// <summary>Windows service application installation class</summary>
 [RunInstallerAttribute(true)]
 public class InstallerEternal : Installer
 {
  /// <summary>ServiceInstallerEternal</summary>
  public  ServiceInstaller         serviceInstallerEternal;

  /// <summary>ServiceInstallerEternal</summary>
  public  ServiceProcessInstaller  serviceProcessInstaller;

  /// <summary>Constructor</summary>
  public InstallerEternal()
  {
   // Instantiate installers for process and services.
   serviceProcessInstaller  =  new ServiceProcessInstaller();
   
   serviceInstallerEternal  =  new ServiceInstaller();
   
   // The services run under the system account.
   serviceProcessInstaller.Account = ServiceAccount.LocalSystem;

   // The services are set to start automatically.
   serviceInstallerEternal.StartType = ServiceStartMode.Automatic;

   // ServiceName must be those given on ServiceBase derived classes.            
   serviceInstallerEternal.ServiceName = "ServiceEternal";

   // Add installers to collection. Order is trival.
   Installers.Add( serviceInstallerEternal );
   Installers.Add( serviceProcessInstaller );
  }//public InstallerEternal()
 }//public class InstallerEternal : Installer
}//namespace WordEngineering