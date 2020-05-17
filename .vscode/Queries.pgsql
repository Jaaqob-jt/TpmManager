INSERT INTO "Machines" ("Name", "Location", "Type", "DateOfInstallation", "Description", "Status", "Cost", "MediaConnected")
VALUES
('Telewizor Samsung','Salon','RTV','20-04-2020','55 cali, ze smuga','OK','100','{"Prad","Antena","Internet Wi-fi"}');

Select * from "Machines";

INSERT INTO "Posts" ("MachineId", "Type", "Content", "Author", "CreationDate")
VALUES
('2','Instalacja','Zamontowano na scianie salonu przy pomocy kolkow molly 10mm na stelazu','Jakub','Now()');

Select * From "Posts";

Update "Posts"
SET "MachineId" = '3';


INSERT INTO "Posts" ("MachineId", "Type", "Content", "Author", "CreationDate")
VALUES
('2','Instalacja','Zamontowano w miejscu starej zmywarki i doklejono stare drzwi na nowym stelazu','Jakub','Now()');
