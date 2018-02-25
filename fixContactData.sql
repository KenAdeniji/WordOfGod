update contact
set   FirstName = tblcontactBackup.Firstname
      , LastName = tblcontactBackup.Lastname
from  wordEngineering.dbo.contact tblContact
        inner join dbBackup.dbo.contact_20050525 tblContactBackup
            on tblContact.SequenceOrderId = tblContactBackup.SequenceOrderId;
