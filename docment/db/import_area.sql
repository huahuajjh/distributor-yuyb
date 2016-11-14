--USE distributor_ly2
--go
--
--import csv file into table
bulk insert [dbo].[Area]
from 'E:\projects\distributor-yuyb\docment\db\areas.csv'
with(firstrow=2,fieldterminator=',',rowterminator='\n')