USE pubs
GO
DECLARE authors_cursor CURSOR FOR
SELECT au_lname FROM authors
WHERE au_lname LIKE 'D%'
ORDER BY au_lname

OPEN authors_cursor

FETCH NEXT FROM authors_cursor

WHILE @@FETCH_STATUS = 0
BEGIN
   FETCH NEXT FROM authors_cursor
END

CLOSE authors_cursor
DEALLOCATE authors_cursor
GO
