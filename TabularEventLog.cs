using System;
using System.Data.Sql;
using Microsoft.SqlServer.Server;
using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics;

//namespace WordEngineering
//{
	///<summary>Extending SQL Server Reporting Services with SQL CLR Table-Valued Functions  (Mon, 12 Mar 2007 17:56:16 GMT)
	///		http://msdn2.microsoft.com/en-us/library/bb293147.aspx
	/// CREATE ASSEMBLY TabularEventLog 
	/// FROM 'D:\WordOfGod\bin\TabularEventLog.dll'
	/// WITH PERMISSION_SET = SAFE; --EXTERNAL_ACCESS, SAFE, UNSAFE
	/// GO
	///		SELECT TOP 10 T.logTime, T.Message, T.InstanceId 
	///			FROM dbo.ReadEventLog(N'Application') as T
	///<summary>
	public class TabularEventLog
	{
	    [SqlFunction(TableDefinition="logTime datetime,Message" +
	        "nvarchar(4000),Category nvarchar(4000),InstanceId bigint",
	        Name="ReadEventLog", FillRowMethodName = "FillRow")]
	    public static IEnumerable InitMethod(String logname)
	    {
	        return new EventLog(logname, Environment.MachineName).Entries;
	    }
	
	    public static void FillRow(Object obj, out SqlDateTime timeWritten,
	        out SqlChars message, out SqlChars category,
	        out long instanceId)
	    {
	        EventLogEntry eventLogEntry = (EventLogEntry)obj;
	        timeWritten = new SqlDateTime(eventLogEntry.TimeWritten);
	        message = new SqlChars(eventLogEntry.Message);
	        category = new SqlChars(eventLogEntry.Category);
	        instanceId = eventLogEntry.InstanceId;
	    }
	}
//}	