
CREATE PROCEDURE [DBO].[CHUONG_TRINH_HOC_SELECT] ( @MaCTHoc AS INT)
AS
SELECT 
[MaCTHoc],[TenCTHoc],[MaTrinhDo],[DiemSoToiThieu] FROM [CHUONG_TRINH_HOC] 
WHERE [MaCTHoc] = @MaCTHoc

go

CREATE PROCEDURE [DBO].
[CHUONG_TRINH_HOC_INSERT] (@TenCTHoc AS NVARCHAR ,@MaTrinhDo AS VARCHAR(15) ,@DiemSoToiThieu AS FLOAT ) AS INSERT INTO CHUONG_TRINH_HOC ( 
[TenCTHoc],[MaTrinhDo],[DiemSoToiThieu] ) VALUES ( 
@TenCTHoc,@MaTrinhDo,@DiemSoToiThieu)

go


CREATE PROCEDURE [DBO].
[CHUONG_TRINH_HOC_DELETE] ( @MaCTHoc AS INT) AS DELETE FROM CHUONG_TRINH_HOC 
WHERE [MaCTHoc] = @MaCTHoc

go


CREATE PROCEDURE [DBO].
[CHUONG_TRINH_HOC_UPDATE] (@MaCTHoc AS VARCHAR(15) ,@TenCTHoc AS NVARCHAR ,@MaTrinhDo AS VARCHAR(15) ,@DiemSoToiThieu AS FLOAT ) AS UPDATE CHUONG_TRINH_HOC SET 
[TenCTHoc] = @TenCTHoc,[MaTrinhDo] = @MaTrinhDo,[DiemSoToiThieu] = @DiemSoToiThieu WHERE [MaCTHoc] = @MaCTHoc


go


CREATE PROCEDURE [DBO].
[HOC_VIEN_SELECT] ( @MaHocVien AS INT) AS SELECT 
[MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] FROM [HOC_VIEN] 
WHERE [MaHocVien] = @MaHocVien

go


