using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Kur", menuName = "Kur/YeniKur")]

public class KurSystem : ScriptableObject
{

    public float DolarKarsiligiDeger;
    public string KurIsmi;
    public Texture[] KurunDogruResimleri;
    public int[] KurunDegerleri;
    public Texture[] Sahte5Lik, Sahte10Luk, Sahte20Lik, Sahte50Lik, Sahte100Luk, Sahte200Luk;
    public Color Renk;


}
