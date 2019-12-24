use master;
go

drop database REBUDB
go

create database REBUDB
go

use REBUDB
go

create table Vehicle (
vid int identity primary key,
license nvarchar(20),
make nvarchar(20),
model nvarchar(20),
year int
);

create table passenger (
passid int identity primary key,
username nvarchar(20),
firstname nvarchar(20),
lastname nvarchar(20),
email nvarchar(20),
password nvarchar(20)
);

create table rideavailable(
vid int not null references vehicle(vid),
passid int not null references passenger(passid),
driverusername nvarchar(20),
startdate datetime,
enddate datetime
);

create table rideneeded(
passid int not null references passenger(passid),
username nvarchar(20),
startdate datetime,
enddate datetime
);

select * from sys.tables;



insert into vehicle(license,make,model,year)
values ('7TY8901','Chevy','MonteCarlo','1995');

insert into vehicle(license,make,model,year)
values ('145AY39A','Ford','Dodge','2014');

insert into vehicle(license,make,model,year)
values ('5345ABO9','Toyota','Prius C','2015');

insert into vehicle(license,make,model,year)
values ('HJSI5123','Audi','Q3','2014');

insert into vehicle(license,make,model,year)
values ('123HDFHD3','Mercedes-Benz','G63 AMG','2014');

insert into passenger(username,firstname,lastname,email,password)
values('admin','admin','admin','aeristher@gmail.com','admin');

insert into passenger(username,firstname,lastname,email,password)
values('Jonaz','Jon','Azcona','jonaz@gmail.com','Jonaz');

insert into passenger(username,firstname,lastname,email,password)
values('Rayab','Rayan','Abedin','rayab@gmail.com','Rayab');

insert into passenger(username,firstname,lastname,email,password)
values('Alexab','Alexa','Bachurski','alexab@gmail.com','Alexab');

insert into passenger(username,firstname,lastname,email,password)
values('JamesP','James','Park','jamesp@gmail.com','JamesP');

insert into passenger(username,firstname,lastname,email,password)
values('AaronS','Aaron','Suranofsky','aarons@gmail.com','AaronS');

insert into passenger(username,firstname,lastname,email,password)
values('Aristher','Aristher','Manalaysay','aeristher@gmail.com','Aristher');

insert into rideavailable(vid,driverusername,passid,startdate,enddate)
values('1','DavidN','1','2019-04-25 9:41:00','2019-04-25 10:00');

insert into rideavailable(vid,driverusername,passid,startdate,enddate)
values('2','JoeL','2','2019-04-25 06:12:00','2019-04-25 07:00');

insert into rideavailable(vid,driverusername,passid,startdate,enddate)
values('3','AdrianL','3','2019-04-25 7:18:00','2019-04-25 08:00');

insert into rideavailable(vid,driverusername,passid,startdate,enddate)
values('4','ArleneW','4','2019-04-25 02:12:00','2019-04-25 03:00');

insert into rideavailable(vid,driverusername,passid,startdate,enddate)
values('5','JasonW','5','2019-04-25 9:30:00','2019-04-25 10:00');

insert into rideneeded(passid,username,startdate,enddate)
values ('2','Jonaz','2019-04-25 9:41:00','2019-04-25 10:00');

insert into rideneeded(passid,username,startdate,enddate)
values ('3','Rayab','2019-04-25 06:12:00','2019-04-25 07:00');

insert into rideneeded(passid,username,startdate,enddate)
values ('4','Alexab','2019-04-25 7:18:00','2019-04-25 08:00');

insert into rideneeded(passid,username,startdate,enddate)
values ('5','JamesP','2019-04-25 02:12:00','2019-04-25 03:00');

insert into rideneeded(passid,username,startdate,enddate)
values ('6','AaronS','2019-04-25 9:30:00','2019-04-25 10:00');

insert into rideneeded(passid,username,startdate,enddate)
values ('7','Aristher','2019-04-25 9:41:00','2019-04-25 10:00');

go
create view rideavailablecheck as
select ra.driverusername,v.make,v.model,v.license,ra.startdate,ra.enddate
from vehicle v
join rideavailable ra on ra.vid=v.vid;
go

select * from rideavailablecheck;

go
create view rideneededcheck as
select rn.username,rn.startdate,rn.enddate
from passenger p
join rideneeded rn on rn.passid=p.passid;
go

select * from rideneededcheck;

select * from vehicle;
select * from passenger;
