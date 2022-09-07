
use master
go
if exists (select name from sysdatabases where name = 'QLTourDuLich')
drop database QLTourDuLich
go
create database QLTourDuLich
go
use QLTourDuLich
go
select * from KHACHSAN where concat(maKS,tenKS,diaChi,sDT) like '%0958583981%'

-- TABLE ============================================================================================================
create table DIACHI
(
	maTinh varchar (10) not null primary key,
	tenTinh nvarchar (100)
)

create table QUYEN 
(
	maQuyen int not null primary key,
	tenQuyen nvarchar (100)
)

create table TAIKHOAN
(
	userName varchar (100) not null primary key,
	pass varchar (100),
	maQuyen int not null,
	constraint fk_TK_Q foreign key (maQuyen) references QUYEN (maQuyen) 
)

create table KHACHHANG
(
	email varchar (100) not null primary key,
	tenKH nvarchar (100),
	diaChi varchar (10) not null,
	gioiTinh nvarchar (3),
	ngaySinh date,
	sDT varchar (10),
	constraint fk_KH_DC foreign key (diaChi) references DIACHI (maTinh),
	constraint fk_KH_TK foreign key (email) references TAIKHOAN (userName)
)

create table CHUCVU
(
	maCV varchar (10) not null primary key,
	tenCV nvarchar (100)
)

create table NHANVIEN
(
	maNV varchar (100) not null primary key,
	tenNV nvarchar (100),
	maCV varchar (10) not null,
	email varchar (100),
	diaChi varchar (10) not null,
	gioiTinh nvarchar (3),
	ngaySinh date,
	sDT varchar (10),
	constraint fk_NV_DC foreign key (diaChi) references DIACHI (maTinh),
	constraint fk_NV_CV foreign key (maCV) references CHUCVU (maCV),
	constraint fk_NV_TK foreign key (maNV) references TAIKHOAN (userName)
)

create table DDTHAMQUAN
(
	maDD varchar (10) not null primary key,
	tenDD nvarchar (100),
	diaChi varchar (10) not null,
	constraint fk_DDTQ_DC foreign key (diaChi) references DIACHI (maTinh)
)

create table TOUR
(
	maTour varchar (10) not null primary key,
	tenTour nvarchar (100),
)

create table CT_TOUR
(
	maTour varchar (10) not null,
	maDD varchar (10) not null,
	diaChi varchar (10) not null,
	primary key (maTour, maDD),
	constraint fk_CTT_TOUR foreign key (maTour) references TOUR (maTour),
	constraint fk_CTT_DC foreign key (diaChi) references DIACHI (maTinh),
	constraint fk_CTT_DDTQ foreign key (maDD) references DDTHAMQUAN (maDD)
)
create table DAILY
(
	maDL varchar (10) not null primary key,
	tenDL nvarchar (100),
	diaChi varchar (10) not null,
	sDT varchar (10),
	maNV varchar (100) not null,
	constraint fk_DL_DC foreign key (diaChi) references DIACHI (maTinh),
	constraint fk_DL_NV foreign key (maNV) references NHANVIEN (maNV)
)

create table KHACHSAN
(
	maKS varchar (10) not null primary key,
	tenKS nvarchar (100),
	diaChi varchar (10) not null,
	sDT varchar (10),
	constraint fk_KS_DC foreign key (diaChi) references DIACHI (maTinh)
)

create table PHUONGTIEN
(
	maPT varchar (10) not null primary key,
	tenPT nvarchar (100),
	hienTrang int		-- 1: Xe đã được đặt; 0: Xe hiện đang trống
)

create table VE
(
	maVe varchar (10) not null primary key,
	maTour varchar (10) not null,
	maDL varchar (10) not null,
	maKS varchar (10) not null,
	maPT varchar (10) not null,
	gia money,
	ngayBD date,
	ngayKT date,
	constraint fk_V_T foreign key (maTour) references TOUR (maTour),
	constraint fk_V_DL foreign key (maDL) references DAILY (maDL),
	constraint fk_V_KS foreign key (maKS) references KHACHSAN (maKS),
	constraint fk_V_PT foreign key (maPT) references PHUONGTIEN (maPT)
)

create table HOADON
(
	maHD varchar (10) not null primary key,
	ngayLap date,
	email varchar (100) not null,
	constraint fk_HD_KH foreign key (email) references KHACHHANG (email)
)

create table CT_HOADON
(
	maHD varchar (10) not null,
	maVe varchar (10) not null,
	sLVe int,
	thanhTien money,
	primary key (maHD, maVe),
	constraint fk_CTHD_HD foreign key (maHD) references HOADON (maHD),
	constraint fk_CTHD_V foreign key (maVe) references VE (maVe)
)


