create database QL_KEODUA_WEB
go
USE [QL_KEODUA_WEB]
GO
/****** Object:  Table [dbo].[CTDONHANG]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDONHANG](
	[MAHD] [int] NOT NULL,
	[MASP] [nvarchar](50) NOT NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [int] NULL,
 CONSTRAINT [PK_CTDONHANG] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTSANPHAM]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTSANPHAM](
	[MASP] [nvarchar](50) NOT NULL,
	[SOLUONG] [int] NULL,
	[ANH] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MAHD] [int] NOT NULL,
	[NGAYBAN] [date] NULL,
	[MAKHACH] [int] NULL,
	[THANHTOAN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKHACH] [int] IDENTITY(1,1) NOT NULL,
	[TENKHACH] [nvarchar](100) NULL,
	[GIOITINH] [nvarchar](100) NULL,
	[TUOI] [nvarchar](100) NULL,
	[NGAYSINH] [nvarchar](100) NULL,
	[NGHENGHIEP] [nvarchar](100) NULL,
	[SDT] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAKHACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISP]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISP](
	[MALOAISP] [nvarchar](50) NOT NULL,
	[TENLOAISP] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAISP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [nvarchar](50) NOT NULL,
	[TENSP] [nvarchar](50) NULL,
	[MALOAISP] [nvarchar](50) NULL,
	[TRONGLUONG] [nvarchar](50) NULL,
	[QUYCACH] [nvarchar](50) NULL,
	[KHUYENMAI] [nvarchar](50) NULL,
	[GIABAN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAITIN]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAITIN](
	[MALOAI] [nvarchar](50) NOT NULL,
	[TENLOAI] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TINTUC]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINTUC](
	[MATIN] [nvarchar](50) NOT NULL,
	[MALOAI] [nvarchar](50) NULL,
	[TIEUDETIN] [nvarchar](max) NULL,
	[NOIDUNG] [nvarchar](max) NULL,
	[NGAYDANGTIN] [date] NULL,
	[ANH] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MATIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/14/2021 6:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C3', 100, N'keo-chuoi-tuoi-goi.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C4', 100, N'keo-chuoi-tuoi-goi.jfif')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C5', 100, N'keo-chuoi-dau-muoi-me-tui.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C6', 100, N'keo-chuoi-dau-muoi-me-tui.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C7', 100, N'keo-chuoi-thanh-binh-tuoi.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C8', 100, N'keo-chuoi-dau-muoi-me-tui.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'C9', 100, N'keo-chuoi-cuon-banh-trang-dau-me.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H1', 100, N'keo-deo-dua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H10', 100, N'keo-deo-dua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H11', 100, N'keo-dua-sau-rieng-dau-phong.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H12', 100, N'keo-dua-dua-sua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H13', 100, N'keo-dua-soc-ca-cao.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H14', 100, N'keo-dua-beo.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H15', 100, N'keo-dua-sua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H16', 100, N'keo-dua-sau-rieng-dau-phong.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H17', 100, N'keo-dua-dua-sua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H18', 100, N'keo-dua-soc-ca-cao.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H19', 100, N'keo-dua-beo.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H20', 100, N'keo-dua-thap-cam.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H21', 100, N'keo-dua-sau-rieng-dau-phong.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H22', 100, N'keo-deo-dua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H23', 100, N'keo-dua-deo-dau-phong-beo.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H24', 100, N'keo-deo-la-dua.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H25', 100, N'keo-deo-dua-mon.jfif')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H26', 100, N'keo-deo-thap-cam.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H3', 100, N'keo-sua-dua-la-dua.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H4', 100, N'keo-dua-sau-rieng-dau-phong-hop-may.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H5', 100, N'keo-dua-beo.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H6', 100, N'keo-dua-sau-rieng-dau-phong.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H7', 100, N'keo-dua-sua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H8', 100, N'keo-dua-dau-phong-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'H9', 100, N'keo-dua-dua-sua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'N2', 100, N'nuoc-mau-dua.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'P1', 100, N'banh-phong-sua-ben-tre.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'P3', 100, N'banh-phong-sua-sau-rieng.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'QT16', 100, N'Hop-qua-tet.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'T1', 100, N'keotonghop2.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'T2', 100, N'keotonghop1.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'T3', 100, N'keotonghop.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'V1', 100, N'keo-dua-sau-rieng.png')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'V2', 100, N'keo-dua-la-dua.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'V3', 100, N'keo-dua-soc-ca-cao.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'V4', 100, N'keo-dua-gung.jpg')
INSERT [dbo].[CTSANPHAM] ([MASP], [SOLUONG], [ANH]) VALUES (N'V5', 100, N'keo-dua-ben-tre.jpeg')
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MAKHACH], [TENKHACH], [GIOITINH], [TUOI], [NGAYSINH], [NGHENGHIEP], [SDT]) VALUES (8, N'Quan123', N'nam', N'20', N'3/11/2000', N'Sinh Viên', N'03333333333')
INSERT [dbo].[KHACHHANG] ([MAKHACH], [TENKHACH], [GIOITINH], [TUOI], [NGAYSINH], [NGHENGHIEP], [SDT]) VALUES (9, N'Khanh', N'nam', N'20', N'3/11/2000', N'Sinh Viên', N'02222222222')
INSERT [dbo].[KHACHHANG] ([MAKHACH], [TENKHACH], [GIOITINH], [TUOI], [NGAYSINH], [NGHENGHIEP], [SDT]) VALUES (10, N'Quang', N'nam', N'20', N'3/11/2000', N'Sinh Viên', N'0111111111111')
INSERT [dbo].[KHACHHANG] ([MAKHACH], [TENKHACH], [GIOITINH], [TUOI], [NGAYSINH], [NGHENGHIEP], [SDT]) VALUES (11, N'khachhang123456', N'nam', N'20', N'21/11/2021', N'sinh viên', N'0123456789')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL01', N'KẸO DỪA HỘP')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL02', N'HỘP KẸO DỪA MÁY')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL03', N'HỘP KẸO DỪA DẺO')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL04', N'KẸO DỪA BAO BÌ')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL05', N'KẸO DỪA MÁY')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL06', N'KẸO DỪA DẺO')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL07', N'KẸO CHUỐI')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL08', N'BÁNH - KẸO TỔNG HỢP')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL09', N'KẸO DỪA BAO BÌ VIÊN NHỎ')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'MAL10', N'KẸO DỪA THANH')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'ML0011111', N'LOAIKEODUAABC')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'ML00123456789', N'KẸO MÚT ABC')
INSERT [dbo].[LOAISP] ([MALOAISP], [TENLOAISP]) VALUES (N'ML0311', N'Keo ABCD')
GO
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C3', N'Kẹo chuối tươi (gói)', N'MAL07', N'400gr', N'50 gói/thùng', N'25túi tặng 1 túi cùng loại', 24500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C4', N'Kẹo chuối tươi (túi)', N'MAL07', N'200gr', N'60 túi/thùng', N'30 kg tặng 1kg cùng loại', 15900)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C5', N'Kẹo chuối đậu - mè', N'MAL07', N'1 kg', N'10kg/thùng', N'30 kg tặng 1kg cùng loại', 77000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C6', N'Kẹo chuối đậu - mè (túi)', N'MAL07', N'200gr', N'60 túi/thùng', N'30 kg tặng 1kg cùng loại', 18500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C7', N'Kẹo chuối tươi (túi)', N'MAL07', N'500gr', N'30 túi/thùng', N'10 túi tặng 1 túi cùng loại', 37700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C8', N'Kẹo chuối đậu - mè (túi)', N'MAL07', N'500gr', N'30 túi/thùng', N'10 túi tặng 1 túi cùng loại', 43000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'C9', N'Kẹo chuối cuộn bánh tráng đậu mè', N'MAL07', N'450gr', N'30 túi/thùng', N'30túi tặng 1 túi cùng loại', 37700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'đasa', N'áđá', N'MAL01', N'ađâsd', N'áđấ', N'sđá', 21312312)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H1', N'Kẹo dừa sữa sầu riêng', N'MAL01', N'300gr', N'50 hộp/thùng', N'25hộp tặng 1 hộp cùng loại', 23300)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H10', N'Kẹo dừa sầu riêng', N'MAL02', N'400gr', N'25 hộp/thùng', N'50hộp tặng 1 hộp cùng loại', 36700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H11', N'Kẹo dừa sầu riêng / đậu phộng', N'MAL02', N'400gr', N'25 hộp/thùng', N'50hộp tặng 1 hộp cùng loại', 36700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H12', N'Kẹo dừa sầu riêng / lá dứa', N'MAL02', N'400gr', N'25 hộp/thùng', N'50hộp tặng 1 hộp cùng loại', 36700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H13', N'Kẹo dừa sữa ca cao', N'MAL02', N'400gr', N'25 hộp/thùng', N'10hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H14', N'Kẹo dừa  béo', N'MAL02', N'400gr', N'25 hộp/thùng', N'10hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H15', N'Kẹo dừa sầu riêng', N'MAL02', N'450gr', N'20 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H16', N'Kẹo dừa sầu riêng / đậu phộng', N'MAL02', N'450gr', N'20 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H17', N'Kẹo dừa sầu riêng / lá dứa', N'MAL02', N'450gr', N'20 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H18', N'Kẹo dừa sữa ca cao', N'MAL02', N'450gr', N'20 hộp/thùng', N'10hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H19', N'Kẹo dừa  béo', N'MAL02', N'450gr', N'20 hộp/thùng', N'10hộp tặng 1 hộp cùng loại', 35000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H20', N'Kẹo dừa thập cẩm viên lớn', N'MAL02', N'540gr', N'20 hộp/thùng', N'10hộp tặng 1 hộp cùng loại', 46500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H21', N'Kẹo dừa sữa đậu phộng', N'MAL01', N'300gr', N'50 hộp/thùng', N'25hộp tặng 1 hộp cùng loại', 23300)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H22', N'Kẹo dừa dẻo sầu riêng', N'MAL03', N'250gr', N'40 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 26800)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H23', N'Kẹo dừa dẻo đậu phộng - béo', N'MAL03', N'250gr', N'40 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 26800)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H24', N'Kẹo dừa dẻo lá dứa', N'MAL03', N'250gr', N'40 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 26400)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H25', N'Kẹo dừa dẻo môn', N'MAL03', N'250gr', N'40 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 26400)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H26', N'Kẹo dẻo thập cẩm', N'MAL03', N'250gr', N'40 hộp/thùng', N'50hộp tặng 1 hộp cùng loại', 26400)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H3', N'Kẹo dừa sữa lá dứa', N'MAL01', N'300gr', N'50 hộp/thùng', N'50hộp tặng 1 hộp cùng loại', 23300)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H4', N'Kẹo dừa sữa sầu riêng/ đậu phộng', N'MAL01', N'300gr', N'50 hộp/thùng', N'25hộp tặng 1 hộp cùng loại', 23300)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H5', N'Kẹo dừa béo', N'MAL01', N'400gr', N'40 hộp/thùng', N'10 hộp tặng 1 hộp cùng loại', 28500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H6', N'Kẹo dừa sữa sầu riêng/ đậu phộng', N'MAL01', N'400gr', N'40 hộp/thùng', N'50 hộp tặng 1 hộp cùng loại', 30600)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H7', N'Kẹo dừa sữa sầu riêng', N'MAL01', N'500gr', N'40 hộp/thùng', N'40 hộp tặng 1 hộp cùng loại', 37000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H8', N'Kẹo dừa sữa sầu riêng/ đậu phộng', N'MAL01', N'500gr', N'40 hộp/thùng', N'50 hộp tặng 1 hộp cùng loại', 37000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'H9', N'Kẹo dừa sữa sầu riêng/ lá dứa', N'MAL01', N'500gr', N'40 hộp/thùng', N'40hộp tặng 1 hộp cùng loại', 37000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'N2', N'Nước màu dừa (chai nhỏ)', N'MAL08', N'250gr', N'60 túi/thùng', N'60túi tặng 1 túi cùng loại', 53000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'P1', N'Bánh phồng sữa', N'MAL08', N'350gr', N'60 túi/thùng', N'30túi tặng 1 túi cùng loại', 25600)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'P3', N'Bánh phồng sữa - sầu riêng (đặc biệt)', N'MAL08', N'450gr', N'50 túi/thùng', N'25túi tặng 1 túi cùng loại', 30700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'QT16', N'HỘP QUÀ TẾT', N'MAL08', N'300gr', N'60 túi/thùng', N'60túi tặng 1 túi cùng loại', 49000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'T1', N'Kẹo tổng hợp (xá)', N'MAL08', N'1 kg', N'60 túi/thùng', N'30túi tặng 1 túi cùng loại', 84700)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'T2', N'Kẹo tổng hợp (túi)', N'MAL08', N'200gr', N'60 túi/thùng', N'30túi tặng 1 túi cùng loại', 18200)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'T3', N'Kẹo tổng hợp (túi)', N'MAL08', N'500gr', N'60 túi/thùng', N'60 túi tặng 1 túi cùng loại', 42900)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'V1', N'Kẹo dừa sầu riêng - túi 3 thanh ', N'MAL10', N'142,5gr', N'60 túi', N'10 túi tặng 1 túi cùng loại', 18500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'V2', N'Kẹo dừa lá dứa - túi 3 thanh', N'MAL10', N'142,5gr', N'60 túi', N'30 túi tặng 1 túi cùng loại', 18500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'V3', N'Kẹo dừa ca cao - túi 3 thanh', N'MAL10', N'142,5gr', N'60 túi', N'30 túi tặng 1 túi cùng loại', 18500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'V4', N'Kẹo dừa gừng -  túi 3 thanh', N'MAL10', N'142,5gr', N'60 túi', N'10 túi tặng 1 túi cùng loại', 18500)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [MALOAISP], [TRONGLUONG], [QUYCACH], [KHUYENMAI], [GIABAN]) VALUES (N'V5', N'Kẹo dừa béo -  túi 3 thanh', N'MAL10', N'142,5gr', N'60 túi', N'10 túi tặng 1 túi cùng loại', 18500)
GO
INSERT [dbo].[THELOAITIN] ([MALOAI], [TENLOAI]) VALUES (N'LT01', N'TIN TỨC TUẦN')
INSERT [dbo].[THELOAITIN] ([MALOAI], [TENLOAI]) VALUES (N'LT02', N'TIN TỨC THÁNG')
INSERT [dbo].[THELOAITIN] ([MALOAI], [TENLOAI]) VALUES (N'LT03', N'NGHIÊN CỨU')
INSERT [dbo].[THELOAITIN] ([MALOAI], [TENLOAI]) VALUES (N'LT04', N'KHÁC')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([idUser], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'HoangQuan', N'quan', N'quan@gmail', N'1')
INSERT [dbo].[Users] ([idUser], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'HoangQuan2', N'quan2', N'quan2@gmail', N'2')
INSERT [dbo].[Users] ([idUser], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'quan123', N'Quan123', N'quan123@gmail.com', N'e10adc3949ba59abbe56e057f20f883e')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CTDONHANG]  WITH CHECK ADD  CONSTRAINT [fk_CTDONHANG] FOREIGN KEY([MAHD])
REFERENCES [dbo].[DONHANG] ([MAHD])
GO
ALTER TABLE [dbo].[CTDONHANG] CHECK CONSTRAINT [fk_CTDONHANG]
GO
ALTER TABLE [dbo].[CTDONHANG]  WITH CHECK ADD  CONSTRAINT [fk_CTDONHANG_MASP] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CTDONHANG] CHECK CONSTRAINT [fk_CTDONHANG_MASP]
GO
ALTER TABLE [dbo].[CTSANPHAM]  WITH CHECK ADD  CONSTRAINT [fk_SP_CTSP] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CTSANPHAM] CHECK CONSTRAINT [fk_SP_CTSP]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [fk_DONHANG_MAKHACH] FOREIGN KEY([MAKHACH])
REFERENCES [dbo].[KHACHHANG] ([MAKHACH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [fk_DONHANG_MAKHACH]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [fk_SP_MLSP] FOREIGN KEY([MALOAISP])
REFERENCES [dbo].[LOAISP] ([MALOAISP])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [fk_SP_MLSP]
GO
ALTER TABLE [dbo].[TINTUC]  WITH CHECK ADD  CONSTRAINT [fk_TINTUC_LOAITIN] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[THELOAITIN] ([MALOAI])
GO
ALTER TABLE [dbo].[TINTUC] CHECK CONSTRAINT [fk_TINTUC_LOAITIN]
GO
