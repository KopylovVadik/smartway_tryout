CREATE TABLE Department
(
id int NOT NULL IDENTITY(1,1),
name text,
phone text,
PRIMARY KEY (id)
);

CREATE TABLE Passport
(
id int NOT NULL IDENTITY(1,1),
type text,
number int,
PRIMARY KEY (id)
);




CREATE TABLE Employees
(
   id int NOT NULL IDENTITY(1,1),
   name text,
   surname text,
   phone text,
   company_id int NOT NULL,
   passport_id int NOT NULL,
   PRIMARY KEY (id),
   FOREIGN KEY (passport_id) REFERENCES Passport (id) ON DELETE CASCADE
);










INSERT INTO Department(name,phone) VALUES ('development','554391');
INSERT INTO Passport(type,number) VALUES ('пасспорт',5612);
INSERT INTO Employees (name,surname,phone,company_id,passport_id) VALUES ('Иван','Иванов','+77775432',1,1);