use pubs
select * from pubs.dbo.Authors
DECLARE contro cursor for
select * from pubs.dbo.Authors
open contro
fetch next from contro
update Authors set City='DongThap' where au_id='172-32-1176'
close contro
deallocate contro
select * from pubs.dbo.Authors

