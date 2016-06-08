--input: mã học viên mới cần thêm vào các lớp phù hợp dựa vào thời gian rảnh và chương trình muốn học.
--output: mã lớp và các thời gian phù hợp với học viên đó có thể ko đầy đủ các buổi của lớp đó (MaLop, MaThu, MaCa)

create procedure LOP_HOC_LIST_BY_TGRANH_CTHOCMONGMUON
(
	@MaHV varchar(15)
)
as
if (Select HOC_VIEN.MaCTMuonHoc from HOC_VIEN where HOC_VIEN.MaHocVien = @MaHV) != ''
	select distinct Table_ThoiGianHoc.MaLop as MaLop, Table_ThoiGianHoc.MaThu as MaThu, Table_ThoiGianHoc.MaCa as MaCa from 
	(select * from THOIGIAN_RANH where THOIGIAN_RANH.MaHV = @MaHV) as Table_ThoiGianRanh
	join 
	( select Table_LopHocTheoCTHoc.MaLop as MaLop, THOIGIAN_HOC.MaThu, THOIGIAN_HOC.MaCa from 
	(select * from LOP_HOC where LOP_HOC.MaCTHoc in
	(Select HOC_VIEN.MaCTMuonHoc from HOC_VIEN where HOC_VIEN.MaHocVien = @MaHV)
	 and LOP_HOC.NgayKhaiGiang > GETDATE()) as Table_LopHocTheoCTHoc 
	join THOIGIAN_HOC on THOIGIAN_HOC.MaLop = Table_LopHocTheoCTHoc.MaLop) as Table_ThoiGianHoc
	on Table_ThoiGianHoc.MaThu = Table_ThoiGianRanh.MaThu and Table_ThoiGianHoc.MaCa = Table_ThoiGianRanh.MaCa

else

	select distinct Table_ThoiGianHoc.MaLop as MaLop, Table_ThoiGianHoc.MaThu as MaThu, Table_ThoiGianHoc.MaCa as MaCa from 
	(select * from THOIGIAN_RANH where THOIGIAN_RANH.MaHV = @MaHV) as Table_ThoiGianRanh
	join 
	( select Table_LopHocTheoCTHoc.MaLop as MaLop, THOIGIAN_HOC.MaThu, THOIGIAN_HOC.MaCa from 
	(select * from LOP_HOC where LOP_HOC.NgayKhaiGiang > GETDATE()) as Table_LopHocTheoCTHoc 
	join THOIGIAN_HOC on THOIGIAN_HOC.MaLop = Table_LopHocTheoCTHoc.MaLop) as Table_ThoiGianHoc
	on Table_ThoiGianHoc.MaThu = Table_ThoiGianRanh.MaThu and Table_ThoiGianHoc.MaCa = Table_ThoiGianRanh.MaCa