-- DATA =============================================================================================================
insert into DIACHI values ('AG', N'An Giang');
insert into DIACHI values ('BRVT', N'Bà rịa - Vũng tàu');
insert into DIACHI values ('BG', N'Bắc Giang');
insert into DIACHI values ('BK', N'Bắc Kạn');
insert into DIACHI values ('BL', N'Bạc Liêu');
insert into DIACHI values ('BN', N'Bắc Ninh');
insert into DIACHI values ('BTre', N'Bến Tre');
insert into DIACHI values ('BDinh', N'Bình Định');
insert into DIACHI values ('BDuong', N'Bình Dương');
insert into DIACHI values ('BP', N'Bình Phước');
insert into DIACHI values ('BThuan', N'Bình Thuận');
insert into DIACHI values ('CM', N'Cà Mau');
insert into DIACHI values ('CT', N'Cần Thơ');
insert into DIACHI values ('CB', N'Cao Bằng');
insert into DIACHI values ('DN', N'Đà Nẵng');
insert into DIACHI values ('DL', N'Đắk Lắk');
insert into DIACHI values ('DNong', N'Đắk Nông');
insert into DIACHI values ('DB', N'Điện Biên');
insert into DIACHI values ('DNai', N'Đồng Nai');
insert into DIACHI values ('DT', N'Đồng Tháp');
insert into DIACHI values ('GL', N'Gia Lai');
insert into DIACHI values ('HaG', N'Hà Giang');
insert into DIACHI values ('HNam', N'Hà Nam');
insert into DIACHI values ('HNoi', N'Hà Nội');
insert into DIACHI values ('HT', N'Hà Tĩnh');
insert into DIACHI values ('HD', N'Hải Dương');
insert into DIACHI values ('HP', N'Hải Phòng');
insert into DIACHI values ('HauG', N'Hậu Giang');
insert into DIACHI values ('HB', N'Hòa Bình');
insert into DIACHI values ('HY', N'Hưng Yên');
insert into DIACHI values ('KH', N'Khánh Hòa');
insert into DIACHI values ('KG', N'Kiên Giang');
insert into DIACHI values ('KT', N'Kon Tum');
insert into DIACHI values ('LChau', N'Lai Châu');
insert into DIACHI values ('LD', N'Lâm Đồng');
insert into DIACHI values ('LSon', N'Lạng Sơn');
insert into DIACHI values ('LCai', N'Lào Cai');
insert into DIACHI values ('LA', N'Long An');
insert into DIACHI values ('ND', N'Nam Định');
insert into DIACHI values ('NA', N'Nghệ An');
insert into DIACHI values ('NB', N'Ninh Bình');
insert into DIACHI values ('NT', N'Ninh Thuận');
insert into DIACHI values ('PT', N'Phú Thọ');
insert into DIACHI values ('PY', N'Phú Yên');
insert into DIACHI values ('QB', N'Quảng Bình');
insert into DIACHI values ('QNam', N'Quảng Nam');
insert into DIACHI values ('QNgai', N'Quảng Ngãi');
insert into DIACHI values ('QN', N'Quảng Ninh');
insert into DIACHI values ('QT', N'Quảng Trị');
insert into DIACHI values ('ST', N'Sóc Trăng');
insert into DIACHI values ('SL', N'Sơn La');
insert into DIACHI values ('TNinh', N'Tây Ninh');
insert into DIACHI values ('TB', N'Thái Bình');
insert into DIACHI values ('TNguyen', N'Thái Nguyên');
insert into DIACHI values ('TH', N'Thanh Hóa');
insert into DIACHI values ('TTH', N'Thừa Thiên Huế');
insert into DIACHI values ('TG', N'Tiền Giang');
insert into DIACHI values ('HCM', N'TP. Hồ Chí Minh');
insert into DIACHI values ('TV', N'Trà Vinh');
insert into DIACHI values ('TQ', N'Tuyên Quang');
insert into DIACHI values ('VL', N'Vĩnh Long');
insert into DIACHI values ('VP', N'Vĩnh Phúc');
insert into DIACHI values ('YB', N'Yên Bái');
select * from DIACHI

insert into QUYEN values (1, N'Quản lý')
insert into QUYEN values (2, N'Nhân viên')
insert into QUYEN values (3, N'Khách hàng')
select * from QUYEN

insert into TAIKHOAN values ('baokk123@gmail.com', '123', 3)
insert into TAIKHOAN values ('nlgb2001@gmail.com', '123', 3)
insert into TAIKHOAN values ('cr7@gmail.com', '123', 3)
insert into TAIKHOAN values ('dhd@gmail.com', '123', 3)
insert into TAIKHOAN values ('ntl@gmail.com', '123', 3)
insert into TAIKHOAN values ('hn@gmail.com', '123', 3)
insert into TAIKHOAN values ('mixigm@gmail.com', '123', 3)
insert into TAIKHOAN values ('pgd@gmail.com', '123', 3)
insert into TAIKHOAN values ('npt@gmail.com', '123', 3)
insert into TAIKHOAN values ('bhva@gmail.com', '123', 3)
insert into TAIKHOAN values ('NV001', '123', 2)
insert into TAIKHOAN values ('NV002', '123', 1)
insert into TAIKHOAN values ('NV003', '123', 2)
insert into TAIKHOAN values ('NV004', '123', 2)
insert into TAIKHOAN values ('NV005', '123', 1)
insert into TAIKHOAN values ('NV006', '123', 2)
insert into TAIKHOAN values ('NV007', '123', 2)
insert into TAIKHOAN values ('NV008', '123', 1)
insert into TAIKHOAN values ('NV009', '123', 2)
select * from TAIKHOAN

set dateformat dmy
insert into KHACHHANG values ('baokk123@gmail.com', N'Phạm Gia Bảo', 'TNinh', 'Nam', '14/02/2001', '0958395893')
insert into KHACHHANG values ('nlgb2001@gmail.com', N'Nguyễn Lê Gia Bảo', 'HCM', 'Nam', '20/06/2001', '0193859893')
insert into KHACHHANG values ('cr7@gmail.com', 'Cristiano Ronaldo', 'HCM', 'Nam', '15/09/1985', '0777777777')
insert into KHACHHANG values ('dhd@gmail.com', N'Đỗ Hùng Dũng', 'HNoi', 'Nam', '14/11/1996', '0198898931')
insert into KHACHHANG values ('ntl@gmail.com', N'Nguyễn Tiến Linh', 'BDuong', 'Nam', '14/12/1998', '0198593829')
insert into KHACHHANG values ('hn@gmail.com', N'Huỳnh Như', 'HCM', N'Nữ', '14/02/1991', '0128989892')
insert into KHACHHANG values ('mixigm@gmail.com', N'Phùng Thanh Độ', 'CB', 'Nam', '12/09/1989', '0198593891')
insert into KHACHHANG values ('pgd@gmail.com', N'Phạm Gia Đạt', 'HCM', 'Nam', '14/05/2001', '0198989201')
insert into KHACHHANG values ('npt@gmail.com', N'Nguyễn Phước Tâm', 'GL', 'Nam', '14/11/2001', '0198583929')
insert into KHACHHANG values ('bhva@gmail.com', N'Bùi Hoàng Việt Anh', 'HCM', 'Nam', '19/12/1999', '0198593891')
select * from KHACHHANG

insert into CHUCVU values ('GD', N'Giám đốc')
insert into CHUCVU values ('NV', N'Nhân viên')
insert into CHUCVU values ('TX', N'Tài xế')
insert into CHUCVU values ('NVQL', N'Nhân viên quản lý')
select * from CHUCVU

set dateformat dmy
insert into NHANVIEN values ('NV001', N'Lê Bữu Điền', 'TX', 'lbd@gmail.com', 'BTre', 'Nam', '11/09/2001', '0295938929')
insert into NHANVIEN values ('NV002', N'Nguyễn Thanh Tùng', 'GD', 'ntt@gmail.com', 'TB', 'Nam', '11/09/1998', '0198395892')
insert into NHANVIEN values ('NV003', N'Bành Thị Hà', 'NV', 'bth@gmail.com', 'HCM', N'Nữ', '15/11/2001', '0958395892')
insert into NHANVIEN values ('NV004', N'Lâm Đình Khoa', 'TX', 'ldk@gmail.com', 'DT', 'Nam', '11/11/1997', '0189593819')
insert into NHANVIEN values ('NV005', N'Phùng Tùng Anh', 'GD', 'pta@gmail.com', 'CB', 'Nam', '12/09/1989', '0958398929')
insert into NHANVIEN values ('NV006', N'Trang Mixi', 'NV', 'tmx@gmail.com', 'HNoi', N'Nữ', '11/09/1997', '0198593891')
insert into NHANVIEN values ('NV007', N'Nghiêm Minh Hiếu', 'NVQL', 'nmh@gmail.com', 'HNoi', 'Nam', '11/09/1989', '0198593891')
insert into NHANVIEN values ('NV008', N'Hoàng Văn Khoa', 'GD', 'hvk@gmail.com', 'HP', 'Nam', '15/11/1990', '0938593892')
insert into NHANVIEN values ('NV009', N'Nguyễn Văn Thuận', 'NV', 'nvt@gmail.com', 'LA', 'Nam', '11/12/1997', '0198593892')
select * from NHANVIEN

