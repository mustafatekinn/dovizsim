using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{
    public class GameManager : MonoBehaviour
    {
        public static float para;
        public int Seconds;
        public string SaatKac;
        public bool MusteriGelebilir;

        public Text Saat, ParaText;

        public KurBozdurmak kurBozdurmak;

        void Start()
        {
            StartCoroutine(Timer());
        }


        IEnumerator Timer()
        {
            while (true)
            {
                if (Seconds < 1439)
                {
                    Seconds++;
                }
                else
                {
                    Seconds = 0;
                }
                if ((Seconds >= 540) && (Seconds <= 1020))
                {
                    MusteriGelebilir = true;
                }
                else
                {
                    if (kurBozdurmak.GunlukCiro != 0)
                    {
                        kurBozdurmak.GunBitti();
                    }
                    MusteriGelebilir = false;
                }
                SaatKac = (Seconds / 60).ToString("00") + ":" + ((Seconds % 60).ToString("00"));
                Saat.text = SaatKac;
                ParaText.text = para + "$";
                yield return new WaitForSeconds(1f);
            }
        }
    }
}