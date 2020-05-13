DROP TABLE IF EXISTS avto.UserTruck;



alter table avto.Truck
ADD UserId BIGINT FOREIGN KEY REFERENCES avto.Users(Id) ON DELETE CASCADE ON UPDATE CASCADE

update avto.Truck
set UserId=5
where Id=1 

update avto.Truck
set UserId=5
where Id=3

update avto.Truck
set UserId=5
where Id=11 

update avto.Truck
set UserId=6
where Id=2

update avto.Truck
set UserId=6
where Id=5

update avto.Truck
set UserId=6
where Id=11


select
	u.Email,
	t.Brand
from 
	avto.Users u
join avto.Truck t on t.UserId=u.Id



select * from avto.Truck

update avto.Truck
set Brand='MAN' 
where Brand='MAN_SE'

update avto.Truck
set Brand='SCANIA' 
where Brand='SCANIA_AB'