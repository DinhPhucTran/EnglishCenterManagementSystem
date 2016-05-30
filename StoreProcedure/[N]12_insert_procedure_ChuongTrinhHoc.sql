Create procedure CHUONG_TRINH_HOC_GET_MACT_FROM_NAME
(
	@TenCTHoc nvarchar(50)
)
as
select MaCTHoc from CHUONG_TRINH_HOC where CHUONG_TRINH_HOC.TenCTHoc = @TenCTHoc

go

Create procedure TRINH_DO_GET_MA_FROM_TEN
(
	@TenTrinhDo varchar(50)
)
as
select MaTrinhDo from TRINH_DO where TRINH_DO.TenTrinhDo = @TenTrinhDo