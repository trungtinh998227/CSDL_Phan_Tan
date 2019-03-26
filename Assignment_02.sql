create database NNTinh_NTHuy_02
go
use NNTinh_NTHuy_02
go
--------------------------------PHẦN 1: TẠO CƠ SỞ DỮ LIỆU TRÊN SQL SERVER-------------------------------
----------I-TẠO CSDL VÀ RÀNG BUỘC (Theo thứ tự chạy và nhập liệu)-----------
--4--
create table TrangThaiTG(
MSTTTG int primary key identity,
TenTT nvarchar(2) not null,
PhanTramTP real not null,
constraint ch_TenTT check (TenTT like 'TG' or TenTT like 'HH' or TenTT like 'DD'),
)
--5--
create table PhiVCHH(
MSPHH int identity primary key not null,
LoaiVe nvarchar(3) not null,
TrongLuongDM real not null,
DonGia_Kg real not null,
ThoiDiemApDung date not null,
constraint ch_LoaiVe check (Loaive like 'VIP' or LoaiVe like 'PT'),
)
--8--
create table MayBay(
MSMB nvarchar(6) primary key not null,
TongGioBay nvarchar(20) not null,
NamSX int not null,
ThoiDiemSD date not null,
MSLMB int identity not null, 
)
--12--
create table Ga(
MSG int identity primary key not null,
TenSB nvarchar(255) not null,
ThanhPho nvarchar(255) not null,
QuocGia nvarchar(255) not null
)
--11--
create table TuyenBay(
MSTB int identity primary key not null,
MSG_Di int not null,
MSG_Den int not null,
constraint fk_TuyenBay_GaDi foreign key (MSG_Di) references Ga(MSG),
constraint fk_TuyenBay_GaDen foreign key (MSG_Den) references Ga(MSG),
)
--6--
create table ChuyenBay(
MSCB nvarchar(9) primary key not null,
TrangThai nvarchar(2) not null,
SoGheTrong int not null,
ThoiDiemDi date,
ThoiDiemDen date,
MSMB nvarchar(6),
MSTB int,
constraint ch_TrangThai check (TrangThai like 'CB' or TrangThai like 'DB' or TrangThai like 'HB'),
constraint fk_ChuyenBay_MayBay foreign key (MSMB) references MayBay(MSMB),
constraint fk_ChuyenBay_TuyenBay foreign key (MSTB) references TuyenBay(MSTB)
)
--3--
create table KhachHang(
MSKH nvarchar(12) primary key,
HoTen nvarchar(255),
NgaySinh date,
GioiTinh nvarchar(3),
QuocTich nvarchar(255),
SoDT nvarchar(20),
DiaChi nvarchar(255),
MSTTTG int, --So tu dong tang
MSPHH int, --So tu dong tang
MSCB nvarchar(9),
KhoiLuongVuot nvarchar(255),
constraint ch_GioiTinh check (GioiTinh like 'Nam' or GioiTinh like 'Nu'),
-----Khoa ngoai toi bang TrangThaiTG
constraint fk_KhachHang_TrangThaiTG foreign key (MSTTTG) references TrangThaiTG(MSTTTG),
-----Khoa ngoai toi bang PhiVCHH
constraint fk_KhachHang_PhiVCHH foreign key (MSPHH) references PhiVCHH(MSPHH),
constraint fk_KhachHang_ChuyenBay foreign key (MSCB) references ChuyenBay(MSCB),
)
--2--
create table KhachHangNL(
MSKH nvarchar(12) primary key,
CMND int unique not null,
Passport nvarchar(16),
constraint fk_KhachHangNL_KhachHang foreign key (MSKH) references KhachHang(MSKH), 
)
--3--
create table KhachHangTE(
MSKH nvarchar(12) primary key,
ThongTinKSinh nvarchar(max),--Toi da so ky tu co the co cua nvarchar
MSNGH nvarchar(12),
constraint fk_KhachHangTE_KhachHang foreign key (MSKH) references KhachHang(MSKH),
)
--9--
create table LoaiMayBay(
MSLMB int identity primary key not null,
HangSX nvarchar(255) not null,
Model nvarchar(255) not null,
SoGheVip int not null,
SoGhePT int not null,
TongSoGhe int not null,
)
--10--
create table GheNgoi(
MSG int identity primary key not null,
GheSo nvarchar(3) not null,
LoaiGhe nvarchar(3) not null,
MSLMB int not null,
constraint ch_LoaiGhe check (LoaiGhe like 'VIP' OR LoaiGhe like 'PT'),
constraint fk_GheNgoi_LoaiMayBay foreign key (MSLMB) references LoaiMayBay(MSLMB),
)
--7--
create table GheKhach(
MSKH nvarchar(12) not null,
GheSo int not null,
Gia real not null,
primary key(MSKH,GheSo),
constraint fk_GheKhach_KhachHang foreign key (MSKH) references KhachHang(MSKH),
constraint fk_GheKhach_GheNgoi foreign key (GheSo) references GheNgoi(MSG),
)
--13--
create table ThucPham(
MSTP int identity primary key not null,
Ten nvarchar(255) not null unique,
MoTa nvarchar(max),
)
--14--
create table GiaThucPham(
MSGTP int identity not null primary key,
Gia real not null,
NgayApDung date not null,
MSTP int,
constraint fk_GiaThucPham foreign key (MSTP) references ThucPham (MSTP),
)
--15--
create table ChuyenBayThucPham(
MSCB nvarchar(9),
MSTP int,
primary key(MSCB,MSTP),
constraint fk_ChuyenBayThucPham_ChuyenBay foreign key (MSCB) references ChuyenBay(MSCB),
constraint fk_ChuyenBayThucPham_ThucPham foreign key (MSTP) references ThucPham(MSTP),
)
--16--
create table NhanVien(
MSNV nvarchar(12) primary key not null,
HoTen nvarchar(255) not null,
NgaySinh date not null,
GioiTinh nvarchar(3) not null,
QuocTich nvarchar(255) not null,
CMND nvarchar(30) not null unique,
Passport nvarchar(30),
NgayVaoLam date not null,
DiaChi nvarchar(255) not null,
SoDT nvarchar(14) not null,
TienLuong nvarchar(30) not null,
)
--17--
create table BangCap(
MSBC int identity primary key not null,
TenBangCap nvarchar(255) not null,
TruongDaoTao nvarchar(255) not null,
NamDat nvarchar(30) not null,
MSNV nvarchar(12) not null,
constraint fk_BangCap_NhanVien foreign key (MSNV) references NhanVien(MSNV),
)
--18--
create table PhiCong(
MSNV nvarchar(12) primary key,
LoaiPhiCong nvarchar(2) not null,
constraint ch_LoaiPhiCong check(LoaiPhiCong like 'CT' or LoaiPhiCong like 'PL'),
constraint fk_PhiCong_NhanVien foreign key (MSNV) references NhanVien (MSNV),
)
--19--
create table TiepVien(
MSNV nvarchar(12) primary key,
NgoaiNguThongThao nvarchar(255) not null,
constraint fk_TiepVien_NhanVien foreign key (MSNV) references  NhanVien (MSNV),
)
--20--
create table ChiNhanh(
MSCN int identity primary key not null,
TenChiNhanh nvarchar(255) not null,
ThanhPho nvarchar(255) not null,
QuocGia nvarchar(255) not null,
)
--21--
create table CaLamViec(
MSCLV nvarchar(2) primary key not null,
TuGio varchar(5) not null,
DenGio varchar(5) not null,
)
--22--
create table NhanVienMD(
MSNV nvarchar(12) primary key not null,
MSCN int not null,
MSNV_Truong nvarchar(12) not null,
constraint fk_NhanVienMD_NhanVien foreign key (MSNV) references NhanVien(MSNV),
constraint fk_NhanVienMD_ChiNhanh foreign key (MSCN) references ChiNhanh(MSCN),
)
--23--
create table NVMatDat_CaLV(
MSNV nvarchar(12) not null,
MSCLV nvarchar(2) not null,
NgayBatDau date,
primary key(MSNV,MSCLV),
constraint fk_NVMatDat_NhanVien foreign key (MSNV) references NhanVien(MSNV),
constraint fk_NVMatDat_CaLamViec foreign key (MSCLV) references CaLamViec(MSCLV),
)
--24--
create table VanHanh(
MSNV nvarchar(12),
MSCB nvarchar(9),
primary key (MSNV,MSCB),
constraint fk_VanHanh_NhanVien foreign key (MSNV) references NhanVien(MSNV),
constraint fk_VanHanh_ChuyenBay foreign key (MSCB) references ChuyenBay(MSCB),
)
--25--
create table Lai(
MSNV nvarchar(12),
MSLMB int,
primary key (MSNV,MSLMB),
constraint fk_Lai_NhanVien foreign key (MSNV) references NhanVien(MSNV),
constraint fk_Lai_LoaiMayBay foreign key (MSLMB) references LoaiMayBay(MSLMB),
)
--26--
create table KiemTra(
MSNV nvarchar(12),
MSCB nvarchar(9),
primary key (MSNV,MSCB),
constraint fk_KiemTra_NhanVien foreign key (MSNV) references NhanVien(MSNV),
constraint fk_KiemTra_ChuyenBay foreign key (MSCB) references ChuyenBay(MSCB),
)
--27--
create table ChuyenMonBD(
MSNV nvarchar(12),
MSLMB int,
primary key (MSNV,MSLMB),
constraint fk_ChuyenMonBD_NhanVien foreign key (MSNV) references NhanVien(MSNV),
constraint fk_ChuyenBayBD_LoaiMayBay foreign key (MSLMB) references LoaiMayBay(MSLMB),
)
----------II-TẠO INDEX-------
--A/ Thông tin chuyến bay còn trống chỗ
create INDEX INFORMATION
ON ChuyenBay(MSCB, SoGheTrong, ThoiDiemDi, ThoiDiemDen, MSTB);
--B/ Danh sách ghế còn trống của 1 chuyến bay
create INDEX SIT_LIST
ON ChuyenBay(MSCB, SoGheTrong);
Go
---------------------------PHẦN 2:  STORE PROCEDURE, FUNCTION, TRIGGER------------------------
--I/TRIGGER
create trigger Check_GHE
on LoaiMayBay
for insert
as
begin
	declare @TongSoGhe int
	declare @SoGhePT int
	declare @SoGheVIP int
	set @TongSoGhe= (select TongSoGhe from inserted)
	set @SoGheVIP=(select SoGheVip from inserted)
	set @SoGhePT=(select SoGhePT from inserted)
	if (@TongSoGhe<>@SoGhePT+@SoGheVIP)
		begin
			print N'Dữ liệu không hợp lệ'
			rollback tran
		end
	end
