use QL_ANHNGU

go
CREATE PROCEDURE LOP_HOC_BY_TIME (@ThoiGianBD as SmallDateTime, @ThoiGianKT as SmallDateTime)
AS
SELECT * FROM LOP_HOC Where ThoiGianKT>= @ThoiGianBD and ThoiGianBD <= @ThoiGianKT