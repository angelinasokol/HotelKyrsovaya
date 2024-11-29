
CREATE TABLE room (
id int IDENTITY(1, 1) NOT NULL,
kind_room varchar(20) NOT NULL,
name_room varchar(20) NOT NULL,
count_room int NOT NULL,
money_room int  NOT NULL,
style_room varchar(20) NOT NULL,
PRIMARY KEY(id)
)
