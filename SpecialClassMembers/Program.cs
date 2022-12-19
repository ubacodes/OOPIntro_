using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[]args)
        {
            #region Constructors
            //new ConstructorClass();
            //new ConstructorClass(5);
            //new ConstructorClass("umut",5);

            ////new PrivateConstructor();     private olarak tanımlanmış bir constructorMetot'a erişim olamıyor ve nesne oluşturulamıyor
            ////PrivateConstructor m1 = new PrivateConstructor();

            //ConstructorClass m = new(); //target-type ile nesne oluşturduk fakat constructor metot her daim tetiklenmek zorundadır (nesne oluşturulurken)
            #endregion
            #region Destructor
            #region Senaryo1
            // ! bilgi : GC sınıfı GarbageCollector'dır. ve System dosyalarının altında yer alır

            // DestructorClass1 k1 = new DestructorClass1(); // --> eğer biz burada oluşturursak nesne gereksiz durumuna düşmüyor çünkü halen daha o nesneyi referans ile işaretleyen bir değişkene sahip main metotu

            //X();
            //GC.Collect(); // bu garbagecollector'ı çağırıp tüm gereksiz nesneleri temizle dediğimiz satır
            //Console.ReadLine(); //readline yaptık çünkü programımız kısa olduğu için daha destructor çalışamadan program sonlanıyor
            #endregion
            #region Senaryo2
            //int sayi = 110;
            //while (sayi >= 1)
            //{
            //    new DestructorClass2(sayi);
            //    sayi--;
            //}
            //Console.WriteLine("************************************");

            //GC.Collect();

            //Console.ReadLine();
            #endregion
            #endregion
            #region StaticConstructor
            new stConstructor();
            new stConstructor();
            #endregion
        }

        static void X()
        {
            DestructorClass1 m = new DestructorClass1();
        }

        #region Constructors
        class ConstructorClass
        {
            // constructor metotların isimleri bulundukları class isimleri ile aynı isimde olmak zorundadır
            // constructor metotların tanımlanmasında geri dönüş değeri hiç bahsedilmez (void dahil) direkt olarak metot ismi ile yazılır
            int a;
            public ConstructorClass()
            {
                Console.WriteLine("Bir tane ConstructorClass nesnesi oluşturulmuştur.");
                a = 5; 
            }
            public ConstructorClass(int a)
            {
                //...
            }
            public ConstructorClass(string b , int a)
            {
                //... Constructor metotlar oveload yapılabilir
            }
            public void X(int t)
            {
                this.a = t;
            }
        }
        #region this Keyword ile constructor tetikleme
        // this keyword ile birden fazla constructor'lı bir yapıda diğer constructorların da tetiklenmesi sağlanabilmekte
        class MyClass
        {
            public MyClass()
            {
                Console.WriteLine("1.Constructor");
            }
            public MyClass(int a) : this()
            {
                Console.WriteLine("2.Constructor");
            }
            public MyClass(int a, string b) : this(a)
            { 
                Console.WriteLine("3.Constructor");
            }
        }
        #endregion
        class PrivateConstructor
        {
            private PrivateConstructor()
            {
                //Dışarıdan nesne oluşturulmasını engelleyip içeriden oluşturulmaya devam edilebilir.

            }

            PrivateConstructor m1 = new PrivateConstructor();
        }
        #endregion
        #region Destructor
        #region Senaryo1
        class DestructorClass1
        {
            public DestructorClass1()
            {
                Console.WriteLine("Nesne üretilmiştir.");
            }
            ~DestructorClass1()
            {
                Console.WriteLine("Nesne imha ediliyor...");
            }
        }
        #endregion
        #region Senaryo2
        class DestructorClass2
        {
            int no;
            public DestructorClass2(int no)
            {
                this.no = no;
                Console.WriteLine($"{no}. nesne oluşturulmuştur.");
            }

            ~DestructorClass2()
            {
                Console.WriteLine($"{no}. nesne imha ediliyor...");
            }
        }
        #endregion
        #endregion
        #region StaticConstructor
        class stConstructor
        {
            static stConstructor()
            {
                //bu static constructor metot
                Console.WriteLine("İlk nesne oluşturulurken ilk tetiklenen metot.");
            }
            public stConstructor()
            {
                //bu constructor metot
                Console.WriteLine("Nesne oluşturulurken ilk tetiklenen metot."); //sadece ilk nesne oluşturulurken veya class içerisinde static yapıdaki herhangi bir member'ın ilk tetiklenmesi esnasında
                //birinciliği static constructor'a kaptırır
            }
        }
        #endregion
    }
}