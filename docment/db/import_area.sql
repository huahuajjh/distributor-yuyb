--import csv file into table
bulk insert [dbo].[Area]
from 'C:\areas.csv'
with(firstrow=2,fieldterminator=',',rowterminator='\n')