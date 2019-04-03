use Northwind
CREATE TABLE SV 
(
	MSSV 	INT 	PRIMARY KEY,
	TEN	NVARCHAR(50)	NOT NULL,
	QUE	NVARCHAR(50)	NULL
)
INSERT INTO SV VALUES(1,'Thanh Su','Dong Thap')
INSERT INTO SV VALUES(2,'Tuan Anh','Dak Lak')
select * from SV
declare c1 cursor scroll for select TEN from SV
open c1
fetch last from c1
select @@fetch_status
delete from SV where MSSV=1
fetch first from c1
select @@fetch_status
fetch last from c1
fetch next from c1
select @@fetch_status
close c1
deallocate c1
