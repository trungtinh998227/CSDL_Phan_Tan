/* tao SP voi tham so OUTPUT la kieu Cursor */
CREATE PROCEDURE OpenCrsr @OutCrsr CURSOR VARYING OUTPUT AS

SET @OutCrsr = CURSOR FOR
SELECT au_lname
FROM authors
WHERE au_lname LIKE 'S%'

OPEN @OutCrsr
GO

/* Khai bao cursor */
DECLARE @CrsrVar CURSOR

/* Thuc hien SP voi tham so output la kieu cursor */
EXEC OpenCrsr @OutCrsr = @CrsrVar OUTPUT

/* truy suat du lieu dung cursor */
FETCH NEXT FROM @CrsrVar
WHILE (@@FETCH_STATUS <> -1)
BEGIN
   FETCH NEXT FROM @CrsrVar
END

CLOSE @CrsrVar

DEALLOCATE @CrsrVar
GO
