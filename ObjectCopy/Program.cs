using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ShallowCopy
            // shallow copy referans tipli değişkenlerde default veri kopyalamadır.
            
            #region Ornek1
            MyClass m1 = new MyClass();
            MyClass m2 = m1;
            MyClass m3 = m2;
            MyClass m4 = new MyClass();
            #endregion
            #endregion
            #region DeepCopy
            // deep copy değer tipli değişkenlerde default veri kopyalamadır.
            MyClass d1 = new MyClass();
            MyClass d2 = d1.Clone();
            #endregion
        }
    }
    class MyClass
    {
        int x;
        string field; 
        public int Id { get; set; }
        public string Name { get; set; }

        public MyClass Clone()
        {
            return (MyClass)this.MemberwiseClone(); //memberwiseclone metotu bir sınıfın içerisinde  o sınıftan üretilmiş olan o anki nesneyi clonlamamızı sağlayan bir fonksiyondur. (içeriğine ileride değinilecektir) | object döndürür
             // yukarıdaki kod satırında bu sınıftan oluşturulan o anki nesneyi klonluyoruz ve bu bize object olarak bir değer döndürüyor
             //daha sonrasında bizde bu değeri (MyClass) sınıfından bir nesne oluşturacağımız için type casting yapıyoruz.
        }
    }
}