insert into DDTHAMQUAN values ('DDDLPQ', N'Địa điểm du lịch Phú Quốc', 'KG')
insert into DDTHAMQUAN values ('DDDLNT', N'Địa điểm du lịch Nha Trang', 'KH')
insert into DDTHAMQUAN values ('DDDLHA', N'Địa điểm du lịch Hội An', 'QNam')
insert into DDTHAMQUAN values ('DDDLDL', N'Địa điểm du lịch Đà Lạt', 'LD')
insert into DDTHAMQUAN values ('DDDLDN', N'Địa điểm du lịch Đà Nẵng', 'DN')
insert into DDTHAMQUAN values ('DDDLHL', N'Địa điểm du lịch Hạ Long', 'QN')
insert into DDTHAMQUAN values ('DDDLSG', N'Địa điểm du lịch Sài Gòn', 'HCM')
select * from DDTHAMQUAN

insert into TOUR values ('TSG', N'Tour du lịch Sài Gòn')
insert into TOUR values ('TDL', N'Tour du lịch Đà Lạt')
insert into TOUR values ('THA', N'Tour du lịch Hội An')
insert into TOUR values ('THL', N'Tour du lịch Hạ Long')
insert into TOUR values ('TPQ', N'Tour du lịch PHú Quốc')
insert into TOUR values ('TDN', N'Tour du lịch Đà Nẵng')
insert into TOUR values ('TNT', N'Tour du lịch Nha Trang')
select * from TOUR

insert into CT_TOUR values ('TSG', 'DDDLSG', 'HCM')
insert into CT_TOUR values ('TDL', 'DDDLDL', 'LD')
insert into CT_TOUR values ('THA', 'DDDLHA', 'QNam')
insert into CT_TOUR values ('THL', 'DDDLHL', 'QN')
insert into CT_TOUR values ('TPQ', 'DDDLPQ', 'KG')
insert into CT_TOUR values ('TDN', 'DDDLDN', 'DN')
insert into CT_TOUR values ('TNT', 'DDDLNT', 'KH')
select * from CT_TOUR

insert into DAILY values ('SGT1', N'Saigontourist 1', 'HCM', '0198593892', 'NV002')
insert into DAILY values ('SGT2', N'Saigontourist 2', 'DN', '0958395892', 'NV005')
insert into DAILY values ('SGT3', N'Saigontourist 3', 'HNoi', '0195839589', 'NV008')
select * from DAILY

insert into KHACHSAN values ('RRHS', 'Renaissance Riverside Hotel Saigon', 'HCM', '0958583981')
insert into KHACHSAN values ('VLNT', 'Vinpearl Luxury Nha Trang', 'KH', '0185938593')
insert into KHACHSAN values ('SRPQI', 'Salinda Resort Phu Quoc Island', 'KG', '0195839589')
insert into KHACHSAN values ('AHA', N'Almanity Hội An ', 'QNam', '0787583782')
insert into KHACHSAN values ('MS', 'Majestic Saigon', 'HCM', '0198583958')
select * from KHACHSAN

insert into PHUONGTIEN values ('X7C', N'Xe 7 chổ', 1)
insert into PHUONGTIEN values ('X16C', N'Xe 16 chổ', 1)
insert into PHUONGTIEN values ('X4C', N'Xe 4 chổ', 1)
insert into PHUONGTIEN values ('X45C', N'Xe 45 chổ', 1)
insert into PHUONGTIEN values ('X30C', N'Xe 7 chổ', 0)
select * from PHUONGTIEN

set dateformat dmy
insert into VE values ('V001', 'TSG', 'SGT1', 'RRHS', 'X7C', '2500000', '11/11/2021', '14/11/2021')
insert into VE values ('V002', 'TSG', 'SGT1', 'MS', 'X16C', '3500000', '11/11/2021', '14/11/2021')
insert into VE values ('V003', 'TNT', 'SGT1', 'VLNT', 'X30C', '4500000', '11/11/2021', '14/11/2021')
insert into VE values ('V004', 'TNT', 'SGT2', 'VLNT', 'X7C', '2500000', '11/11/2021', '14/11/2021')
insert into VE values ('V005', 'TNT', 'SGT2', 'VLNT', 'X30C', '4500000', '10/11/2021', '14/11/2021')
insert into VE values ('V006', 'TPQ', 'SGT3', 'SRPQI', 'X7C', '3800000', '10/11/2021', '14/11/2021')
insert into VE values ('V007', 'TPQ', 'SGT3', 'SRPQI', 'X7C', '3800000', '10/11/2021', '14/11/2021')
insert into VE values ('V008', 'TPQ', 'SGT2', 'SRPQI', 'X7C', '3800000', '10/11/2021', '14/11/2021')
insert into VE values ('V009', 'TPQ', 'SGT2', 'SRPQI', 'X7C', '3800000', '10/11/2021', '14/11/2021')
insert into VE values ('V010', 'THA', 'SGT3', 'AHA', 'X45C', '4500000', '11/11/2021', '14/11/2021')
select * from VE

set dateformat dmy
insert into HOADON values ('HD001', '11/11/2021', 'baokk123@gmail.com')
insert into HOADON values ('HD002', '11/11/2021', 'pgd@gmail.com')
insert into HOADON values ('HD003', '10/11/2021', 'cr7@gmail.com')
select * from HOADON

insert into CT_HOADON values ('HD001', 'V001', 5, '150000000')
insert into CT_HOADON values ('HD002', 'V003', 1, '4500000')
insert into CT_HOADON values ('HD003', 'V006', 2, '7600000')
select * from CT_HOADON

-- PROCEDURE ========================================================================================================
-- Thêm tài khoản vào SQL Server
--USE master
--GO
--EXEC sp_addlogin @loginame = 'tom', @passwd = 'tom123'
--GO

