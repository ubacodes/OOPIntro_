using System;

namespace OOPIntro_
{
    class Program
    {
        static void Main(string[]args)
        {
            #region ornek-ek
            /*
            Obje obje = new Obje();
            Terlik terlik = new Terlik();
            Mouse mouse = new Mouse();


            obje.Bilgi();
            terlik.Bilgi();
            Console.WriteLine("------------------virtual-------------------------");
            mouse.Bilgi(); 
             */
            #endregion

            #region ornek1
            Memeli memeli = new Memeli();
            Maymun maymun = new Maymun();
            Inek  inek = new Inek();

            memeli.Konus();
            maymun.Konus();
            inek.Konus();
            #endregion
            #region ornek2
            Console.WriteLine("----------------------------ornek2--------------------------------");
            Ucgen u = new Ucgen(4,2);
            Dortgen d = new Dortgen(4, 2);

            Console.WriteLine("Ucgen nesnesi AlanHesapla metotu : " + u.AlanHesapla());
            Console.WriteLine("Dortgen nesnesi AlanHesapla metotu : " + d.AlanHesapla());

            #endregion

        }
    }

    #region ornek-ek
    class Obje
    {
        /*
         * public void Bilgi()
         * {
         *      Console.WriteLine("Ben bir objeyim!");
         * }
         * bu şekilde metot oluşturmuş olsaydık override edemezdik bu yüzden virtual keyword ile oluşturulması gerekiyor bu metotun
         */

        public virtual void Bilgi()
        {
            Console.WriteLine("Ben bir objeyim!");
        }
    }

    class Terlik : Obje
    {
        // atadan gelen metot veya property memberlar virtual ile gelmiş olsa bile eğer biz override etmez isek direkt miras alındığı gibi çalışacak ve runtimeda base class üzerinden çalışacağı karar verilecektir.
    }
    class Mouse : Obje
    {
        // eğer biz override kullanır ve derived classımız üzerinde override edersek yine runtime esnasında derived class üzerinden çalıştırılacağına karar verilecektir. 
        public override void Bilgi()
        {
            Console.WriteLine("Ben bir bilgisayar faresiyim!");
        }
    }
    #endregion

    #region ornek1
    class Memeli
    {
        virtual public void Konus()
        {
            Console.WriteLine("Ben konusmuyorum...");
        }
    }


    class Maymun : Memeli
    {
        public override void Konus() 
        {
            Console.WriteLine("Ben maymunum...");
        }
    }

    class Inek : Memeli
    {
        public override void Konus()
        {
            Console.WriteLine("Ben ineğim...");   
        }
    }

    #endregion
    #region ornek2
    class Sekil
    {
        protected int _boy; // protected erişim belirteci tanımlandığı class içerisinden veya o classtan türetilen diğer nesneler tarafından erişilebilmesini sağlayan bir erişim belirleyicisidir.
        protected int _en;

        public Sekil(int boy, int en)
        {
            _boy = boy;
            _en = en;   
        }

        public virtual int AlanHesapla()
        {
            return 0;
        }
    }

    class Ucgen : Sekil
    {
        public Ucgen(int boy, int en) : base(boy, en)
        {
            // bu constructor yapılanmasını miras aldığı Sekil classındaki constructor yapısının parametre alan bir constructor olmasından dolayı yapmak durumundayız
        }

        public override int AlanHesapla()
        {
            return _boy * _en / 2;  
        }

    }


    class Dortgen : Sekil
    {
        public Dortgen(int boy, int en) : base(boy, en)
        {

        }

        public override int AlanHesapla()
        {
            return _boy * _en;
        }

    }


    class Dikdortgen : Sekil
    {
        public Dikdortgen(int boy, int en) : base(boy, en)
        {

        }

        public override int AlanHesapla()
        {
            return _boy * _en;
        }

    }

    #endregion
}