use DotNetMilos

create table Drzave
(
id int primary key identity (1,1),
naziv nvarchar(20)
);

create table Prvenstva
(
naziv nvarchar(50),
godinaOdrzavanja int,
drzavaDomacin int,
drzavaOsvajac int,
foreign key(drzavaDomacin) references Drzave(id),
foreign key(drzavaOsvajac) references Drzave(id)
);