CREATE PROCEDURE [DBO].
[HOC_VIEN_INSERT] (@TenHocVien AS NVARCHAR ,@NgaySinh AS DATE ,@Phai AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS INSERT INTO HOC_VIEN ( 
[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] ) VALUES ( 
@TenHocVien,@NgaySinh,@Phai,@DiaChi,@SoDT,@MaCTDaHoc,@MaCTMuonHoc,@MaTDDaHoc,@MaTDMuonHoc)


go


CREATE PROCEDURE [DBO].
[HOC_VIEN_DELETE] ( @MaHocVien AS INT) AS DELETE FROM HOC_VIEN 
WHERE [MaHocVien] = @MaHocVien

go


CREATE PROCEDURE [DBO].
[HOC_VIEN_UPDATE] (@MaHocVien AS VARCHAR(15) ,@TenHocVien AS NVARCHAR ,@NgaySinh AS DATE ,@Phai AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS UPDATE HOC_VIEN SET 
[TenHocVien] = @TenHocVien,[NgaySinh] = @NgaySinh,[Phai] = @Phai,[DiaChi] = @DiaChi,[SoDT] = @SoDT,[MaCTDaHoc] = @MaCTDaHoc,[MaCTMuonHoc] = @MaCTMuonHoc,[MaTDDaHoc] = @MaTDDaHoc,[MaTDMuonHoc] = @MaTDMuonHoc WHERE [MaHocVien] = @MaHocVien


go


CREATE PROCEDURE [DBO].
[THU_SELECT] ( @MaThu AS INT) AS SELECT 
[MaThu],[TenThu] FROM [THU] 
WHERE [MaThu] = @MaThu

go


CREATE PROCEDURE [DBO].
[THU_INSERT] (@TenThu AS NVARCHAR ) AS INSERT INTO THU ( 
[TenThu] ) VALUES ( 
@TenThu)

go



CREATE PROCEDURE [DBO].
[THU_DELETE] ( @MaThu AS INT) AS DELETE FROM THU 
WHERE [MaThu] = @MaThu

go


CREATE PROCEDURE [DBO].
[THU_UPDATE] (@MaThu AS VARCHAR(15) ,@TenThu AS NVARCHAR ) AS UPDATE THU SET 
[TenThu] = @TenThu WHERE [MaThu] = @MaThu


go


CREATE PROCEDURE [DBO].
[CA_SELECT] ( @MaCa AS INT) AS SELECT 
[MaCa],[ThoiGianBD],[ThoiGianKT] FROM [CA] 
WHERE [MaCa] = @MaCa

go


CREATE PROCEDURE [DBO].
[CA_INSERT] (@ThoiGianBD AS TIME ,@ThoiGianKT AS TIME ) AS INSERT INTO CA ( 
[ThoiGianBD],[ThoiGianKT] ) VALUES ( 
@ThoiGianBD,@ThoiGianKT)

go



CREATE PROCEDURE [DBO].
[CA_DELETE] ( @MaCa AS INT) AS DELETE FROM CA 
WHERE [MaCa] = @MaCa

go


CREATE PROCEDURE [DBO].
[CA_UPDATE] (@MaCa AS VARCHAR(15) ,@ThoiGianBD AS TIME ,@ThoiGianKT AS TIME ) AS UPDATE CA SET 
[ThoiGianBD] = @ThoiGianBD,[ThoiGianKT] = @ThoiGianKT WHERE [MaCa] = @MaCa


go


CREATE PROCEDURE [DBO].
[THOIGIAN_RANH_SELECT] ( @MaHV AS INT) AS SELECT 
[MaHV],[MaThu],[MaCa] FROM [THOIGIAN_RANH] 
WHERE [MaHV] = @MaHV

go


CREATE PROCEDURE [DBO].
[THOIGIAN_RANH_INSERT] (@MaThu AS VARCHAR(15) ,@MaCa AS VARCHAR(15) ) AS INSERT INTO THOIGIAN_RANH ( 
[MaThu],[MaCa] ) VALUES ( 
@MaThu,@MaCa)

go



CREATE PROCEDURE [DBO].
[THOIGIAN_RANH_DELETE] ( @MaHV AS INT) AS DELETE FROM THOIGIAN_RANH 
WHERE [MaHV] = @MaHV

go


CREATE PROCEDURE [DBO].
[THOIGIAN_RANH_UPDATE] (@MaHV AS VARCHAR(15) ,@MaThu AS VARCHAR(15) ,@MaCa AS VARCHAR(15) ) AS UPDATE THOIGIAN_RANH SET 
[MaThu] = @MaThu,[MaCa] = @MaCa WHERE [MaHV] = @MaHV


go


CREATE PROCEDURE [DBO].
[PHONG_SELECT] ( @MaPhong AS INT) AS SELECT 
[MaPhong],[TenPhong] FROM [PHONG] 
WHERE [MaPhong] = @MaPhong

go


CREATE PROCEDURE [DBO].
[PHONG_INSERT] (@TenPhong AS NVARCHAR ) AS INSERT INTO PHONG ( 
[TenPhong] ) VALUES ( 
@TenPhong)


go


CREATE PROCEDURE [DBO].
[PHONG_DELETE] ( @MaPhong AS INT) AS DELETE FROM PHONG 
WHERE [MaPhong] = @MaPhong

go


CREATE PROCEDURE [DBO].
[PHONG_UPDATE] (@MaPhong AS VARCHAR(15) ,@TenPhong AS NVARCHAR ) AS UPDATE PHONG SET 
[TenPhong] = @TenPhong WHERE [MaPhong] = @MaPhong

go



CREATE PROCEDURE [DBO].
[DE_THI_SELECT] ( @MaDeThi AS INT) AS SELECT 
[MaDeThi],[LoaiDeThi],[ChiTiet] FROM [DE_THI] 
WHERE [MaDeThi] = @MaDeThi

go


CREATE PROCEDURE [DBO].
[DE_THI_INSERT] (@LoaiDeThi AS VARCHAR(15) ,@ChiTiet AS NVARCHAR ) AS INSERT INTO DE_THI ( 
[LoaiDeThi],[ChiTiet] ) VALUES ( 
@LoaiDeThi,@ChiTiet)


go


CREATE PROCEDURE [DBO].
[DE_THI_DELETE] ( @MaDeThi AS INT) AS DELETE FROM DE_THI 
WHERE [MaDeThi] = @MaDeThi

go


CREATE PROCEDURE [DBO].
[DE_THI_UPDATE] (@MaDeThi AS VARCHAR(15) ,@LoaiDeThi AS VARCHAR(15) ,@ChiTiet AS NVARCHAR ) AS UPDATE DE_THI SET 
[LoaiDeThi] = @LoaiDeThi,[ChiTiet] = @ChiTiet WHERE [MaDeThi] = @MaDeThi


go


CREATE PROCEDURE [DBO].
[THI_XEP_LOP_SELECT] ( @MaThiXL AS INT) AS SELECT 
[MaThiXL],[MaPhong],[CaThi],[MaDeThi] FROM [THI_XEP_LOP] 
WHERE [MaThiXL] = @MaThiXL

go


CREATE PROCEDURE [DBO].
[THI_XEP_LOP_INSERT] (@MaPhong AS VARCHAR(15) ,@CaThi AS VARCHAR(15) ,@MaDeThi AS VARCHAR(15) ) AS INSERT INTO THI_XEP_LOP ( 
[MaPhong],[CaThi],[MaDeThi] ) VALUES ( 
@MaPhong,@CaThi,@MaDeThi)

go



CREATE PROCEDURE [DBO].
[THI_XEP_LOP_DELETE] ( @MaThiXL AS INT) AS DELETE FROM THI_XEP_LOP 
WHERE [MaThiXL] = @MaThiXL

go


CREATE PROCEDURE [DBO].
[THI_XEP_LOP_UPDATE] (@MaThiXL AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ,@CaThi AS VARCHAR(15) ,@MaDeThi AS VARCHAR(15) ) AS UPDATE THI_XEP_LOP SET 
[MaPhong] = @MaPhong,[CaThi] = @CaThi,[MaDeThi] = @MaDeThi WHERE [MaThiXL] = @MaThiXL


go


CREATE PROCEDURE [DBO].
[CHI_TIET_THI_XL_SELECT] ( @MaThiXepLop AS INT) AS SELECT 
[MaThiXepLop],[MaHV],[KetQuaThi],[ChuongTrinhDeNghi],[ChuongTrinhMongMuon] FROM [CHI_TIET_THI_XL] 
WHERE [MaThiXepLop] = @MaThiXepLop

go


CREATE PROCEDURE [DBO].
[CHI_TIET_THI_XL_INSERT] (@MaHV AS VARCHAR(15) ,@KetQuaThi AS FLOAT ,@ChuongTrinhDeNghi AS VARCHAR(15) ,@ChuongTrinhMongMuon AS VARCHAR(15) ) AS INSERT INTO CHI_TIET_THI_XL ( 
[MaHV],[KetQuaThi],[ChuongTrinhDeNghi],[ChuongTrinhMongMuon] ) VALUES ( 
@MaHV,@KetQuaThi,@ChuongTrinhDeNghi,@ChuongTrinhMongMuon)


go


CREATE PROCEDURE [DBO].
[CHI_TIET_THI_XL_DELETE] ( @MaThiXepLop AS INT) AS DELETE FROM CHI_TIET_THI_XL 
WHERE [MaThiXepLop] = @MaThiXepLop

go


CREATE PROCEDURE [DBO].
[CHI_TIET_THI_XL_UPDATE] (@MaThiXepLop AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@KetQuaThi AS FLOAT ,@ChuongTrinhDeNghi AS VARCHAR(15) ,@ChuongTrinhMongMuon AS VARCHAR(15) ) AS UPDATE CHI_TIET_THI_XL SET 
[MaHV] = @MaHV,[KetQuaThi] = @KetQuaThi,[ChuongTrinhDeNghi] = @ChuongTrinhDeNghi,[ChuongTrinhMongMuon] = @ChuongTrinhMongMuon WHERE [MaThiXepLop] = @MaThiXepLop

go



CREATE PROCEDURE [DBO].
[GIANG_VIEN_SELECT] ( @MaGiangVien AS INT) AS SELECT 
[MaGiangVien],[TenGiangVien],[DiaChi],[SoDT] FROM [GIANG_VIEN] 
WHERE [MaGiangVien] = @MaGiangVien

go


CREATE PROCEDURE [DBO].
[GIANG_VIEN_INSERT] (@TenGiangVien AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ) AS INSERT INTO GIANG_VIEN ( 
[TenGiangVien],[DiaChi],[SoDT] ) VALUES ( 
@TenGiangVien,@DiaChi,@SoDT)


go


CREATE PROCEDURE [DBO].
[GIANG_VIEN_DELETE] ( @MaGiangVien AS INT) AS DELETE FROM GIANG_VIEN 
WHERE [MaGiangVien] = @MaGiangVien

go


CREATE PROCEDURE [DBO].
[GIANG_VIEN_UPDATE] (@MaGiangVien AS VARCHAR(15) ,@TenGiangVien AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ) AS UPDATE GIANG_VIEN SET 
[TenGiangVien] = @TenGiangVien,[DiaChi] = @DiaChi,[SoDT] = @SoDT WHERE [MaGiangVien] = @MaGiangVien

go



CREATE PROCEDURE [DBO].
[LOP_HOC_SELECT] ( @MaLop AS INT) AS SELECT 
[MaLop],[NgayKhaiGiang],[ThoiGianBD],[ThoiGianKT],[SoTien],[MaGV],[MaCTHoc],[MaPhong] FROM [LOP_HOC] 
WHERE [MaLop] = @MaLop

go


CREATE PROCEDURE [DBO].
[LOP_HOC_INSERT] (@NgayKhaiGiang AS SMALLDATETIME ,@ThoiGianBD AS SMALLDATETIME ,@ThoiGianKT AS SMALLDATETIME ,@SoTien AS DECIMAL ,@MaGV AS VARCHAR(15) ,@MaCTHoc AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ) AS INSERT INTO LOP_HOC ( 
[NgayKhaiGiang],[ThoiGianBD],[ThoiGianKT],[SoTien],[MaGV],[MaCTHoc],[MaPhong] ) VALUES ( 
@NgayKhaiGiang,@ThoiGianBD,@ThoiGianKT,@SoTien,@MaGV,@MaCTHoc,@MaPhong)

go



CREATE PROCEDURE [DBO].
[LOP_HOC_DELETE] ( @MaLop AS INT) AS DELETE FROM LOP_HOC 
WHERE [MaLop] = @MaLop

go


CREATE PROCEDURE [DBO].
[LOP_HOC_UPDATE] (@MaLop AS VARCHAR(15) ,@NgayKhaiGiang AS SMALLDATETIME ,@ThoiGianBD AS SMALLDATETIME ,@ThoiGianKT AS SMALLDATETIME ,@SoTien AS DECIMAL ,@MaGV AS VARCHAR(15) ,@MaCTHoc AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ) AS UPDATE LOP_HOC SET 
[NgayKhaiGiang] = @NgayKhaiGiang,[ThoiGianBD] = @ThoiGianBD,[ThoiGianKT] = @ThoiGianKT,[SoTien] = @SoTien,[MaGV] = @MaGV,[MaCTHoc] = @MaCTHoc,[MaPhong] = @MaPhong WHERE [MaLop] = @MaLop


go


CREATE PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_SELECT] ( @MaLopHoc AS INT) AS SELECT 
[MaLopHoc],[MaHV],[TinhTrangDongHP],[KetQuaThi],[SoTienNo] FROM [CHI_TIET_LOP_HOC] 
WHERE [MaLopHoc] = @MaLopHoc

go


CREATE PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_INSERT] (@MaHV AS VARCHAR(15) ,@TinhTrangDongHP AS TINYINT ,@KetQuaThi AS FLOAT ,@SoTienNo AS DECIMAL ) AS INSERT INTO CHI_TIET_LOP_HOC ( 
[MaHV],[TinhTrangDongHP],[KetQuaThi],[SoTienNo] ) VALUES ( 
@MaHV,@TinhTrangDongHP,@KetQuaThi,@SoTienNo)

