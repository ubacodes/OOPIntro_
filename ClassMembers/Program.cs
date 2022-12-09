using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Field
            Console.WriteLine("------------------------FieldIntro------------------------------");
            //Nesne içerisinde değer tutmamızı sağlayan alanlardır.
            //Sadece nesne üretilen class içerisinde tanımlanan değişkenlere field ismi verilir. Metot, property, main'de tanımlanan değişkenlere field denilmez.
            Field f1 = new Field();
            f1.a = 1;
            Console.WriteLine(f1.a);
            Field f2 = new Field();
            f2.a = 25; // Her bir nesnede bu fieldlar farklı değerler tutarlar.
            Console.WriteLine(f2.a);
            #endregion
            #region Property
            Console.WriteLine("------------------------PropertyIntro------------------------------");
            Property p1 = new Property();
            p1.Yasi = 24;
            Console.WriteLine(p1.Yasi); // 24 sonucu çıkar çünkü hemen üst satırda set ettik
            #endregion
            #region FullProperty
            Console.WriteLine("------------------------FullProperty------------------------------");
            //Property yapısı kullanacaksak eğer ilk önce nesne üzerindeki fieldlara erişimin kapatılması/engellenmesi gerekiyor (yazılım ahlakı açısından önemli)
            FullProperty fullProperty = new FullProperty();

            Console.WriteLine(fullProperty.Adi);
            fullProperty.Adi = "Batuhan";
            Console.WriteLine(fullProperty.Adi);

            Console.WriteLine("Bakiye ilk durum : " + fullProperty.Bakiye);
            fullProperty.Bakiye = 199;
            Console.WriteLine("Bakiye 199TL geldi : " + fullProperty.Bakiye);  //property içerisinde bakiye*10/100 olarak get ediyor dikkat!
            fullProperty.Bakiye = 50;
            Console.WriteLine("Bakiye 50TL daha geldi : " + fullProperty.Bakiye);

            #endregion
            #region Prop Property
            Console.WriteLine("------------------------PropProperty------------------------------");
            PropProperty propProperty = new PropProperty();
            Console.WriteLine("İlk değer ( default ) : " + propProperty.Yasi);
            propProperty.Yasi = 65;
            Console.WriteLine("İkinci değer ( 65 değeri atandıktan sonra ) : " + propProperty.Yasi);
            #endregion
            #region Auto Initialzers Property
            Console.WriteLine("------------------------AutoInitialzersProperty------------------------------");
            InsanEntity autoProperty = new InsanEntity();
            Entity autoProperty2 = new Entity();
            Console.WriteLine(autoProperty.Adi + "\n" + autoProperty.Soyadi + "\n" + autoProperty.Yasi);
            Console.WriteLine(autoProperty2.Adi);
            #endregion
            #region Ref ReadOnly Returns Property
            Console.WriteLine("------------------------RefReadonlyReturnsProperty------------------------------");
            RefReadonlyReturn refReadonly = new RefReadonlyReturn();
            Console.WriteLine("Adi : " + refReadonly.Adi + "\n" + "Soyadı : " + refReadonly.Soyadi + "\n" + "Yasi : " + refReadonly.Yasi);

            // refReadonly.Adi = "Mehmet"; //bu işlem yapılamaz çünkü bizim imzamız artık readonly olarak sunuyor fieldlarımızı

            #endregion
            #region Computed Property
            Console.WriteLine("------------------------ComputedProperty------------------------------");
            ComputedProperty computedProperty = new ComputedProperty();
            Console.WriteLine("değer : " + computedProperty.Topla);
            #endregion
            #region Metot
            Console.WriteLine("------------------------Metotlar------------------------------");
            MetotClass metot1 = new MetotClass();
            MetotClass metot2 = new MetotClass();

            Console.WriteLine("Metot 1 : " + metot1.X);
            Console.WriteLine("Metot 2 (s1 = 30, s2 = 70) : " + metot2.Y(30, 70));
            #endregion
            #region Indexer
            Console.WriteLine("------------------------Indexer------------------------------");
            IndexerClass indexer = new IndexerClass();
            indexer[6] = 67;
            Console.WriteLine("indexer : " + indexer[6]);
            Console.WriteLine("indexer[1] : " + indexer[1]);
            #endregion
            #region MyObject
            new MyObject(); // bu bizim nesnemizi oluşturmamız için yeterli bir koddur. Şuan nesnemiz oluşturuldu ve HEAP'de bir yeri var fakat biz onu referans olarak göstermeden erişim sağlayamayız.

            MyObject newObject = new MyObject(); //şimdi yeni bir nesne oluşturduk ve newObject isminde bir değer tutucu ile STACK de referans noktasını tutuyoruz. Dolayısıyla biz nesnemize bu değişken üzerinden artık erişebiliriz.

            //Target Type -- New Expressions (c# 9.0) ile gelen yeni bir tanımlamaya göre nesne oluşturulur oluşturulmaz referans gösterilmesi için bir değişkene referansı atanıyorsa bu şekilde bir tanımlamada artık geçerlidir.
            MyObject newObject2 = new();
            #endregion
        }
        #region FieldClass
        class Field
        {
            public int a;
        }
        class Property
        {
            int yasi = 15;

            public int Yasi
            {
                get { return yasi; } // yasi field'ına ulaşılmak istenildiği zaman bu property'in get metotu çalışır
                set { yasi = value; } // yasi field'ına değer atanmak istenildiği zaman bu property'in set metotu çalışır
            }
        }
        #endregion
        #region FullPropertyClass
        class FullProperty
        {
            //Property'ler hangi field'a erişim sağlıyor/hangi field'ı temsil ediyorsa türü o field ile aynı olmak zorundadır.
            //Property isimleri genellikle temsil edecekleri field'ın baş harfi büyük harf ile başlayacak şekilde isimlendirilir.
            int bakiye;
            string adi;

            public string Adi
            {
                get
                {
                    //Property üzerinden değer talep edildiğinde bu blok tetiklenir.
                    return adi + " Yılmaz";
                }
                set
                {
                    //value keyword'u gönderilen değeri yakalar
                    //value keyword'u property'in türünde değer alır ( otomatik )
                    adi = value;
                }
            }

            public int Bakiye
            {
                get
                {
                    if (bakiye >= 0) { return bakiye * 10 / 100; }
                    else { return bakiye; }
                }
                set
                {
                    bakiye = bakiye + value;
                }
            }
        }
        #endregion
        #region PropPropertyClass
        class PropProperty
        {
            //prop imzalarda ilgili property'in temsil ettiği bir field'ı ayrıca tanımlanmasına gerek yoktur. Compile edilirken prop imzalarda kendisi tanımlama yapıyor.
            public int Yasi { get; set; }
            public string Adi { get; } //prop imzalarda read only olabilir
                                       //public string Adi {  set; } prop imzalarda ilgili property read only olabilir fakat write only olamaz.
        }
        #endregion
        #region AutoInitializersPropertyClass
        class InsanEntity
        {
            public string Adi { get; set; } = "Umut Batuhan";
            public string Soyadi { get; set; } = "Alpan";
            public int Yasi { get; set; } = 24;
        }
        class Entity
        {
            public string Adi { get; } = "Adem";
        }
        #endregion
        #region RefReadOnlyReturnsClass
        class RefReadonlyReturn
        {
            string adi = "Umut Batuhan";
            string soyadi = "ALPAN";
            int yasi = 24;
            // adi field'ımız get edilmek istenildiği zaman bizim refreadonly return property imzamız bu field'ın referanası ile birlikte değeri gönderecektir
            public ref readonly string Adi => ref adi;
            public ref readonly string Soyadi => ref soyadi; //=> işaretinin adı lambda demektir hangi field'ı temsil ettiğini belirtmek için kullandık.
            public ref readonly int Yasi => ref yasi;
        }
        #endregion
        #region ComputedPropertyClass
        class ComputedProperty
        {
            int s1 = 5;
            int s2 = 10;

            public int Topla
            {
                get
                {
                    return s1 + s2; // bu property imzasının olayı fieldları get veya set ederken belirli matematiksel işlemlere tabi tutmaktır.
                }
            }
        }
        #endregion
        #region MetotClass
        class MetotClass
        {
            public int X()
            { return 5; }
            public int Y(int s1, int s2)
            { return (s1 + s2) / 100; }
        }
        #endregion
        #region IndexerClass
        class IndexerClass
        {
            public int this[int i]
            {
                get { return i; }
                set { i = value; }
            }
        }
        #endregion
        #region MyObjectClass
        //bir nesne nasıl oluşturulur konusuna örnek niteliğinde
        class MyObject
        {
            int a;
            public string Adi { get; set; }
            public int SayiTopla(int a, int b)
            {
                return a + b;
            }
        }
        #endregion
    }
}