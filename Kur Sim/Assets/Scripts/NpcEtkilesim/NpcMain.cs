using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace StarterAssets
{
    public class NpcMain : MonoBehaviour
    {
        public int Siralama;
        public GameObject NpcEtkilesimMain;
        public GameObject HedefLocation, CikisLokation;

        NavMeshAgent navMesh;
        public float mesafe;

        public bool isimbitti, kontrol;
        Animator animator;
        private void Start()
        {
            animator = GetComponent<Animator>();
            navMesh = GetComponent<NavMeshAgent>();
        }
        private void FixedUpdate()
        {
            if (!isimbitti)
            {

                Siralama = NpcEtkilesimMain.GetComponent<NpcEtkilesimMain>().MusteriList.IndexOf(gameObject);
                HedefLocation = NpcEtkilesimMain.GetComponent<MusteriSpawn>().HedefLocation[Siralama];
                mesafe = Vector3.Distance(gameObject.transform.position, HedefLocation.transform.position);
                if (Vector3.Distance(gameObject.transform.position, HedefLocation.transform.position) > 1.5f)
                {
                    navMesh.SetDestination(HedefLocation.transform.position);
                    animator.SetBool("Idle", false);
                }
                else
                {
                    animator.SetBool("Idle", true);
                }

            }
            else
            {
                if (!kontrol)
                {
                    print("test");
                    kontrol = true;
                    navMesh.SetDestination(CikisLokation.transform.position);
                    NpcEtkilesimMain.GetComponent<NpcEtkilesimMain>().MusteriList.RemoveAt(0);
                    animator.SetBool("Idle", false);
                }

                if (Vector3.Distance(gameObject.transform.position, CikisLokation.transform.position) < 3f)
                {

                    Destroy(gameObject);
                }
            }
        }
    }
}
