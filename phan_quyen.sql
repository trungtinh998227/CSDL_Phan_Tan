USE [THI_TN]
GO
/****** Object:  User [001]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE USER [001] FOR LOGIN [001] WITH DEFAULT_SCHEMA=[001]
GO
/****** Object:  User [002]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE USER [002] FOR LOGIN [002] WITH DEFAULT_SCHEMA=[002]
GO
/****** Object:  User [HTKN]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE USER [HTKN] FOR LOGIN [HTKN] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [TH101]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE USER [TH101] FOR LOGIN [TH101] WITH DEFAULT_SCHEMA=[TH101]
GO
/****** Object:  User [TH123]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE USER [TH123] FOR LOGIN [TH123] WITH DEFAULT_SCHEMA=[TH123]
GO
/****** Object:  User [TH234]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE USER [TH234] FOR LOGIN [TH234] WITH DEFAULT_SCHEMA=[TH234]
GO
/****** Object:  DatabaseRole [COSO]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE ROLE [COSO]
GO
/****** Object:  DatabaseRole [GIANGVIEN]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE ROLE [GIANGVIEN]
GO
/****** Object:  DatabaseRole [SINHVIEN]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE ROLE [SINHVIEN]
GO
/****** Object:  DatabaseRole [TRUONG]    Script Date: 1/4/2017 3:49:16 PM ******/
CREATE ROLE [TRUONG]
GO
ALTER ROLE [SINHVIEN] ADD MEMBER [001]
GO
ALTER ROLE [SINHVIEN] ADD MEMBER [002]
GO
ALTER ROLE [db_owner] ADD MEMBER [HTKN]
GO
ALTER ROLE [COSO] ADD MEMBER [TH101]
GO
ALTER ROLE [COSO] ADD MEMBER [TH123]
GO
/****** Object:  Schema [001]    Script Date: 1/4/2017 3:49:17 PM ******/
CREATE SCHEMA [001]
GO
/****** Object:  Schema [002]    Script Date: 1/4/2017 3:49:17 PM ******/
CREATE SCHEMA [002]
GO
/****** Object:  Schema [TH101]    Script Date: 1/4/2017 3:49:17 PM ******/
CREATE SCHEMA [TH101]
GO
/****** Object:  Schema [TH123]    Script Date: 1/4/2017 3:49:17 PM ******/
CREATE SCHEMA [TH123]
GO
/****** Object:  Schema [TH234]    Script Date: 1/4/2017 3:49:17 PM ******/
CREATE SCHEMA [TH234]
GO
/****** Object:  StoredProcedure [dbo].[SP_A]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_A]
AS
BEGIN
	SELECT *FROM SINHVIEN
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhapGiaoVien]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DangNhapGiaoVien]
@TENLOGIN NVARCHAR (50)
AS
DECLARE @TENUSER NVARCHAR(50)
SELECT @TENUSER=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@TENLOGIN)
 SELECT USERNAME = @TENUSER, 
  HOTEN = (SELECT HO+ ' '+ TEN FROM GIAOVIEN WHERE MAGV = @TENUSER ),NAME
   FROM sys.sysusers 
   WHERE UID = (SELECT GROUPUID 
                 FROM SYS.SYSMEMBERS 
               WHERE MEMBERUID= (SELECT UID FROM sys.sysusers  WHERE NAME=@TENUSER))

GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhapSinhVien]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DangNhapSinhVien]
@TENLOGIN NVARCHAR (50)
AS
DECLARE @TENUSER NVARCHAR(50)
SELECT @TENUSER=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@TENLOGIN)
 SELECT USERNAME = @TENUSER, 
  HOTEN = (SELECT HO+ ' '+ TEN FROM SINHVIEN  WHERE MASV = @TENUSER ),
   NAME
   FROM sys.sysusers 
   WHERE UID = (SELECT GROUPUID 
                 FROM SYS.SYSMEMBERS 
                   WHERE MEMBERUID= (SELECT UID FROM sys.sysusers 
                                      WHERE NAME=@TENUSER))


GO
/****** Object:  StoredProcedure [dbo].[SP_DSSV_LOP]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DSSV_LOP]
@MALOP VARCHAR (8)
AS
SELECT  [MASV]
      ,[HO]
      ,[TEN]
      ,[NGAYSINH]
      ,[DIACHI]
      ,SV.MALOP
      ,TENLOP
  FROM [SINHVIEN] SV, LOP
  WHERE SV.MALOP= @MALOP AND SV.MALOP = LOP.MALOP


GO
/****** Object:  StoredProcedure [dbo].[sp_GhiDiemSinhVien]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GhiDiemSinhVien] 
	@MASV CHAR(8),@MAMH CHAR(5),@LAN SMALLINT,
	@NGAYTHI DATETIME, @DIEM FLOAT, @BAITHI NTEXT
	AS
BEGIN
	INSERT INTO BANGDIEM (MASV,MAMH,LAN,NGAYTHI,DIEM,BAITHI)
	VALUES (@MASV,@MAMH,@LAN,@NGAYTHI,@DIEM,@BAITHI)
END


GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraGiaoVien]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KiemTraGiaoVien] 
@MAGV char(8)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM dbo.GIAOVIEN WHERE dbo.GIAOVIEN.MAGV=@MAGV)
		BEGIN
			RETURN 1
		END	
	RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraGiaoVienDK]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KiemTraGiaoVienDK]
@MAMH CHAR(5),
@MALOP CHAR(8),
@LAN SMALLINT,
@NGAY_THI DATETIME
AS
BEGIN

	DECLARE @mh CHAR(5), @lop CHAR(8)
	DECLARE @kt INT
	DECLARE @temp_lan SMALLINT

	-- kiểm tra xem đăng kí(maMH, maLop, lan) có tồn tài chưa
	IF EXISTS (	SELECT 1
				FROM GIAOVIEN_DANGKY gvdk
				WHERE  gvdk.MAMH = @MAMH AND gvdk.MALOP = @MALOP AND gvdk.LAN = @LAN)
	BEGIN							
		RETURN 1 -- đăng kí bị trùng							 								
	END		
	ELSE
	BEGIN		
				SET @temp_lan = @LAN
				
				DECLARE @ngay DATETIME
				WHILE(@temp_lan > 0) 
				BEGIN		
							SET @ngay = 0					
							SELECT @ngay = gvdk.NGAYTHI   
							FROM GIAOVIEN_DANGKY gvdk
							WHERE gvdk.MAMH = @MAMH AND gvdk.MALOP = @MALOP AND gvdk.LAN = @temp_lan
														
							IF(@ngay != 0)
							BEGIN
								IF (@NGAY_THI <= @ngay)
								BEGIN
									RETURN 2 -- ngày dk nhỏ hơn ngày trước đó
								END
							END
							SET @temp_lan = @temp_lan - 1
				END	
				
				RETURN 0 -- đăng kí hợp lệ	
	END	
END


GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraSinhVien]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KiemTraSinhVien] 
@MASV char(8)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM dbo.SINHVIEN WHERE dbo.SINHVIEN.MASV=@MASV)
		BEGIN
			RETURN 1  -- <=> trùng sinh viên
		END
	IF EXISTS(SELECT 1 FROM [L1].THI_TN.dbo.SINHVIEN AS P WHERE P.MASV=@MASV) -- dùng link để đến cơ sở còn lại kiểm tra
		BEGIN
			RETURN 1
		END
	RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraSoCauThi]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KiemTraSoCauThi] @SOCAUTHI SMALLINT,
@MAMH CHAR(5), 
@TRINHDO CHAR(1)
AS
BEGIN
	IF(@SOCAUTHI > (SELECT COUNT(*)
					FROM THI_TN.dbo.BODE
					WHERE MAMH = @MAMH AND TRINHDO >= @TRINHDO))
	BEGIN
		RETURN 1
	END

	RETURN 0

END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayMaLop_TenLopSV]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayMaLop_TenLopSV]
@MASV CHAR(8),
@MA_LOP CHAR(8) OUTPUT, 
@TEN_LOP VARCHAR(40) OUTPUT
AS
BEGIN
	SET @MA_LOP = (SELECT sv.MALOP
	FROM THI_TN.dbo.SINHVIEN sv
	WHERE sv.MASV = @MASV)

	SET @TEN_LOP = (SELECT  l.TENLOP
	FROM THI_TN.dbo.LOP l
	WHERE l.MALOP = @MA_LOP)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_LayMaMonHoc]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayMaMonHoc]
AS
BEGIN
	SELECT *
	FROM THI_TN.dbo.MONHOC
END



GO
/****** Object:  StoredProcedure [dbo].[sp_LayMaMonThi]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayMaMonThi]
@NGAY_THI DATETIME,
@MA_LOP CHAR(8)
AS
BEGIN
	SELECT gvdk.MAMH, gvdk.LAN
	FROM THI_TN.DBO.GIAOVIEN_DANGKY gvdk
	WHERE gvdk.NGAYTHI = @NGAY_THI AND gvdk.MALOP = @MA_LOP
END

GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinThi]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayThongTinThi]
@MAMH CHAR(5),
@MALOP CHAR(8),
@LAN SMALLINT,
@SOCAUTHI SMALLINT OUTPUT,
@TRINHDO CHAR OUTPUT,
@THOIGIAN SMALLINT OUTPUT
AS
BEGIN
	
	SELECT @SOCAUTHI = gvdk.SOCAUTHI, @TRINHDO = gvdk.TRINHDO, @THOIGIAN = gvdk.THOIGIAN
	FROM THI_TN.dbo.GIAOVIEN_DANGKY gvdk
	WHERE gvdk.MAMH = @MAMH AND gvdk.MALOP = @MALOP AND gvdk.LAN = @LAN
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Report]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report]
(@MASV CHAR(8) )	
AS
BEGIN 
	SELECT LOP.MALOP,LOP.TENLOP,SINHVIEN.MASV,HOTEN = SINHVIEN.TEN+' '+SINHVIEN.HO,BANGDIEM.DIEM,BANGDIEM.MAMH,BANGDIEM.BAITHI,BANGDIEM.LAN,BANGDIEM.NGAYTHI
	FROM SINHVIEN 
		JOIN LOP ON LOP.MALOP=SINHVIEN.MALOP
		JOIN BANGDIEM ON SINHVIEN.MASV=BANGDIEM.MASV
	WHERE SINHVIEN.MASV = @MASV
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Select_Question]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Select_Question]
 @SOCAUTHI int,
 @TRINHDO NVARCHAR(3),
 @MAMH NVARCHAR(6)
AS
 DECLARE @N INT, @M INT
BEGIN
	SET @N= (SELECT COUNT (*) FROM BODE
	INNER JOIN GIAOVIEN ON GIAOVIEN.MAGV=BODE.MAGV
	INNER JOIN KHOA ON KHOA.MAKH=GIAOVIEN.MAKH
	WHERE MAMH=@MAMH)
	IF(@N>=@SOCAUTHI)
		SET @N=@SOCAUTHI
	SET @M=@SOCAUTHI-@N
	SELECT [NOIDUNG],[A],[B],[C],[D],[DAP_AN]from (
		SELECT TOP (@N) [NOIDUNG],[A],[B],[C],[D],[DAP_AN],gv.MAGV 
		FROM 
			( select MAMH,[NOIDUNG],[A],[B],[C],[D],[DAP_AN],MAGV from [THI_TN].[dbo].[BODE] where MAMH=@MAMH AND TRINHDO>=@TRINHDO) as bd
		inner join 
			(select MAGV,makh from GIAOVIEN ) as gv
				on gv.MAGV=bd.MAGV 
		inner join 
			(select makh from KHOA) as kh
				on kh.MAKH=gv.MAKH 
		ORDER BY NEWID()
		UNION ALL
		SELECT TOP (@M) [NOIDUNG],[A],[B],[C],[D],[DAP_AN],gv.MAGV 
		FROM 
			( select MAMH,[NOIDUNG],[A],[B],[C],[D],[DAP_AN],MAGV from [THI_TN].[dbo].[BODE] where MAMH=@MAMH AND TRINHDO>=@TRINHDO ) as bd
		inner join 
			(select MAGV,makh from GIAOVIEN ) as gv
				on gv.MAGV=bd.MAGV 
		left join 
			(select makh from KHOA) as kh
				on kh.MAKH=gv.MAKH 
			WHERE kh.MAKH is null ORDER BY NEWID()
			) AS A
END



GO
/****** Object:  StoredProcedure [dbo].[sp_TaoLogin]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_TaoLogin]
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
  EXEC sp_addsrvrolemember @LGNAME ,'SecurityAdmin'
  EXEC sp_addsrvrolemember @LGNAME ,'DBCreator'
  EXEC sp_addsrvrolemember @LGNAME ,'ProcessAdmin'
  EXEC sp_addrolemember 'COSO', @USERNAME
  END
  ELSE IF(@ROLE='TRUONG')
  BEGIN
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

GO
/****** Object:  StoredProcedure [dbo].[sp_test]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_test]
@NGAY_THI DATETIME,
@MA_LOP CHAR(8)
AS
BEGIN
	SELECT *
	FROM THI_TN.DBO.GIAOVIEN_DANGKY gvdk
	WHERE gvdk.NGAYTHI = @NGAY_THI AND gvdk.MALOP = @MA_LOP
END
GO
/****** Object:  StoredProcedure [dbo].[spLayMaLop]    Script Date: 1/4/2017 3:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLayMaLop]
AS
BEGIN
	SELECT LOP.MALOP
	FROM LOP; 
END
