--Danh sach lop hoc theo ma chuong trinh hoc
create procedure LOP_HOC_BY_MA_CHUONG_TRINH_HOC
(
	@MaChuongTrinh varchar(15)
)
as
select * from LOP_HOC where LOP_HOC.MaCTHoc = @MaChuongTrinh

go

--Danh sach thi xep lop dua vao thoi gian ranh cua hoc vien

create procedure THI_XEP_LOP_BY_TGRANH
(
	@MaHV varchar(15)
)
as
select * from (select * from THI_XEP_LOP where THI_XEP_LOP.NgayThi > GETDATE()) as Table_ThiXepLopHienTai
join (select * from THOIGIAN_RANH where THOIGIAN_RANH.MaHV = @MaHV) as Table_ThoiGianRanh
on DATENAME(WEEKDAY, Table_ThiXepLopHienTai.NgayThi) = Table_ThoiGianRanh.MaThu 
and Table_ThiXepLopHienTai.CaThi = Table_ThoiGianRanh.MaCa

--lay danh sach thi xep lop hien tai
create procedure THI_XEP_LOP_NOW
as
select distinct THI_XEP_LOP.MaThiXL as MaThiXL, THI_XEP_LOP.MaPhong as MaPhong,
THI_XEP_LOP.CaThi as CaThi, THI_XEP_LOP.MaDeThi as MaDeThi, THI_XEP_LOP.NgayThi as NgayThi
 from THI_XEP_LOP join
(select * from LOP_HOC where LOP_HOC.ThoiGianBD < GETDATE() and LOP_HOC.NgayKhaiGiang > GETDATE())
as Table_DsLopHoc 
on THI_XEP_LOP.NgayThi > Table_DsLopHoc.ThoiGianBD and THI_XEP_LOP.NgayThi < Table_DsLopHoc.NgayKhaiGiang

--lay danh sach hoc vien trong 1 lop thi xep lop
create procedure CHI_TIET_THI_XEP_LOP_BY_MA_TXL
(
	@MaTXL varchar(15)
)
as
select * from CHI_TIET_THI_XL where CHI_TIET_THI_XL.MaThiXepLop = @MaTXL