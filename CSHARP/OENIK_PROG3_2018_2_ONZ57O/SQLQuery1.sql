create table ELHELYEZES(
cellaszam NUMERIC(4),
agy NUMERIC(1),
reszleg VARCHAR(1),
emelet NUMERIC(1),
constraint cellaszam_agy_pk PRIMARY KEY (cellaszam, agy),
constraint emelet_ck CHECK (emelet< 5),
constraint reszleg_ck CHECK (reszleg IN ('A','B','C')),
constraint agy_ck CHECK (agy IN (1,2)) 
);

create table BORTONOR(
bortonor_ID NUMERIC(3),
munka_kezdete DATE,
szuletesi_datum DATE,
szuletesi_hely VARCHAR(25),
nev VARCHAR(30),
jelveny_szam NUMERIC(10) UNIQUE,
constraint bortonor_pk PRIMARY KEY (bortonor_ID)
);

create table BUNTETT(
buntett_ID NUMERIC(5),
letartoztato_szemely VARCHAR(25),
buntett_leiras VARCHAR(50),
aldozat VARCHAR(25),
elkovetes_helye VARCHAR(25),
constraint buntett_pk PRIMARY KEY (buntett_ID)
);

create table ITELET(
itelet_ID NUMERIC(5),
itelet_datuma DATE,
letoltendo_ido NUMERIC(2),
biro VARCHAR(25) NOT NULL,
ugyved VARCHAR(25),
buntett_ID NUMERIC(5),
constraint itelet_pk PRIMARY KEY (itelet_ID),
constraint buntett_fk FOREIGN KEY(buntett_ID) references 
BUNTETT(buntett_ID)
);

create table FEGYENC(
fegyenc_ID NUMERIC(5),
nev VARCHAR(25) NOT NULL,
nem VARCHAR(6),
szuletesi_datum DATE,
szuletesi_hely VARCHAR(20),
letoltesi_ido_kezdete DATE,
itelet_ID NUMERIC(5),
cellaszam NUMERIC(4),
agy NUMERIC(1),
bortonor_ID NUMERIC(3),
constraint fegyenc_pk PRIMARY KEY (fegyenc_ID),
constraint nem_ck CHECK (nem IN ('Férfi','Nő')),
constraint itelet_fk FOREIGN KEY(itelet_ID) references ITELET(itelet_ID),
constraint cellaszam_agy_fk FOREIGN KEY(cellaszam, agy) references ELHELYEZES(cellaszam, agy),
constraint bortonor_fk FOREIGN KEY(bortonor_ID) references BORTONOR(bortonor_ID)
);

insert into ELHELYEZES values (1, 1, 'A', 1);
insert into ELHELYEZES values (11, 2, 'B', 2);
insert into ELHELYEZES values (51, 2, 'A', 3);
insert into ELHELYEZES values (90, 2, 'C', 1);
insert into ELHELYEZES values (5, 2, 'A', 1);
insert into ELHELYEZES values (96, 1, 'A', 4);
insert into ELHELYEZES values (11, 1, 'B', 3);
insert into ELHELYEZES values (56, 1, 'C', 4);
insert into ELHELYEZES values (10, 2, 'B', 3);
insert into ELHELYEZES values (16, 1, 'A', 2);


insert into BORTONOR values (1, Datefromparts(2014,03,26), Datefromparts(1969,05,16),  'New York', 'Tom Harris', 12345);
insert into BORTONOR values (2, Datefromparts(2000,01,31), Datefromparts(1975,08,30), 'New Orleans', 'Stephen King', 12455);
insert into BORTONOR values (3, Datefromparts(1998,03,31), Datefromparts(1955,09,25), 'Quantico', 'Ronald Atkinson', 14515);
insert into BORTONOR values (4, Datefromparts(1980,04,12), Datefromparts(1971,06,01), 'Pheonix', 'Dennis White', 19941);
insert into BORTONOR values (5, Datefromparts(1999,08,26), Datefromparts(1990,04,21), 'Philadelphia', 'Samuel Whitaker', 15584);

