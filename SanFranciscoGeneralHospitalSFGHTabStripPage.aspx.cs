using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>SanFranciscoGeneralHospitalSFGHTabStripPage.</summary>
 public class SanFranciscoGeneralHospitalSFGHTabStripPage : Page
 {

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  ///Access Database FileName
  //public const string AccessDatabaseFileName = @"c:\windows\system32\inetsrv\SanFranciscoGeneralHospitalSFGHSurgery.mdb";
  public const string AccessDatabaseFileName = @"SanFranciscoGeneralHospitalSFGHSurgery.mdb";
  
  ///SelectRecord
  public string SelectRecord = "SELECT MedicalRecordPatientNo, AccountNo FROM {0} WHERE MedicalRecordPatientNo = '{1}' AND AccountNo = '{2}'";

  ///CoreDataRecordInsert
  public string CoreDataRecordInsert = "INSERT INTO CoreData ( MedicalRecordPatientNo, AccountNo, AltMRN, NameLast, NameFirst ) VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}' )";

  ///CoreDataRecordSelect
  public string CoreDataRecordSelect = "SELECT MedicalRecordPatientNo, AccountNo, AltMRN, NameLast, NameFirst FROM CoreData WHERE MedicalRecordPatientNo = '{0}' AND AccountNo = '{1}'";

  ///CoreDataRecordUpdate
  public string CoreDataRecordUpdate = "UPDATE CoreData SET MedicalRecordPatientNo = '{0}', AccountNo = '{1}', AltMRN = '{2}', NameLast = '{3}', NameFirst = '{4}' WHERE MedicalRecordPatientNo = '{1}' AND AccountNo = '{2}'";

  /// <summary>TextBoxMedicalRecordPatientNo</summary>  
  protected TextBox   TextBoxMedicalRecordPatientNo;

  /// <summary>TextBoxAccountNo</summary>  
  protected TextBox   TextBoxAccountNo;

  /// <summary>TextBoxAltMRN</summary>  
  protected TextBox   TextBoxAltMRN;

  /// <summary>TextBoxNameLast</summary>  
  protected TextBox   TextBoxNameLast;

  /// <summary>TextBoxNameFirst</summary>  
  protected TextBox   TextBoxNameFirst;

  /// <summary>The exception message.</summary>  
  protected Literal   LiteralFeedback;
 
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   serverMapPath = this.MapPath("");
   
   if ( !Page.IsPostBack )
   {
    Page_Default();
   }//if ( !Page.IsPostBack ) 
   
  }//Page_Load
  
  /// <summary>Page Default.</summary>
  public void Page_Default()
  {
   
  }//public static void Page_Default()  	

  /// <summary>MedicalRecordPatientNo.</summary>
  public String MedicalRecordPatientNo
  {
   get
   {
    return ( TextBoxMedicalRecordPatientNo.Text.Trim() );
   } 
   set
   {
    TextBoxMedicalRecordPatientNo.Text = value;
   }
  }//public String MedicalRecordPatientNo

  /// <summary>AccountNo.</summary>
  public String AccountNo
  {
   get
   {
    return ( TextBoxAccountNo.Text.Trim() );
   } 
   set
   {
    TextBoxAccountNo.Text = value;
   }
  }//public String AccountNo

  /// <summary>AltMRN.</summary>
  public String AltMRN
  {
   get
   {
    return ( TextBoxAltMRN.Text.Trim() );
   } 
   set
   {
    TextBoxAltMRN.Text = value;
   }
  }//public String AltMRN

  /// <summary>NameLast.</summary>
  public String NameLast
  {
   get
   {
    return ( TextBoxNameLast.Text.Trim() );
   } 
   set
   {
    TextBoxNameLast.Text = value;
   }
  }//public String NameLast

  /// <summary>NameFirst</summary>
  public String NameFirst  {
   get
   {
    return ( TextBoxNameFirst.Text.Trim() );
   } 
   set
   {
    TextBoxNameFirst.Text = value;
   }
  }//public String NameFirst
  
  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text.Trim() );
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String Feedback

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   StringBuilder    sb                      =  null;
   OleDbCommand     oleDbCommand            =  null;
   OleDbConnection	oleDbConnection         =  null;
   OleDbDataReader  oleDbDataReader         =  null;   
   
   string           sbFormat                = null;
   string           medicalRecordPatientNo  = null;
   string           accountNo               = null;
   string           altMRN                  = null;
   string           nameLast                = null;
   string           nameFirst               = null;
   bool             databaseSelect          = false;
     
   try
   {   

    medicalRecordPatientNo  =  MedicalRecordPatientNo.Trim();
    accountNo               =  AccountNo.Trim();
    altMRN                  =  AltMRN.Trim();
    nameLast                =  NameLast.Trim();
    nameFirst               =  NameFirst.Trim();
    
    if 
    ( 
     medicalRecordPatientNo == string.Empty || medicalRecordPatientNo == null ||
     accountNo == string.Empty || accountNo == null
    )
    {
     Feedback = "Required columns Medical record patient No	and Account No";
     return;
    }
    
    sb = new StringBuilder();
    sb.AppendFormat
    ( 
     SelectRecord,
     "CoreData",
     medicalRecordPatientNo,
     accountNo
    );

	oleDbConnection  =  new OleDbConnection
	(
	 "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
	 serverMapPath + @"\" + AccessDatabaseFileName +
	 ";Persist Security Info=False"
	);
	
	oleDbConnection.Open();
	
    oleDbCommand = new OleDbCommand( sb.ToString(), oleDbConnection);
    oleDbDataReader = oleDbCommand.ExecuteReader();
    
    databaseSelect = false;
    while(oleDbDataReader.Read())
    {
     medicalRecordPatientNo  =  oleDbDataReader.GetString(0);
     accountNo               =  oleDbDataReader.GetString(1);
     
     /*
     UtilityDebug.Write(string.Format("medicalRecordPatientNo: {0}", medicalRecordPatientNo));
     UtilityDebug.Write(string.Format("account: {0}", accountNo));
     */
     databaseSelect = true;
    }

    //close the reader 
    oleDbDataReader.Close();
    
    sb = new StringBuilder();
    if ( databaseSelect == false )
    {
     sbFormat = CoreDataRecordInsert;
    }
    else
    {
     sbFormat = CoreDataRecordUpdate;
    }
    	 
    sb.AppendFormat
    (
     sbFormat,
     medicalRecordPatientNo,
     accountNo,
     altMRN,
     nameLast,
     nameFirst
    );

    //UtilityDebug.Write(string.Format("sb: {0}", sb.ToString()));     
     
    oleDbCommand = new OleDbCommand( sb.ToString(), oleDbConnection); 
     
    oleDbCommand = new OleDbCommand();
    oleDbCommand.Connection = oleDbConnection;
    oleDbCommand.CommandText = sb.ToString();
     
    oleDbCommand.ExecuteNonQuery();

   }
   catch ( Exception exception )
   {
    UtilityDebug.Write(string.Format("Exception: {0}", exception.Message));
   }//catch 
   finally
   {
    if (oleDbConnection.State == System.Data.ConnectionState.Open)
    {
     oleDbConnection.Close();
    }//if (oleDbConnection.State == System.Data.ConnectionState.Open)
   }//finally
    
   
  }//public void ButtonSubmit_Click

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback                =  null;

   MedicalRecordPatientNo  = null;
   AccountNo               = null;
   AltMRN                  = null;
   NameLast                = null;
   NameFirst               = null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxMedicalRecordPatientNo
   );


  }//public void ButtonReset_Click()

  /// <summary>ButtonOpen_Click().</summary>
  public void ButtonOpen_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   StringBuilder    sb                      =  null;
   OleDbCommand     oleDbCommand            =  null;
   OleDbConnection	oleDbConnection         =  null;
   OleDbDataReader  oleDbDataReader         =  null;   
   
   string           medicalRecordPatientNo  = null;
   string           accountNo               = null;
   bool             databaseSelect          = false;
   
   try
   {   

    medicalRecordPatientNo  =  MedicalRecordPatientNo.Trim();
    accountNo               =  AccountNo.Trim();

    if 
    ( 
     medicalRecordPatientNo == string.Empty || medicalRecordPatientNo == null ||
     accountNo == string.Empty || accountNo == null
    )
    {
     Feedback = "Required columns Medical record patient No	and Account No";
     return;
    }
    
    sb = new StringBuilder();
    sb.AppendFormat
    ( 
     CoreDataRecordSelect,
     medicalRecordPatientNo,
     accountNo
    );

	oleDbConnection  =  new OleDbConnection
	(
	 "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
	 serverMapPath + @"\" + AccessDatabaseFileName +
	 ";Persist Security Info=False"
	);
	
	oleDbConnection.Open();
	
    oleDbCommand = new OleDbCommand( sb.ToString(), oleDbConnection);
    oleDbDataReader = oleDbCommand.ExecuteReader();
    
    databaseSelect = false;
    while(oleDbDataReader.Read())
    {
     MedicalRecordPatientNo  =  oleDbDataReader.GetString(0);
     AccountNo               =  oleDbDataReader.GetString(1);
     AltMRN                  =  oleDbDataReader.GetString(2);
     NameLast                =  oleDbDataReader.GetString(3);
     NameFirst               =  oleDbDataReader.GetString(4);
     /*
     UtilityDebug.Write(string.Format("medicalRecordPatientNo: {0}", medicalRecordPatientNo));
     UtilityDebug.Write(string.Format("account: {0}", accountNo));
     */
     databaseSelect = true;
    }
    //close the reader 
    oleDbDataReader.Close();
    
    if ( databaseSelect == false )
    {
     Feedback = "Record Not Found";
     UtilityDebug.Write("Record Not Found");     
    }    	
   }
   catch ( Exception exception )
   {
    UtilityDebug.Write(string.Format("Exception: {0}", exception.Message));
   }//catch 
   finally
   {
    if (oleDbConnection.State == System.Data.ConnectionState.Open)
    {
     oleDbConnection.Close();
    }//if (oleDbConnection.State == System.Data.ConnectionState.Open)
   }//finally
   
  }//public void ButtonOpen_Click()

 }//SanFranciscoGeneralHospitalSFGHTabStripPage class.
}//WordEngineering namespace.