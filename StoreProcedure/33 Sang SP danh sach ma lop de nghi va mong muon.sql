use QL_ANHNGU
go
CREATE procedure [dbo].[DANH_SACH_LOP_SAP_MO_THEO_2MA_CHT](@maCTDeNghi as VARCHAR(15), @maCTMuonHoc as VARCHAR(15), @fromDate as SmallDateTime)
AS
select l.MaLop from LOP_HOC l where l.MaCTHoc = @maCTDeNghi and l.MaCTHoc = @maCTMuonHoc and l.NgayKhaiGiang>=@fromDate