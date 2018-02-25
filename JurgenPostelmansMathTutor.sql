--Registering Class Libraries in SQL Server
CREATE ASSEMBLY JurgenPostelmansMathTutor FROM 'D:\WordOfGod\JurgenPostelmansMathTutor.dll' WITH PERMISSION_SET = SAFE
--DROP ASSEMBLY JurgenPostelmansMathTutor

CREATE FUNCTION AddNumbers (@I INT, @J INT) RETURNS INT 
EXTERNAL NAME JurgenPostelmansMathTutor:[WordEngineering.JurgenPostelmansMathTutor]::AddNumbers

CREATE FUNCTION SubtractNumbers (@I INT, @J INT) RETURNS INT
AS EXTERNAL NAME JurgenPostelmansMathTutor:[WordEngineering.JurgenPostelmansMathTutor]::SubtractNumbers