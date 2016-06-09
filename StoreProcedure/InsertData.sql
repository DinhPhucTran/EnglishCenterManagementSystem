use QL_ANHNGU

insert into Ca values('1','7:00','9:00')
insert into Ca values('2','9:00','11:00')
insert into Ca values('3','13:00','15:00')
insert into Ca values('4','15:00','17:00')
insert into Ca values('5','17:00','19:00')
insert into Ca values('6','19:00','21:00')



Insert into TRINH_DO values('BEGIN','Beginner')
Insert into TRINH_DO values('ELEMN','Elementary')
Insert into TRINH_DO values('PREIN','Pre-Intermediate')
Insert into TRINH_DO values('INTER','Intermediate')
Insert into TRINH_DO values('UPPER','Upper-Intermediate')
Insert into TRINH_DO values('ADVAN','Advanced')
select * from TRINH_DO

Insert into CHUONG_TRINH_HOC values('IELT.BE','IELTS for Beginner','BEGIN',1,2)
Insert into CHUONG_TRINH_HOC values('TOEI.BE','TOEIC for Beginner','BEGIN',0,150)
Insert into CHUONG_TRINH_HOC values('IELT.EL','IELTS for Elementary','ELEMN',2,3)
Insert into CHUONG_TRINH_HOC values('TOEI.EL','TOEIC for Elementary','ELEMN',151,300)

Insert into CHUONG_TRINH_HOC values('IELT.PR','IELTS Pre-intermediate','PREIN',3,4)
Insert into CHUONG_TRINH_HOC values('TOEF.PR','TOEFL Pre-intermediate','PREIN',0,31)
Insert into CHUONG_TRINH_HOC values('TOEI.PR','TOEIC Pre-intermediate','PREIN',301,400)

Insert into CHUONG_TRINH_HOC values('IELT.IN','IELTS Intermediate','INTER',4,5)
Insert into CHUONG_TRINH_HOC values('TOEF.IN','TOEFL Intermediate','INTER',31,34)
Insert into CHUONG_TRINH_HOC values('TOEI.IN','TOEIC Intermediate','INTER',401,525)

Insert into CHUONG_TRINH_HOC values('IELT.UP','IELTS upper-intermediate','UPPER',5,6)
Insert into CHUONG_TRINH_HOC values('TOEF.UP','TOEFL upper-intermediate','UPPER',35,59)
Insert into CHUONG_TRINH_HOC values('TOEI.UP','TOEIC upper-intermediate','UPPER',526,750)

Insert into CHUONG_TRINH_HOC values('IELT.AD','IELTS Advanced','ADVAN',6,7)
Insert into CHUONG_TRINH_HOC values('TOEF.AD','TOEFL Advanced','ADVAN',60,93)
Insert into CHUONG_TRINH_HOC values('TOEI.AD','TOEIC Advanced','ADVAN',751,900)



Insert into THU values('T2',N'Thứ 2')
Insert into THU values('T3',N'Thứ 3')
Insert into THU values('T4',N'Thứ 4')
Insert into THU values('T5',N'Thứ 5')
Insert into THU values('T6',N'Thứ 6')
Insert into THU values('T7',N'Thứ 7')
Insert into THU values('CN',N'Chủ Nhật')

delete from GIANG_VIEN
Insert into GIANG_VIEN values ('1',N'Phan Nguyệt Minh',N'Quận 1 TPHCM','0969696969')
Insert into GIANG_VIEN values ('2',N'Lê Thanh Trọng',N'Quân 2 TPHCM','0969696969')
Insert into GIANG_VIEN values ('3',N'Nguyễn Thị Nhơn',N'Quân 3 TPHCM','0969696969')
Insert into GIANG_VIEN values ('4',N'Trần Đình Phúc',N'Quận 4 TPHCM','0969696969')


Insert into Phong values('1',N'Phòng 1')
Insert into Phong values('2',N'Phòng 2')
Insert into Phong values('3',N'Phòng 3')
Insert into Phong values('4',N'Phòng 4')
Insert into Phong values('5',N'Phòng 5')
Insert into Phong values('6',N'Phòng 6')
Insert into Phong values('7',N'Phòng 7')
Insert into Phong values('8',N'Phòng 8')
Insert into Phong values('9',N'Phòng 9')
Insert into Phong values('10',N'Phòng 10')
Insert into Phong values('11',N'Phòng 11')
Insert into Phong values('12',N'Phòng 12')
Insert into Phong values('13',N'Phòng 13')

select * from phong



Insert into DE_THI values ('1','TOEIC',N'Đề thi xếp lớp TOEIC')
Insert into DE_THI values ('2','TOEFL',N'Đề thi xếp lớp TOEFL')
Insert into DE_THI values ('3','IELTS',N'Đề thi xếp lớp IELTS')

insert into LOP_HOC values('PR2016.1', '2016-06-01','2016-06-01','2016-08-01',2000000,'1','IELT.PR','1')
insert into LOP_HOC values('PR2016.2', '2016-06-01','2016-06-01','2016-08-01',2000000,'1','TOEF.PR','2')
insert into LOP_HOC values('PR2016.3', '2016-06-01','2016-06-01','2016-08-01',2000000,'1','TOEI.PR','3')
insert into LOP_HOC values('IN2016.4', '2016-06-01','2016-06-01','2016-08-01',3000000,'2','IELT.INT','4')
insert into LOP_HOC values('IN2016.5', '2016-06-01','2016-06-01','2016-08-01',3000000,'2','TOEF.INT','5')
insert into LOP_HOC values('IN2016.6', '2016-06-01','2016-06-01','2016-08-01',3000000,'2','TOEI.INT','6')
insert into LOP_HOC values('UP2016.7', '2016-06-01','2016-06-01','2016-08-01',3500000,'3','IELT.UP','7')
insert into LOP_HOC values('UP2016.8', '2016-06-01','2016-06-01','2016-08-01',3500000,'3','TOEF.UP','8')
insert into LOP_HOC values('UP2016.9', '2016-06-01','2016-06-01','2016-08-01',3500000,'3','TOEI.UP','9')
insert into LOP_HOC values('AD2016.10', '2016-06-01','2016-06-01','2016-08-01',4000000,'4','IELT.AD','10')
insert into LOP_HOC values('AD2016.11', '2016-06-01','2016-06-01','2016-08-01',4000000,'4','TOEF.AD','11')
insert into LOP_HOC values('AD2016.12', '2016-06-01','2016-06-01','2016-08-01',4000000,'4','TOEI.AD','12')

select * from LOP_HOC