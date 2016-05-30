use QL_ANHNGU

insert into Ca values('1','7:00','9:00')
insert into Ca values('2','9:00','11:00')
insert into Ca values('3','13:00','15:00')
insert into Ca values('4','15:00','17:00')
insert into Ca values('5','17:00','19:00')
insert into Ca values('6','19:00','21:00')



Insert into TRINH_DO values('BEGIN','Beginner')
Insert into TRINH_DO values('ELEM','Elementary')
Insert into TRINH_DO values('PRE','Pre-Intermediate')
Insert into TRINH_DO values('INTER','Intermediate')
Insert into TRINH_DO values('UPPER','Upper-Intermediate')
Insert into TRINH_DO values('ADV','Advanced')


Insert into CHUONG_TRINH_HOC values('IELT.BE','IELTS for Beginner','BEGIN',1,2)
Insert into CHUONG_TRINH_HOC values('TOEI.BE','TOEIC for Beginner','BEGIN',0,150)
Insert into CHUONG_TRINH_HOC values('IELT.EL','IELTS for Elementary','ELEM',2,3)
Insert into CHUONG_TRINH_HOC values('TOEI.EL','TOEIC for Elementary','ELEM',151,300)

Insert into CHUONG_TRINH_HOC values('IELT.PR','IELTS Pre-intermediate','PRE',3,4)
Insert into CHUONG_TRINH_HOC values('TOEF.PR','TOEFL Pre-intermediate','PRE',0,31)
Insert into CHUONG_TRINH_HOC values('TOEI.PR','TOEIC Pre-intermediate','PRE',301,400)

Insert into CHUONG_TRINH_HOC values('IELT.INT','IELTS Intermediate','INTER',4,5)
Insert into CHUONG_TRINH_HOC values('TOEF.INT','TOEFL Intermediate','INTER',31,34)
Insert into CHUONG_TRINH_HOC values('TOEI.INT','TOEIC Intermediate','INTER',401,525)

Insert into CHUONG_TRINH_HOC values('IELT.UP','IELTS upper-intermediate','UPPER',5,6)
Insert into CHUONG_TRINH_HOC values('TOEF.UP','TOEFL upper-intermediate','UPPER',35,59)
Insert into CHUONG_TRINH_HOC values('TOEI.UP','TOEIC upper-intermediate','UPPER',526,750)

Insert into CHUONG_TRINH_HOC values('IELT.AD','IELTS Advanced','ADV',6,7)
Insert into CHUONG_TRINH_HOC values('TOEF.AD','TOEFL Advanced','ADV',60,93)
Insert into CHUONG_TRINH_HOC values('TOEI.AD','TOEIC Advanced','ADV',751,900)



Insert into THU values('T2',N'Thứ 2')
Insert into THU values('T3',N'Thứ 3')
Insert into THU values('T4',N'Thứ 4')
Insert into THU values('T5',N'Thứ 5')
Insert into THU values('T6',N'Thứ 6')
Insert into THU values('T7',N'Thứ 7')
Insert into THU values('CN',N'Chủ Nhật')


Insert into GIANG_VIEN values ('1',N'Phan Nguyệt Minh','Quận 1 TPHCM','0969696969')
Insert into GIANG_VIEN values ('2',N'Lê Thanh Trọng','Quân 2 TPHCM','0969696969')
Insert into GIANG_VIEN values ('3',N'Nguyễn Thị Nhơn','Quân 3 TPHCM','0969696969')
Insert into GIANG_VIEN values ('4',N'Trần Đình Phúc','Quận 4 TPHCM','0969696969')

Insert into Phong values('1','Phòng 1')
Insert into Phong values('2','Phòng 2')
Insert into Phong values('3','Phòng 3')
Insert into Phong values('4','Phòng 4')
Insert into Phong values('5','Phòng 5')


Insert into DE_THI values ('1','TOEIC',N'Đề thi xếp lớp TOEIC')
Insert into DE_THI values ('2','TOEFL',N'Đề thi xếp lớp TOEFL')
Insert into DE_THI values ('3','IELTS',N'Đề thi xếp lớp IELTS')