go



CREATE PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_DELETE] ( @MaLopHoc AS INT) AS DELETE FROM CHI_TIET_LOP_HOC 
WHERE [MaLopHoc] = @MaLopHoc

go


CREATE PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_UPDATE] (@MaLopHoc AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@TinhTrangDongHP AS TINYINT ,@KetQuaThi AS FLOAT ,@SoTienNo AS DECIMAL ) AS UPDATE CHI_TIET_LOP_HOC SET 
[MaHV] = @MaHV,[TinhTrangDongHP] = @TinhTrangDongHP,[KetQuaThi] = @KetQuaThi,[SoTienNo] = @SoTienNo WHERE [MaLopHoc] = @MaLopHoc


go


CREATE PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_SELECT] ( @MaPhieuThu AS INT) AS SELECT 
[MaPhieuThu],[MaLopHoc],[MaHocVien],[NgayLap],[SoTienDong] FROM [PHIEU_THU_HOP_PHI] 
WHERE [MaPhieuThu] = @MaPhieuThu

go


CREATE PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_INSERT] (@MaLopHoc AS VARCHAR(15) ,@MaHocVien AS VARCHAR(15) ,@NgayLap AS SMALLDATETIME ,@SoTienDong AS DECIMAL ) AS INSERT INTO PHIEU_THU_HOP_PHI ( 
[MaLopHoc],[MaHocVien],[NgayLap],[SoTienDong] ) VALUES ( 
@MaLopHoc,@MaHocVien,@NgayLap,@SoTienDong)


