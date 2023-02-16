using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject Main;
    public int Sayisi;
    enum DataType { Menu, Katalog };
    [SerializeField] DataType dataType;
    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        if (dataType == DataType.Menu)
        {
            print("11");
            Main.GetComponent<OnlineSiparis>().MainMenu = Sayisi;
            Main.GetComponent<OnlineSiparis>().MenuChange();
        }
        if (dataType == DataType.Katalog)
        {
            print("22");
            Main.GetComponent<OnlineSiparis>().KatalogInt = Sayisi;
            Main.GetComponent<OnlineSiparis>().OfficeMenuOpen();
        }
    }
}
