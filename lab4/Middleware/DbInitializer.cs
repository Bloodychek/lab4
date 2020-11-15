using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Middleware
{
    public static class DbInitializer
    {
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static Random random = new Random();

        public static void Initialize(Petrol_StationContext petrol_Station)
        {
            petrol_Station.Database.EnsureCreated();

            int rowCount;

            int rowIndex;

            int minStringLength;

            int maxStringLength;

            if (!petrol_Station.Gsm.Any())

            {

                string typeOfGSM;

                string tTKOfType;

                rowCount = 500;

                rowIndex = 0;

                while (rowIndex < rowCount)

                {

                    minStringLength = 8;

                    maxStringLength = 16;

                    typeOfGSM = GetString(minStringLength, maxStringLength);

                    maxStringLength = 32;

                    tTKOfType = GetString(minStringLength, maxStringLength);

                    petrol_Station.Gsm.Add(new Gsm { TTkofType = tTKOfType, TypeOfGsm = typeOfGSM });

                    rowIndex++;

                }

                petrol_Station.SaveChanges();

            }

            if (!petrol_Station.Staff.Any())

            {
                string fullName;

                int staffAge;

                string staffFunction;

                DateTime workingHoursForAWeek;

                rowCount = 20000;

                rowIndex = 0;

                while (rowIndex < rowCount)

                {
                    minStringLength = 8;

                    maxStringLength = 32;

                    fullName = GetString(minStringLength, maxStringLength);

                    staffAge = random.Next(1, 11);

                    staffFunction = GetString(minStringLength, maxStringLength);

                    workingHoursForAWeek = GetDateTime();

                    petrol_Station.Staff.Add(new Staff

                    {

                        FullName = fullName,

                        StaffAge = staffAge,

                        StaffFunction = staffFunction,

                        WorkingHoursForAweek = workingHoursForAWeek,
                    });

                    rowIndex++;

                }

            }

            if (!petrol_Station.IncomeAndExpensesOfGsm.Any())

            {
                minStringLength = 8;

                maxStringLength = 32;
                
                int numberOfCapacity;

                int incomeOrExpensePerliter;

                DateTime dateAndTimeOfTheOperationIncomeOrExpense;

                string responsibleForTheOperation;

                rowCount = 20000;

                rowIndex = 0;

                while (rowIndex < rowCount)

                {

                    numberOfCapacity = random.Next(1, 8);

                    incomeOrExpensePerliter = random.Next(1, 13);

                    dateAndTimeOfTheOperationIncomeOrExpense = GetDateTime();

                    responsibleForTheOperation = GetString(minStringLength, maxStringLength);

                    petrol_Station.IncomeAndExpensesOfGsm.Add(new IncomeAndExpensesOfGsm

                    {

                        NumberOfCapacity = numberOfCapacity,

                        IncomeOrExpensePerliter = incomeOrExpensePerliter,

                        DateAndTimeOfTheOperationIncomeOrExpense = dateAndTimeOfTheOperationIncomeOrExpense,

                        ResponsibleForTheOperation = responsibleForTheOperation
                    });

                    rowIndex++;

                }

                petrol_Station.SaveChanges();

            }

        }

        private static string GetString(int minStringLength, int maxStringLength)

        {

            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            int stringPosition;

            for (int i = 0; i < stringLimit; i++)

            {

                stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];

            }

            return result;

        }

        private static DateTime GetDateTime()

        {

            DateTime start = new DateTime(1995, 1, 1);

            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));

        }
    }
}
