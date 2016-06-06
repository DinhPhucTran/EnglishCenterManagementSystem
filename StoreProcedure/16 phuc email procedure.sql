--Them Email 
ALTER PROCEDURE [DBO].[HOC_VIEN_SELECT] ( @MaHocVien AS varchar(15)) AS SELECT 
[MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc],[Email] FROM [HOC_VIEN] 
WHERE [MaHocVien] = @MaHocVien

CREATE PROCEDURE [dbo].[CHI_TIET_LOP_HOC_SELECT_BY_MAHV]
	@MaHV VARCHAR(15)
AS
	SELECT * FROM CHI_TIET_LOP_HOC WHERE CHI_TIET_LOP_HOC.MaHV = @MaHV


