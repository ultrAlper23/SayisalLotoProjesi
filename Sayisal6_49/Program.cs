using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sayisal6_49
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] myCoupon;
            KuponOlustur(out myCoupon, 200);
            KuponIcerigi(myCoupon);

            int[][] cekilenler;
            KuponOlustur(out cekilenler, 1);
            Console.WriteLine("----------Şanslı Sayılar------------");
            KuponIcerigi(cekilenler);
            Karsilastir(myCoupon, cekilenler);
            Console.ReadLine();
        }

        static void Karsilastir(int[][] myCoupon, int[][] cekilenler)
        {
            //cekilenler sadece 1 dizi saklayan jagged array. 
            for (int i = 0; i < myCoupon.Length; i++)
            {
                int sayi = 0;//her kolonda kaç adet bulduk bilgisi 0lanmalı
                for (int j = 0; j < cekilenler[0].Length; j++)
                {
                    if (myCoupon[i].Contains(cekilenler[0][j]))//cekilenler[0] içerideki tek dizi.
                    {
                        sayi++;
                    }
                }
                if (sayi >= 3)
                    Console.WriteLine(string.Format("{0}. kolonda {1} adet bulundu ve ikramiye kazandınız.",(i+1),sayi));
                else
                    Console.WriteLine("{0}. kolonda {1} adet bulundu", (i + 1), sayi);
            }
        }

        static void KuponIcerigi(int[][] kupon)
        {
            foreach (int[] kolon in kupon)
            {
                foreach (int numara in kolon)
                {
                    Console.Write(numara + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        static void KuponOlustur(out int[][] kupon, int kolonSayisi)
        {
            kupon = new int[kolonSayisi][];
            Random rnd = new Random();
            int sayi;
            for (int kolon = 0; kolon < kupon.Length; kolon++)//her bir kolon için
            {
                int[] dizi = new int[6];

                for (int num = 0; num < 6; num++)
                {
                    sayi = rnd.Next(1, 50);
                    if (dizi.Contains(sayi))
                        num--;
                    else
                        dizi[num] = sayi;
                }
                Array.Sort(dizi);
                kupon[kolon] = dizi;
                Thread.Sleep(15);
            }
        }
    }
}
