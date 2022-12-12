using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MetotEncapsulation
            // Property yapılanması olmadan önce metotlar ile eskiden encapsulation' u bu şekilde sağlıyorduk
            
            MyClass m1 = new MyClass();
            Console.WriteLine("MyClass'dan türetilen nesnemin içerisindeki a field'ının değeri :  "+m1.AGet()); 
            m1.ASet(15);
            Console.WriteLine("MyClass'dan türetilen nesnemin içerisindeki a field'ının değeri : "+m1.AGet());

            #endregion
            #region PropertyEncapsulation
            // Property yapılanması tamamen bu iş için ortaya çıkmış bir ClassMembers'dır. Yani amacı nesne içerisindeki değer tutucu olan fieldlara direkt erişimi engelleyip encapsule etmektir.
            MyClass2 m2 = new MyClass2();
            Console.WriteLine("Field'ımın değeri : " + m2.A);
            m2.A = 15;
            Console.WriteLine("Field'ımın değeri : " + m2.A);
            // Console.WriteLine("Adi : "+ m2.Adi); prop property (get)
            #endregion
        }
        #region MetotEncapsulationClass
        class MyClass
        {
            int a;
            public int AGet()
            {
                // int value = this.a * 3; gibi veriyi istediğimiz şekilde kurallar ile yönetip istediğimiz değeri dış dünyaya açabiliriz tamamen bizim elimizde
                return this.a;
            }
            public void ASet(int value)  // dış dünyadan gelen değeri bizim field'ımıza aktaracağız fakat geriye herhangi bir veri türünde değer dönmeyeceği için void metot kullandık 
            {
                this.a = value; 
            }
        }
        #endregion
        #region PropertyEncapsulationClass
        class MyClass2
        {
            int a;
            // field'ı eğer biz oluşturmuş ve kendi oluşturmuş olduğumuz field için bir encapsulation yapacaksak full property'i kullanıyoruz.
            public int A
            {
                get
                {
                    return a;
                }
                set { a = value;}
            }
            // field'ı biz oluşturmadık ve encapsulation yaparken herhangi bir kontrol yapısı (field'ın değerinde değişikliğe gitmeden) kurmadan direkt field'ın değerini olduğu gibi dış dünyaya verip alacak isek prop property kullanabiliriz
            public string Adi { get; set; } // compile kendisi adi field'ını oluşturacaktır.
        }
        #endregion
    }
}