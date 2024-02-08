create database connection
use connection

create table Fils(
[ID] [int] IDENTITY(1,1) NOT NULL,
NAME nvarchar(MAX),
ZANR nvarchar(50),
YEAR nvarchar(50),
TIME nvarchar(MAX),
OPIS nvarchar(MAX),
IMAGE varbinary(MAX),
OG int
)
create table Comm(
LOGIN varchar(50),
NAME varchar(50),
KOMMENT varchar(50)
)
create table Izbrannoe
(
[ID] [int] IDENTITY(1,1) NOT NULL,
Login nvarchar(MAX),
Name nvarchar(MAX),
Zanr nvarchar(MAX),
Image varbinary(MAX)
)

create table User
(
[ID] [int] IDENTITY(1,1) NOT NULL,
LOGIN nvarchar(50),
PASSWORD nvarchar(50)
)