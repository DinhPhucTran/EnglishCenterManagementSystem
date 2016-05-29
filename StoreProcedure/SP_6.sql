use ql_anhngu

go

alter table Trinh_do
alter column TenTrinhDo varchar(50)

go 
Alter PROCEDURE [DBO].
[THOIGIAN_HOC_SELECT] ( @MaLop AS varchar(15)) AS SELECT 
[MaLop],[MaThu],[MaCa] FROM [THOIGIAN_HOC] 
WHERE [MaLop] = @MaLop

go 
Alter PROCEDURE [DBO].
[THOIGIAN_HOC_INSERT] (@MaLop AS VARCHAR(15) ,@MaThu AS VARCHAR(15) ,@MaCa AS VARCHAR(15) ) AS INSERT INTO THOIGIAN_HOC ( 
[MaLop],[MaThu],[MaCa] ) VALUES ( 
@MaLop,@MaThu,@MaCa)


go
 Alter PROCEDURE [DBO].
[THOIGIAN_HOC_DELETE] ( @MaLop AS varchar(15)) AS DELETE FROM THOIGIAN_HOC 
WHERE [MaLop] = @MaLop

go
 Alter PROCEDURE [DBO].
[THOIGIAN_HOC_UPDATE] (@MaLop AS VARCHAR(15) ,@MaThu AS VARCHAR(15) ,@MaCa AS VARCHAR(15) ) AS UPDATE THOIGIAN_HOC SET 
[MaThu] = @MaThu,[MaCa] = @MaCa WHERE [MaLop] = @MaLop


go
 Alter PROCEDURE [DBO].
[TRINH_DO_SELECT] ( @MaTrinhDo AS varchar(15)) AS SELECT 
[MaTrinhDo],[TenTrinhDo] FROM [TRINH_DO] 
WHERE [MaTrinhDo] = @MaTrinhDo

go
 Alter PROCEDURE [DBO].
[TRINH_DO_INSERT] (@MaTrinhDo AS VARCHAR(15) ,@TenTrinhDo AS VARCHAR(10) ) AS INSERT INTO TRINH_DO ( 
[MaTrinhDo],[TenTrinhDo] ) VALUES ( 
@MaTrinhDo,@TenTrinhDo)


go 
Alter PROCEDURE [DBO].
[TRINH_DO_DELETE] ( @MaTrinhDo AS varchar(15)) AS DELETE FROM TRINH_DO 
WHERE [MaTrinhDo] = @MaTrinhDo

go 
Alter PROCEDURE [DBO].
[TRINH_DO_UPDATE] (@MaTrinhDo AS VARCHAR(15) ,@TenTrinhDo AS VARCHAR(10) ) AS UPDATE TRINH_DO SET 
[TenTrinhDo] = @TenTrinhDo WHERE [MaTrinhDo] = @MaTrinhDo


go 
Alter PROCEDURE [DBO].
[CHUONG_TRINH_HOC_SELECT] ( @MaCTHoc AS varchar(15)) AS SELECT 
[MaCTHoc],[TenCTHoc],[MaTrinhDo],[DiemSoToiThieu],[DiemSoToiDa] FROM [CHUONG_TRINH_HOC] 
WHERE [MaCTHoc] = @MaCTHoc

go 
Alter PROCEDURE [DBO].
[CHUONG_TRINH_HOC_INSERT] (@MaCTHoc AS VARCHAR(15) ,@TenCTHoc AS NVARCHAR ,@MaTrinhDo AS VARCHAR(15) ,@DiemSoToiThieu AS FLOAT ,@DiemSoToiDa AS FLOAT ) AS INSERT INTO CHUONG_TRINH_HOC ( 
[MaCTHoc],[TenCTHoc],[MaTrinhDo],[DiemSoToiThieu],[DiemSoToiDa] ) VALUES ( 
@MaCTHoc,@TenCTHoc,@MaTrinhDo,@DiemSoToiThieu,@DiemSoToiDa)


go 
Alter PROCEDURE [DBO].
[CHUONG_TRINH_HOC_DELETE] ( @MaCTHoc AS varchar(15)) AS DELETE FROM CHUONG_TRINH_HOC 
WHERE [MaCTHoc] = @MaCTHoc

