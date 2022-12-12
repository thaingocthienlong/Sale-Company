create database pharmacy

create table users(
id int identity (1,1) primary key,
userRole varchar(50) not null,
name varchar(250) not null, 
dob varchar(250) not null, 
mobile bigint not null, 
email varchar(250) not null, 
username varchar(250) unique not null,
pass varchar(250) not null
)

userRole,name, dob, mobile, email,username, pass

select * from users