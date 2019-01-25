# Job Hours Tracking Program


This will allow a user to track and accumulate his/her job hours and keep track of total hours worked to date. 


There are some features and buttons that the user will need to know. 

On the main form, there is a Clock in, Break, Back from Break, and Clock out button available on the program. These are pretty straightforward, when you press Clock out, the total hours worked that shift is now added to the total hours worked to date. 

Clear All Button: will clear all user data including the current shift 

This includes:

Total work to Date, Total hours worked this shift. 


Manually enter hours button: This allows the user to manually input hours into the program, adding them into the total hours worked to date. For example, if the user has worked a week prior to tracking their job hours, then they could enter all of the hours missed so far. 

			





    Manual Hour Entry Form:

This is pretty straightforward:

Enter the time you started your shift to the time you stopped working, either a break or a clock out. For example, if you worked from 8:00 AM, then took a break at 10:15, then you would enter ‘8’ or ‘08’ for ‘hh’ and ‘0’ or ‘00’ for mm. You would do the same for the second time, only in the right two boxes. Once you have the 2 times inputted, press ‘Add’ to store these values to the job tracker. Rinse and repeat until you have all of the times you want entered. Press “Log Hours” to log them in the program and increment the total hours worked to date. If you make a mistake and want to re-enter the hours again, pressing ‘clear’ will start the manual entry over and you can re-enter the hours again. 


Lastly, don’t delete or modify “AccumulatorLog.txt”. This is the file that holds the tracker information to log the hours worked. If deleted, the program has nothing to retrieve data from.


Possible future Updates and Additions: 

1. Multiple profiles so that more than one person can use the program. 
2. A “version control” system where if the user inputs the time wrong or forgets to clock in/out, then they can go back and make the changes that are necessary. 
3. Have the user be able to track total hours worked for each day of the week, plus averages of a specific day of the week, week of a month, possibly month of a year
4. A server where every user input will be stored in a database. This information can be used to find totals and averages of multiple stats including:

-How many people work on a certain day of the week and the number of hours they work

-What week do people like working the most

-Average break time 

-Average shift time

-Etc.







 
