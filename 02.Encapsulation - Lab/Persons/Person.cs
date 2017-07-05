using System;
using System.CodeDom;

class Person
{
    private string firtstName;
    private string lastName;
    private int age;
    private double salary;

    public string FirstName
    {
        get { return this.firtstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firtstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Age)} cannot be zero or negative integer");
            }

            this.age = value;
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value < 460)
            {
                throw new ArgumentException($"{nameof(this.Salary)} cannot be less than 460 leva");
            }

            this.salary = value;
        }
    }

    public Person(string firtstName, string lastName, int age, double salary)
    {
        this.FirstName = firtstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public void IncreaseSalary(double percent)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * percent / 100;
        }
        else
        {
            this.salary += this.salary * percent / 200;
        }
    }

    public override string ToString()
    {
        return $"{this.firtstName} {this.lastName} get {this.salary:f2} leva";
    }
}
