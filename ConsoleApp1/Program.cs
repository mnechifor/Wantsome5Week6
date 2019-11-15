using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int i = 1;

            Add1(i);

            Student s1 = new Student {Address = new Address {Line1 = "Iasi"}};

            UpdateAddress(s1, "Bucuresti");

            var newAddress = s1.Address.Line1;

            var k = i;
        }

        public static void Add1(int nr)
        {
            nr++;

        }

        public static void UpdateAddress(Student student, string address)
        {
            student.Address.Line1 = address;
        }

        private static void PointExample()
        {
            CloneExample();

            List<Point> list = new List<Point>();

            var p1 = new Point {X = 4, Y = 7};
            list.Add(p1);

            var p2 = new Point {X = 1, Y = 7};
            list.Add(p2);

            list.Sort();
        }

        private static void CloneExample()
        {
            var s1 = new Student();
            s1.Name = "Mihai";
            s1.Address = new Address();
            s1.Address.Line1 = "Iasi";




            var s2 = new Student();
            s2.Name = "Mihai";

            if (s1 == s2)
                Console.WriteLine("Egalitate");
            else
                Console.WriteLine("Diferite");


            var s3 = s1.Clone();

            s1.Address.Line1 = "Bucuresti";

            var c = 5 is object;
        }
    }

    class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int CompareTo(Point otherPoint)
        {
            if (this.X != otherPoint.X)
            {
                return (this.X - otherPoint.X);
            }
            if (this.Y != otherPoint.Y)
            {
                return (this.Y - otherPoint.Y);
            }
            return 0;
        }
    }

    public class Address
    {
        public string Line1 { get; set; }
    }

    public class Student : ICloneable
    {
        public Address Address { get; set; }
        public string Name { get; set; }

        public List<int> Rooms { get; set; }

        public int Age { get; set; }

        public object Clone()
        {
            Student s1 = new Student();
            s1.Name = this.Name;
            s1.Age = this.Age;

            s1.Address = new Address();
            s1.Address.Line1 = this.Address.Line1;

            //s1.Rooms = new List<int>();
            //foreach (var room in Rooms)
            //{
            //    s1.Rooms.Add(new Room(room.Name));
            //}

            return s1;
        }

        public static bool operator ==(Student student1,
            Student student2)
        {
            return Equals(student1, student2);
        }

        public static bool operator !=(Student student1,
            Student student2)
        {
            return !Equals(student1, student2);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public override bool Equals(object param)
        {
            // If the cast is invalid, the result will be null
            var student = param as Student;
            // Check if we have valid not null Student object
            if (student == null)
                return false;
            // Compare the reference type member fields
            if (!Equals(Name, student.Name))
                return false;
            // Compare the value type member fields
            if (Age != student.Age)
                return false;

            return true;
        }
    }
}