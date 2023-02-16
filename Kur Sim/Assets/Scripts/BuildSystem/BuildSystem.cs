using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class BuildSystem : MonoBehaviour
    {
        public GameObject YerlesecekObje, YerlesecekPreview, ButtonObj, Canvas, PaketleObje;
        public GameObject Pivot;
        public BuildObject[] buildObject;
        public int Objectcode;


        public bool Yerlestiriyorum;
        void Start()
        {
            Yapi();
        }
        public void Yapi()
        {
            YerlesecekObje = buildObject[Objectcode].Obje;
            YerlesecekPreview = Instantiate(buildObject[Objectcode].ObjePriview, Pivot.transform.position, Pivot.transform.rotation);
            YerlesecekPreview.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        void Update()
        {
            if (Yerlestiriyorum)
            {
                YerlesecekPreview.transform.position = Pivot.transform.position;
                if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
                {
                    YerlesecekPreview.transform.Rotate(0, 360 * UnityEngine.Time.deltaTime, 0, Space.Self);
                    print("yukari");
                }
                else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                {
                    print("assa");
                    YerlesecekPreview.transform.Rotate(0, -360 * UnityEngine.Time.deltaTime, 0, Space.Self);
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    Vector3 temp = new Vector3(0, 1, 0);
                    Pivot.transform.position += temp * UnityEngine.Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.E))//asagi indirme
                {
                    Vector3 temp = new Vector3(0, -1, 0);
                    Pivot.transform.position += temp * UnityEngine.Time.deltaTime;
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (YerlesecekPreview.GetComponent<BuildControl>().YapiYapilabilir)
                    {
                        GameObject SpamlananObje = Instantiate(YerlesecekObje, YerlesecekPreview.transform.position, YerlesecekPreview.transform.rotation);

                        SpamlananObje.GetComponent<SagTikMenu>().ObjeCode = Objectcode;

                        Yerlestiriyorum = false;
                        Destroy(YerlesecekPreview);
                    }

                }
            }
        }

    }
}