create procedure USER_CHECK_USERNAME
(
	@mUserName varchar(100)
)
as
select * from mUSER where mUSER.mUsername = @mUserName