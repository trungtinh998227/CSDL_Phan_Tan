declare c1 cursor for select FirstName from Northwind.dbo.Employees
declare c2 cursor for select LastName from Northwind.dbo.Employees
open c1
open c2


declare @contro cursor
exec sp_cursor_list @cursor_return=@contro output,@cursor_scope=3


fetch next from @contro
while @@fetch_status=0
begin
	fetch next from @contro
end

close @contro
deallocate @contro

close c1
close c2
deallocate c1
deallocate c2