using System;

namespace ConsoleApp1
{
    internal class Base
    {
    }

    internal class Derived : Base
    {
    }

    internal class Operators
    {
        private static void TestOperators()
        {
            object objBase = new Base();

            if (objBase is Base)
                Console.WriteLine("objBase is Base");
            // Result: objBase is Base


            if (!(objBase is Derived))
                Console.WriteLine("objBase is not Derived");
            // Result : objBase is not Derived


            if (objBase is object)
                Console.WriteLine("objBase is System.Object");
            // Result : objBase is System.Object

            var b = objBase as Base;
            Console.WriteLine("b = {0}", b);
            // Result: b = Base

            var d = objBase as Derived;
            if (d == null)
                Console.WriteLine("d is null");
            // Result: d is null
            var o = objBase;
            Console.WriteLine("o = {0}", o);
            // Result: o = Base


            var der = new Derived();
            var bas = der as Base;

            var aa = (Base) der;
            Console.WriteLine("bas = {0}", bas);
            // Result: bas = Derived
        }
    }
}