--USE QLTourDuLich
--GO
--EXEC sp_adduser @loginame = 'tom', @name_in_db = 'tom'
--GO

-- Thêm ____________________________________________________________________________________________________________
-- DIACHI ----------------------------------------------------------------------------------------------------------
create proc insert_DIACHI
@maTinh varchar (10),
@tenTinh nvarchar (100)
as
begin
	begin
		insert into DIACHI 
		values (@maTinh, @tenTinh)
	end
end

exec insert_DIACHI 'dd1', N'test chơi'
select * from DIACHI

-- QUYEN -----------------------------------------------------------------------------------------------------------
create proc insert_QUYEN
@maQuyen int,
@tenQuyen nvarchar (100)
as
begin
	begin
		insert into QUYEN 
		values (@maQuyen, @tenQuyen)
	end
end

exec insert_QUYEN 4, N'test chơi'
select * from QUYEN

-- TAIKHOAN --------------------------------------------------------------------------------------------------------
create proc insert_TAIKHOAN
@userName varchar (100),
@pass varchar (100),
@maQuyen int
as
begin
	begin
		insert into TAIKHOAN 
		values (@userName, @pass, @maQuyen)
	end
end

exec insert_TAIKHOAN 'gigido', 'test chơi', 4
select * from TAIKHOAN

-- KHACHHANG -------------------------------------------------------------------------------------------------------
create proc insert_KHACHHANG
@email varchar (100),
@tenKH nvarchar (100),
@diaChi varchar (10),
@gioiTinh nvarchar (3),
@ngaySinh date,
@sDT varchar (10)
as
begin
	begin
		insert into KHACHHANG 
		values (@email, @tenKH, @diaChi, @gioiTinh, @ngaySinh, @sDT)
	end
end

exec insert_KHACHHANG 'gigido', 'hihi', 'HNoi', 'Nam', '11/11/2001', '1340950395'
select * from KHACHHANG

-- CHUCVU ----------------------------------------------------------------------------------------------------------
create proc insert_CHUCVU
@maCV varchar (10),
@tenCV nvarchar (100)
as
begin
	begin
		insert into CHUCVU 
		values (@maCV, @tenCV)
	end
end

exec insert_CHUCVU 'cv003', N'test chơi'
select * from CHUCVU

-- NHANVIEN --------------------------------------------------------------------------------------------------------
create proc insert_NHANVIEN
@maNV varchar (10),
@tenNV nvarchar (100),
@maCV varchar (10),
@email varchar (100),
@diaChi varchar (10),
@gioiTinh nvarchar (3),
@ngaySinh date,
@sDT varchar (10)
as
begin
	begin
		insert into NHANVIEN 
		values (@maNV, @tenNV, @maCV, @email, @diaChi, @gioiTinh, @ngaySinh, @sDT)
	end
end

insert into TAIKHOAN values ('nvgigido', '123', 2)
exec insert_NHANVIEN 'nvgigido', 'gigido', 'TX', 'gigidodo@gmail.com', 'HNoi', 'Nam', '11/11/2001', '1059385938'
select * from NHANVIEN

-- DDTHAMQUAN ------------------------------------------------------------------------------------------------------
create proc insert_DDTHAMQUAN
@maDD varchar (10),
@tenDD nvarchar (100),
@diaChi varchar (10)
as
begin
	begin
		insert into DDTHAMQUAN 
		values (@maDD, @tenDD, @diaChi)
	end
end

exec insert_DDTHAMQUAN 'ddgigido', 'gigido', 'HNoi'
select * from DDTHAMQUAN

-- TOUR ------------------------------------------------------------------------------------------------------------
create proc insert_TOUR
@maTour varchar (10),
@tenTour nvarchar (100)
as
begin
	begin
		insert into TOUR 
		values (@maTour, @tenTour)
	end
end

exec insert_TOUR 'tourgigido', N'test chơi'
select * from TOUR

-- CT_TOUR ---------------------------------------------------------------------------------------------------------
create proc insert_CT_TOUR
@maTour varchar (10),
@maDD varchar (10),
@diaChi varchar (10)
as
begin
	begin
		insert into CT_TOUR 
		values (@maTour, @maDD, @diaChi)
	end
end

exec insert_CT_TOUR 'tourgigido', 'DDDLDL', 'LD'
select * from CT_TOUR

-- DAILY -----------------------------------------------------------------------------------------------------------
create proc insert_DAILY
@maDL varchar (10),
@tenDL nvarchar (100),
@diaChi varchar (10),
@sDT varchar (10),
@maNV varchar (10)
as
begin
	begin
		insert into DAILY 
		values (@maDL, @tenDL, @diaChi, @sDT, @maNV)
	end
end

exec insert_DAILY 'dailygigido', 'gigido', 'DN', '1239859389', 'NV002'
select * from DAILY

-- KHACHSAN --------------------------------------------------------------------------------------------------------
create proc insert_KHACHSAN
@maKS varchar (10),
@tenKS nvarchar (100),
@diaChi varchar (10),
@sDT varchar (10)
as
begin
	begin
		insert into KHACHSAN 
		values (@maKS, @tenKS, @diaChi, @sDT)
	end
end

exec insert_KHACHSAN 'ksgigido', 'gigido', 'DN', '1239859389'
select * from KHACHSAN

-- PHUONGTIEN ------------------------------------------------------------------------------------------------------
create proc insert_PHUONGTIEN
@maPT varchar (10),
@tenPT nvarchar (100),
@hienTrang int
as
begin
	begin
		insert into PHUONGTIEN 
		values (@maPT, @tenPT, @hienTrang)
	end
end

exec insert_PHUONGTIEN 'ptgigido', 'gigido', 1
select * from PHUONGTIEN

-- VE --------------------------------------------------------------------------------------------------------------
create proc insert_VE
@maVe varchar (10),
@maTour varchar (10),
@maDL varchar (10),
@maKS varchar (10),
@maPT varchar (10),
@gia money,
@ngayBD date,
@ngayKT date
as
begin
	begin
		insert into VE 
		values (@maVe, @maTour, @maDL, @maKS, @maPT, @gia, @ngayBD, @ngayKT)
	end
end

set dateformat dmy
exec insert_VE 'vegigido', 'tourgigido', 'dailygigido', 'ksgigido', 'ptgigido', '10000', '11/11/2021', '17/11/2021'
select * from VE

-- HOADON ----------------------------------------------------------------------------------------------------------
create proc insert_HOADON
@maHD varchar (10),
@ngayLap date,
@email varchar (100)
as
begin
	begin
		insert into HOADON 
		values (@maHD, @ngayLap, @email)
	end
