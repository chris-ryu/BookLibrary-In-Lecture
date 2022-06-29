USE [master];
GO
RESTORE DATABASE [AdventureWorks] 
FROM DISK = N'C:\Users\wtime\Downloads\AdventureWorksLT2019.bak' WITH  FILE = 1, NOUNLOAD, STATS = 5;
GO