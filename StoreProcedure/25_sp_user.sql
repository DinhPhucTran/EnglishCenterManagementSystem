--mPERMISSION
Create procedure PERMISSION_LIST
as
select * from mPERMISSION

go

Create procedure PERMISSION_DELETE
(
	@mIdPermission varchar(15)
)
as
delete from mPERMISSION where mPERMISSION.mIdPermission = @mIdPermission

go

Create procedure PERMISSION_INSERT
(
	@mIdPermission varchar(15),
	@mNamePermission nvarchar(50)
)
as
insert into mPERMISSION values (@mIdPermission, @mNamePermission)

go

Create procedure PERMISSION_UPDATE
(
	@mIdPermission varchar(15),
	@mNamePermission nvarchar(50)
)
as
update PERMISSION
set mNamePermission = @mNamePermission
where mIdPermission = @mIdPermission

go

Create procedure USER_LIST
as
select * from mUSER

go

Create procedure USER_DELETE
(
	@username varchar(100)
)
as
delete from mUSER where mUsername = @username

go

Create procedure USER_INSERT
(
	@mUsername varchar(100),
	@mPassword varchar(100),
	@mPermission varchar(15)
)
as
insert into mUSER values (@mUsername, @mPassword, @mPermission)

go

Create procedure USER_UPDATE_PASSWORD
(
	@mUsername varchar(100),
	@mPassword varchar(100)
)
as
update mUSER
set mPassword = @mPassword
where mUsername = @mUsername

go

Create procedure USER_UPDATE_PERMISSION
(
	@mUsername varchar(100),
	@mPermission varchar(15)
)
as
update mUSER
set mPermission = @mPermission
where mUsername = @mUsername

go

Create procedure TABMANAGER_LIST
as
select * from mTABMANAGER

go

Create procedure TABMANAGER_DELETE
(
	@mIdTab varchar(15)
)
as
delete from mTABMANAGER where mIdTab = @mIdTab

go

Create procedure TABMANAGER_INSERT
(
	@mIdTab varchar(15),
	@mNameTab varchar(50)
)
as
insert into mTABMANAGER values (@mIdTab, @mNameTab)

go

Create procedure TABMANAGER_UPDATE
(
	@mIdTab varchar(15),
	@mNameTab varchar(50)
)
as
update mTABMANAGER
set mNameTab = @mNameTab
where mIdTab = @mIdTab

go

--list, delete, insert, update

Create procedure DETAIL_PERMISSION_LIST
as
select * from mDETAIL_PERMISSION

go 

Create procedure DETAIL_PERMISSION_LIST_BY_ID_PERMISSION
(
	@mIdPermission varchar(15)
)
as
select * from mDETAIL_PERMISSION where mIdPermission = @mIdPermission

go

Create procedure DETAIL_PERMISSION_DELETE
(
	@mIdPermission varchar(15),
	@mIdTab varchar(15)
)
as
delete from mDETAIL_PERMISSION where mIdPermission = @mIdPermission and mIdTab = @mIdTab

go

Create procedure DETAIL_PERMISSION_INSERT
(
	@mIdPermission varchar(15),
	@mIdTab varchar(15)
)
as
insert into mDETAIL_PERMISSION values (@mIdPermission, @mIdTab)