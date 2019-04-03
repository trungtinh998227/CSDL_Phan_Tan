use Northwind
DECLARE contro cursor for
select * from Customers
open contro
fetch next from contro
insert into Customers values('54321','ProNet',null,null,null,null,null,null,null,null,null)
close contro
deallocate contro
select * from Customers