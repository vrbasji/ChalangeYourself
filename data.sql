insert into AspNetRoles(id,name) values (1,'user');
insert into AspNetRoles(id,name) values (2,'admin');

insert into interests values ('Sport');
insert into interests values ('Adrenalin');
insert into interests values ('Jídlo');
insert into interests values ('Párty');
insert into interests values ('Pití');
insert into interests values ('Příroda');
insert into interests values ('Auta');
insert into interests values ('Cestování');
insert into interests values ('Lezení');
insert into interests values ('Plavání');
insert into interests values ('Počítače');

insert into Sponsors values ('Alza','alza@info.cz');

INSERT INTO [dbo].[Chalanges]
           ([Name]
           ,[Description]
           ,[PublishDate]
           ,[StartDate]
           ,[EndDate]
           ,[Active]
           ,[ThumbnailUrl]
           ,[Difficulty]
           ,[MinAge]
           ,[MaxAge]
           ,[SponsorInfo_SponsorId])
     VALUES
           ('Test name2'
           ,'Test description 2'
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,'Content\Photos\Chalanges\first.jpg'
           ,1
           ,10
           ,50
           ,1)
