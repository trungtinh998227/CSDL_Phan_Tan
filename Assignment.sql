﻿USE [QLDSV]
GO
CREATE ROLE [USER] AUTHORIZATION [dbo]
GO
CREATE ROLE [ADMIN] AUTHORIZATION [dbo]
GO
CREATE USER [KYTHU] FOR LOGIN [KYTHU] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE SCHEMA [ADMIN] AUTHORIZATION [ADMIN]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHOA](
	[MAKH] [char](4) NOT NULL,
	[TENKH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_KHOA] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

INSERT [dbo].[KHOA] ([MAKH], [TENKH]) VALUES (N'CNTT', N'Công nghệ thông tin')
INSERT [dbo].[KHOA] ([MAKH], [TENKH]) VALUES (N'VT', N'Viễn thông')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MONHOC](
	[MAMH] [char](6) NOT NULL,
	[TENMH] [varchar](40) NULL,
 CONSTRAINT [PK_MONHOC] PRIMARY KEY CLUSTERED 
(
	[MAMH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_MONHOC] UNIQUE NONCLUSTERED 
(
	[TENMH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'CTDL', N'Cấu trúc dữ liệu')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'CSDLPT', N'Cơ sở dữ liệu phân tán')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'CSDL', N'Cơ sở dữ liệu')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'VB', N'Lập trình Visual Basic nâng cao')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'LTCB', N'Lập trình cơ bản')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'THCS1', N'Tin học cơ sở 1')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'THDC', N'Tin học đại cương')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'TRR1', N'Toán rời rạc 1')
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOP](
	[MALOP] [char](8) NOT NULL,
	[TENLOP] [varchar](80) NULL,
	[MAKH] [char](4) NULL,
 CONSTRAINT [PK_LOP] PRIMARY KEY CLUSTERED 
(
	[MALOP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_TENLOP] UNIQUE NONCLUSTERED 
(
	[TENLOP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH]) VALUES (N'C10THA1', N'Cao đẳng chính qui CNTT Khoá 19', N'CNTT')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH]) VALUES (N'D08-HTTT', N'Đại học chính qui 1  CNTT  Khoá 20 ', N'CNTT')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH]) VALUES (N'D08VTA1', N'Đại học chính qui 1  VT  Khóa 19 ', N'VT  ')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH]) VALUES (N'D09THA1', N'Đại học chính qui 1  CNTT  Khóa 18', N'CNTT')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH]) VALUES (N'D09VTA1', N'Đại học chính qui 1  VT  Khóa 20', N'VT  ')
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GIANGVIEN](
	[MAGV] [nchar](10) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[TEN] [nchar](10) NOT NULL,
	[MAKH] [char](4) NOT NULL,
 CONSTRAINT [PK_GIANGVIEN] PRIMARY KEY CLUSTERED 
(
	[MAGV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH]) VALUES (N'GV01', N'Dung Cẩm', N'Quang', N'CNTT')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH]) VALUES (N'GV02', N'Trương Đình', N'Tú', N'CNTT')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH]) VALUES (N'GV03', N'Nguyễn Xuân', N'Hải', N'VT  ')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH]) VALUES (N'GV04', N'Trần Thị Hồng', N'Nhung', N'VT  ')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DSLOP] AS
  SELECT  TENLOP FROM DBO.LOP
