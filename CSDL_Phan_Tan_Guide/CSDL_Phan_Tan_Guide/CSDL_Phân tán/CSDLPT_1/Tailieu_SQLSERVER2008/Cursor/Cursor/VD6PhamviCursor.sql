
USE pubs
GO
CREATE PROCEDURE MoCursor
AS
	DECLARE SampleCrsr CURSOR FOR
	SELECT au_lname
	FROM authors
	WHERE au_lname LIKE 'S%'
	
	OPEN SampleCrsr
GO

CREATE PROCEDURE DocCursor
AS
	FETCH NEXT FROM SampleCrsr
	WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	   FETCH NEXT FROM SampleCrsr
	END
GO

EXEC MoCursor 
EXEC DocCursor
Deallocate SampleCrsr