create procedure THI_XEP_LOP_LIST_BY_DAY
(
	@NgayThi SmallDateTime
)
as
select * from THI_XEP_LOP where THI_XEP_LOP.NgayThi = @NgayThi

go
--sử dụng để lấy tất cả các lớp học chưa học tương ứng với ngày thi xếp lớp
create procedure LOP_HOC_LIST_WITH_NGAY_THI_XEP_LOP
(
	@NgayThi SmallDateTime
)
as
select * from LOP_HOC where LOP_HOC.NgayKhaiGiang > @NgayThi and LOP_HOC.ThoiGianBD < @NgayThi