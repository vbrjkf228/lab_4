using System;

namespace DateApp
{
    struct Date
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public Date(int day, int month, int year)
        {
            if (!IsValidDate(day, month, year))
                throw new ArgumentException("Некоректна дата.");

            Day = day;
            Month = month;
            Year = year;
        }

        public static bool IsValidDate(int day, int month, int year)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            int[] daysInMonth = { 31, IsLeapYear(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return day <= daysInMonth[month - 1];
        }

        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public Date AddDays(int days)
        {
            DateTime dateTime = new DateTime(Year, Month, Day).AddDays(days);
            return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
        }

        public Date SubtractDays(int days)
        {
            DateTime dateTime = new DateTime(Year, Month, Day).AddDays(-days);
            return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
        }

        public static int CompareDates(Date d1, Date d2)
        {
            DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day);
            DateTime date2 = new DateTime(d2.Year, d2.Month, d2.Day);
            return date1.CompareTo(date2);
        }

        public static int DaysBetween(Date d1, Date d2)
        {
            DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day);
            DateTime date2 = new DateTime(d2.Year, d2.Month, d2.Day);
            return Math.Abs((date1 - date2).Days);
        }

        public string ToFormattedString(string format)
        {
            DateTime dateTime = new DateTime(Year, Month, Day);
            return dateTime.ToString(format);
        }

        public override string ToString()
        {
            return $"{Day:D2}.{Month:D2}.{Year}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Ввести дату");
                Console.WriteLine("2. Додати дні до дати");
                Console.WriteLine("3. Відняти дні від дати");
                Console.WriteLine("4. Перевірити, чи рік високосний");
                Console.WriteLine("5. Порівняти дві дати");
                Console.WriteLine("6. Різниця між двома датами у днях");
                Console.WriteLine("7. Вивести дату в іншому форматі");
                Console.WriteLine("0. Вийти");
                Console.Write("Ваш вибір: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Введіть дату (день.місяць.рік): ");
                            string[] input = Console.ReadLine().Split('.');
                            int day = int.Parse(input[0]);
                            int month = int.Parse(input[1]);
                            int year = int.Parse(input[2]);

                            Date date = new Date(day, month, year);
                            Console.WriteLine($"Ви ввели дату: {date}");
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write("Введіть дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            day = int.Parse(input[0]);
                            month = int.Parse(input[1]);
                            year = int.Parse(input[2]);

                            date = new Date(day, month, year);
                            Console.Write("Кількість днів для додавання: ");
                            int daysToAdd = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Нова дата: {date.AddDays(daysToAdd)}");
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("Введіть дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            day = int.Parse(input[0]);
                            month = int.Parse(input[1]);
                            year = int.Parse(input[2]);

                            date = new Date(day, month, year);
                            Console.Write("Кількість днів для віднімання: ");
                            int daysToSubtract = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Нова дата: {date.SubtractDays(daysToSubtract)}");
                            break;

                        case 4:
                            Console.Clear();
                            Console.Write("Введіть рік: ");
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Рік {year} {(Date.IsLeapYear(year) ? "є високосним" : "не є високосним")}");
                            break;

                        case 5:
                            Console.Clear();
                            Console.Write("Введіть першу дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            Date date1 = new Date(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

                            Console.Write("Введіть другу дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            Date date2 = new Date(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

                            int comparison = Date.CompareDates(date1, date2);
                            string comparisonResult = comparison == 0 ? "є однаковою" : (comparison < 0 ? "раніше" : "пізніше");
                            Console.WriteLine($"Перша дата {comparisonResult} другої.");
                            break;

                        case 6:
                            Console.Clear();
                            Console.Write("Введіть першу дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            date1 = new Date(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

                            Console.Write("Введіть другу дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            date2 = new Date(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

                            Console.WriteLine($"Різниця у днях: {Date.DaysBetween(date1, date2)}");
                            break;

                        case 7:
                            Console.Clear();
                            Console.Write("Введіть дату (день.місяць.рік): ");
                            input = Console.ReadLine().Split('.');
                            day = int.Parse(input[0]);
                            month = int.Parse(input[1]);
                            year = int.Parse(input[2]);

                            date = new Date(day, month, year);
                            Console.WriteLine($"Дата у форматі 'Місяць день, рік': {date.ToFormattedString("MMMM dd, yyyy")}");
                            break;

                        case 0:
                            Console.WriteLine("Вихід з програми.");
                            return;

                        default:
                            Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
    }
}
