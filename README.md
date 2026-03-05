Download repository, run the backend solution file by downloading C# ASP.NET extension in VSCode and running debugger with launch option C#
Set the localhost:<port> settings in appsettings.json and build solution file using VSCode to run the backend

Database is migrated using ef and schema can be seen in SharingVision.Api/Models folder and will automatically insert into local database using following command

`dotnet ef database update` to commit changes in pending migrations table

password for DB is localhost user root, made in mysql.
