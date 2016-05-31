use QL_ANHNGU

go
CREATE PROCEDURE LOP_HOC_BY_TIME (@ThoiGianBD as SmallDateTime, @ThoiGianKT as SmallDateTime)
AS
SELECT * FROM LOP_HOC Where ThoiGianKT>= @ThoiGianBD and ThoiGianBD <= @ThoiGianKT

Go 
CREATE PROCEDURE THOIGIAN_HOC_CUA_LOP (@MaLop as varchar(15))
as
SELECT * FROM THOIGIAN_HOC WHERE MaLop = @MaLop