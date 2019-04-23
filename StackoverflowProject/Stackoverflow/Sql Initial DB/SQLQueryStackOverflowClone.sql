create database StackOverFlowDatabase
go

use StackOverFlowDatabase
go

create table Categories(
CategoryID int primary key identity(1,1),
CategoryName nvarchar(max))
go

create table Users(
UserID int primary key identity(1,1),
Email nvarchar(max),
PasswordHash nvarchar(max),
Name nvarchar(max),
Mobile nvarchar(max),
IsAdmin bit default(0))
go

create table Questions(
QuestionID int primary key identity(1,1),
QuestionName nvarchar(max),
QuestionDateAndTime datetime,
UserID int references Users(UserID) on delete cascade,
CategoryID int references Categories(CategoryID)on delete cascade,
VotesCount int,
AnwsersCount int,
ViewsCount int)
go

create table Answers(
AnswerID int primary key identity(1,1),
AnswerText nvarchar(max),
AnswerDateAndTime datetime,
userID int references Users(UserID),
QuestionId int references Questions(QuestionID) on delete cascade,
VotesCount int)
go

Create table Votes(
VoteID int primary key identity(1,1),
UserId int references Users(UserID),
Anweser int references Answers(AnswersID) on delete cascade,
VoteValue int)
go

use StackOverFlowDatabase
go

insert into Users values ('darkogele@hotmail.com', 'E823A44ACA1EDDA7551208A4C1C1559F61D30A821862B311DF3A76AB2B901BCE','AdminDarko','070806508',1)
go
insert into Users values('darkogele23@gmail.com','FE79E0AC4B7DB16D59A67BE682F0C2E85E24241CCCBB7A6303446E7105362BCC','UserDarko','070806508',0)
go

insert into Categories values('HTMl')
go
insert into Categories values('CSS')
go
insert into Categories values('JavaScript')
go

insert into Questions values('How to display icon in the browser titlebar using HTML','2018-8-2 10:03 am', 2,1,0,0,0)
go
insert into Questions values('How to set background image css','2019-2-2 1:23 am', 2,2,0,0,0)
go