end

exec insert_HOADON 'hdgigido', '11/11/2021', 'gigido'
select * from HOADON

-- CT_HOADON -------------------------------------------------------------------------------------------------------
create proc insert_CT_HOADON
@maHD varchar (10),
@maVe varchar (10),
@sLVe int,
@thanhTien money
as
begin
	begin
		insert into CT_HOADON 
		values (@maHD, @maVe, @sLVe, @thanhTien)
	end
end

exec insert_CT_HOADON 'hdgigido', 'vegigido', 3, '30000'
select * from CT_HOADON

-- SỬA _____________________________________________________________________________________________________________
-- DIACHI ----------------------------------------------------------------------------------------------------------
create proc update_DIACHI
@maTinh varchar (10),
@tenTinh nvarchar (100)
as
begin 
	update DIACHI
	set maTinh = @maTinh, 
		tenTinh = @tenTinh
	where maTinh = @maTinh
end

exec update_DIACHI 'dd1', N'tinhgigido'
select * from DIACHI

-- QUYEN -----------------------------------------------------------------------------------------------------------
create proc update_QUYEN
@maQuyen int,
@tenQuyen nvarchar (100)
as
begin 
	update QUYEN
	set maQuyen = @maQuyen, 
		tenQuyen = @tenQuyen
	where maQuyen = @maQuyen
end

exec update_QUYEN 4, N'quyengigido'
select * from QUYEN

-- TAIKHOAN --------------------------------------------------------------------------------------------------------
create proc update_TAIKHOAN
@userName varchar (100),
@pass varchar (100),
@maQuyen int
as
begin 
	update TAIKHOAN
	set userName = @userName, 
		pass = @pass,
		maQuyen = @maQuyen
	where userName = @userName
end

exec update_TAIKHOAN 'gigido', N'tengigido', 4
select * from TAIKHOAN

-- KHACHHANG -------------------------------------------------------------------------------------------------------
create proc update_KHACHHANG
@email varchar (100),
@tenKH nvarchar (100),
@diaChi varchar (10),
@gioiTinh nvarchar (3),
@ngaySinh date,
@sDT varchar (10)
as
begin 
	update KHACHHANG
	set email = @email, 
		tenKH = @tenKH,
		diaChi = @diaChi,
		gioiTinh = @gioiTinh,
		ngaySinh = @ngaySinh,
		sDT = @sDT
	where email = @email
end

exec update_KHACHHANG 'gigido', N'metquabanei', 'HCM', N'Nam', '11/10/2000', '0985938593'
select * from KHACHHANG

-- CHUCVU ----------------------------------------------------------------------------------------------------------
create proc update_CHUCVU
@maCV varchar (10),
@tenCV nvarchar (100)
as
begin 
	update CHUCVU
	set maCV = @maCV, 
		tenCV = @tenCV
	where maCV = @maCV
end

exec update_CHUCVU 'cv003', N'dvgigido'
select * from CHUCVU

-- NHANVIEN --------------------------------------------------------------------------------------------------------
create proc update_NHANVIEN
@maNV varchar (10),
@tenNV nvarchar (100),
@maCV varchar (10),
@email varchar (100),
@diaChi varchar (10),
@gioiTinh nvarchar (3),
@ngaySinh date,
@sDT varchar (10)
as
begin 
	update NHANVIEN
	set maNV = @maNV, 
		tenNV = @tenNV,
		maCV = @maCV,
		email = @email,
		diaChi = @diaChi,
		gioiTinh = @gioiTinh,
		ngaySinh = @ngaySinh,
		sDT = @sDT
	where maNV = @maNV
end

exec update_NHANVIEN 'nvgigido', N'ulatroi', 'NV', 'gigido@gmail.com', 'HCM', 'Nam', '11/10/2000', '0958395839'
select * from NHANVIEN

-- DDTHAMQUAN ------------------------------------------------------------------------------------------------------
create proc update_DDTHAMQUAN
@maDD varchar (10),
@tenDD nvarchar (100),
@diaChi varchar (10)
as
begin 
	update DDTHAMQUAN
	set maDD = @maDD, 
		tenDD = @tenDD,
		diaChi = @diaChi
	where maDD = @maDD
end

exec update_DDTHAMQUAN 'ddgigido', N'uibanui', 'HCM'
select * from DDTHAMQUAN

-- TOUR ------------------------------------------------------------------------------------------------------------
create proc update_TOUR
@maTour varchar (10),
@tenTour nvarchar (100)
as
begin 
	update TOUR
	set maTour = @maTour, 
		tenTour = @tenTour
	where maTour = @maTour
end

exec update_TOUR 'tourgigido', N'gigido'
select * from TOUR

-- CT_TOUR ---------------------------------------------------------------------------------------------------------
create proc update_CT_TOUR
@maTour varchar (10),
@maDD varchar (10),
@diaChi varchar (10)
as
begin 
	update CT_TOUR
	set maTour = @maTour, 
		maDD = @maDD,
		diaChi = @diaChi
	where maTour = @maTour
end

exec update_CT_TOUR 'tourgigido', 'DDDLPQ', 'HCM'
select * from CT_TOUR

-- DAILY -----------------------------------------------------------------------------------------------------------
create proc update_DAILY
@maDL varchar (10),
@tenDL nvarchar (100),
@diaChi varchar (10),
@sDT varchar (10),
@maNV varchar (10)
as
begin 
	update DAILY
	set maDL = @maDL, 
		tenDL = @tenDL,
		diaChi = @diaChi,
		sDT = @sDT,
		maNV = @maNV
	where maDL = @maDL
end

exec update_DAILY 'dailygigid', 'hihi', 'CB', '1349859385', 'NV001'
select * from DAILY

-- KHACHSAN --------------------------------------------------------------------------------------------------------
create proc update_KHACHSAN
@maKS varchar (10),
@tenKS nvarchar (100),
@diaChi varchar (10),
@sDT varchar (10)
as
begin 
	update KHACHSAN
	set maKS = @maKS, 
		tenKS = @tenKS,
		diaChi = @diaChi,
		sDT = @sDT
	where maKS = @maKS
end

exec update_KHACHSAN 'ksgigido', 'hihi', 'TNinh', '0985839589'
select * from KHACHSAN

-- PHUONGTIEN ------------------------------------------------------------------------------------------------------
create proc update_PHUONGTIEN
@maPT varchar (10),
@tenPT nvarchar (100),
@hienTrang int
as
begin 
	update PHUONGTIEN
	set maPT = @maPT, 
		tenPT = @tenPT,
		hienTrang = @hienTrang
	where maPT = @maPT
end

