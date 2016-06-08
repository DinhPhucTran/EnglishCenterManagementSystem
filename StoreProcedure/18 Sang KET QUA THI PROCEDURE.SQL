USE QL_ANHNGU
go
create procedure KET_QUA_THI_HOC_VIEN(@fromDate as smalldatetime, @toDate as smalldatetime) 
as
select hv.MaHocVien,hv.TenHocVien, hv.NgaySinh,hv.Phai, hv.DiaChi, hv.SoDT,hv.MaCTDaHoc,hv.MaCTMuonHoc ,hv.MaTDDaHoc, hv.MaTDMuonHoc, hv.Email,
		ct.MaThiXepLop, ct.KetQuaThi, ct.ChuongTrinhDeNghi, ct.ChuongTrinhMongMuon, txl.MaPhong, txl.CaThi, txl.MaDeThi, txl.NgayThi
from HOC_VIEN hv,CHI_TIET_THI_XL ct, THI_XEP_LOP txl
where hv.MaHocVien = ct.MaHV and txl.MaThiXL = ct.MaThiXepLop 
and hv.MaHocVien not in (select MaHV from LOP_HOC lh, CHI_TIET_LOP_HOC ctlh where lh.MaLop = ctlh.MaLopHoc) 
and txl.NgayThi>=@fromDate and txl.NgayThi <=@toDate;
