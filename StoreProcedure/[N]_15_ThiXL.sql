create procedure LOP_HOC_LIST_MALOP_TGHOC_NOW
as
select Lop_Hoc.MaLop as MaLop, MaPhong, THOIGIAN_HOC.MaThu as MaThu, MaCa from LOP_HOC join THOIGIAN_HOC on LOP_HOC.MaLop = THOIGIAN_HOC.MaLop
where ThoiGianBD < GETDATE() and ThoiGianKT > GETDATE()

go
--su dung khi add thi xep lop bat ki
create procedure LOP_HOC_LIST_TO_ADD_THIXL
(
	@MaPhong varchar(15),
	@NgayThi SmallDateTime,
	@MaCa varchar(15)
)
as
select Lop_Hoc.MaLop as MaLop, Lop_Hoc.MaPhong as MaPhong, THOIGIAN_HOC.MaThu as MaThu, THOIGIAN_HOC.MaCa as MaCa from LOP_HOC join THOIGIAN_HOC on LOP_HOC.MaLop = THOIGIAN_HOC.MaLop
where Lop_Hoc.ThoiGianBD < @NgayThi and Lop_Hoc.ThoiGianKT > @NgayThi and LOP_HOC.MaPhong = @MaPhong and THOIGIAN_HOC.MaCa = @MaCa

go

create procedure THI_XEP_LOP_LIST_BY_DATE
(
	@MaPhong varchar(15),
	@NgayThi SmallDateTime,
	@CaThi varchar(15)
)
as
select * from THI_XEP_LOP where THI_XEP_LOP.NgayThi = @NgayThi and THI_XEP_LOP.CaThi = @CaThi and THI_XEP_LOP.MaPhong = @MaPhong

go

create procedure Lop_Hoc_LIST_BY_DAY
	(
		@NgayThi SmallDateTime,
		@MaThu varchar(15)
	)

	as select Lop_Hoc.MaLop as MaLop, Lop_Hoc.MaPhong as MaPhong, THOIGIAN_HOC.MaThu as MaThu, Thoigian_hoc.MaCa as MaCa
	from LOP_HOC Join THOIGIAN_HOC on LOP_HOC.MaLop = THOIGIAN_HOC.MaLop
	where THOIGIAN_HOC.MaThu = @MaThu and Lop_Hoc.ThoiGianBD <= @NgayThi and Lop_Hoc.ThoiGianKT >= @NgayThi