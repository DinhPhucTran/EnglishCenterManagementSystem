use QL_ANHNGU
go
create procedure DANH_SACH_LOP_SAP_MO_THEO_MA_CHT(@maCT as VARCHAR(15), @fromDate as SmallDateTime)
AS
select l.MaLop from LOP_HOC l where l.MaCTHoc = @maCT and l.NgayKhaiGiang>=@fromDate
