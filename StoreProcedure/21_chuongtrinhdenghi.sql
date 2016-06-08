create
 procedure CHUONG_TRINH_HOC_DENGHI
(
	@MaChiTietTXL varchar(15),
	@MaHV varchar(15)
)
as
if (select CHI_TIET_THI_XL.ChuongTrinhMongMuon as MaCTMuonHoc from CHI_TIET_THI_XL
where CHI_TIET_THI_XL.MaThiXepLop = @MaChiTietTXL
and CHI_TIET_THI_XL.MaHV = @MaHV) != ''

	
	select Table_CacChuongTrinhPhuHop.MaCTHoc as MaCTHoc from
	(
		select CHUONG_TRINH_HOC.MaCTHoc as MaCTHoc From CHUONG_TRINH_HOC where CHUONG_TRINH_HOC.MaTrinhDo in
		(
			select top(1) CHUONG_TRINH_HOC.MaTrinhDo from CHUONG_TRINH_HOC where CHUONG_TRINH_HOC.DiemSoToiThieu > 
			(
			select CHI_TIET_THI_XL.KetQuaThi from CHI_TIET_THI_XL where CHI_TIET_THI_XL.MaThiXepLop = @MaChiTietTXL 
			and CHI_TIET_THI_XL.MaHV = @MaHV
			) 
			and 
			CHUONG_TRINH_HOC.MaCTHoc like 'TOEI%' order by CHUONG_TRINH_HOC.DiemSoToiThieu asc
		)
	) as Table_CacChuongTrinhPhuHop
	where Table_CacChuongTrinhPhuHop.MaCTHoc like 
	(
	select top(1)
	 SUBSTRING(Table_CTMuonHoc.MaCTMuonHoc, 0, CHARINDEX('.', Table_CTMuonHoc.MaCTMuonHoc)) + '%'
	  from 
	(select CHI_TIET_THI_XL.ChuongTrinhMongMuon as MaCTMuonHoc from CHI_TIET_THI_XL
	where CHI_TIET_THI_XL.MaThiXepLop = @MaChiTietTXL
	and CHI_TIET_THI_XL.MaHV =@MaHV) as Table_CTMuonHoc
	)

else
 
 select Table_CacChuongTrinhPhuHop.MaCTHoc as MaCTHoc from
	(
		select CHUONG_TRINH_HOC.MaCTHoc as MaCTHoc From CHUONG_TRINH_HOC where CHUONG_TRINH_HOC.MaTrinhDo in
		(
			select top(1) CHUONG_TRINH_HOC.MaTrinhDo from CHUONG_TRINH_HOC where CHUONG_TRINH_HOC.DiemSoToiThieu > 
			(
			select CHI_TIET_THI_XL.KetQuaThi from CHI_TIET_THI_XL where CHI_TIET_THI_XL.MaThiXepLop = @MaChiTietTXL
			and CHI_TIET_THI_XL.MaHV = @MaHV
			) 
			and 
			CHUONG_TRINH_HOC.MaCTHoc like 'TOEI%' order by CHUONG_TRINH_HOC.DiemSoToiThieu asc
		)
	) as Table_CacChuongTrinhPhuHop
