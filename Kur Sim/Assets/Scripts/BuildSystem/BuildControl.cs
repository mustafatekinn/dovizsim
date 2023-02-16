using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildControl : MonoBehaviour
{
    public bool YapiYapilabilir;
    public Color Yesil, Kirmizi;
    public Text text;
    void Start()
    {
        YapiYapilabilir = true;
        GetComponent<Renderer>().material.SetColor("_Color", Yesil);
    }
    private void OnTriggerStay(Collider other)
    {
        YapiYapilabilir = false;
        GetComponent<Renderer>().material.SetColor("_Color", Kirmizi);
    }
    private void OnTriggerExit(Collider other)
    {
        YapiYapilabilir = true;
        GetComponent<Renderer>().material.SetColor("_Color", Yesil);
    }


}
