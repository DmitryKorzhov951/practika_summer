-- =====================================================
-- Починка прав доступа к существующей БД CarRentalDB.
-- Не удаляет данные. Даёт текущей Windows-учётке
-- (под которой запущен SSMS) полный доступ к БД.
-- =====================================================
-- Запускать в SSMS под той же Windows-учёткой,
-- под которой работает Visual Studio.

USE master;
GO

-- 1. Покажем текущего пользователя - убедись, что это та учётка,
--    под которой ты запускаешь Visual Studio:
SELECT SUSER_SNAME() AS [Current Windows User];

-- 2. Состояние БД (должно быть ONLINE / MULTI_USER):
SELECT name, state_desc, user_access_desc
FROM sys.databases WHERE name = 'CarRentalDB';
GO

-- 3. Если БД в SINGLE_USER - выводим в MULTI_USER
ALTER DATABASE CarRentalDB SET MULTI_USER WITH ROLLBACK IMMEDIATE;
GO

-- 4. Если БД OFFLINE - поднимаем
ALTER DATABASE CarRentalDB SET ONLINE;
GO

-- 5. Меняем владельца БД на sa (освобождаем dbo)
ALTER AUTHORIZATION ON DATABASE::CarRentalDB TO sa;
GO

-- 6. Создаём LOGIN текущей Windows-учётки, если его нет
DECLARE @user NVARCHAR(255) = SUSER_SNAME();
IF SUSER_ID(@user) IS NULL
BEGIN
    DECLARE @sql NVARCHAR(MAX) = N'CREATE LOGIN [' + @user + N'] FROM WINDOWS';
    EXEC sp_executesql @sql;
    PRINT 'LOGIN создан: ' + @user;
END
ELSE
    PRINT 'LOGIN уже существует: ' + @user;
GO

-- 7. Даём этому LOGIN'у роль sysadmin (для учебного проекта удобно)
DECLARE @user NVARCHAR(255) = SUSER_SNAME();
DECLARE @sql NVARCHAR(MAX) = N'ALTER SERVER ROLE sysadmin ADD MEMBER [' + @user + N']';
BEGIN TRY EXEC sp_executesql @sql; END TRY BEGIN CATCH END CATCH;
GO

-- 8. Создаём USER внутри БД и даём роль db_owner
USE CarRentalDB;
GO

DECLARE @user NVARCHAR(255) = SUSER_SNAME();
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @user)
BEGIN
    DECLARE @sql NVARCHAR(MAX) = N'CREATE USER [' + @user + N'] FOR LOGIN [' + @user + N']';
    EXEC sp_executesql @sql;
    PRINT 'USER создан в БД: ' + @user;
END
ELSE
    PRINT 'USER уже существует в БД: ' + @user;

DECLARE @sql2 NVARCHAR(MAX) = N'ALTER ROLE db_owner ADD MEMBER [' + SUSER_SNAME() + N']';
BEGIN TRY EXEC sp_executesql @sql2; END TRY BEGIN CATCH END CATCH;
GO

PRINT '=== Готово. Запускай приложение. ===';
