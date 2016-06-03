select MaPhong from LOP_HOC where LOP_HOC.MaLop in
(
select MaLop from LOP_HOC Where ThoiGianKT>= @ThoiGianBD and ThoiGianBD <= ''
)