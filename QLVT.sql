create database QLVT
use QLVT

create table ChiNhanh(
	MACN char(10) not null,
	ChiNhanh varchar(100) not null,
	DIACHI varchar(100),
	SoDT varchar(10),
	primary key(MACN),
	unique(ChiNhanh)
);

create table NhanVien(
	MANV int not null,
	HO varchar(40),
	TEN varchar(10),
	DIACHI varchar(40),
	NGAYSINH date,
	LUONG float check (LUONG >= 800000),
	MACN char(10),
	primary key(MANV),
	constraint fk_nv_cn foreign key(MACN) references ChiNhanh(MACN), 
);

create table Kho(
	MAKHO char(4) not null,
	TENKHO varchar(30) not null,
	DIACHI varchar(70),
	MACN char(10),
	primary key(MAKHO),
	unique(TENKHO),
	constraint fk_kho_cn foreign key(MACN) references ChiNhanh(MACN)
);

create table Vattu(
	MAVT char(4) not null,
	TENVT varchar(30) not null,
	DVT varchar(15),
	primary key(MAVT),
	unique(TENVT)
);

create table Phatsinh(
	PHIEU char(8) not null,
	NGAY datetime,
	LOAI char(1) default 'N' check(LOAI = 'N' or LOAI = 'X' or LOAI = 'T' or LOAI = 'C'),
	HOTENKH varchar(40),
	THANHTIEN float,
	MANV int,
	MAKHO char(4),
	primary key(PHIEU),
	constraint fk_phatsinh_nv foreign key(MANV) references NhanVien(MANV),
	constraint fk_phatsinh_kho foreign key(MAKHO) references Kho(MAKHO)
);

create table CT_Phatsinh(
	PHIEU char(8) not null,
	MAVT char(4) not null,
	SOLUONG int,
	DONGIA float,
	primary key(PHIEU, MAVT),
	constraint chk_soluong check (SOLUONG > 0),
	constraint chk_dongia check (DONGIA > 0)
);

------Chi Nhanh--------
insert into ChiNhanh values ('CN01', 'Quan 7', '19 Nguyen Huu Thọ, phuong Tan Phong, Q7', '0396736333')
insert into ChiNhanh values ('CN02', 'Quan 8', '19 Duong ba trac, Q8', '1234894231')
insert into ChiNhanh values ('CN03', 'Quan 9', '36 Hoa Binh, Q9', '0346689873')
insert into ChiNhanh values ('CN04', 'Quan 10','455 CMTT, Q10', '1232215644')

-------Nhan Vien-------
insert into NhanVien values (01, 'Le Ngoc', 'Son', '19 Nguyen Huu Thọ, Tan Phong, Q7', '03/05/1998',10000000, 'CN01')
insert into NhanVien values (02, 'Nguyen Trung', 'Tinh', '20 Le Van Luong, Tan Phong, Q7', '26/04/1998',5000000, 'CN02')
insert into NhanVien values (03, 'Nguyen Quoc', 'Cuong', '311 Hoang Dao Thuy, Q8', '26/05/1998',7000000, 'CN03')
insert into NhanVien values (04, 'Nguyen Van', 'An', '39 Hoang Dao Thuy, Q10', '26/01/1998',5000000, 'CN04')

------Kho--------------
insert into Kho values ('K01', 'DH Ton Duc Thang', 'Quan 7', 'CN01')
insert into Kho values ('K02', 'DH Van Lang', 'Quan 8', 'CN02')
insert into Kho values ('K03', 'DH Van Hien', 'Quan 8', 'CN03')
insert into Kho values ('K04', 'DH Tai chinh - Marketing', 'Quan 7', 'CN04')

------Vat Tu-----------
insert into Vattu values ('VT01', 'Xi mang', 'VND')
insert into Vattu values ('VT02', 'Thep', 'VND')
insert into Vattu values ('VT03', 'Cat', 'VND')
insert into Vattu values ('VT04', 'Gach, soi', 'VND')

------Phat Sinh--------
insert into Phatsinh values ('P001', '30/4/2019', 'N' , 'Le Ngoc Son', 1000000, 01, 'K01')
insert into Phatsinh values ('P002', '30/4/2019', 'N' , 'Nguyen Trung Tinh', 2000000, 02, 'K01')
insert into Phatsinh values ('P003', '30/4/2019', 'N' , 'Nguyen Quoc Cuong', 3000000, 03, 'K01')
insert into Phatsinh values ('P004', '30/4/2019', 'N' , 'Nguyen Van An', 5000000, 04, 'K01')

------CT_Phat Sinh-------
insert into Phatsinh values ('P005', 'VT06', 10, 5000000)
insert into Phatsinh values ('P006', 'VT07', 5, 3000000)
insert into Phatsinh values ('P007', 'VT08', 2, 2000000)
insert into Phatsinh values ('P008', 'VT09', 7, 8000000)

select * from ChiNhanh
select * from NhanVien
select * from Vattu