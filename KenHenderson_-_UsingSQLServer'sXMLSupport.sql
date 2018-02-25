SELECT bookID, bookTitle
FROM BibleBook
FOR XML RAW
GO

SELECT *
FROM BibleBook
FOR XML AUTO
GO

SELECT bookID, BookTitle
FROM BibleBook
FOR XML AUTO, ELEMENTS
GO