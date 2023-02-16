using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KurManager : MonoBehaviour
{
    public KurSystem[] Kurlar;

    public int KurunBeklemeSuresi;
    public Text[] KurunIsmi, AlisFiyati, SatisFiyati;
    public int sayisi, SlotSayisi;

    public Color DususRenk, ArtisRenk;
    public RawImage[] KurArkaPlan;
    public int kalan;
    void Start()
    {
        SlotSayisi = KurArkaPlan.Length;
        /* for (int i = 0; i < SlotSayisi; i++)
         {
             KurunIsmi[i].text = Kurlar[i + SlotSayisi * sayisi].KurIsmi;
             AlisFiyati[i].text = Kurlar[i + SlotSayisi * sayisi].DolarKarsiligiDeger + "$";
             SatisFiyati[i].text = Kurlar[i + SlotSayisi * sayisi].DolarKarsiligiDeger * 1.05f + "$";
             KurArkaPlan[i].color = Kurlar[i + SlotSayisi * sayisi].Renk;
         }*/

        StartCoroutine(KurDegis());
        // StartCoroutine(KurGoruntusuDegis());
    }

    /*IEnumerator KurGoruntusuDegis()
    {
        while (true)
        {
            for (int i = 0; i < kalan; i++)
            {
                KurunIsmi[i].text = Kurlar[i + SlotSayisi * sayisi].KurIsmi;
                AlisFiyati[i].text = Kurlar[i + SlotSayisi * sayisi].DolarKarsiligiDeger + "$";
                SatisFiyati[i].text = Kurlar[i + SlotSayisi * sayisi].DolarKarsiligiDeger * 1.05f + "$";
                KurArkaPlan[i].color = Kurlar[i + SlotSayisi * sayisi].Renk;
            }
            if (sayisi < Kurlar.Length / SlotSayisi)
            {
                if (Kurlar.Length % SlotSayisi != 0)
                {

                    sayisi++;
                    if (sayisi == 2)
                    {
                        kalan = Kurlar.Length % SlotSayisi;
                    }
                    else
                    {
                        if (sayisi < Kurlar.Length / SlotSayisi - 1)
                        {
                            kalan = SlotSayisi;
                        }

                    }
                }
                else
                {
                    sayisi++;
                }

            }
            else
            {
                kalan = SlotSayisi;
                sayisi = 0;
            }

            yield return new WaitForSeconds(2f);
        }
    }*/


    IEnumerator KurDegis()
    {

        while (true)
        {
            for (int i = 0; i < Kurlar.Length; i++)
            {
                float Degisim = Random.RandomRange(0, 0);
                Kurlar[i].DolarKarsiligiDeger += Degisim;
                /*if (Degisim >= 0)
                {
                    Kurlar[i].Renk = ArtisRenk;
                }
                else
                {
                    Kurlar[i].Renk = DususRenk;
                }*/
            }
            yield return new WaitForSeconds(KurunBeklemeSuresi);
        }
    }
}
