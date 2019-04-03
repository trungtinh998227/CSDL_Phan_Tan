select LastName,FirstName from Employees

declare contro scroll cursor for
select LastName,FirstName from Employees

open contro

fetch first from contro
fetch absolute 6 from contro
fetch next from contro
fetch last from contro
fetch relative -4 from contro
fetch prior from contro

close contro
deallocate contro