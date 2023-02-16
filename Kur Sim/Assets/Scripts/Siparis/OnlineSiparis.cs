using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSiparis : MonoBehaviour
{
    public int MainMenu;
    public GameObject[] Menus;

    public GameObject[] OfficeMenu, HouseMenu;
    public int KatalogInt;

    private void Start()
    {

        MainMenu = 0;
        KatalogInt = 0;
        foreach (GameObject officeMenu in OfficeMenu)
        {
            officeMenu.SetActive(false);
        }
        foreach (GameObject housemenu in HouseMenu)
        {
            housemenu.SetActive(false);
        }
        MenuChange();
    }

    public void OfficeMenuOpen()
    {
        foreach (GameObject officeMenu in OfficeMenu)
        {
            officeMenu.SetActive(false);
        }
        foreach (GameObject housemenu in HouseMenu)
        {
            housemenu.SetActive(false);
        }
        HouseMenu[KatalogInt].SetActive(true);
        OfficeMenu[KatalogInt].SetActive(true);
    }

    public void MenuChange()
    {
        foreach (GameObject menus in Menus)
        {
            menus.SetActive(false);
        }
        OfficeMenuOpen();
        Menus[MainMenu].SetActive(true);
    }
}