go
---Kiểm tra nhất quán dữ liệu----insert into LoaiMayBay values('Airbus', 'A3210', '40', '80', '112')

--II/STORE PROCEDURE-FUNCTION
-----THỦ TỤC CỦA BẢNG KhachHang-----
CREATE PROCEDURE Insert_KhachHang
@Loai varchar(2),
@Hoten nvarchar(255),
@NgaySinh varchar(10),
@GioiTinh nvarchar(3),
@QuocTich nvarchar(255),
@SoDT nvarchar(20), 
@DiaChi nvarchar(255), 
@MSTTTG int, 
@MSPHH int, 
@MSCB nvarchar(9), 
@KhoiLuongVuot nvarchar(255)
AS
BEGIN
	declare @New_MSKH nvarchar(12)
	declare @New_Day varchar(10)
	set @New_Day = convert(varchar(10),cast(@NgaySinh as date),101)
	declare @New_SDT nvarchar(12)
	select @New_SDT=right(@SoDT,9)
	set @New_SDT='+84'+@New_SDT
	select @New_MSKH = (max(right(MSKH,10))) from KhachHang
	declare @dem int
	set @dem = cast(@New_MSKH as int) + 1
		select @New_MSKH = case
			when @dem>=0 and @dem<10 then @Loai + '000000000' + cast(@dem as varchar(1))
			when @dem >= 10 then @Loai + '00000000' + cast(@dem as varchar(2))
			when @dem > 99  then @Loai + '0000000' + cast(@dem as varchar(3))
			when @dem > 999  then @Loai + '000000' + cast(@dem as varchar(4))
			when @dem > 9999  then @Loai + '00000' + cast(@dem as varchar(5))
			when @dem > 99999  then @Loai + '0000' + cast(@dem as varchar(6))
			when @dem > 999999  then @Loai + '000' + cast(@dem as varchar(7))
			when @dem > 9999999  then @Loai + '00' + cast(@dem as varchar(8))
			when @dem > 99999999  then @Loai + '0' + cast(@dem as varchar(9))
		END
	Insert into KhachHang values (@New_MSKH , @Hoten,@New_Day,@GioiTinh,@QuocTich,@New_SDT,@DiaChi,@MSTTTG,@MSPHH,@MSCB,@KhoiLuongVuot)
