fix sql:  -> add data trong link: 
https://docs.google.com/spreadsheets/d/1AKIx7_Wdlfe6P1_aKczUjd34mm6_wsMksL_gNGPmbYQ/edit#gid=0

alter table mTabManager
alter column mNameTab nvarchar(100)


alter table mDetail_permission
drop constraint FK_DETAIL_TABMANAGER
--delete

alter table mTabManager
drop constraint PK__mTABMANA__8F7EB6BC23C0F652


alter table mTabManager
alter column mIdTab nvarchar(100) not null

alter table mTabManager
add constraint PL_TABMANAGER primary key (mIdTab)

alter table mDetail_permission
drop constraint PK_DEtail 

alter table mDetail_Permission
alter column mIdTab nvarchar(100) not null

alter table mDetail_Permission
add constraint FK_DETAIL_TABMANAGER foreign key (mIdTab) references mTabMANAGER(mIdTab)

alter table mDetail_Permission
add constraint PK_DETAIL primary key (mIdPermission, mIdTab)

