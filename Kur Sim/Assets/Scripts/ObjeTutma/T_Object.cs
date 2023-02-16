using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class T_Object : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public bool Tasiniyorum = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Tasiniyorum)
        {
            ResetForce();
            GameObject obj = GameObject.FindGameObjectWithTag("Pivot");
            //rb.MovePosition(obj.transform.position);
            transform.position = obj.transform.position;
            transform.rotation = (Quaternion.LookRotation(Camera.main.transform.forward));
            //rb.MoveRotation(Quaternion.LookRotation(Camera.main.transform.forward));
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Tasiniyorum = false;
        if ((other.gameObject.tag == "Trash") && (gameObject.tag == "TakeAble"))
        {
            Destroy(gameObject);
        }
    }

    void ResetForce()
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }

    public void Force()
    {
        rb.AddForce(Camera.main.transform.forward * 10, ForceMode.Impulse);
    }
}

