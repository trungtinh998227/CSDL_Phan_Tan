create database NNTinh_NTHuy
go
use NNTinh_NTHuy
go

create table Khoa(
MAKH char(8) primary key,
TENKH varchar(40) unique
)

create table Lop(
MALOP char(8) primary key,
TENLOP varchar(40) unique,
MAKH char(8) --foreign key
constraint fk_Lop_Khoa foreign key (MAKH) references Khoa(MAKH)
)

create table SinhVien(
MASV char(8) primary key,
HO varchar(40),
TEN varchar(10),
MALOP char(8), --foreign key
PHAI bit default '1',
NGAYSINH datetime,
NOISINH varchar(40),
DIACHI varchar(80),
NGHIHOC bit,
constraint ch_Phai check (PHAI like '0' or PHAI like '1'),
constraint fk_SinhVien_Lop foreign key (MALOP) references Lop(MALOP)
)

create table Monhoc(
MAMH char(5) primary key,
TENMH varchar(40) unique,
)

create table DIEM(
MASV char(8), --foreign key
MAMH char(5), --foreign key
LAN smallint,
DIEM float,
primary key(MASV,MAMH,LAN),
constraint ch_LAN check (LAN >= '1' and LAN <= '2'),
constraint ch_DIEM check (DIEM >= '0' and DIEM <= '10'),
constraint fk_Diem_SV foreign key (MASV) references SinhVien(MASV),
constraint fk_Diem_Monhoc foreign key (MAMH) references MonHoc(MAMH)
)