 

 DECLARE @TableName VARCHAR(MAX) = 'bankbranch' -- Replace 'tablename' with your table name
    DECLARE @NameSpace VARCHAR(MAX) = 'namespace' -- Replace 'namespace' with your class namespace
    DECLARE @TableSchema VARCHAR(MAX) = 'rma' -- Replace 'dbo' with your schema name
    DECLARE @result varchar(max) = ''

    SET @result = @result + 'using System;' + CHAR(13)
    SET @result = @result + 'using System.ComponentModel.DataAnnotations;' + CHAR(13) + CHAR(13) 

    IF (@TableSchema IS NOT NULL) 
    BEGIN
        SET @result = @result + 'namespace ' + @NameSpace  + CHAR(13) + '{' + CHAR(13) 
    END

    SET @result = @result + 'public class ' + @TableName + CHAR(13) + '{' + CHAR(13) 

    SET @result = @result + '#region Instance Properties' + CHAR(13)  

    SELECT @result = @result + CHAR(13)     
        + ' [Display(Name = "' + ColumnName + '")] ' + CHAR(13) 
        + CASE bRequired WHEN 'NO' 
        THEN 
        CASE WHEN Len(MaxLen) > 0 THEN ' [Required, StringLength(' + MaxLen + ')]' + CHAR(13) ELSE ' [Required] ' + CHAR(13)  END   
        ELSE
        CASE WHEN Len(MaxLen) > 0 THEN ' [StringLength(' + MaxLen + ')]' + CHAR(13) ELSE '' END  
        END
        + ' public ' + ColumnType + ' ' + ColumnName + ' { get; set; } ' + CHAR(13) 
    FROM
    (
        SELECT  c.COLUMN_NAME   AS ColumnName 
            , CASE c.DATA_TYPE   
                WHEN 'bigint' THEN
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Int64?' ELSE 'Int64' END
                WHEN 'binary' THEN 'Byte[]'
                WHEN 'bit' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Boolean?' ELSE 'Boolean' END            
                WHEN 'char' THEN 'String'
                WHEN 'date' THEN
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                        
                WHEN 'datetime' THEN
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                        
                WHEN 'datetime2' THEN  
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                        
                WHEN 'datetimeoffset' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'DateTimeOffset?' ELSE 'DateTimeOffset' END                                    
                WHEN 'decimal' THEN  
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                    
                WHEN 'float' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Single?' ELSE 'Single' END                                    
                WHEN 'image' THEN 'Byte[]'
                WHEN 'int' THEN  
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Int32?' ELSE 'Int32' END
                WHEN 'money' THEN
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                
                WHEN 'nchar' THEN 'String'
                WHEN 'ntext' THEN 'String'
                WHEN 'numeric' THEN
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                            
                WHEN 'nvarchar' THEN 'String'
                WHEN 'real' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Double?' ELSE 'Double' END                                                                        
                WHEN 'smalldatetime' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                                    
                WHEN 'smallint' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Int16?' ELSE 'Int16'END            
                WHEN 'smallmoney' THEN  
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                                        
                WHEN 'text' THEN 'String'
                WHEN 'time' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'TimeSpan?' ELSE 'TimeSpan' END                                                                                    
                WHEN 'timestamp' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                                    
                WHEN 'tinyint' THEN 
                    CASE C.IS_NULLABLE
                        WHEN 'YES' THEN 'Byte?' ELSE 'Byte' END                                                
                WHEN 'uniqueidentifier' THEN 'Guid'
                WHEN 'varbinary' THEN 'Byte[]'
                WHEN 'varchar' THEN 'String'
                ELSE 'Object'
            END AS ColumnType,
                c.IS_NULLABLE AS bRequired,
                CASE c.DATA_TYPE             
                WHEN 'char' THEN  CONVERT(varchar(10),c.CHARACTER_MAXIMUM_LENGTH)
                WHEN 'nchar' THEN  CONVERT(varchar(10),c.CHARACTER_MAXIMUM_LENGTH)
                WHEN 'nvarchar' THEN  CONVERT(varchar(10),c.CHARACTER_MAXIMUM_LENGTH)
                WHEN 'varchar' THEN  CONVERT(varchar(10),c.CHARACTER_MAXIMUM_LENGTH)
                ELSE ''
            END AS MaxLen,
            c.ORDINAL_POSITION 
    FROM    INFORMATION_SCHEMA.COLUMNS c
    WHERE   c.TABLE_NAME = @TableName and ISNULL(@TableSchema, c.TABLE_SCHEMA) = c.TABLE_SCHEMA  
    ) t
    ORDER BY t.ORDINAL_POSITION

    SET @result = @result + CHAR(13) + '#endregion Instance Properties' + CHAR(13)  

    SET @result = @result  + '}' + CHAR(13)

    IF (@TableSchema IS NOT NULL) 
    BEGIN
        SET @result = @result + CHAR(13) + '}' 
    END

    PRINT @result