UNION
  SELECT  TENLOP FROM LINK1.QLDSV.DBO.LOP
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SINHVIEN](
	[MASV] [char](8) NOT NULL,
	[HO] [varchar](40) NULL,
	[TEN] [varchar](10) NULL,
	[MALOP] [char](8) NOT NULL,
	[PHAI] [bit] NULL,
	[NGAYSINH] [datetime] NULL,
	[NOISINH] [varchar](40) NULL,
	[DIACHI] [varchar](80) NULL,
	[GHICHU] [text] NULL,
	[NGHIHOC] [bit] NULL,
 CONSTRAINT [PK_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_MALOP_TEN] ON [dbo].[SINHVIEN] 
(
	[MALOP] ASC,
	[TEN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TENHO] ON [dbo].[SINHVIEN] 
(
	[TEN] ASC,
	[HO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'08THA101', N'Nguyễn Trung', N'Tính', N'D08-HTTT', 1, CAST(0x0000883300000000 AS DateTime), N'Tiền Giang', N'Chợ Gạo Tiền Giang', N' ', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'08THA102', N'Nguyễn Tuấn', N'Huy', N'D08-HTTT', 1, CAST(0x0000882600000000 AS DateTime), N'Hồ Chí Minh', N'Bình Chánh', NULL, 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'08THA103', N'Lâm Nhật', N'Hạ', N'D08-HTTT', 0, CAST(0x000087BB00000000 AS DateTime), N'Đồng Tháp', N'Cao Lãnh', N' ', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'08VTA101', N'Nguyễn', N'Thanh', N'D08VTA1 ', 1, CAST(0x00006C5500000000 AS DateTime), N'Hà Nội', N'11 Lê Văn Sỹ', N'', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'08VTA102', N'Võ Tiến', N'Phát', N'D08VTA1 ', 1, CAST(0x00006CEB00000000 AS DateTime), N'Phú Yên', N'26 Phan Đình Phùng', N' ', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'09THA101', N'Lê Thị Mỹ', N'Vân', N'D09THA1 ', 0, CAST(0x00006D0B00000000 AS DateTime), N'Lâm Đồng', N'Đà Lạt', N' ', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'09THA102', N'Trần Thúy', N'Hoa', N'D09THA1 ', 0, CAST(0x00006D2A00000000 AS DateTime), N'Bình Dương', N'2 Lý Chính Thắng', N' ', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC]) VALUES (N'09THA103', N'Nguyễn Thị Yến', N'Nhi', N'D09THA1 ', 0, CAST(0x00006D4A00000000 AS DateTime), N'Khánh Hòa', N'14 Nguyễn Văn Linh', NULL, 0)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_SISO]
AS
SELECT L.MALOP , L.TENLOP, COUNT(S.MASV ) AS SISO
FROM LOP L LEFT JOIN 
  (SELECT MASV, MALOP FROM SINHVIEN WHERE NGHIHOC='FALSE') S
     ON L.MALOP=S.MALOP 
GROUP BY L.MALOP, L.TENLOP
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIEM](
	[MASV] [char](8) NOT NULL,
	[MAMH] [char](6) NOT NULL,
	[LAN] [smallint] NOT NULL,
	[DIEM] [float] NOT NULL,
 CONSTRAINT [PK_DIEM] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC,
	[MAMH] ASC,
	[LAN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'CSDL', 1, 4)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'CTDL', 1, 4)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'CTDL', 2, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'LTCB', 1, 3)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'LTCB', 2, 4)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'THDC', 1, 5)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA101', N'VB', 1, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA102', N'CSDL', 1, 10)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA102', N'CTDL', 1, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA102', N'LTCB', 1, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA102', N'THDC', 1, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA102', N'VB', 1, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA103', N'CSDL', 1, 8)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA103', N'CTDL', 1, 7)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA103', N'LTCB', 1, 6)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA103', N'THDC', 1, 8)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08THA103', N'VB', 1, 8)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08VTA101', N'THDC', 1, 3)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08VTA101', N'THDC', 2, 8)
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM]) VALUES (N'08VTA102', N'THDC', 1, 7)

ALTER TABLE [dbo].[DIEM]  WITH NOCHECK ADD  CONSTRAINT [CK_DIEM_DIEM] CHECK  (([DIEM]>=(0) AND [DIEM]<=(10)))
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [CK_DIEM_DIEM]
GO

ALTER TABLE [dbo].[DIEM]  WITH NOCHECK ADD  CONSTRAINT [CK_DIEM_LAN] CHECK  (([LAN]=(1) OR [LAN]=(2)))
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [CK_DIEM_LAN]
GO

ALTER TABLE [dbo].[DIEM]  WITH CHECK ADD  CONSTRAINT [FK_DIEM_MONHOC1] FOREIGN KEY([MAMH])
REFERENCES [dbo].[MONHOC] ([MAMH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [FK_DIEM_MONHOC1]
GO

ALTER TABLE [dbo].[DIEM]  WITH NOCHECK ADD  CONSTRAINT [FK_DIEM_SINHVIEN] FOREIGN KEY([MASV])
REFERENCES [dbo].[SINHVIEN] ([MASV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [FK_DIEM_SINHVIEN]
GO

ALTER TABLE [dbo].[GIANGVIEN]  WITH CHECK ADD  CONSTRAINT [FK_GIANGVIEN_KHOA] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHOA] ([MAKH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GIANGVIEN] CHECK CONSTRAINT [FK_GIANGVIEN_KHOA]
GO

ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_KHOA1] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHOA] ([MAKH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_KHOA1]
GO

ALTER TABLE [dbo].[SINHVIEN]  WITH CHECK ADD  CONSTRAINT [FK_SINHVIEN_LOP] FOREIGN KEY([MALOP])
REFERENCES [dbo].[LOP] ([MALOP])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SINHVIEN] CHECK CONSTRAINT [FK_SINHVIEN_LOP]
GO