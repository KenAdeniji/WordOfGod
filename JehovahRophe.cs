using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WordEngineering
{
 ///<summary>JehovahRophe.</summary>
 public class JehovahRophe : WordSaid
 {
  ///<summary>Constructor.</summary>
  public JehovahRophe
  (
   int      sequenceOrderId,
   string   commentary,
   string   scriptureReference,
   DateTime dated,
   Guid     uniqueId
  )
  :base
  (
   sequenceOrderId,
   commentary,
   scriptureReference,
   dated,
   uniqueId
  )   
  {}//public JehovahRophe().
 }//public class JehovahRophe.
}//namespace WordEngineering.
