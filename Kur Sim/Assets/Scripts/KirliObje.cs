using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirliObje : MonoBehaviour
{
    int Kirlilik;
    float kirlilikseviyesi;
    MeshRenderer meshRenderer;
    BoxCollider collider;
    public GameObject Supurge;
    public static int copciksinmi;
    public GameObject CopTorbasi;
    public bool Kirlendi;

    void Start()
    {
        kirlilikseviyesi = 100;
        StartCoroutine(Kirlet());
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();
    }
    IEnumerator Kirlet()
    {
        yield return new WaitForSeconds(1f);
        while (Kirlilik <= 5)
        {
            if (Kirlilik >= 5)
            {

                meshRenderer.enabled = true;
                collider.enabled = true;
                Kirlendi = true;
                kirlilikseviyesi = 100;
            }
            Kirlilik++;
            print("Ab");
            yield return new WaitForSeconds(1f);
        }

    }
    public void Yenile()
    {
        collider.enabled = false;
        meshRenderer.enabled = false;
        Kirlilik = 0;
        Kirlendi = false;
        StartCoroutine(Kirlet());
    }

    private void OnMouseOver()
    {
        print("3131");
        if (Input.GetMouseButton(0))
        {

            if (kirlilikseviyesi >= 0)
            {
                Supurge.SetActive(true);
                kirlilikseviyesi -= 50 * Time.deltaTime;
            }
            else
            {
                copciksinmi++;
                if (copciksinmi >= 2)
                {
                    Instantiate(CopTorbasi, Supurge.transform.position, Quaternion.identity);
                    copciksinmi = 0;
                }
                Supurge.SetActive(false);
                Yenile();
            }
        }
        else
        {
            Supurge.SetActive(false);
        }

    }
}