exec update_PHUONGTIEN 'ptgigido', 'hihi', 0
select * from PHUONGTIEN

-- VE --------------------------------------------------------------------------------------------------------------
create proc update_VE
@maVe varchar (10),
@maTour varchar (10),
@maDL varchar (10),
@maKS varchar (10),
@maPT varchar (10),
@gia money,
@ngayBD date,
@ngayKT date
as
begin 
	update VE
	set maVe = @maVe, 
		maTour = @maTour,
		maDL = @maDL,
		maKS = @maKS,
		maPT = @maPT,
		gia = @gia,
		ngayBD = @ngayBD,
		ngayKT = @ngayKT
	where maVe = @maVe
end

set dateformat dmy
exec update_VE 'vegigido', 'tourgigido', 'dailygigido', 'ksgigido', 'ptgigido', '20000', '11/11/2021', '16/11/2021'
select * from VE

-- HOADON ----------------------------------------------------------------------------------------------------------
create proc update_HOADON
@maHD varchar (10),
@ngayLap date,
@email varchar (100)
as
begin 
	update HOADON
	set maHD = @maHD, 
		ngayLap = @ngayLap,
		email = @email
	where maHD = @maHD
end

exec update_HOADON 'hdgigido', '11/10/2020', 'baokk123@gmail.com'
select * from HOADON

-- CT_HOADON -------------------------------------------------------------------------------------------------------
create proc update_CT_HOADON
@maHD varchar (10),
@maVe varchar (10),
@sLVe int,
@thanhTien money
as
begin 
	update CT_HOADON
	set maHD = @maHD, 
		maVe = @maVe,
		sLVe = @sLVe,
		thanhTien = @thanhTien
	where maHD = @maHD
end

exec update_CT_HOADON 'hdgigido', 'vegigido', 3, 60000
select * from CT_HOADON

-- XÓA _____________________________________________________________________________________________________________
-- DIACHI ----------------------------------------------------------------------------------------------------------
create proc delete_DIACHI
@maTinh varchar (10)
as
begin
	delete from DIACHI
	where maTinh = @maTinh
end

exec delete_DIACHI 'dd1'
select * from DIACHI

-- QUYEN ----------------------------------------------------------------------------------------------------------
create proc delete_QUYEN
@maQuyen int
as
begin
	delete from QUYEN
	where maQuyen = @maQuyen
end

exec delete_QUYEN 4
select * from QUYEN

-- TAIKHOAN --------------------------------------------------------------------------------------------------------
create proc delete_TAIKHOAN
@userName varchar (100)
as
begin
	delete from TAIKHOAN
	where userName = @userName
end

exec delete_TAIKHOAN 'gigido'
select * from TAIKHOAN

-- KHACHHANG -------------------------------------------------------------------------------------------------------
create proc delete_KHACHHANG
@email varchar (100)
as
begin
	delete from KHACHHANG
	where email = @email
end

exec delete_KHACHHANG 'gigido'
select * from KHACHHANG

-- CHUCVU ----------------------------------------------------------------------------------------------------------
create proc delete_CHUCVU
@maCV varchar (10)
as
begin
	delete from CHUCVU
	where maCV = @maCV
end

exec delete_CHUCVU 'cv003'
select * from CHUCVU

-- NHANVIEN --------------------------------------------------------------------------------------------------------
create proc delete_NHANVIEN
@maNV varchar (100)
as
begin
	delete from NHANVIEN
	where maNV = @maNV
end

exec delete_NHANVIEN 'nvgigido'
select * from NHANVIEN

-- DDTHAMQUAN ------------------------------------------------------------------------------------------------------
create proc delete_DDTHAMQUAN
@maDD varchar (10)
as
begin
	delete from DDTHAMQUAN
	where maDD = @maDD
end

exec delete_DDTHAMQUAN 'ddgigido'
select * from DDTHAMQUAN

-- TOUR ------------------------------------------------------------------------------------------------------------
create proc delete_TOUR
@maTour varchar (10)
as
begin
	delete from TOUR
	where maTour = @maTour
end

exec delete_TOUR 'tourgigido'
select * from TOUR

-- CT_TOUR ---------------------------------------------------------------------------------------------------------
create proc delete_CT_TOUR
@maTour varchar (10),
@maDD varchar (10)
as
begin
	delete from CT_TOUR
	where maTour = @maTour
end

exec delete_CT_TOUR 'tourgigido', 'DDDLPQ'
select * from CT_TOUR

-- DAILY -----------------------------------------------------------------------------------------------------------
create proc delete_DAILY
@maDL varchar (10)
as
begin
	delete from DAILY
	where maDL = @maDL
end

exec delete_DAILY 'dailygigid'
select * from DAILY

-- KHACHSAN --------------------------------------------------------------------------------------------------------
create proc delete_KHACHSAN
@maKS varchar (10)
as
begin
	delete from KHACHSAN
	where maKS = @maKS
end

exec delete_KHACHSAN 'ksgigido'
select * from KHACHSAN

-- PHUONGTIEN ------------------------------------------------------------------------------------------------------
create proc delete_PHUONGTIEN
@maPT varchar (10)
as
begin
	delete from PHUONGTIEN
	where maPT = @maPT
end

exec delete_PHUONGTIEN 'ptgigido'
select * from PHUONGTIEN

-- VE --------------------------------------------------------------------------------------------------------------
create proc delete_VE
@maVe varchar (10)
as
begin
	delete from VE
	where maVe = @maVe
end

exec delete_VE 'vegigido'
select * from VE

-- HOADON ----------------------------------------------------------------------------------------------------------
create proc delete_HOADON
@maHD varchar (10)
as
begin
	delete from HOADON
	where maHD = @maHD
end

exec delete_HOADON 'hdgigido'
select * from HOADON

-- CT_HOADON -------------------------------------------------------------------------------------------------------
create proc delete_CT_HOADON
@maHD varchar (10),
@maVe varchar (10)
as
begin
	delete from CT_HOADON
	where maHD = @maHD
end

exec delete_CT_HOADON 'hdgigido', 'vegigido'
select * from CT_HOADON

-- XEM + VIEW ______________________________________________________________________________________________________
-- DIACHI ----------------------------------------------------------------------------------------------------------
-- VIEW -----------------------
create view view_DIACHI
as
	select * from DIACHI
go

-- XEM ------------------------
create proc info_DIACHI
as
begin
	select * from view_DIACHI
end

exec info_DIACHI

-- QUYEN -----------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_QUYEN
as
	select * from QUYEN
go

-- XEM ----------------------
create proc info_QUYEN
as
begin
	select * from view_QUYEN
end