insert into BUNTETT values (1, 'Andrew Andrews', 'Nemi erőszak', 'Samantha Jones', 'Detroit');
insert into BUNTETT values (2, 'Poppy Starbucks', 'Emberölés', 'Charles Minnie', 'Detroit');
insert into BUNTETT values (3, 'Sin McDonalds', 'Személyi szabadság megsértése', 'Samantha Harris', 'Philadelphia');
insert into BUNTETT values (4, 'Balzac Cervantes', 'Rendőri korrupció', 'Taylor Justice', 'Dallas');
insert into BUNTETT values (5, 'Miguel Santos', 'Emberölés', 'Aaron Hotchner', 'Austin');
insert into BUNTETT values (6, 'Pepe Garcia', 'Nemi erőszak', 'Penelope Cruz', 'Indianapolis');
insert into BUNTETT values (7, 'Faun Mutte', 'Emberölés', 'Sam Pepper', 'Detroit');
insert into BUNTETT values (8, 'Philip Phillipson', 'Nemi erőszak', 'Poor Marry', 'Seattle');
insert into BUNTETT values (9, 'Poppy Starbucks', 'Állatkínzás', 'Buksi', 'Dallas');
insert into BUNTETT values (10, 'Sin McDonalds', 'Öngyilkosságban közreműködés', 'Samantha Jones', 'Quantico');


insert into ITELET values (1, Datefromparts(2014,03,26), 10, 'Mary Justice', 'Frank Moore', 10); 
insert into ITELET values (2, DATEFROMPARTS(2017,04,30), 3, 'Mary Justice', 'Miriam Frankly', 9); 
insert into ITELET values (3, Datefromparts(2016,01,31), 25, 'Phillip Poppinson', 'George Foyet', 8); 
insert into ITELET values (4, Datefromparts(1990,03,26), 35, 'Francis Atkinson', 'Michael Keaton', 7); 
insert into ITELET values (5, Datefromparts(2004,06,19), 15, 'Marley John', 'Jim Morrison', 6); 
insert into ITELET values (6, Datefromparts(2015,09,30), 4, 'George Washington', 'Sun Fillante', 5); 
insert into ITELET values (7, Datefromparts(2018,07,01), 1, 'Francis Frances', null, 4); 
insert into ITELET values (8, Datefromparts(2015,03,26), 6, 'Marley John', 'Damien Superest', 3); 
insert into ITELET values (9, Datefromparts(2010,03,26), 10, 'Phillip Poppinson', 'Frank Moore', 2); 
insert into ITELET values (10, Datefromparts(2014,03,26), 10, 'Mary Justice', 'Langhorne Slim', 1);

insert into FEGYENC values (1, 'Luis Garavito','Férfi', Datefromparts(1957,01,25), 'Génova', Datefromparts(2005,01,26),5, 1,1, 1);
insert into FEGYENC values (2, 'Gary Ridgway','Férfi', Datefromparts(1969,03,25), 'Dallas', Datefromparts(1990,04,01),4, 11,2, 1);
insert into FEGYENC values (3, 'Ted Bundy','Férfi', Datefromparts(1968,06,25), 'Philadelphia', Datefromparts(2016,02,28),3, 51,2, 2);
insert into FEGYENC values (4, 'John Wayne Gacy','Férfi', Datefromparts(1944,03,11), 'Detroit', Datefromparts(2010,05,12),2, 90,2, 2);
insert into FEGYENC values (5, 'Juana Barraza','Nő', Datefromparts(1969,05,25), 'Detroit', Datefromparts(2014,05,05),1, 5,2, 3);
insert into FEGYENC values (6, 'Juan Vallejo Corona','Férfi', Datefromparts(1955,11,30), 'Quantico', Datefromparts(2015,10,20),6, 96,1, 3);
insert into FEGYENC values (7, 'Kiss Béla','Férfi', Datefromparts(1985,12,01), 'Seattle', Datefromparts(2015,05,01),10, 11,1, 4);
insert into FEGYENC values (8, 'Ronald Dominique','Férfi', Datefromparts(1980,12,25), 'New Orleans', Datefromparts(2010,03,31),9, 56,1, 4);
insert into FEGYENC values (9, 'Earle Nelson','Férfi', Datefromparts(1949,07,12), 'New York', Datefromparts(2016,05,01),8, 10,2, 3);
insert into FEGYENC values (10, 'Aieleen Wuornos','Nő', Datefromparts(1959,04,23), 'New Jersey', Datefromparts(2018,08,12),7, 16,1, 5);
