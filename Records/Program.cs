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
                Adi = "Umut" //Object İnitializer ile sorunsuz bir şekilde ilk değer ataması yapabiliriz.
            };
            // i1.Adi = "Batuhan"; // bu şekilde set edemeyiz çünkü ready only
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
        }
        #endregion
    }
}