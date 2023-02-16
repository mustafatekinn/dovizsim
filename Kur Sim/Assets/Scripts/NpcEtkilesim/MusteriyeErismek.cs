using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class MusteriyeErismek : MonoBehaviour
    {
        public GameObject ParaBozdurma, Canvas, Player, KurBozdurmak;
        public bool EkranAcik;
        private void OnMouseDown()
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0)) && (!EkranAcik))
            {
                if (GetComponent<NpcMain>().Siralama == 0)
                {
                    EkranAcik = true;
                    print("musteriilekonus");
                    var InputSystem = Player.GetComponent<StarterAssetsInputs>();
                    InputSystem.cursorLocked = false;
                    InputSystem.cursorInputForLook = false;
                    Canvas.SetActive(true);
                    ParaBozdurma.GetComponent<KurBozdurmak>().MusteriGeldi();
                    KurBozdurmak.GetComponent<KurBozdurmak>().MusteriObj = gameObject;
                    //player masaya yakin olmali
                }

            }
        }


        public void IsimBitti()
        {
            EkranAcik = false;
            GetComponent<NpcMain>().isimbitti = true;
            Canvas.SetActive(false);
            var InputSystem = Player.GetComponent<StarterAssetsInputs>();
            InputSystem.cursorLocked = true;
            InputSystem.cursorInputForLook = true;
        }
    }
}