END
GO
-----THỦ TỤC CỦA BẢNG NhanVien-----
create procedure Insert_NhanVien
@Loai nvarchar(12),
@HoTen nvarchar(255),
@NgaySinh date,
@GioiTinh nvarchar(3),
@QuocTich nvarchar(255),
@CMND nvarchar(30),
@Passport nvarchar(30),
@NgayVaoLam varchar(10),
@DiaChi nvarchar(255),
@SoDT nvarchar(14),
@TienLuong nvarchar(30)
as
	BEGIN
	declare @New_MSNV nvarchar(12)--kiểm tra để MSNV tự động tăng
	declare @New_Date varchar(10)--kiểm tra đưa date thành chuẩn dd/mm/yyy
	set @New_Date = convert(varchar(10),cast(@NgaySinh as date),103)
	declare @New_SDT nvarchar(12)--chuyển hóa sđt
	select @New_SDT=right(@SoDT,9)
	set @New_SDT='+84'+@New_SDT
	declare @New_NgayVaoLam varchar(10)--kiểm tra đưa ngày thành dd/mm/yyy
	set @New_NgayVaoLam = CONVERT(varchar(10),CAST(@NgayVaoLam as date),103)
	select @New_MSNV = (max(right(MSNV,10))) from NhanVien
	declare @dem int
	set @dem = cast(@New_MSNV as int) + 1
		select @New_MSNV = case
			when @dem>=0 and @dem<10 then @Loai + '000000000' + cast(@dem as varchar(1))
			when @dem >= 10 then @Loai + '00000000' + cast(@dem as varchar(2))
			when @dem > 99  then @Loai + '0000000' + cast(@dem as varchar(3))
			when @dem > 999  then @Loai + '000000' + cast(@dem as varchar(4))
			when @dem > 9999  then @Loai + '00000' + cast(@dem as varchar(5))
			when @dem > 99999  then @Loai + '0000' + cast(@dem as varchar(6))
			when @dem > 999999  then @Loai + '000' + cast(@dem as varchar(7))
			when @dem > 9999999  then @Loai + '00' + cast(@dem as varchar(8))
			when @dem > 99999999  then @Loai + '0' + cast(@dem as varchar(9))
		END
	Insert into NhanVien values (@New_MSNV, @Hoten, @New_Date,@GioiTinh,@QuocTich,@CMND,@Passport,@New_NgayVaoLam,@DiaChi,@New_SDT,@TienLuong)
