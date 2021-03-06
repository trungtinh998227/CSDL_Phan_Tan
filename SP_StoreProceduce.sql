USE [THI_TN]
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoLogin]    Script Date: 5/12/2019 12:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_TaoLogin]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'THI_TN'
  IF (@RET = 1)  -- LOGIN NAME BI TRUNG
     RETURN 1
 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RETURN 2
  END
  IF(@ROLE ='COSO')
  BEGIN
  EXEC sp_addsrvrolemember @LGNAME ,'sysadmin'
  EXEC sp_addsrvrolemember @LGNAME ,'securityadmin'
  EXEC sp_addsrvrolemember @LGNAME ,'dbcreator'
  EXEC sp_addsrvrolemember @LGNAME ,'processadmin'
  EXEC sp_addrolemember 'COSO', @USERNAME
  END
  ELSE IF(@ROLE='TRUONG')
  BEGIN
	EXEC sp_addsrvrolemember @LGNAME ,'sysadmin'
	EXEC sp_addsrvrolemember @LGNAME ,'securityadmin'
	EXEC sp_addsrvrolemember @LGNAME ,'processadmin'
	EXEC sp_addrolemember 'TRUONG', @USERNAME
  END
  ELSE IF(@ROLE='GIAOVIEN')
  BEGIN
	EXEC sp_addrolemember 'GIAOVIEN', @USERNAME
  END
  ELSE IF(@ROLE='SINHVIEN')
  BEGIN
	EXEC sp_addrolemember'SINHVIEN',@USERNAME
  END
  RETURN 0