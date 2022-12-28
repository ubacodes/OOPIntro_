using System;


namespace OOPIntro_
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Polimorfizm : bir nesnenin kendi türü dışında veya birden fazla türle referans / işaretlenebilmesidir.
                 polimoefizim olması için kalıtımsal bir yapılanmak olmak zorundadır yoksa bir nesneyi kendi türünden başka bir tür ile referans edilemez
             */

            Insan insan = new Insan();  //burada normal bir Insan türünden referans oluşturduk ve yine Insan türünden bir nesneyi bu referans ile işaretledik
            Insan erkek = new Erkek(); //şimdi ise biz erkekten bir nesne oluşturup insan türünde bir referans ile işaretliyoruz. Aralarında kalıtımsal ilişki olmasa yapamazdık


            A a = new C();
            B b = new C();
            C c = new C();

            /*
             * şimdi yukarıdaki C'den 3 tane farklı referans türleri ile işaretlenmiş olan nesnelere bakalım
             * a.X() gelir fakat C nesnesi içerisinde bulunan diğer Y ve Z metotlarına erişim sağlayamayız
             * b.X() ve b.Y() gelir fakat C nesnesi içerisinde bulunan yine diğer Z metotuna erişim sağlayamayız
             * c.X(), c.Y() ve c.Z() nesnelerinin tamamı gelir
             * bunun sebebi polimorfizm kullandığımız zaman nesnemizi hangi tür ile referans ediyorsak o türe göre davranış sergileyecektir.
             */


            #region staticPolimorfizm
            // polimorfizm, buradaki hali birden fazla Topla fonksiyonun bulunması o metot için bir çok biçimlilik oluşuturuyor
            Matematik matematik = new Matematik();
            matematik.Topla(3, 6); // derleme esnasında hangi metotun çalışıp çalışmayacağına karar verebiliyoruz
            #endregion
            #region dinamikPolimorfizm
            Arac arac = new Arac();
            Taksi taksi = new Taksi();

            arac.Calistir();
            taksi.Calistir();

            Arac taksi2 = new Arac();
            taksi2.Calistir(); //burada sanal yapıda oluşturulmuş olan metotun hangi class yapısından çağırılacağını runtime esnasında belirleyecektir.
            #endregion

            /*  Cast operatörü ile polimorfizm kurallarınca tür dönüştürme
             *  A a1 = new C();
                C c2 = (C)a;

                
                kalıtımsal olarak nesnenin daha alt sınıfında olan bir türde dönüşüm yapmak istersek
                A a2 = new B();
                C c1 = (C)a2;   //"cast" ile runtime'da hata verir
                C c2 = a as C;  //"as" ile runtime da hata vermez null döndürür

                //benzer işler bu işleme Unboxing deniyor
                object o = new 123;
                int i = (int)o;
             */
        }

        class Insan { }

        class Erkek : Insan { }
        class Kadın : Insan { }


        class A { public void X() { } }

        class B : A { public void Y() { } }

        class C : B { public void Z() { } }

        #region staticPolimorfizm
        class Matematik
        {
            public long Topla(int s1, int s2) => s1 + s2;
            public long Topla(int s1, int s2, int s3) => s1 + s2 + s3;
            public long Topla(int s1, int s2, int s3, int s4) => s1 + s2 + s3 + s4;
        }
        #endregion
        #region dinamikPolimorfizm
        class Arac
        {
            public virtual void Calistir()
            {
                Console.WriteLine("Araç çalıştı...");
            }
        }

        class Taksi : Arac
        {
            public override void Calistir()
            {
                Console.WriteLine("Taksi çalıştı...");
            }
        }
        #endregion
    }
}