end
GO
--1/---THỦ TỤC CỦA BẢNG PHIVCHH-----
create procedure Update_PHIVCHH
@MSKH nvarchar(12),
@MSPHH int
as
	begin
		if @MSKH in (select MSKH from KhachHang)
			if @MSPHH in (select MSPHH from PhiVCHH)
				update KhachHang set MSPHH = @MSPHH where KhachHang.MSKH=@MSKH
			else 
				print N'MSPHH Không hợp lệ'
		else
			print N'Khách hàng không tồn tại'
	end
GO
--------Chạy để thử cập nhật PVCHH----------exec  Update_PHIVCHH 'NL0000000003','3'
---------------------------------------------------------------------------------------------------------------------------
--2a/---THỦ TỤC CỦA KhoiLuongVuot-----
create procedure Update_KhoiLuongVuot
@KLCanDuoc int,
@MSKH nvarchar(12)
as
begin
declare @TrongLuongDM int
declare @KhoiLuongVuot int
select @TrongLuongDM=TrongLuongDM from PhiVCHH,KhachHang where PhiVCHH.MSPHH=KhachHang.MSPHH and @MSKH=KhachHang.MSKH
	if(@KLCanDuoc>@TrongLuongDM)
		set @KhoiLuongVuot=@KLCanDuoc-@TrongLuongDM
	else
		set @KhoiLuongVuot=0
	update KhachHang set KhoiLuongVuot=@KhoiLuongVuot where @MSKH=KhachHang.MSKH
end
go
--------Chạy để thử cập nhật KhoiLuongVuot----------exec Update_KhoiLuongVuot 20,'NL0000000001'
------FUNCTION------
create function TienVCHH(@KLCanDuoc int,@MSKH nvarchar(12))
returns int
as
begin
declare @DonGia int
declare @PhiVC int
select @DonGia=DonGia_Kg from PhiVCHH,KhachHang where @MSKH=KhachHang.MSKH and PhiVCHH.MSPHH=KhachHang.MSPHH
set @PhiVC=@KLCanDuoc*@DonGia
return @PhiVC
end
go
---------Chạy để thử tính phí vận chuyển------- select dbo.TienVCHH(20,'NL0000000001')