exec info_QUYEN

-- TAIKHOAN --------------------------------------------------------------------------------------------------------
-- VIEW ------------------
create view view_TAIKHOAN
as
	select * from TAIKHOAN
go

-- XEM -------------------------
create proc info_TAIKHOAN
as
begin
	select * from view_TAIKHOAN
end

exec info_TAIKHOAN

-- KHACHHANG -------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_KHACHHANG
as
	select * from KHACHHANG
go

-- XEM -------------------------
create proc info_KHACHHANG
as
begin
	select * from view_KHACHHANG
end

exec info_KHACHHANG

-- CHUCVU ----------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_CHUCVU
as
	select * from CHUCVU
go

-- XEM -------------------------
create proc info_CHUCVU
as
begin
	select * from view_CHUCVU
end

exec info_CHUCVU

-- NHANVIEN --------------------------------------------------------------------------------------------------------
-- VIEW -------------------
create view view_NHANVIEN
as
	select * from NHANVIEN
go

-- XEM -------------------------
create proc info_NHANVIEN
as
begin
	select * from view_NHANVIEN
end

exec info_NHANVIEN

-- DDTHAMQUAN ------------------------------------------------------------------------------------------------------
-- VIEW ---------------------
create view view_DDTHAMQUAN
as
	select * from DDTHAMQUAN
go

-- XEM -------------------------
create proc info_DDTHAMQUAN
as
begin
	select * from view_DDTHAMQUAN
end

exec info_DDTHAMQUAN

-- TOUR ------------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_TOUR
as
	select * from TOUR
go

-- XEM -------------------------
create proc info_TOUR
as
begin
	select * from view_TOUR
end

exec info_TOUR

-- CT_TOUR ---------------------------------------------------------------------------------------------------------
-- VIEW ------------------
create view view_CT_TOUR
as
	select * from CT_TOUR
go

-- XEM -------------------------
create proc info_CT_TOUR
as
begin
	select * from view_CT_TOUR
end

exec info_CT_TOUR

-- DAILY -----------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_DAILY
as
	select * from DAILY
go

-- XEM -------------------------
create proc info_DAILY
as
begin
	select * from view_DAILY
end

exec info_DAILY

-- KHACHSAN --------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_KHACHSAN
as
	select * from KHACHSAN
go

-- XEM -------------------------
create proc info_KHACHSAN
as
begin
	select * from view_KHACHSAN
end

exec info_KHACHSAN

-- PHUONGTIEN ------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_PHUONGTIEN
as
	select * from PHUONGTIEN
go

-- XEM -------------------------
create proc info_PHUONGTIEN
as
begin
	select * from view_PHUONGTIEN
end

exec info_PHUONGTIEN

-- VE --------------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_VE
as
	select * from VE
go

-- XEM -------------------------
create proc info_VE
as
begin
	select * from view_VE
end

exec info_VE

-- HOADON ----------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_HOADON
as
	select * from HOADON
go

-- XEM -------------------------
create proc info_HOADON
as
begin
	select * from view_HOADON
end

exec info_HOADON

-- CT_HOADON -------------------------------------------------------------------------------------------------------
-- VIEW ----------------
create view view_CT_HOADON
as
	select * from CT_HOADON
go

-- XEM -------------------------
create proc info_CT_HOADON
as
begin
	select * from view_CT_HOADON
end

exec info_CT_HOADON


-- PHÂN QUYỀN CƠ SỞ DỮ LIỆU ========================================================================================
-- Tạo các tài khoản _______________________________________________________________________________________________
-- // Chạy từng dòng
--sp_addlogin 'quanLy', '123'				-- Tạo login truy cập vào hệ thống ('tenDangNhap', 'matKhau')
--sp_adduser 'quanLy', 'quanLy'			-- Tạo user truy cập vào database ('tenDangNhap', 'tenNguoiDung')

--sp_addlogin 'nhanVien', '123'			
--sp_adduser 'nhanVien', 'nhanVien'			

--sp_addlogin 'khachHang', '123' 
--sp_adduser 'khachHang', 'khachHang'

---- Tạo các nhóm quyền ____________________________________________________________________________________________
---- Ban quản lý
--sp_addrole 'quanTri'
--grant select, insert, delete, update
--on DIACHI 
--to quanTri

--grant select, insert, delete, update
--on KHACHHANG 
--to quanTri

--grant select, insert, delete, update
--on CHUCVU 
--to quanTri

--grant select, insert, delete, update
--on NHANVIEN 
--to quanTri

--grant select, insert, delete, update
--on DDTHAMQUAN 
--to quanTri

--grant select, insert, delete, update
--on TOUR 
--to quanTri

--grant select, insert, delete, update
--on CT_TOUR 
--to quanTri

--grant select, insert, delete, update
--on DAILY 
--to quanTri

--grant select, insert, delete, update
--on KHACHSAN 
--to quanTri

--grant select, insert, delete, update
--on PHUONGTIEN 
--to quanTri

--grant select, insert, delete, update
--on VE 
--to quanTri

--grant select, insert, delete, update
--on HOADON 
--to quanTri

--grant select, insert, delete, update
--on CT_HOADON 
--to quanTri

---- Nhân viên _____________________________________________________________________________________________________
--sp_addrole 'NV'
--grant select, insert, update
--on DIACHI 
--to NV

--grant select, insert, delete, update
--on KHACHHANG 
--to NV

--grant select
--on CHUCVU 
--to NV

--grant select, update
--on NHANVIEN 
--to NV

--grant select, insert, delete, update
--on DDTHAMQUAN 
--to NV

--grant select, insert, delete, update
--on TOUR 
--to NV

--grant select, insert, delete, update
--on CT_TOUR 
--to NV

--grant select, insert, delete, update
--on DAILY 
--to NV

--grant select, insert, delete, update
--on KHACHSAN 
--to NV

--grant select, insert, delete, update
--on PHUONGTIEN 
--to NV

--grant select, insert, delete, update
--on VE 
--to NV

--grant select, insert, delete, update
--on HOADON 
--to NV

--grant select, insert, delete, update
--on CT_HOADON 
--to NV

---- Khách hàng ____________________________________________________________________________________________________
--sp_addrole 'KH'
--grant select, update
--on KHACHHANG
--to KH

--grant select
--on TOUR
--to KH

--grant select
--on VE
--to KH

--grant select
--on DDTHAMQUAN
--to KH

--grant select
--on DIACHI
--to KH

--grant select
--on KHACHSAN
--to KH

--grant select
--on PHUONGTIEN
--to KH

--grant select
--on HOADON
--to KH

