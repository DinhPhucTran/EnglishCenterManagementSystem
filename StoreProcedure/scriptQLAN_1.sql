Create database QL_ANHNGU

Use QL_ANHNGU

Create table TRINH_DO
(
	MaTrinhDo varchar(15) primary key,
	TenTrinhDo varchar(10)
)

Create table CHUONG_TRINH_HOC
(
	MaCTHoc varchar(15) primary key,
	TenCTHoc nvarchar(50),
	MaTrinhDo varchar(15),
	DiemSoToiThieu float,
	constraint FK_CTHOC_TRINHDO foreign key (MaTrinhDo) references TRINH_DO(MaTrinhDo)
)

Create table HOC_VIEN
(
	MaHocVien varchar(15) Primary key,
	TenHocVien nvarchar(50),
	NgaySinh Date,
	Phai nvarchar(10),
	DiaChi nvarchar(100),
	SoDT varchar(15),
	MaCTDaHoc varchar(15),
	MaCTMuonHoc varchar(15),
	MaTDDaHoc varchar(15),
	MaTDMuonHoc varchar(15)
	constraint FK_HOCVIEN_CTDaHoc foreign key (MaCTDaHoc) references CHUONG_TRINH_HOC(MaCTHoc),
	constraint FK_HOCVIEN_CTMuonHoc foreign key (MaCTMuonHoc) references CHUONG_TRINH_HOC(MaCTHoc),
	constraint FK_HOCVIEN_TDDaHoc foreign key (MaTDDaHoc) references TRINH_DO(MaTrinhDo),
	constraint FK_HOCVIEN_TDMuonHOC foreign key (MaTDMuonHoc) references TRINH_DO(MaTrinhDo)
)

Create table THU
(
	MaThu varchar(15) primary key,
	TenThu nvarchar(20)
)

Create table CA
(
	MaCa varchar(15) primary key,
	ThoiGianBD time(3),
	ThoiGianKT time(3)
)

Create table THOIGIAN_RANH
(
	MaHV varchar(15),
	MaThu varchar(15),
	MaCa varchar(15),
	constraint FK_TGRANH_HOCVIEN foreign key (MaHV) references HOC_VIEN(MaHocVien),
	constraint FK_TGRANH_THU foreign key (MaThu) references THU(MaThu),
	constraint FK_TGRANH_CA foreign key (MaCa) references CA(MaCa),
	constraint PK_TGRANH primary key (MaHV, MaThu, MaCa)
)
 
Create table PHONG
(
	MaPhong varchar(15) primary key,
	TenPhong nvarchar(50)
)

Create table DE_THI
(
	MaDeThi varchar(15) primary key,
	LoaiDeThi varchar(15),
	ChiTiet nvarchar(100)
)

Create table THI_XEP_LOP
(
	MaThiXL varchar(15) primary key,
	MaPhong varchar(15),
	CaThi varchar(15),
	MaDeThi varchar(15),
	constraint FL_THIXL_PHONG foreign key (MaPhong) references PHONG(MaPhong),
	constraint FL_THIXL_CA foreign key (CaThi) references CA(MaCa),
	constraint FL_THIXL_DETHI foreign key (MaDeThi) references DE_THI(MaDeThi)
)

Create table CHI_TIET_THI_XL
(
	MaThiXepLop varchar(15),
	MaHV varchar(15),
	KetQuaThi float,
	ChuongTrinhDeNghi varchar(15),
	ChuongTrinhMongMuon varchar(15),
	constraint FK_CHITIETTHIXL_THIXL foreign key (MaThiXepLop) references THI_XEP_LOP(MaThiXL),
	constraint FK_CHITIETTHIXL_HOCVIEN foreign key (MaHV) references HOC_VIEN(MaHocVien),
	constraint FK_CHITIETTHIXL_CTDENGHIHOC foreign key (ChuongTrinhDeNghi) references CHUONG_TRINH_HOC(MaCTHoc),
	constraint FK_CHITIETTHIXL_CTMONGMUONHOC foreign key (ChuongTrinhMongMuon) references CHUONG_TRINH_HOC(MaCTHoc),
	constraint PL_CHITIETTHIXL primary key (MaThiXepLop, MaHV)
)

Create table GIANG_VIEN
(
	MaGiangVien varchar(15) primary key,
	TenGiangVien nvarchar(50),
	DiaChi nvarchar(100),
	SoDT varchar(15)
)

Create table LOP_HOC
(
	MaLop varchar(15) primary key,
	NgayKhaiGiang smalldatetime, 
	ThoiGianBD smalldatetime,
	ThoiGianKT smalldatetime,
	SoTien decimal(15,5),
	MaGV varchar(15),
	MaCTHoc varchar(15),
	MaPhong varchar(15),
	constraint FK_LOPHOC_CTHOC foreign key (MaCTHoc) references CHUONG_TRINH_HOC(MaCTHoc),
	constraint FK_LOPHOC_GIANGVIEN foreign key (MaGV) references GIANG_VIEN(MaGiangVien),
	constraint FK_LOPHOC_PHONG foreign key (MaPhong) references PHONG(MaPhong),
)

Create table CHI_TIET_LOP_HOC
(
	MaLopHoc varchar(15),
	MaHV varchar(15),
	TinhTrangDongHP tinyint,
	KetQuaThi float,
	SoTienNo decimal(15, 5),
	constraint FK_CTLOP_LOPHOC foreign key (MaLopHoc) references LOP_HOC(MaLop),
	constraint FK_CTLOP_HOCVIEN foreign key (MaHV) references HOC_VIEN(MaHocVien),
	constraint PK_CTLOPHOC primary key (MaLopHoc, MaHV)
)

Create table PHIEU_THU_HOP_PHI
(
	MaPhieuThu varchar(15) primary key,
	MaLopHoc varchar(15),
	MaHocVien varchar(15),
	NgayLap smalldatetime,
	SoTienDong decimal(15,5),
	constraint FK_PHIEUTHU_LOPHOC foreign key (MaLopHoc) references LOP_HOC(MaLop),
	constraint FK_PHIEUTHU_HOCVIEN foreign key (MAHocVien) references HOC_VIEN(MaHocVien)
)

Create table THAM_SO
(
	TenThamSo varchar(15),
	GiaTri int
)