---------------------------PHẦN 3:THAO TÁC VỚI DATABASE----------------
--I-INSERT DỮ LIỆU-----
-----------------------Nhập dữ liệu bảng TrangThaiTG------------------------------------
insert into TrangThaiTG values ('TG','50')
insert into TrangThaiTG values ('DD','23.5')
insert into TrangThaiTG values ('HH','25')
insert into TrangThaiTG values ('TG','13.5')
insert into TrangThaiTG values ('HH','14.9')
insert into TrangThaiTG values ('DD','65')
insert into TrangThaiTG values ('DD','55')
insert into TrangThaiTG values ('TG','50')
select * from TrangThaiTG
-----------------------Nhập dữ liệu bảng PhiVCHH------------------------------------
insert into PhiVCHH values ('VIP',15.5,20000,'04/01/2018')
insert into PhiVCHH values ('VIP',25,20000,'05/01/2018')
insert into PhiVCHH values ('VIP',12,20000,'06/01/2018')
insert into PhiVCHH values ('PT',16,25000,'12/12/2018')
insert into PhiVCHH values ('PT',18,20000,'12/12/2018')
insert into PhiVCHH values ('PT',12,25000,'06/05/2018')
select * from PhiVCHH
----------------------Nhập dữ liệu bảng LoaiMayBay------------------------------------
insert into LoaiMayBay values('Airbus', 'A300', 10, 90, 100)
insert into LoaiMayBay values ('Boeing','747',15,80,95)
insert into LoaiMayBay values ('Canadair','CL-44',20,180,200)
insert into LoaiMayBay values ('Douglas','DC-8',50,250,300)
insert into LoaiMayBay values ('EMBRAER','ERJ 135',40,260,300)
select * from LoaiMayBay
----------------------Nhập dữ liệu bảng MayBay-------------------------------------
insert into MayBay values('SAP250', '4', '2012', '1/1/2015')
insert into MayBay values('SAP251','5','2015','12/12/2015')
insert into MayBay values('SAP254','3','2013','12/12/2013')
insert into MayBay values('SAP252','6','2012','1/1/2012')
insert into MayBay values('SAP253','5','2013','1/1/2013')
select * from MayBay
----------------------Nhập dữ liệu bảng Ga-------------------------------------
insert into Ga values(N'Tân Sơn Nhất', N'Thành phố HCM', N'Việt Nam')
insert into Ga values(N'Cần Thơ',N'Cần Thơ',N'Việt Nam')
insert into Ga values(N'Cam Ranh',N'Khánh Hòa',N'Việt Nam')
insert into Ga values(N'Nội Bài',N'Hà Nội',N'Việt Nam')
select * from Ga
----------------------Nhập dữ liệu bảng TuyenBay-------------------------------------
insert into TuyenBay values('1', '2')
insert into TuyenBay values('2','3')
insert into TuyenBay values('2','1')
insert into TuyenBay values('1','3')
insert into TuyenBay values('2','4')
select * from TuyenBay
----------------------Nhập dữ liệu bảng ChuyenBay-------------------------------------
insert into ChuyenBay values('SA1233411', 'CB', '15', '4/14/2018', '4/15/2018', 'SAP250', '1')
insert into ChuyenBay values('SA1234213','CB','11','12/12/2018','12/13/2018','SAP250','2')
insert into ChuyenBay values('SA1234212','CB','10','10/12/2018','10/13/2018','SAP251','3')
insert into ChuyenBay values('SA1234214','CB','10','10/12/2018','10/13/2018','SAP251','4')
select * from ChuyenBay
----------------------Nhập dữ liệu bảng KhachHang-------------------------------------
insert into KhachHang values ('NL0000000001',N'Nguyễn Trung Tính','01/04/1998','Nam',N'Việt Nam','+84328760088',N'1168/9 Lê Văn Lương, Phước Kiển, Nhà Bè','1','1','SA1233411','')
execute Insert_KhachHang 'NL',N'Nguyễn Tuấn Huy','10/03/1998','Nam',N'Việt Nam','09013256602',N'Tân Quý Tây, Bình Chánh','2','2','SA1234213',''
exec Insert_KhachHang 'NL',N'Nguyễn Phúc Hậu','11/12/1998','Nam',N'Việt Nam','0123456781',N'Nguyễn Thị Minh Khai,Phường 10, Quận 10','3','3','SA1234213',''
exec Insert_KhachHang 'TE',N'Nguyễn Thị Huyền Khanh','11/12/2003','Nu',N'Việt Nam','03241717834',N'Phạm Ngũ Lão, Phường 1, Quận 1','4','4','SA1233411',''
exec Insert_KhachHang 'TE',N'Nguyễn Thị Trà My','11/10/2003','Nu',N'Việt Nam','0324114145',N'19 Nguyễn Hữu Thọ, Tân Phong, Quận 7','5','5','SA1234212',''
exec Insert_KhachHang 'TE',N'Nguyễn Ngọc Huỳnh Giao','5/4/2005','Nu',N'Việt Nam','0981900756',N'19 Nguyễn Thị Minh Khai, Phường 5, Quận 3','6','6','SA1234212',''
exec Insert_KhachHang 'NL',N'Nguyễn Thành Đô','09/12/1998','Nam',N'Việt Nam','0981900776',N'1168/9 Lê Văn Lương, Phước Kiển, Nhà Bè','7','5','SA1233411',''
exec Insert_KhachHang 'TE',N'Nguyễn Ngọc Huỳnh Như','5/24/2005','Nu',N'Việt Nam','0981870756',N'19 Nguyễn Thị Minh Khai, Phường 5, Quận 3','8','6','SA1234213',''
select * from KhachHang
----------------------Nhập dữ liệu bảng KhachHangNL-------------------------------------
insert into KhachHangNL values ('NL0000000001','312366414','A3343342')
insert into KhachHangNL values ('NL0000000002','321354321','B2131345')
insert into KhachHangNL values ('NL0000000003','321354343','C2134545')
insert into KhachHangNL values ('NL0000000007','321351244','D2134123')
select * from KhachHangNL
----------------------Nhập dữ liệu bảng KhachHangTE-------------------------------------
insert into KhachHangTE values ('TE0000000004','..','NL0000000001')
insert into KhachHangTE values ('TE0000000005','..','NL0000000002')
insert into KhachHangTE values ('TE0000000006','..','NL0000000002')
insert into KhachHangTE values ('TE0000000008','..','NL0000000001')
select * from KhachHangTE
----------------------Nhập dữ liệu bảng GheNgoi-------------------------------------
insert into GheNgoi values ('A01','PT','1')
insert into GheNgoi values ('B02','VIP','2')
insert into GheNgoi values ('A02','VIP','3')
insert into GheNgoi values ('A03','VIP','4')
insert into GheNgoi values ('A04','VIP','5')
insert into GheNgoi values ('A05','VIP','5')
insert into GheNgoi values ('A04','VIP','3')