go 
Alter PROCEDURE [DBO].
[CHUONG_TRINH_HOC_UPDATE] (@MaCTHoc AS VARCHAR(15) ,@TenCTHoc AS NVARCHAR ,@MaTrinhDo AS VARCHAR(15) ,@DiemSoToiThieu AS FLOAT ,@DiemSoToiDa AS FLOAT ) AS UPDATE CHUONG_TRINH_HOC SET 
[TenCTHoc] = @TenCTHoc,[MaTrinhDo] = @MaTrinhDo,[DiemSoToiThieu] = @DiemSoToiThieu,[DiemSoToiDa] = @DiemSoToiDa WHERE [MaCTHoc] = @MaCTHoc


go 
Alter PROCEDURE [DBO].
[HOC_VIEN_SELECT] ( @MaHocVien AS varchar(15)) AS SELECT 
[MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] FROM [HOC_VIEN] 
WHERE [MaHocVien] = @MaHocVien

go
Alter PROCEDURE [DBO].
[HOC_VIEN_INSERT] (@MaHocVien AS VARCHAR(15) ,@TenHocVien AS NVARCHAR ,@NgaySinh AS DATE ,@Phai AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS INSERT INTO HOC_VIEN ( 
[MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] ) VALUES ( 
@MaHocVien,@TenHocVien,@NgaySinh,@Phai,@DiaChi,@SoDT,@MaCTDaHoc,@MaCTMuonHoc,@MaTDDaHoc,@MaTDMuonHoc)


go 
Alter PROCEDURE [DBO].
[HOC_VIEN_DELETE] ( @MaHocVien AS varchar(15)) AS DELETE FROM HOC_VIEN 
WHERE [MaHocVien] = @MaHocVien

go 
Alter PROCEDURE [DBO].
[HOC_VIEN_UPDATE] (@MaHocVien AS VARCHAR(15) ,@TenHocVien AS NVARCHAR ,@NgaySinh AS DATE ,@Phai AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS UPDATE HOC_VIEN SET 
[TenHocVien] = @TenHocVien,[NgaySinh] = @NgaySinh,[Phai] = @Phai,[DiaChi] = @DiaChi,[SoDT] = @SoDT,[MaCTDaHoc] = @MaCTDaHoc,[MaCTMuonHoc] = @MaCTMuonHoc,[MaTDDaHoc] = @MaTDDaHoc,[MaTDMuonHoc] = @MaTDMuonHoc WHERE [MaHocVien] = @MaHocVien


go 
Alter PROCEDURE [DBO].
[THU_SELECT] ( @MaThu AS varchar(15)) AS SELECT 
[MaThu],[TenThu] FROM [THU] 
WHERE [MaThu] = @MaThu

go 
Alter PROCEDURE [DBO].
[THU_INSERT] (@MaThu AS VARCHAR(15) ,@TenThu AS NVARCHAR ) AS INSERT INTO THU ( 
[MaThu],[TenThu] ) VALUES ( 
@MaThu,@TenThu)


go
 Alter PROCEDURE [DBO].
[THU_DELETE] ( @MaThu AS varchar(15)) AS DELETE FROM THU 
WHERE [MaThu] = @MaThu

go 
Alter PROCEDURE [DBO].
[THU_UPDATE] (@MaThu AS VARCHAR(15) ,@TenThu AS NVARCHAR ) AS UPDATE THU SET 
[TenThu] = @TenThu WHERE [MaThu] = @MaThu


go 
Alter PROCEDURE [DBO].
[CA_SELECT] ( @MaCa AS varchar(15)) AS SELECT 
[MaCa],[ThoiGianBD],[ThoiGianKT] FROM [CA] 
WHERE [MaCa] = @MaCa

go 
Alter PROCEDURE [DBO].
[CA_INSERT] (@MaCa AS VARCHAR(15) ,@ThoiGianBD AS TIME ,@ThoiGianKT AS TIME ) AS INSERT INTO CA ( 
[MaCa],[ThoiGianBD],[ThoiGianKT] ) VALUES ( 
@MaCa,@ThoiGianBD,@ThoiGianKT)


go 
Alter PROCEDURE [DBO].
[CA_DELETE] ( @MaCa AS varchar(15)) AS DELETE FROM CA 
WHERE [MaCa] = @MaCa

go 
Alter PROCEDURE [DBO].
[CA_UPDATE] (@MaCa AS VARCHAR(15) ,@ThoiGianBD AS TIME ,@ThoiGianKT AS TIME ) AS UPDATE CA SET 
[ThoiGianBD] = @ThoiGianBD,[ThoiGianKT] = @ThoiGianKT WHERE [MaCa] = @MaCa


go 
Alter PROCEDURE [DBO].
[THOIGIAN_RANH_SELECT] ( @MaHV AS varchar(15)) AS SELECT 
[MaHV],[MaThu],[MaCa] FROM [THOIGIAN_RANH] 
WHERE [MaHV] = @MaHV

go 
Alter PROCEDURE [DBO].
[THOIGIAN_RANH_INSERT] (@MaHV AS VARCHAR(15) ,@MaThu AS VARCHAR(15) ,@MaCa AS VARCHAR(15) ) AS INSERT INTO THOIGIAN_RANH ( 
[MaHV],[MaThu],[MaCa] ) VALUES ( 
@MaHV,@MaThu,@MaCa)


go 
Alter PROCEDURE [DBO].
[THOIGIAN_RANH_DELETE] ( @MaHV AS varchar(15)) AS DELETE FROM THOIGIAN_RANH 
WHERE [MaHV] = @MaHV

go 
Alter PROCEDURE [DBO].
[THOIGIAN_RANH_UPDATE] (@MaHV AS VARCHAR(15) ,@MaThu AS VARCHAR(15) ,@MaCa AS VARCHAR(15) ) AS UPDATE THOIGIAN_RANH SET 
[MaThu] = @MaThu,[MaCa] = @MaCa WHERE [MaHV] = @MaHV


go 
Alter PROCEDURE [DBO].
[PHONG_SELECT] ( @MaPhong AS varchar(15)) AS SELECT 
[MaPhong],[TenPhong] FROM [PHONG] 
WHERE [MaPhong] = @MaPhong

go 
Alter PROCEDURE [DBO].
[PHONG_INSERT] (@MaPhong AS VARCHAR(15) ,@TenPhong AS NVARCHAR ) AS INSERT INTO PHONG ( 
[MaPhong],[TenPhong] ) VALUES ( 
@MaPhong,@TenPhong)


go 
Alter PROCEDURE [DBO].
[PHONG_DELETE] ( @MaPhong AS varchar(15)) AS DELETE FROM PHONG 
WHERE [MaPhong] = @MaPhong

go
Alter PROCEDURE [DBO].
[PHONG_UPDATE] (@MaPhong AS VARCHAR(15) ,@TenPhong AS NVARCHAR ) AS UPDATE PHONG SET 
[TenPhong] = @TenPhong WHERE [MaPhong] = @MaPhong


go 
Alter PROCEDURE [DBO].
[DE_THI_SELECT] ( @MaDeThi AS varchar(15)) AS SELECT 
[MaDeThi],[LoaiDeThi],[ChiTiet] FROM [DE_THI] 
WHERE [MaDeThi] = @MaDeThi

go 
Alter PROCEDURE [DBO].
[DE_THI_INSERT] (@MaDeThi AS VARCHAR(15) ,@LoaiDeThi AS VARCHAR(15) ,@ChiTiet AS NVARCHAR ) AS INSERT INTO DE_THI ( 
[MaDeThi],[LoaiDeThi],[ChiTiet] ) VALUES ( 
@MaDeThi,@LoaiDeThi,@ChiTiet)


go 
Alter PROCEDURE [DBO].
[DE_THI_DELETE] ( @MaDeThi AS varchar(15)) AS DELETE FROM DE_THI 
WHERE [MaDeThi] = @MaDeThi

go 
Alter PROCEDURE [DBO].
[DE_THI_UPDATE] (@MaDeThi AS VARCHAR(15) ,@LoaiDeThi AS VARCHAR(15) ,@ChiTiet AS NVARCHAR ) AS UPDATE DE_THI SET 
[LoaiDeThi] = @LoaiDeThi,[ChiTiet] = @ChiTiet WHERE [MaDeThi] = @MaDeThi


go 
Alter PROCEDURE [DBO].
[THI_XEP_LOP_SELECT] ( @MaThiXL AS varchar(15)) AS SELECT 
[MaThiXL],[MaPhong],[CaThi],[MaDeThi],[NgayThi] FROM [THI_XEP_LOP] 
WHERE [MaThiXL] = @MaThiXL

go 
Alter PROCEDURE [DBO].
[THI_XEP_LOP_INSERT] (@MaThiXL AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ,@CaThi AS VARCHAR(15) ,@MaDeThi AS VARCHAR(15) ,@NgayThi AS SMALLDATETIME ) AS INSERT INTO THI_XEP_LOP ( 
[MaThiXL],[MaPhong],[CaThi],[MaDeThi],[NgayThi] ) VALUES ( 
@MaThiXL,@MaPhong,@CaThi,@MaDeThi,@NgayThi)


go 
Alter PROCEDURE [DBO].
[THI_XEP_LOP_DELETE] ( @MaThiXL AS varchar(15)) AS DELETE FROM THI_XEP_LOP 
WHERE [MaThiXL] = @MaThiXL

go 
Alter PROCEDURE [DBO].
[THI_XEP_LOP_UPDATE] (@MaThiXL AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ,@CaThi AS VARCHAR(15) ,@MaDeThi AS VARCHAR(15) ,@NgayThi AS SMALLDATETIME ) AS UPDATE THI_XEP_LOP SET 
[MaPhong] = @MaPhong,[CaThi] = @CaThi,[MaDeThi] = @MaDeThi,[NgayThi] = @NgayThi WHERE [MaThiXL] = @MaThiXL


go 
Alter PROCEDURE [DBO].
[CHI_TIET_THI_XL_SELECT] ( @MaThiXepLop AS varchar(15)) AS SELECT 
[MaThiXepLop],[MaHV],[KetQuaThi],[ChuongTrinhDeNghi],[ChuongTrinhMongMuon] FROM [CHI_TIET_THI_XL] 
WHERE [MaThiXepLop] = @MaThiXepLop

go 
Alter PROCEDURE [DBO].
[CHI_TIET_THI_XL_INSERT] (@MaThiXepLop AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@KetQuaThi AS FLOAT ,@ChuongTrinhDeNghi AS VARCHAR(15) ,@ChuongTrinhMongMuon AS VARCHAR(15) ) AS INSERT INTO CHI_TIET_THI_XL ( 
[MaThiXepLop],[MaHV],[KetQuaThi],[ChuongTrinhDeNghi],[ChuongTrinhMongMuon] ) VALUES ( 
@MaThiXepLop,@MaHV,@KetQuaThi,@ChuongTrinhDeNghi,@ChuongTrinhMongMuon)


go 
Alter PROCEDURE [DBO].
[CHI_TIET_THI_XL_DELETE] ( @MaThiXepLop AS varchar(15)) AS DELETE FROM CHI_TIET_THI_XL 
WHERE [MaThiXepLop] = @MaThiXepLop

go 
Alter PROCEDURE [DBO].
[CHI_TIET_THI_XL_UPDATE] (@MaThiXepLop AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@KetQuaThi AS FLOAT ,@ChuongTrinhDeNghi AS VARCHAR(15) ,@ChuongTrinhMongMuon AS VARCHAR(15) ) AS UPDATE CHI_TIET_THI_XL SET 
[MaHV] = @MaHV,[KetQuaThi] = @KetQuaThi,[ChuongTrinhDeNghi] = @ChuongTrinhDeNghi,[ChuongTrinhMongMuon] = @ChuongTrinhMongMuon WHERE [MaThiXepLop] = @MaThiXepLop


go 
Alter PROCEDURE [DBO].
[GIANG_VIEN_SELECT] ( @MaGiangVien AS varchar(15)) AS SELECT 
[MaGiangVien],[TenGiangVien],[DiaChi],[SoDT] FROM [GIANG_VIEN] 
WHERE [MaGiangVien] = @MaGiangVien

go 
Alter PROCEDURE [DBO].
[GIANG_VIEN_INSERT] (@MaGiangVien AS VARCHAR(15) ,@TenGiangVien AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ) AS INSERT INTO GIANG_VIEN ( 
[MaGiangVien],[TenGiangVien],[DiaChi],[SoDT] ) VALUES ( 
@MaGiangVien,@TenGiangVien,@DiaChi,@SoDT)


go 
Alter PROCEDURE [DBO].
[GIANG_VIEN_DELETE] ( @MaGiangVien AS varchar(15)) AS DELETE FROM GIANG_VIEN 
WHERE [MaGiangVien] = @MaGiangVien

go 
Alter PROCEDURE [DBO].
[GIANG_VIEN_UPDATE] (@MaGiangVien AS VARCHAR(15) ,@TenGiangVien AS NVARCHAR ,@DiaChi AS NVARCHAR ,@SoDT AS VARCHAR(15) ) AS UPDATE GIANG_VIEN SET 
[TenGiangVien] = @TenGiangVien,[DiaChi] = @DiaChi,[SoDT] = @SoDT WHERE [MaGiangVien] = @MaGiangVien


go 
Alter PROCEDURE [DBO].
[LOP_HOC_SELECT] ( @MaLop AS varchar(15)) AS SELECT 
[MaLop],[NgayKhaiGiang],[ThoiGianBD],[ThoiGianKT],[SoTien],[MaGV],[MaCTHoc],[MaPhong] FROM [LOP_HOC] 
WHERE [MaLop] = @MaLop

go 
Alter PROCEDURE [DBO].
[LOP_HOC_INSERT] (@MaLop AS VARCHAR(15) ,@NgayKhaiGiang AS SMALLDATETIME ,@ThoiGianBD AS SMALLDATETIME ,@ThoiGianKT AS SMALLDATETIME ,@SoTien AS DECIMAL ,@MaGV AS VARCHAR(15) ,@MaCTHoc AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ) AS INSERT INTO LOP_HOC ( 
[MaLop],[NgayKhaiGiang],[ThoiGianBD],[ThoiGianKT],[SoTien],[MaGV],[MaCTHoc],[MaPhong] ) VALUES ( 
@MaLop,@NgayKhaiGiang,@ThoiGianBD,@ThoiGianKT,@SoTien,@MaGV,@MaCTHoc,@MaPhong)


go 
Alter PROCEDURE [DBO].
[LOP_HOC_DELETE] ( @MaLop AS varchar(15)) AS DELETE FROM LOP_HOC 
WHERE [MaLop] = @MaLop

go 
Alter PROCEDURE [DBO].
[LOP_HOC_UPDATE] (@MaLop AS VARCHAR(15) ,@NgayKhaiGiang AS SMALLDATETIME ,@ThoiGianBD AS SMALLDATETIME ,@ThoiGianKT AS SMALLDATETIME ,@SoTien AS DECIMAL ,@MaGV AS VARCHAR(15) ,@MaCTHoc AS VARCHAR(15) ,@MaPhong AS VARCHAR(15) ) AS UPDATE LOP_HOC SET 
[NgayKhaiGiang] = @NgayKhaiGiang,[ThoiGianBD] = @ThoiGianBD,[ThoiGianKT] = @ThoiGianKT,[SoTien] = @SoTien,[MaGV] = @MaGV,[MaCTHoc] = @MaCTHoc,[MaPhong] = @MaPhong WHERE [MaLop] = @MaLop


go 
Alter PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_SELECT] ( @MaLopHoc AS varchar(15)) AS SELECT 
[MaLopHoc],[MaHV],[TinhTrangDongHP],[KetQuaThi],[SoTienNo] FROM [CHI_TIET_LOP_HOC] 
WHERE [MaLopHoc] = @MaLopHoc

go 
Alter PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_INSERT] (@MaLopHoc AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@TinhTrangDongHP AS TINYINT ,@KetQuaThi AS FLOAT ,@SoTienNo AS DECIMAL ) AS INSERT INTO CHI_TIET_LOP_HOC ( 
[MaLopHoc],[MaHV],[TinhTrangDongHP],[KetQuaThi],[SoTienNo] ) VALUES ( 
@MaLopHoc,@MaHV,@TinhTrangDongHP,@KetQuaThi,@SoTienNo)


