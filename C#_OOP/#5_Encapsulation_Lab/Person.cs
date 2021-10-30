﻿using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName, int age, decimal salary)
            : this(firstName, lastName, age)
        {
            Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }
        }


        public string LastName
        {
            get { return lastName; }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }


        public int Age
        {
            get { return age; }

            set 
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value; 
            }
        }

        private decimal salary;

        public decimal Salary
        {
            get { return salary; }

            set 
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                salary = value; 
            }
        }

        public void IncreaseSalary(decimal parcentage)
        {
            if (Age < 30)
            {
                parcentage /= 2;
            }

            Salary += Salary * parcentage / 100;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }

    }
}
