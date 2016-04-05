GO

--If you get errors during database deploy along the lines of "user xeromatic could not connect to database" - then comment out this file.


CREATE LOGIN [XeromaticUser] WITH PASSWORD = N'Password1'
GO

CREATE USER [XeromaticUser] FOR LOGIN [XeromaticUser]
GO

CREATE ROLE [Xeromatic_ReadWrite]
GO  

-- GRANT [XeromaticUser] ROLE [Xeromatic_ReadWrite]

EXEC sp_addrolemember 'Xeromatic_ReadWrite', 'XeromaticUser'

GO 
--ALTER ROLE [Xeromatic_ReadWrite] ADD Member [XeromaticUser]
--GO

/* Permissions */


GRANT CONNECT TO [Xeromatic_ReadWrite]
GO
GRANT SElECT TO [Xeromatic_ReadWrite]
GO
GRANT EXECUTE TO [Xeromatic_ReadWrite]
GO
GRANT DELETE TO [Xeromatic_ReadWrite]
GO
GRANT UPDATE TO [Xeromatic_ReadWrite]
GO
GRANT INSERT TO [Xeromatic_ReadWrite]
GO
