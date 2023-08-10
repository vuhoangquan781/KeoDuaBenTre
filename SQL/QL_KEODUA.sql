create database QL_KEODUA
go
use QL_KEODUA
go
create table LOAISP
(
	MALOAISP nvarchar(50) primary key,
	TENLOAISP nvarchar(50),
)
create table SANPHAM
(
	MASP nvarchar(50) primary key,
	TENSP nvarchar(50),
	MALOAISP nvarchar(50),
	TRONGLUONG nvarchar(50),
	QUYCACH nvarchar(50),
	KHUYENMAI nvarchar(50),
	GIABAN int,
	constraint fk_SANPHAM_MALOAISP foreign key (MALOAISP) references LOAISP(MALOAISP)
)
create table KHUVUC
(
	MAKV nvarchar(50) primary key,
	TENKV nvarchar(50),
)
create table TINH
(
	MAKVC nvarchar(50) primary key,
	TENKVC nvarchar(50),
	MAKV nvarchar(50),
	constraint fk_TINH_MAKV foreign key (MAKV) references KHUVUC(MAKV)
)
create table CHINHANH
(
	MACN nvarchar(50) primary key,
	TENCN nvarchar(50),
)
create table NHANVIEN
(
	MANV nvarchar(50) primary key,
	TENNV nvarchar(50),
	GIOITINH nvarchar(50),
	DIACHI nvarchar(50),
	SDT nvarchar(50),
	MACN nvarchar(50),
	constraint fk_NHANVIEN_MACN foreign key (MACN) references CHINHANH(MACN)
)
create table NHAPP
(
	MANPP nvarchar(50) primary key,
	TENNPP nvarchar(50),
)
create table KHACHHANG
(
	MAKHACH nvarchar(50) primary key,
	TENKHACH nvarchar(50),
	GIOITINH nvarchar(50),
	TUOI nvarchar(50),
	NGAYSINH nvarchar(50),
	NGHENGHIEP nvarchar(50),
	SDT nvarchar(50),
)
create table DONDATHANG
(
	MADDH nvarchar(50) primary key,
	MAKHACH nvarchar(50),
	MANPP nvarchar(50),
	NGAY date,
	SOTIENHD int,
	NPP6PT float,
	SOTHANHTOAN float,
	constraint fk_DONDATHANG_MAKHACH foreign key (MAKHACH) references KHACHHANG(MAKHACH),
	constraint fk_DONDATHANG_MANPP foreign key (MANPP) references NHAPP(MANPP),	
)
create table CTDONDATHANG
(
	MADDH nvarchar(50),
	MASP nvarchar(50),
	SOLUONG int,
	constraint pk_ctddh primary key(MADDH,MASP),
	constraint fk_DATHANG_MASP foreign key (MASP) references SANPHAM(MASP),
	CONSTRAINT fk01_CTHD FOREIGN KEY(MADDH) REFERENCES DONDATHANG(MADDH)
)
create table XUATHANG
(
	MAXH nvarchar(50) primary key,
	MANV nvarchar(50),
	NGAY date,
	DOANHTHU float,
	constraint fk_XUATHANG_MANV foreign key (MANV) references NHANVIEN(MANV)
)
create table CTXUATHANG
(
	MAXH nvarchar(50),
	MASP nvarchar(50),
	SOLUONG int,
	TRONGLUONG int,
	GIABAN int,
	MAKVC nvarchar(50),
	constraint pk_ctxh primary key(MAXH,MASP),
	constraint fk_XUATHANG_MAKVC foreign key (MAKVC) references TINH(MAKVC),
	constraint fk_XUATHANG_MAXH foreign key (MAXH) references XUATHANG(MAXH),
	constraint fk_XUATHANG_MASP foreign key (MASP) references SANPHAM(MASP),
)
create table ACCOUNT
(
	TenDangNhap varchar(30),
	MatKhau varchar(30),
	MANV nvarchar(50),
	SDT varchar(30),
	EMAIL varchar(50),
	ChucVu nvarchar(30),
	Quyen int,
	primary key(TenDangNhap,MANV),
	constraint fk_ACCOUNT_MANV foreign key (MANV) references NHANVIEN(MANV),
)
insert into ACCOUNT
values
('quan','123456','NV01','123456789','lenedq@gmail.com','Nhân viên',1),
('khanh','123456','NV02','123456789','lenedq@gmail.com','Nhân viên',1),
('quang','123456','NV03','123456789','lenedq@gmail.com','Nhân viên',1),
('Admin','1','ADMIN','123456789','leenedq7@gmail.com','Quản Lý',0)

create proc suaaccount
@tendn varchar(30),
@matkhau varchar(30),
@manv varchar(30),
@sdt varchar(30),
@Email varchar(50),
@chucvu nvarchar(30),
@quyen int
as
begin
	update ACCOUNT set MatKhau=@matkhau,MANV=@manv,SDT=@sdt,EMAIL=@Email,ChucVu=@chucvu,Quyen=@quyen where TenDangNhap=@tendn
end
return
exec suaaccount @tendn,@matkhau,@manv,@sdt,@Email,@chucvu,@quyen

create proc quenmk
@matkhau varchar(30),
@Email varchar(50)
as
	if(exists(select * from ACCOUNT where EMAIL=@Email ))
	begin		
		update ACCOUNT set MatKhau=@matkhau,EMAIL=@Email where EMAIL=@Email	
	end
	else
	begin
		raiserror('Email không có trong dữ liệu công ty, vui lòng kiểm tra lại Email',16,1)
	end
return
exec quenmk @matkhau='1',@Email='leenedq7896@gmail.com'




create proc xoaaccount
@tendn varchar(30)
as
begin
	delete from ACCOUNT where TenDangNhap = @tendn
end


create proc themaccount
@tendn varchar(30),
@matkhau varchar(30),
@manv varchar(30),
@sdt varchar(30),
@Email varchar(50),
@chucvu nvarchar(30),
@quyen int
as
begin
	if(exists(select * from ACCOUNT where TenDangNhap=@tendn and MANV=@manv ))
	begin
		raiserror('Mã nhân viên đã trùng',16,1)		
	end
	else
	begin
		insert into ACCOUNT values(@tendn,@matkhau,@manv,@sdt,@Email,@chucvu,@quyen)
	end
end