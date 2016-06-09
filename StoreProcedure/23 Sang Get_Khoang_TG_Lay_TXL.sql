use QL_ANHNGU

go
CREATE PROCEDURE GET_KHOANG_THOI_GIAN_THI_XL(@CurrentTime as smalldatetime)
as
select min(ThoigianBD), max(ngaykhaigiang) from LOP_HOC where ThoiGianBD<= @CurrentTime and NgayKhaiGiang >= @CurrentTime 