using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float Aclik, Susuzluk;
    public Image AclikBar, SusuzlukBar;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Aclik -= 1 * Time.deltaTime;
        Susuzluk -= 1 * Time.deltaTime;
        AclikBar.fillAmount = Aclik / 100;
        SusuzlukBar.fillAmount = Susuzluk / 100;
    }
}
