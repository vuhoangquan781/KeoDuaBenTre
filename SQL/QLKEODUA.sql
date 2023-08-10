create database QLKEODUA
go
use QLKEODUA
go
create table LOAISP
(
	MALOAISP varchar(50) primary key,
	TENLOAISP nvarchar(50),
	NGAYNAP nvarchar(50)
)
create table SANPHAM
(
	MASP varchar(50) primary key,
	TENSP nvarchar(50),
	MALOAISP varchar(50),
	TRONGLUONG nvarchar(50),
	QUYCACH nvarchar(50),
	KHUYENMAI nvarchar(50),
	GIABAN int,
	NGAYNAP nvarchar(50)
	constraint fk_SANPHAM_MALOAISP foreign key (MALOAISP) references LOAISP(MALOAISP)
)
create table KHUVUC
(
	MAKV varchar(50) primary key,
	TENKV nvarchar(50),
	NGAYNAP nvarchar(50)
)
create table TINH
(
	MAKVC varchar(50) primary key,
	TENKVC nvarchar(50),
	MAKV varchar(50),
	NGAYNAP nvarchar(50)
	constraint fk_TINH_MAKV foreign key (MAKV) references KHUVUC(MAKV)
)
create table CHINHANH
(
	MACN varchar(50) primary key,
	TENCN nvarchar(50),
	NGAYNAP nvarchar(50)
)
create table NHAPP
(
	MANPP varchar(50) primary key,
	TENNPP nvarchar(50),
	NGAYNAP nvarchar(50)
)
create table NHANVIEN
(
	MANV varchar(50) primary key,
	TENNV nvarchar(50),
	GIOITINH nvarchar(50),
	DIACHI nvarchar(50),
	SDT nvarchar(50),
	MACN varchar(50),
	NGAYNAP nvarchar(50)
	constraint fk_NHANVIEN_MACN foreign key (MACN) references CHINHANH(MACN)
)
create table KHACHHANG
(
	MAKHACH varchar(50) primary key,
	TENKHACH nvarchar(50),
	GIOITINH nvarchar(50),
	TUOI nvarchar(50),
	NGAYSINH nvarchar(50),
	NGHENGHIEP nvarchar(50),
	SDT nvarchar(50),
	NGAYNAP nvarchar(50)
)
create table THOIGIAN
(
	MATG varchar(50) primary key,
	THANG nvarchar(50),
	NAM nvarchar(50),
	NGAYNAP nvarchar(50)
)
create table FACT
(
	MASP varchar(50),
	MAKHACH varchar(50),
	MAKVC varchar(50),
	MANV varchar(50),
	MANPP varchar(50),
	MATG varchar(50),
	SOLUONG int,
	CHIPHIVC int,
	DOANHTHU float,
	NGAYNAP nvarchar(50)
	constraint fk_FACT_MASP foreign key (MASP) references SANPHAM(MASP),
	constraint fk_FACT_MAKHACH foreign key (MAKHACH) references KHACHHANG(MAKHACH),
	constraint fk_FACT_MAKVC foreign key (MAKVC) references TINH(MAKVC),
	constraint fk_FACT_MANV foreign key (MANV) references NHANVIEN(MANV),
	constraint fk_FACT_MANPP foreign key (MANPP) references NHAPP(MANPP),
	constraint fk_FACT_MATG foreign key (MATG) references THOIGIAN(MATG)
)