using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace StarterAssets
{
    public class MusteriSpawn : MonoBehaviour
    {
        public bool Spawbable;
        public GameObject NpcEtkilesim;
        public GameManager gameManager;
        int MaksimumMusteriSayisi;


        public GameObject MusteriProfili;
        public GameObject SpawnLocation;

        public GameObject[] HedefLocation;
        public int a;
        private void OnEnable()
        {
            MaksimumMusteriSayisi = NpcEtkilesim.GetComponent<NpcEtkilesimMain>().MaksimumMusteriSayisi;
            StartCoroutine(MusteriSpawnCor());
        }



        IEnumerator MusteriSpawnCor()
        {
            while (true)
            {
                if ((NpcEtkilesim.GetComponent<NpcEtkilesimMain>().MusteriList.Count < MaksimumMusteriSayisi) && (gameManager.MusteriGelebilir))
                {
                    GameObject Musteri = Instantiate(MusteriProfili, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
                    NpcEtkilesim.GetComponent<NpcEtkilesimMain>().MusteriList.Add(Musteri);
                    Musteri.SetActive(true);
                    print("musteriEklendi");
                }
                yield return new WaitForSeconds(2);
            }
        }
    }
}