select * from GheNgoi
----------------------Nhập dữ liệu bảng GheKhach-------------------------------------
insert into GheKhach values ('NL0000000001','1','300000')
insert into GheKhach values ('NL0000000002','2','300000')
insert into GheKhach values ('TE0000000004','3','300000')
insert into GheKhach values ('NL0000000002','4','300000')
insert into GheKhach values ('NL0000000003','5','300000')
insert into GheKhach values ('NL0000000007','3','300000')
insert into GheKhach values ('TE0000000008','7','300000')
select * from GheKhach
----------------------Nhập dữ liệu bảng ThucPham-------------------------------------
insert into ThucPham values (N'Nước lọc','NL')
insert into ThucPham values (N'Mì gói','MG')
insert into ThucPham values (N'Buffet','BF')
insert into ThucPham values (N'Trái cây','TC')
insert into ThucPham values (N'Socola','S')
select * from ThucPham
----------------------Nhập dữ liệu bảng GiaThucPham-------------------------------------
insert into GiaThucPham values ('15000','11/20/2018',1)
insert into GiaThucPham values ('10000','11/20/2018',2)
insert into GiaThucPham values ('150000','11/20/2018',3)
insert into GiaThucPham values ('80000','11/20/2018',4)
insert into GiaThucPham values ('55000','11/20/2018',5)
select * from GiaThucPham
----------------------Nhập dữ liệu bảng ChuyenBayThucPham------------------------------------
insert into ChuyenBayThucPham values ('SA1233411',1)
insert into ChuyenBayThucPham values ('SA1234213',2)
insert into ChuyenBayThucPham values ('SA1234212',3)
insert into ChuyenBayThucPham values ('SA1234213',4)
insert into ChuyenBayThucPham values ('SA1234213',5)
select * from ChuyenBayThucPham
----------------------Nhập dữ liệu bảng NhanVien------------------------------------
insert into NhanVien values ('DH0000000001',N'Nguyễn Ngọc Ngạn','5/4/1989','Nam',N'Việt Nam','312366456','A3542342','3/8/2012',N'Đa Kao, Quận 1, HCM','+84961435738','10000000')
exec Insert_NhanVien 'DH',N'Nguyễn Ngọc Thùy Duyên','5/4/1989','Nu',N'Việt Nam','312166456','B4442342','4/8/2012',N'Đa Kao, Quận 1, HCM','0961435956','9000000'
exec Insert_NhanVien 'DH',N'Nguyễn Hoàng Gia Linh','12/12/1990','Nu',N'Việt Nam','312164567','B5552342','4/12/2013',N'Đa Kao, Quận 1, HCM','0989114093','9500000'
exec Insert_NhanVien 'DH',N'Nguyễn Hoàng','5/4/1990','Nam',N'Việt Nam','312164326','B4232342','01/04/2013',N'Bình Chánh, HCM','0961435644','8000000'
-----------------------
exec Insert_NhanVien 'KS',N'Trần Hoàng Nam','5/10/1988','Nam',N'Việt Nam','272164326','C4342342','01/04/2013',N'Tân Bình, HCM','0986731201','9000000'
exec Insert_NhanVien 'KS',N'Trần Nguyễn Lâm','5/11/1989','Nam',N'Việt Nam','270264328','C3452342','01/04/2013',N'Phước Kiển, Nhà Bè, HCM','0988022614','10000000'
exec Insert_NhanVien 'KS',N'Nguyễn Ngọc Thúy','9/12/1989','Nu',N'Việt Nam','270543327','A3452242','1/5/2013',N'Phước Kiển, Nhà Bè, HCM','0961435958','10000000'
exec Insert_NhanVien 'KS',N'Nguyễn Hồng Ngọc','2/11/1990','Nu',N'Việt Nam','270123527','A3852352','1/5/2013',N'Tân Phong, Quận 7, HCM','0961435722','10000000'
----------------------
exec Insert_NhanVien 'KT',N'Đặng Huỳnh Nghĩa','2/12/1989','Nam',N'Việt Nam','270167540','D3985352','11/6/2012',N'Tân Phong, Quận 7, HCM','0961436048','15000000'
exec Insert_NhanVien 'KT',N'Lý Hoàng Quyên','2/11/1990','Nu',N'Việt Nam','312123529','E3857659','12/12/2013',N'Tân Hưng, Quận 7, HCM','0961436076','9000000'
exec Insert_NhanVien 'KT',N'Lữ Huỳnh Giang','2/12/1989','Nam',N'Việt Nam','242123526','F3851250','12/5/2013',N'Tân Quý Tây, Bình Chánh, HCM','0961436026','9000000'
exec Insert_NhanVien 'KT',N'Quan Hiền Quyên','12/11/1990','Nu',N'Việt Nam','276123456','F3852352','11/9/2013',N'Đất Đỏ, Vũng Tàu','0961435933','8000000'
----------------------
exec Insert_NhanVien 'PC',N'Trần Minh Khôi','12/1/1991','Nam',N'Việt Nam','376122450','F3852352','1/9/2012',N'Kiên Giang','0121435946','9000000'
exec Insert_NhanVien 'PC',N'Phạm Trường Giang','1/11/1991','Nam',N'Việt Nam','327612346','E3852353','11/11/2012',N'Ninh Kiều, Cần Thơ','0121436056','8500000'
exec Insert_NhanVien 'PC',N'Huỳnh Đức','2/11/1988','Nam',N'Việt Nam','212123459','A3852334','5/12/2013',N'Cái Bè, Tiền Giang','0961435816','8800000'
exec Insert_NhanVien 'PC',N'Lý Hoàng Gia Huy','1/11/1990','Nam',N'Việt Nam','276765457','N3852325','11/12/2011',N'Đất Đỏ, Vũng Tàu','0121445816','7500000'
----------------------
exec Insert_NhanVien 'TV',N'Huỳnh Kim Phụng','8/5/1992','Nu',N'Việt Nam','211265459','A3765334','12/12/2013',N'Cai Lậy, Tiền Giang','0961435729','8000000'
exec Insert_NhanVien 'TV',N'Huỳnh Như Phương','2/12/1991','Nu',N'Việt Nam','672123450','B3890734','12/12/2012',N'Lai Vung, Đồng Tháp','0961435611','9800000'
exec Insert_NhanVien 'TV',N'Huỳnh Gia Khanh','12/11/1992','Nu',N'Việt Nam','274123459','C3852514','5/10/2013',N'Cái Bè, Tiền Giang','0961436019','800000'
exec Insert_NhanVien 'TV',N'Huỳnh Ngọc Thanh Trân','2/1/1991','Nu',N'Việt Nam','216752140','F3852634','5/10/2012',N'Long Hồ, Vĩnh Long','0961435749','9800000'
select * from NhanVien
----------------------Nhập dữ liệu bảng BangCap ------------------------------------
insert into BangCap values (N'Cử Nhân',N'Học Viện Hàng Không',2011,'DH0000000001')
insert into BangCap values (N'Thạc Sĩ',N'Đại học RMIT',2012,'DH0000000002')
insert into BangCap values (N'Thạc Sĩ',N'Học Viện Hàng Không',2011,'DH0000000003')
insert into BangCap values (N'Tiến Sĩ',N'Đại học Tài chính',2010,'DH0000000004')
---------------------
insert into BangCap values (N'Cử Nhân',N'Học Viện Hàng Không',2009,'KS0000000005')
insert into BangCap values (N'Cử Nhân',N'Đại học Tôn Đức Thắng',2012,'KS0000000006')
insert into BangCap values (N'Thạc Sĩ',N'Học Viện Hàng Không',2011,'KS0000000007')
insert into BangCap values (N'Cử Nhân',N'Đại học Nông Lâm',2010,'KS0000000008')
---------------------
insert into BangCap values (N'Tiến Sĩ',N'Học Viện Hàng Không',2010,'KT0000000009')
insert into BangCap values (N'Cử Nhân',N'Học Viện Hàng Không',2011,'KT0000000010')
insert into BangCap values (N'Tiến Sĩ',N'Cao Đẳng Cao Thắng',2012,'KT0000000011')
insert into BangCap values (N'Cử Nhân',N'Hoc Viện Hàng Không',2010,'KT0000000012')
---------------------
insert into BangCap values (N'Tiến Sĩ',N'Học Viện Hàng Không',2010,'PC0000000013')
insert into BangCap values (N'Cử Nhân',N'Đại học Vĩnh Long',2011,'PC0000000014')
insert into BangCap values (N'Thạc Sĩ',N'Học Viện Hàng Không',2012,'PC0000000015')
insert into BangCap values (N'Cử Nhân',N'Đại học Cần Thơ',2012,'PC0000000016')
--------------------
insert into BangCap values (N'Cử Nhân',N'Đại học Nông Lâm',2010,'TV0000000017')
insert into BangCap values (N'Cử Nhân',N'Học Viện Hàng Không',2012,'TV0000000018')
insert into BangCap values (N'Cử Nhân',N'Học Viện Hàng Không',2010,'TV0000000019')
insert into BangCap values (N'Thạc Sĩ',N'Đại học tài chính',2009,'TV0000000020')
select * from BangCap
----------------------Nhập dữ liệu bảng PhiCong ------------------------------------
insert into PhiCong values ('PC0000000013','CT')
insert into PhiCong values ('PC0000000014','PL')
insert into PhiCong values ('PC0000000015','PL')
insert into PhiCong values ('PC0000000016','CT')
select * from PhiCong
----------------------Nhập dữ liệu bảng TiepVien ------------------------------------
insert into TiepVien values  ('TV0000000017',N'Tiếng Anh')
insert into TiepVien values  ('TV0000000018',N'Tiếng Nhật')
insert into TiepVien values  ('TV0000000019',N'Tiếng Trung')
insert into TiepVien values  ('TV0000000020',N'Tiếng Anh')
select * from TiepVien
----------------------Nhập dữ liệu bảng ChiNhanh ------------------------------------
insert into ChiNhanh values(N'Tân Sơn Nhất', N'Thành phố HCM', N'Việt Nam')
insert into ChiNhanh values(N'Cần Thơ',N'Cần Thơ',N'Việt Nam')
insert into ChiNhanh values(N'Cam Ranh',N'Khánh Hòa',N'Việt Nam')
insert into ChiNhanh values(N'Nội Bài',N'Hà Nội',N'Việt Nam')
select * from ChiNhanh
----------------------Nhập dữ liệu bảng CaLamViec ------------------------------------
insert into CaLamViec values ('C1','07:30','15:30')
insert into CaLamViec values ('C2','15:00','23:00')
insert into CaLamViec values ('C3','22:00','4:00')
insert into CaLamViec values ('C4','03:30','7:00')
select * from CaLamViec
----------------------Nhập dữ liệu bảng NhanVienMD ------------------------------------
---------Chi Nhánh 1--------
insert into NhanVienMD values ('DH0000000001','1','DH0000000001')
insert into NhanVienMD values ('KS0000000005','1','DH0000000001')
insert into NhanVienMD values ('KT0000000009','1','DH0000000001')
---------Chi Nhánh 2--------
insert into NhanVienMD values ('DH0000000002','2','DH0000000002')
insert into NhanVienMD values ('KS0000000006','2','DH0000000002')
insert into NhanVienMD values ('KT0000000010','2','DH0000000002')
---------Chi Nhánh 3--------
insert into NhanVienMD values ('DH0000000003','3','DH0000000003')
insert into NhanVienMD values ('KS0000000007','3','DH0000000003')
insert into NhanVienMD values ('KT0000000011','3','DH0000000003')
---------Chi Nhánh 4--------
insert into NhanVienMD values ('DH0000000004','4','DH0000000004')
insert into NhanVienMD values ('KS0000000008','4','DH0000000004')
insert into NhanVienMD values ('KT0000000012','4','DH0000000004')
select * from NhanVienMD
----------------------Nhập dữ liệu bảng NVMatDat_CaLV ------------------------------------
insert into NVMatDat_CaLV values ('DH0000000001','C1','03/08/2012')
insert into NVMatDat_CaLV values ('DH0000000002','C2','03/08/2012')
insert into NVMatDat_CaLV values ('DH0000000003','C3','03/08/2012')
insert into NVMatDat_CaLV values ('DH0000000004','C4','03/08/2012')

