using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ready-Only Property
            // Record konusu içerisinde ready-only property'nin yer almasının sebebi init-only property ile arasındaki farklı anlayabilmek ve daha sonrasında record yapılanmasını anlayabilmektir.
            ReadyOnly r1 = new ReadyOnly
            { // bu yapılanmaya biz object initializer diyorduk
                // Adi = "umut" "cannot be assigned ... it is read only" hatası alıyoruz çünkü burada asıl temelde yapılan işlem set etmektir. Dolayısıyla bu şekilde kullanım yapılabilmesi adına "init-only property" çıkmıştır
            };

            #endregion
            #region Init-Only Property
            InitOnly i1 = new InitOnly
            {
                Adi = "Umut", //Object İnitializer ile sorunsuz bir şekilde ilk değer ataması yapabiliriz.
                Afield = 5
            };
            // i1.Adi = "Batuhan"; // bu şekilde set edemeyiz çünkü ready only
            #endregion
            #region Record
            MyRecord employee1 = new MyRecord   //Record oluşturma ve stack de referans olarak işaretleme
            {
                Afield= 5,      //readonly olan field'a encapsulation (Afield) üzerinden init ile başlangıç değeri ataması
                Name = "Gençay",
                Surname = "YILDIZ",         //record yapısında object initializers kullanımı da yapılabilmektedir.
                Position= 1
            };
             // recordlarda bulunan sabit yapıdaki propertylerde herhangi bir değeri değiştirmek zorunda kalırsak kolaylıkla kullanabileceğimiz "with expression" özelliğinin kullanımı
            MyRecord employee2 = employee1 with {  Position= 2 };
            MyRecord employee3 =employee1 with { Name = "Umut" , Position= 3 }; 
            #endregion
        }
        #region ReadOnlyClass
        class ReadyOnly
        {
            public string Adi { get; }  //  = "batuhan" ; default değeri ancak bu şekilde verebiliyoruz
        }
        #endregion
        #region InitOnlyClass
        class InitOnly
        {
            public string Adi { get; init; } // init; keyword'u sayesinde artık bu property init only property olarak davranacaktır.

            // init ile readonly olan field'a değer atama durumu
            readonly int a;
            public int Afield { get { return a;} init { a = value; } }  

        }
        #endregion
        #region MyRecord
        //Record'larda birer class'dır classMember'ların hepsini bir record içerisinde de tanımlanabilir
        record MyRecord
        {
            readonly int a;

            public int Afield
            {
                get { return a; }
                init { a = value; }
            }

            public string Name { get; init; }       //init yapısı object initializer esnasında başlangıç değeri atanıp daha sonrasında readonly olarak davranmasını sağlıyoruz
            public string Surname { get; init; }        //recordlarda set'de kullanılabilir fakat init metotunun kullanılması daha doğrudur
            public int Position { get; init; }
        }
        #endregion
    }
}