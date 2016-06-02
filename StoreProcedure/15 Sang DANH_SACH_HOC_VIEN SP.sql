use QL_ANHNGU

GO
CREATE PROCEDURE DANH_SACH_HOC_VIEN (@MaLopHoc as varchar(15))
as
SELECT [MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] FROM [HOC_VIEN] , [CHI_TIET_LOP_HOC]
WHERE CHI_TIET_LOP_HOC.MaLopHoc = @MaLopHoc AND [MaHocVien] = CHI_TIET_LOP_HOC.MaHV 