go


CREATE PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_DELETE] ( @MaPhieuThu AS INT) AS DELETE FROM PHIEU_THU_HOP_PHI 
WHERE [MaPhieuThu] = @MaPhieuThu

go


CREATE PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_UPDATE] (@MaPhieuThu AS VARCHAR(15) ,@MaLopHoc AS VARCHAR(15) ,@MaHocVien AS VARCHAR(15) ,@NgayLap AS SMALLDATETIME ,@SoTienDong AS DECIMAL ) AS UPDATE PHIEU_THU_HOP_PHI SET 
[MaLopHoc] = @MaLopHoc,[MaHocVien] = @MaHocVien,[NgayLap] = @NgayLap,[SoTienDong] = @SoTienDong WHERE [MaPhieuThu] = @MaPhieuThu


go


CREATE PROCEDURE [DBO].
[THAM_SO_SELECT] ( @TenThamSo AS INT) AS SELECT 
[TenThamSo],[GiaTri] FROM [THAM_SO] 
WHERE [TenThamSo] = @TenThamSo

go


CREATE PROCEDURE [DBO].
[THAM_SO_INSERT] (@GiaTri AS INT ) AS INSERT INTO THAM_SO ( 
[GiaTri] ) VALUES ( 
@GiaTri)


go


CREATE PROCEDURE [DBO].
[THAM_SO_DELETE] ( @TenThamSo AS INT) AS DELETE FROM THAM_SO 
WHERE [TenThamSo] = @TenThamSo

go


CREATE PROCEDURE [DBO].
[THAM_SO_UPDATE] (@TenThamSo AS VARCHAR(15) ,@GiaTri AS INT ) AS UPDATE THAM_SO SET 
[GiaTri] = @GiaTri WHERE [TenThamSo] = @TenThamSo

