USE [THI_TN]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'001',
		@PASS = N'123',
		@USERNAME = N'001',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'003',
		@PASS = N'123',
		@USERNAME = N'003',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'005',
		@PASS = N'123',
		@USERNAME = N'005',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'007',
		@PASS = N'123',
		@USERNAME = N'007',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'009',
		@PASS = N'123',
		@USERNAME = N'009',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'011',
		@PASS = N'123',
		@USERNAME = N'011',
		@ROLE = N'SINHVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'admin',
		@PASS = N'1234567',
		@USERNAME = N'admin',
		@ROLE = N'COSO'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'TH234',
		@PASS = N'123',
		@USERNAME = N'TH234',
		@ROLE = N'GIAOVIEN'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoLogin]
		@LGNAME = N'TH101',
		@PASS = N'123',
		@USERNAME = N'TH101',
		@ROLE = N'TRUONG'

SELECT	'Return Value' = @return_value