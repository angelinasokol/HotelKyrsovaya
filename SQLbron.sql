
CREATE TABLE bron (
id_bron int IDENTITY(1, 1) NOT NULL, 
id int NOT NULL,
id_visitor int NOT NULL,
datazaezd DATE NOT NULL,
dataexit DATE NOT NULL,
PRIMARY KEY(id_bron), 
);