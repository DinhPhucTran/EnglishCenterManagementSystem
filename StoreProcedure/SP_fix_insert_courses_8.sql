USE [QL_ANHNGU]
GO
/****** Object:  StoredProcedure [dbo].[CHUONG_TRINH_HOC_INSERT]    Script Date: 5/28/2016 8:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CHUONG_TRINH_HOC_INSERT] (@MaCTHoc AS VARCHAR(15) ,@TenCTHoc AS NVARCHAR(100) ,@MaTrinhDo AS VARCHAR(15) ,@DiemSoToiThieu AS FLOAT ,@DiemSoToiDa AS FLOAT ) AS INSERT INTO CHUONG_TRINH_HOC ( 
[MaCTHoc],[TenCTHoc],[MaTrinhDo],[DiemSoToiThieu],[DiemSoToiDa] ) VALUES ( 
@MaCTHoc,@TenCTHoc,@MaTrinhDo,@DiemSoToiThieu,@DiemSoToiDa)
