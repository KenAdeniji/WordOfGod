using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WordEngineering
{
 /// <summary>DatabaseEventArgs.</summary>
 public class DatabaseEventArgs : EventArgs
 {
  private readonly string tableName = null;
  
  ///<summary>TableName property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public string TableName
  {
   get 
   {
    return ( tableName );
   }//get
  }//public string TableName
  
 }//public class DatabaseEventArgs : EventArgs
 
}//namespace WordEngineering