go 
Alter PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_DELETE] ( @MaLopHoc AS varchar(15)) AS DELETE FROM CHI_TIET_LOP_HOC 
WHERE [MaLopHoc] = @MaLopHoc

go 
Alter PROCEDURE [DBO].
[CHI_TIET_LOP_HOC_UPDATE] (@MaLopHoc AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@TinhTrangDongHP AS TINYINT ,@KetQuaThi AS FLOAT ,@SoTienNo AS DECIMAL ) AS UPDATE CHI_TIET_LOP_HOC SET 
[MaHV] = @MaHV,[TinhTrangDongHP] = @TinhTrangDongHP,[KetQuaThi] = @KetQuaThi,[SoTienNo] = @SoTienNo WHERE [MaLopHoc] = @MaLopHoc


go 
Alter PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_SELECT] ( @MaPhieuThu AS varchar(15)) AS SELECT 
[MaPhieuThu],[MaLopHoc],[MaHocVien],[NgayLap],[SoTienDong] FROM [PHIEU_THU_HOP_PHI] 
WHERE [MaPhieuThu] = @MaPhieuThu

go 
Alter PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_INSERT] (@MaPhieuThu AS VARCHAR(15) ,@MaLopHoc AS VARCHAR(15) ,@MaHocVien AS VARCHAR(15) ,@NgayLap AS SMALLDATETIME ,@SoTienDong AS DECIMAL ) AS INSERT INTO PHIEU_THU_HOP_PHI ( 
[MaPhieuThu],[MaLopHoc],[MaHocVien],[NgayLap],[SoTienDong] ) VALUES ( 
@MaPhieuThu,@MaLopHoc,@MaHocVien,@NgayLap,@SoTienDong)


