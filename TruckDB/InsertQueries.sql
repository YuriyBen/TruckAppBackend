select * from avto.Users

ALTER TABLE avto.Users
add column Role VARCHAR (30) DEFAULT('user');



insert into avto.Users
(FirstName,LastName,Email,PasswordHash,RegistrationToken,DateOfBirth,Sex,Role)
values(
'Yuriy',
'Ben',
'yurben2001@gmail.com',
'hashpass',
'token',
'2001-05-08',
'man',
default
),(
'Nazar',
'Serdiuk',
'serdiuk_naz4418@gmail.com',
'hashpass',
'token',
'2000-10-18',
'man',
default
),(
'Sania',
'Libik',
'lbiksania2000@gmail.com',
'hashpass',
'token',
'2000-11-18',
'man',
default
)

insert into avto.Users
(FirstName,LastName,Email,PasswordHash,RegistrationToken,DateOfBirth,Sex,Role)
values(
'Admin',
'Adminovich',
'adminking@gmail.com',
'hashpass',
'token',
'1999-01-10',
'man',
'admin'
)
