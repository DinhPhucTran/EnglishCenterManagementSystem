create table mPERMISSION
(
	mIdPermission varchar(15) primary key,
	mNamePermission nvarchar(50)
)

create table mUSER
(
	mUsername varchar(100) primary key,
	mPassword varchar(100),
	mPermission varchar(15),
	constraint FK_USER_PERMISSION foreign key (mPermission) references mPermission(mIdPermission)
)

create table mTABMANAGER
(
	mIdTab varchar(15) primary key,
	mNameTab varchar(50)
)

create table mDETAIL_PERMISSION
(
	mIdPermission varchar(15),
	mIdTab varchar(15),
	constraint FK_DETAIL_PERMISSION foreign key (mIdPermission) references mPermission(mIdPermission),
	constraint FK_DETAIL_TABMANAGER foreign key (mIdTab) references mTabManager(mIdTab),
	constraint PK_DETAIL primary key (mIdPermission, mIdTab)
)



Insert into mPERMISSION values ('GV', N'Giảng viên')
Insert into mPERMISSION values ('HV', N'Học vụ')
Insert into mPERMISSION values ('NVTV', N'Nhân viên tư vấn')

Insert into mUSER values ('a', '123', 'GV')
Insert into mUSER values ('b', '123', 'HV')
Insert into mUSER values ('c', '123', 'NVTV')

Insert into mTABMANAGER values ('QL_HV', 'tab_QLHV')
Insert into mTABMANAGER values ('QL_LH', 'tab_QLLH')
Insert into mTABMANAGER values ('QL_KH', 'tab_QLKH')
Insert into mTABMANAGER values ('QL_THI', 'tab_QLTHi')

Insert into mDETAIL_PERMISSION values ('GV', 'QL_HV')
Insert into mDETAIL_PERMISSION values ('GV', 'QL_LH')
Insert into mDETAIL_PERMISSION values ('HV', 'QL_KH')
Insert into mDETAIL_PERMISSION values ('HV', 'QL_THI')
Insert into mDETAIL_PERMISSION values ('HV', 'QL_HV')