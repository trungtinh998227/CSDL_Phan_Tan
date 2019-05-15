USE [THI_TN]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'002',
		@PASS = N'123',
		@USERNAME = N'002',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'004',
		@PASS = N'123',
		@USERNAME = N'004',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'006',
		@PASS = N'123',
		@USERNAME = N'006',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'008',
		@PASS = N'123',
		@USERNAME = N'008',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'010',
		@PASS = N'123',
		@USERNAME = N'010',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'Admin2',
		@PASS = N'12345678',
		@USERNAME = N'Admin2',
		@ROLE = N'COSO'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'TH123',
		@PASS = N'123',
		@USERNAME = N'TH123',
		@ROLE = N'GIAOVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'TH657',
		@PASS = N'123',
		@USERNAME = N'TH657',
		@ROLE = N'TRUONG'

SELECT	'Return Value' = @return_value