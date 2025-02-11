MyOfficeAPI Backend Exam

環境需求
- .NET 8.0
- SQL Server 2022
- Entity Framework Core 9.0.1

安裝步驟
1. Clone 此專案：
   
   git clone https://github.com/qwe0088978/BackendExam.git
   cd BackendExam
   
2.還原資料庫
在 SQL Server Management Studio (SSMS) 內，執行：

RESTORE DATABASE MyOfficeDB
FROM DISK = 'C:\Path\To\MyOfficeDB.bak'
WITH MOVE 'MyOfficeDB_Data' TO 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyOfficeDB.mdf',
     MOVE 'MyOfficeDB_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyOfficeDB.ldf',
     REPLACE
     
3.更新 appsettings.json 內的 SQL 連線字串

"ConnectionStrings": {
   "DefaultConnection": "Server=YOUR_SERVER;Database=MyOfficeDB;Trusted_Connection=True;"
}

4.執行專案

dotnet ef database update
dotnet run

5.使用 Swagger 測試 API
啟動專案後，打開 http://localhost:5107/swagger 來測試 CRUD API。
