--de thi : chi tiet
use ql_anhngu
GO
ALTER PROCEDURE [dbo].[DE_THI_INSERT] (@MaDeThi AS VARCHAR(15) ,@LoaiDeThi AS VARCHAR(15) ,@ChiTiet AS NVARCHAR(100)) AS INSERT INTO DE_THI ( 
[MaDeThi],[LoaiDeThi],[ChiTiet] ) VALUES ( 
@MaDeThi,@LoaiDeThi,@ChiTiet)

--giang vien: ten, dia chi

GO
ALTER PROCEDURE [dbo].[GIANG_VIEN_INSERT] (@MaGiangVien AS VARCHAR(15) ,@TenGiangVien AS NVARCHAR(50),@DiaChi AS NVARCHAR (100),@SoDT AS VARCHAR(15) ) AS INSERT INTO GIANG_VIEN ( 
[MaGiangVien],[TenGiangVien],[DiaChi],[SoDT] ) VALUES ( 
@MaGiangVien,@TenGiangVien,@DiaChi,@SoDT)

--hoc vien: ten

GO
ALTER PROCEDURE [dbo].[HOC_VIEN_INSERT] (@MaHocVien AS VARCHAR(15) ,@TenHocVien AS NVARCHAR(50) ,@NgaySinh AS DATE ,@Phai AS NVARCHAR(10) ,@DiaChi AS NVARCHAR(100) ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS INSERT INTO HOC_VIEN ( 
[MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] ) VALUES ( 
@MaHocVien,@TenHocVien,@NgaySinh,@Phai,@DiaChi,@SoDT,@MaCTDaHoc,@MaCTMuonHoc,@MaTDDaHoc,@MaTDMuonHoc)


--phong: ten phong,

GO
ALTER PROCEDURE [dbo].[PHONG_INSERT] (@MaPhong AS VARCHAR(15) ,@TenPhong AS NVARCHAR(50) ) AS INSERT INTO PHONG ( 
[MaPhong],[TenPhong] ) VALUES ( 
@MaPhong,@TenPhong)

--thu: ten thu
GO
ALTER PROCEDURE [dbo].[THU_INSERT] (@MaThu AS VARCHAR(15) ,@TenThu AS NVARCHAR(20) ) AS INSERT INTO THU ( 
[MaThu],[TenThu] ) VALUES ( 
@MaThu,@TenThu)
