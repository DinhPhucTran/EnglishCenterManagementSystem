alter PROCEDURE [DBO].[CHI_TIET_THI_XL_UPDATE] 
	(@MaThiXepLop AS VARCHAR(15) ,@MaHV AS VARCHAR(15) ,@KetQuaThi AS FLOAT ,
	@ChuongTrinhDeNghi AS VARCHAR(15) ,@ChuongTrinhMongMuon AS VARCHAR(15) )
 AS UPDATE CHI_TIET_THI_XL SET 
[MaHV] = @MaHV,[KetQuaThi] = @KetQuaThi,[ChuongTrinhDeNghi] = @ChuongTrinhDeNghi,[ChuongTrinhMongMuon] = @ChuongTrinhMongMuon
 WHERE [MaThiXepLop] = @MaThiXepLop and [MaHV] = @MaHV