insert into NVMatDat_CaLV values ('KS0000000005','C1','10/08/2012')
insert into NVMatDat_CaLV values ('KS0000000006','C2','10/08/2012')
insert into NVMatDat_CaLV values ('KS0000000007','C3','10/08/2012')
insert into NVMatDat_CaLV values ('KS0000000008','C4','10/08/2012')

insert into NVMatDat_CaLV values ('KT0000000009','C1','03/09/2013')
insert into NVMatDat_CaLV values ('KT0000000010','C2','03/09/2013')
insert into NVMatDat_CaLV values ('KT0000000011','C3','03/09/2013')
insert into NVMatDat_CaLV values ('KT0000000012','C4','03/09/2013')
select * from NVMatDat_CaLV
----------------------Nhập dữ liệu bảng VanHanh ------------------------------------
----------Máy bay 1----------------
insert into VanHanh values ('PC0000000013','SA1233411')
insert into VanHanh values ('TV0000000017','SA1233411')
----------Máy bay 2----------------
insert into VanHanh values ('PC0000000014','SA1234213')
insert into VanHanh values ('TV0000000018','SA1234213')
----------Máy bay 3----------------
insert into VanHanh values ('PC0000000015','SA1234212')
insert into VanHanh values ('TV0000000019','SA1234212')
----------Máy bay 4----------------
insert into VanHanh values ('PC0000000016','SA1234214')
insert into VanHanh values ('TV0000000020','SA1234214')
select * from VanHanh
----------------------Nhập dữ liệu bảng Lai ------------------------------------
insert into Lai values ('PC0000000013','1')
insert into Lai values ('PC0000000014','2')
insert into Lai values ('PC0000000015','3')
insert into Lai values ('PC0000000016','4')
select * from Lai
----------------------Nhập dữ liệu bảng KiemTra ------------------------------------
insert into KiemTra values ('KT0000000009','SA1233411')
insert into KiemTra values ('KT0000000010','SA1234213')
insert into KiemTra values ('KT0000000011','SA1234212')
insert into KiemTra values ('KT0000000012','SA1234214')
select * from KiemTra
----------------------Nhập dữ liệu bảng ChuyenMonMD ------------------------------------
insert into ChuyenMonBD values ('KT0000000009','1')
insert into ChuyenMonBD values ('KT0000000010','2')
insert into ChuyenMonBD values ('KT0000000011','3')
insert into ChuyenMonBD values ('KT0000000012','4')
select * from ChuyenMonBD
--II-UPDATE DỮ LIỆU-----
update ChuyenBay set TrangThai = 'DB' where TrangThai = 'CB'
select * from ChuyenBay

