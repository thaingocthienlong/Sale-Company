create table medic(

id int identity (1,1) primary key,

mid varchar(250) not null,

mname varchar(250) not null,

mnumber varchar(250) not null,

mDate varchar(250) not null,

eDate varchar(250) not null,

quantity bigint not null,

perUnit bigint not null,

sold bigint not null

);

select * from medic