create procedure USER_ISEXIST
(
	@mUsername varchar(100),
	@mPassword varchar(100)
)
as
select COUNT(*) from mUSER where mUSER.mUsername = @mUsername 
and mUSER.mPassword = @mPassword