update KhachHang set MSTTTG = '2' where MSTTTG = '1'
select * from KhachHang
--III- DELETE DỮ LIỆU-----
-------------------------------------------Không xóa được-----------------------
--------Chạy để kiểm tra delete bảng ThucPham-------------delete from ThucPham where MSTP = '1'
--Không thể xóa dữ liệu bảng thực phẩm do có liên kết khóa ngoại đến
--bảng GiaThucPham và ChuyenBayThucPham
--Để xóa được bảng thực phẩm thì thêm thuộc tính ON UPDATE CASCADE ON DELETE khi tạo ràng buộc khóa ngoại

--IV- SELECT DỮ LIỆU-----
--a--
Select NhanVien.MSNV, NhanVien.Hoten, NhanVien.SoDT, NhanVien.DiaChi from NhanVien,VanHanh 
where NhanVien.MSNV = VanHanh.MSNV and VanHanh.MSCB = 'SA1233411'
GO
--b--
Select NhanVien.MSNV, NhanVien.HoTen,CaLamViec.TuGio,CaLamViec.DenGio from NhanVien,CaLamViec,NVMatDat_CaLV
where NhanVien.MSNV = NVMatDat_CaLV.MSNV and NVMatDat_CaLV.MSCLV = CaLamViec.MSCLV and NVMatDat_CaLV.MSCLV = 'C2'
GO
--c--
Select ChuyenBay.MSCB, ChuyenBay.SoGheTrong, ChuyenBay.ThoiDiemDi, TuyenBay.MSG_Di, TuyenBay.MSG_Den from ChuyenBay,TuyenBay,Ga
where ChuyenBay.MSTB = TuyenBay.MSTB and TuyenBay.MSG_Di = Ga.MSG and ChuyenBay.SoGheTrong > 0
GO
--d--
Select ChuyenBay.MSCB, ChuyenBay.SoGheTrong, ChuyenBay.ThoiDiemDi, TuyenBay.MSG_Di, TuyenBay.MSG_Den from ChuyenBay,TuyenBay,Ga
where ChuyenBay.MSTB = TuyenBay.MSTB and TuyenBay.MSG_Di = Ga.MSG and ChuyenBay.SoGheTrong > 0