go 
Alter PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_DELETE] ( @MaPhieuThu AS varchar(15)) AS DELETE FROM PHIEU_THU_HOP_PHI 
WHERE [MaPhieuThu] = @MaPhieuThu

go 
Alter PROCEDURE [DBO].
[PHIEU_THU_HOP_PHI_UPDATE] (@MaPhieuThu AS VARCHAR(15) ,@MaLopHoc AS VARCHAR(15) ,@MaHocVien AS VARCHAR(15) ,@NgayLap AS SMALLDATETIME ,@SoTienDong AS DECIMAL ) AS UPDATE PHIEU_THU_HOP_PHI SET 
[MaLopHoc] = @MaLopHoc,[MaHocVien] = @MaHocVien,[NgayLap] = @NgayLap,[SoTienDong] = @SoTienDong WHERE [MaPhieuThu] = @MaPhieuThu


go 
Alter PROCEDURE [DBO].
[THAM_SO_SELECT] ( @TenThamSo AS varchar(15)) AS SELECT 
[TenThamSo],[GiaTri] FROM [THAM_SO] 
WHERE [TenThamSo] = @TenThamSo

go 
Alter PROCEDURE [DBO].
[THAM_SO_INSERT] (@TenThamSo AS VARCHAR(15) ,@GiaTri AS INT ) AS INSERT INTO THAM_SO ( 
[TenThamSo],[GiaTri] ) VALUES ( 
@TenThamSo,@GiaTri)


go 
Alter PROCEDURE [DBO].
[THAM_SO_DELETE] ( @TenThamSo AS varchar(15)) AS DELETE FROM THAM_SO 
WHERE [TenThamSo] = @TenThamSo

go 
Alter PROCEDURE [DBO].
[THAM_SO_UPDATE] (@TenThamSo AS VARCHAR(15) ,@GiaTri AS INT ) AS UPDATE THAM_SO SET 
[GiaTri] = @GiaTri WHERE [TenThamSo] = @TenThamSo

