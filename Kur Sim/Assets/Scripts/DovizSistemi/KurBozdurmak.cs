using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace StarterAssets
{
    public class KurBozdurmak : MonoBehaviour
    {

        public bool musterituru;
        public int HangiDoviz;
        public int HangiBoyDoviz; // 5-10-20-50-100-200
        public int SahteOlmaIhtimali = 1; // 25 = 100 de 25 sahte 0-99
        public int SahteMi;

        public KurSystem[] Kurlar;

        public GameObject OrnekPara, MusterininParasi;
        public int ArkaYuzInt, rasgele;

        public GameObject MusteriObj;
        public Vector2 ornekParaLocation, MusterininParasiLocation;

        public float GunlukCiro;

        void location()
        {
            if (!musterituru)
            {
                musterituru = true;
                ornekParaLocation = OrnekPara.transform.position;
                MusterininParasiLocation = MusterininParasi.transform.position;
            }
            OrnekPara.transform.position = ornekParaLocation;
            MusterininParasi.transform.position = MusterininParasiLocation;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("bastım");
                StartCoroutine(ResetPosition());
            }
        }
        IEnumerator ResetPosition()
        {
            while ((Vector3.Distance(OrnekPara.transform.position, ornekParaLocation) > 0.1f) || (Vector3.Distance(MusterininParasi.transform.position, MusterininParasiLocation) > 0.1f))
            {
                OrnekPara.transform.position = Vector2.MoveTowards(OrnekPara.transform.position, ornekParaLocation, 20);
                MusterininParasi.transform.position = Vector2.MoveTowards(MusterininParasi.transform.position, MusterininParasiLocation, 20);
                yield return new WaitForSeconds(0.01f);
            }
        }


        public void MusteriGeldi()
        {
            OrnekPara.SetActive(false);
            MusterininParasi.SetActive(false);
            HangiDoviz = Random.RandomRange(0, Kurlar.Length);
            HangiBoyDoviz = Random.RandomRange(0, Kurlar[HangiDoviz].KurunDogruResimleri.Length / 2);
            ArkaYuzInt = Kurlar[HangiDoviz].KurunDogruResimleri.Length / 2;
            SahteMi = Random.RandomRange(0, 100);
            if (SahteMi <= SahteOlmaIhtimali)
            {
                rasgele = Random.RandomRange(0, Kurlar[HangiDoviz].Sahte5Lik.Length / 2);
                OrnekPara.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].KurunDogruResimleri[HangiBoyDoviz];
                OrnekPara.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].KurunDogruResimleri[HangiBoyDoviz + ArkaYuzInt];

                if (HangiBoyDoviz == 0)
                {
                    MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].Sahte5Lik[rasgele];
                    MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].Sahte5Lik[rasgele + 3];
                }
                if (HangiBoyDoviz == 1)
                {
                    MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].Sahte10Luk[rasgele];
                    MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].Sahte10Luk[rasgele + 3];
                }
                if (HangiBoyDoviz == 2)
                {
                    MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].Sahte20Lik[rasgele];
                    MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].Sahte20Lik[rasgele + 3];
                }
                if (HangiBoyDoviz == 3)
                {
                    MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].Sahte50Lik[rasgele];
                    MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].Sahte50Lik[rasgele + 3];
                }
                if (HangiBoyDoviz == 4)
                {
                    MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].Sahte100Luk[rasgele];
                    MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].Sahte100Luk[rasgele + 3];
                }
                if (HangiBoyDoviz == 5)
                {
                    MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].Sahte200Luk[rasgele];
                    MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].Sahte200Luk[rasgele + 3];
                }
            }
            else
            {
                OrnekPara.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].KurunDogruResimleri[HangiBoyDoviz];
                OrnekPara.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].KurunDogruResimleri[HangiBoyDoviz + ArkaYuzInt];
                MusterininParasi.GetComponent<DragDrop>().Onyuz = Kurlar[HangiDoviz].KurunDogruResimleri[HangiBoyDoviz];
                MusterininParasi.GetComponent<DragDrop>().ArkaYuz = Kurlar[HangiDoviz].KurunDogruResimleri[HangiBoyDoviz + ArkaYuzInt];
            }
            OrnekPara.SetActive(true);
            MusterininParasi.SetActive(true);
            location();
        }


        public void KuruBozdur()
        {
            if (SahteMi <= SahteOlmaIhtimali)
            {
                GunlukCiro -= Kurlar[HangiDoviz].DolarKarsiligiDeger * Kurlar[HangiDoviz].KurunDegerleri[HangiBoyDoviz];
            }
            else
            {
                GunlukCiro += (Kurlar[HangiDoviz].DolarKarsiligiDeger * Kurlar[HangiDoviz].KurunDegerleri[HangiBoyDoviz]) * 0.05f;
            }
            MusteriObj.GetComponent<MusteriyeErismek>().IsimBitti();
        }
        public void GeriÇevir()
        {
            MusteriObj.GetComponent<MusteriyeErismek>().IsimBitti();
        }


        public void GunBitti()
        {
            print("günbitti");
            GameManager.para += GunlukCiro;
            GunlukCiro = 0;
            MusteriObj.GetComponent<MusteriyeErismek>().IsimBitti();
        }
    }
}