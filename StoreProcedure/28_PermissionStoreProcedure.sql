--lay permission theo user
create procedure USER_GET_PERMISSION
(
	@mUsername varchar(100),
	@mPassword varchar(100)
)
as
select mUSER.mPermission from mUSER where mUSER.mUsername = @mUsername and mPassword = @mPassword

go

create procedure DETAIL_PERMISSION_GET_TAB
(
	@mIdPermission varchar(15)
)
as
select mDETAIL_PERMISSION.mIdTab from mDETAIL_PERMISSION where mDETAIL_PERMISSION.mIdPermission = @mIdPermission