---- Thêm các tài khoản vào các nhóm quyền tương ứng _______________________________________________________________
---- // Chạy từng dòng
--sp_addrolemember 'quanTri', 'quanLy'	-- Thêm user 'quanLy' vào nhóm quyền 'quanTri'
--sp_addrolemember 'NV', 'nhanVien' 
--sp_addrolemember 'KH', 'khachHang'

--hiển thị tour đặt form khách hàng
go
create proc hienthitourdatkhachhang 
as
 begin
 select CT_TOUR.maTour,tenTour,CT_TOUR.maDD,tenDD,CT_TOUR.diaChi from CT_TOUR,DDTHAMQUAN,TOUR where CT_TOUR.maTour=TOUR.maTour and CT_TOUR.maDD=DDTHAMQUAN.maDD
 end

exec hienthitourdatkhachhang

--tìm kiếm tour đặt form khách hàng
go
create proc TimKiemtourdatkhachhang @tk nvarchar(100)
as
 begin
 select CT_TOUR.maTour,tenTour,CT_TOUR.maDD,tenDD,CT_TOUR.diaChi from CT_TOUR,DDTHAMQUAN,TOUR
 where CT_TOUR.maTour=TOUR.maTour and CT_TOUR.maDD=DDTHAMQUAN.maDD 
 and CT_TOUR.maTour=@tk
 end

exec TimKiemtourdatkhachhang 'TSG'
select * from TOUR
select CT_TOUR.maTour,tenTour,CT_TOUR.maDD,tenDD,CT_TOUR.diaChi from CT_TOUR,DDTHAMQUAN,TOUR
where CT_TOUR.maTour=TOUR.maTour and CT_TOUR.maDD=DDTHAMQUAN.maDD
select * from DDTHAMQUAN
select * from CT_TOUR
select * from TAIKHOAN
--hiển thị vé đặt form khách hàng
go
create proc hienthivedatkhachhang 
as
 begin
 select maVe,ve.maTour,TOUR.tenTour,VE.maDL,DAILY.tenDL,VE.maKS,KHACHSAN.tenKS,VE.maPT,
PHUONGTIEN.tenPT,gia,ngayBD,ngayKT
from PHUONGTIEN,VE,KHACHSAN,DAILY,TOUR 
where VE.maPT=PHUONGTIEN.maPT and VE.maKS=KHACHSAN.maKS and VE.maDL=DAILY.maDL
and ve.maTour=TOUR.maTour
 end

exec hienthivedatkhachhang
select * from VE
select * from KHACHSAN
select * from DAILY
select * from PHUONGTIEN
select * from TOUR
select maVe,ve.maTour,TOUR.tenTour,VE.maDL,DAILY.tenDL,VE.maKS,KHACHSAN.tenKS,VE.maPT,
PHUONGTIEN.tenPT,gia,ngayBD,ngayKT
from PHUONGTIEN,VE,KHACHSAN,DAILY,TOUR 
where VE.maPT=PHUONGTIEN.maPT and VE.maKS=KHACHSAN.maKS and VE.maDL=DAILY.maDL
and ve.maTour=TOUR.maTour

--tìm kiếm VÉ đặt form khách hàng
go
create proc TimKiemvedatkhachhang @tk nvarchar(100)
as
 begin
 select maVe,ve.maTour,TOUR.tenTour,VE.maDL,DAILY.tenDL,VE.maKS,KHACHSAN.tenKS,VE.maPT,
PHUONGTIEN.tenPT,gia,ngayBD,ngayKT
from PHUONGTIEN,VE,KHACHSAN,DAILY,TOUR 
where VE.maPT=PHUONGTIEN.maPT and VE.maKS=KHACHSAN.maKS and VE.maDL=DAILY.maDL
and ve.maTour=TOUR.maTour and CONCAT(maVe,ve.maTour,TOUR.tenTour,VE.maDL,DAILY.tenDL,VE.maKS,KHACHSAN.tenKS,VE.maPT,
PHUONGTIEN.tenPT,gia,ngayBD,ngayKT) like @tk
 end

exec TimKiemvedatkhachhang N'%Tour du lịch Sài Gòn%'

--đặt vé chưa có hóa đơn
go
create proc DatVe @mhd varchar(10),@eml varchar(100),@sl int,@mve varchar(10)
as
 begin
 insert into HOADON values(@mhd,GETDATE(),@eml)
 insert into CT_HOADON(maHD,maVe,sLVe) values (@mhd,@mve,@sl)
 end

 exec DatVe 'h1','baokk123@gmail.com',1,'V009'
 select * from HOADON
 select count(*) from HOADON
 select * from CT_HOADON
 update CT_HOADON set sLVe = 1 where maHD='1'

 --đặt vé  có hóa đơn
go
create proc DatVeCoHD @mhd varchar(10),@eml varchar(100),@sl int,@mve varchar(10)
as
 begin
  if(select count(*) from CT_HOADON where maHD=@mhd and maVe=@mve)>0 --ct hóa đơn đã tồn tại
   begin
    update CT_HOADON set sLVe=@sl where maHD=@mhd and maVe=@mve
   end
  else--chưa có ct hóa đơn này
   begin
    insert into CT_HOADON(maHD,maVe,sLVe) values (@mhd,@mve,@sl)
   end
 end

 exec DatVe 'h8','baokk123@gmail.com',1,'V009'
 select * from HOADON
 select count(*) from HOADON
 select * from CT_HOADON
 update CT_HOADON set sLVe = 1 where maHD='1'
 select * from CT_HOADON where maHD='16'
 -- Trigger tính thành tiền của CT_HOADON (Thành tiền = Giá * Số lượng)
go
create trigger thanhTien_CTHD on CT_HOADON
for insert,update
as
begin
	update CT_HOADON 
	set thanhTien = ((select gia from VE where CT_HOADON.maVe = VE.maVe) * sLVe)
end

-- đăng ký tài khoản ----------------------------------------------------------------------------------------------
go
create proc dkTaiKhoan 
@userName varchar (100),
@pass varchar (100)
as
begin
	insert into TAIKHOAN values (@userName, @pass, '3')
	insert into KHACHHANG values (@userName, null, 'HCM', null, null, null)
end

exec dkTaiKhoan 'gigido', '123'
select * from KHACHHANG
select * from TAIKHOAN
insert into TAIKHOAN values('','','2')
delete TAIKHOAN where userName=''
select * from NHANVIEN
select * from CHUCVU
select * from DDTHAMQUAN
select * from PHUONGTIEN
select NHANVIEN.* from NHANVIEN,TAIKHOAN where NHANVIEN.maNV=TAIKHOAN.userName and maQuyen !=1