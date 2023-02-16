using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    public float Distance = 5f;
    public bool ObjeyiAldim;
    public GameObject Item;
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (ObjeyiAldim)
        {
            if (Item != null)
            {
                var ObjComp = Item.GetComponent<T_Object>();
                if (!ObjComp.Tasiniyorum)
                {
                    ObjeyiAldim = false;
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ObjComp.Force();
                    ObjeyiAldim = false;
                    ObjComp.Tasiniyorum = false;
                }
            }
            else
            {
                ObjeyiAldim = false;
            }

        }

        if (!ObjeyiAldim)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, Distance))
            {
                if ((hit.collider.gameObject.tag == "TakeAble") || (hit.collider.gameObject.tag == "Koli"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Item = hit.collider.gameObject;
                        Item.GetComponent<T_Object>().Tasiniyorum = true;
                        ObjeyiAldim = true;
                    }

                }
            }

        }
    }
}
