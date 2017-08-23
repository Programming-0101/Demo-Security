-- CREATE DATABASE [ProTechTED]

/* ************************
 * Part A) Tables for Storing Encrypted Data
 */
USE [ProTechTED]
GO

/****** Object:  Table [dbo].[Unidentified]    Script Date: 8/22/2017 3:11:36 PM ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unidentified]') AND type in (N'U'))
    CREATE TABLE [dbo].[People](
	    [PersonID] [int] PRIMARY KEY IDENTITY(1009,3) NOT NULL,
	    [FirstName] [varbinary](256) NOT NULL,
	    [LastName] [varbinary](256) NOT NULL,
	    [DOB] [varbinary](256) NULL
    )
GO
/****** Object:  Table [dbo].[People]    Script Date: 8/22/2017 3:11:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U'))
    CREATE TABLE [dbo].[Unidentified](
	    [ID] [int] IDENTITY(1,1) NOT NULL,
	    [Data1] [varbinary](256) NOT NULL,
	    [Data2] [varbinary](256) NOT NULL,
	    [Data3] [varbinary](256) NOT NULL,
	    [Data4] [varbinary](256) NOT NULL,
	    [Active] [bit] NOT NULL
    )
GO


CREATE PROCEDURE [dbo].[SavePerson]
    @keyName   varchar(20),
    @firstName varchar(50),
    @lastName varchar(50)
AS
        INSERT INTO dbo.People(FirstName, LastName)
    values(ENCRYPTBYKEY(KEY_GUID(@keyName), @firstName),ENCRYPTBYKEY(KEY_GUID(@keyName), @lastName))
RETURN

GO

CREATE PROCEDURE [dbo].[ListPeople]
AS
        SELECT  PersonID,
                FirstName,
                LastName,
                DOB,
                CONVERT(varchar, DecryptByKey(FirstName)) AS 'GivenName',
                CONVERT(varchar, DecryptByKey(LastName)) AS 'Surname'
        FROM    dbo.People
RETURN

GO

/* ************************
 * Part B) Setup
 *  In order to use column-level encryption on a database,
 *  some preliminary setup is required. This can be done
 *  before or after the creation of tables in the database.
 *  Credits:
 *      - https://www.mssqltips.com/sqlservertip/2431/sql-server-column-level-encryption-example-using-symmetric-keys/
 *      - http://www.dotnetpiper.com/2015/01/database-table-encryption-using.html?m=1
 */

--  0)  Just checking that a Service Master Key is present.
--      It's the root of the SQL Server encryption hierarchy
USE master;
GO

SELECT *
FROM sys.symmetric_keys
WHERE name = '##MS_ServiceMasterKey##';
GO

USE [ProTechTED]
GO

--  1)  Create a Master Key for the database.
--      The Master Key is used to protect the private keys of the certificates.
--      A database can have only one master key
CREATE MASTER KEY ENCRYPTION BY   
PASSWORD = 'Str0ng.Mast3r.Pa55w0rd';
GO

--  2)  Create a certificate
--      Certificates are used to encrypt the data in the database and the symmetric key
CREATE CERTIFICATE EncryptTestCert
WITH SUBJECT = 'MyCertificate'
GO

--  3)  Create a Symmetric Key
--      A symmetric key is a common key used to encrypt and decrypt a message; it is used by both the sender and receiver of a message.
CREATE SYMMETRIC KEY SharedEncryptionKey
WITH ALGORITHM = TRIPLE_DES
ENCRYPTION BY CERTIFICATE EncryptTestCert
GO


/* ************************
 * Part C) Inserting and Viewing Sample Encrypted Data
 */

--OPEN SYMMETRIC KEY SymmetricKey1
--DECRYPTION BY CERTIFICATE Certificate1;
---- Performs the update of the record
--INSERT INTO dbo.Customer_data (Customer_id, Customer_Name, Credit_card_number_encrypt)
--VALUES (25665, 'mssqltips4', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'4545-58478-1245') ) );    
GO

OPEN SYMMETRIC KEY SharedEncryptionKey
DECRYPTION BY CERTIFICATE EncryptTestCert

INSERT INTO dbo.People(FirstName, LastName)
VALUES (ENCRYPTBYKEY(KEY_GUID('SharedEncryptionKey'), 'Dan'),
        ENCRYPTBYKEY(KEY_GUID('SharedEncryptionKey'), 'Gilleland'))
GO

OPEN SYMMETRIC KEY SharedEncryptionKey
DECRYPTION BY CERTIFICATE EncryptTestCert

SELECT  CONVERT(varchar, DecryptByKey(FirstName)) AS 'First Name'
       ,CONVERT(varchar, DecryptByKey(LastName)) AS 'Last Name'
FROM    People
GO

