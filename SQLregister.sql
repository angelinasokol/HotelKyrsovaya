

create table register(
id_user int identity(1, 1) NOT NULL,
login_user varchar(50) NOT NULL,
password_user varchar(50) NOT NULL,
); 
insert into register (login_user, password_user) values ('admin', 'admin')

select * from register