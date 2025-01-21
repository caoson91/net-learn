CREATE DATABASE app2;
go

USE app2;
go

  CREATE TABLE Cat(
	[Id] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[ParentId] [int] NULL,
	[Status] [int] NULL
) ON [PRIMARY];
go

  delete from cat where id = 9;
  insert into Cat values(9, 'cat9', null, 0);