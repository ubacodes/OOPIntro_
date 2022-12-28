using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[]args)
        {
            // bir class sade ve sadece bir classtan kalıtım alabilir
            new D();
            /* ben bu kodu çalıştırdığımda aşağıdaki hiyerarşik kalıtım yapısına göre sırasıyla 
                1 - A dan nesne üretecek
                2 - B den nesne üretecek
                3 - C den nesne üretecek
                4 - D den nesne üretecektir.
             */

            new MyClass2();
            new MyClass2(9);

        }
        
        class BaseClass
        {
            int a;
            public int MyProperty { get; set; }
            public void X()
            {

            }
            private void Y()
            {

            }

        }
        class DerivedClass : BaseClass
        {
            int b;
            public int MyProperty2 { get; set; }
            private void Z()
            {
                this.b = 5;
                this.MyProperty2= 10;
                // base.a = 15;
                base.MyProperty = 20;
                base.X();
                // base.Y(); erişim belirleyicisi private olan memberlar kalıtımsal aktarılmaz ve erişilemez
            } 
        }

        class MyClass
        {
            public MyClass(int a)
            {

            }
            public MyClass()
            {
                
            }
        }
        class MyClass2 : MyClass
        {
            public MyClass2() : base(5)
            {
                //MyClass2 parametresizdir ve base classa int 5 sabitini yollar
            }
            public MyClass2(int a) : base(a)
            {
                //MyClass2 constructorunun parametresini base classa parametre olarak yollar
            }
        }

        class A
        {
            public A()
            {
                Console.WriteLine($"{nameof (A)} nesnesi oluşturulmuştur.");
            }
        }
        class B :A 
        {
            public B()
            {
                Console.WriteLine($"{nameof(B)} nesnesi oluşturulmuştur.");
            }
        }
        class C :B 
        {
            public C()
            {
                Console.WriteLine($"{nameof(C)}  nesnesi oluşturulmuştur.");
            }
        }
        class D :C 
        {
            public D()
            {
                Console.WriteLine($"{nameof(D)}  nesnesi oluşturulmuştur.");
            }
        }
    }
}