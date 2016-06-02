alter table Hoc_vien
add Email varchar(50)

go

alter PROCEDURE [dbo].[HOC_VIEN_INSERT] (@MaHocVien AS VARCHAR(15) ,@TenHocVien AS NVARCHAR(50) ,@NgaySinh AS DATE ,@Phai AS NVARCHAR(10) ,@DiaChi AS NVARCHAR(100), @Email AS VARCHAR(50) ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS INSERT INTO HOC_VIEN ( 
[MaHocVien],[TenHocVien],[NgaySinh],[Phai],[DiaChi], [Email],[SoDT],[MaCTDaHoc],[MaCTMuonHoc],[MaTDDaHoc],[MaTDMuonHoc] ) VALUES ( 
@MaHocVien,@TenHocVien,@NgaySinh,@Phai,@DiaChi,@Email,@SoDT,@MaCTDaHoc,@MaCTMuonHoc,@MaTDDaHoc,@MaTDMuonHoc)

go

alter PROCEDURE [DBO].[HOC_VIEN_UPDATE] (@MaHocVien AS VARCHAR(15) ,@TenHocVien AS NVARCHAR(50) ,@NgaySinh AS DATE ,@Phai AS NVARCHAR(10),@DiaChi AS NVARCHAR(100), @Email AS VARCHAR(50) ,@SoDT AS VARCHAR(15) ,@MaCTDaHoc AS VARCHAR(15) ,@MaCTMuonHoc AS VARCHAR(15) ,@MaTDDaHoc AS VARCHAR(15) ,@MaTDMuonHoc AS VARCHAR(15) ) AS UPDATE HOC_VIEN SET 
[TenHocVien] = @TenHocVien,[NgaySinh] = @NgaySinh,[Phai] = @Phai, [Email] = @Email,[DiaChi] = @DiaChi,[SoDT] = @SoDT,[MaCTDaHoc] = @MaCTDaHoc,[MaCTMuonHoc] = @MaCTMuonHoc,[MaTDDaHoc] = @MaTDDaHoc,[MaTDMuonHoc] = @MaTDMuonHoc WHERE [MaHocVien] = @MaHocVien

go
create procedure HOC_VIEN_LIST_MAHV
as
select MaHocVien from HOC_VIEN