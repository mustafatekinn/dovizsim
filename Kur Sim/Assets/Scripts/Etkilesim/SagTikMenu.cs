using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{
    public class SagTikMenu : MonoBehaviour
    {
        public GameObject InputsObject, BuildSystem, ButtonObj, Canvas, PaketleObject;
        public int ObjeCode;
        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            InputsObject = GameObject.Find("PlayerCapsule");
            BuildSystem = GameObject.Find("MainCamera");

            ButtonObj = BuildSystem.GetComponent<BuildSystem>().ButtonObj;
            Canvas = BuildSystem.GetComponent<BuildSystem>().Canvas;
            PaketleObject = BuildSystem.GetComponent<BuildSystem>().PaketleObje;
        }
        void OnMouseOver()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                var a = InputsObject.GetComponent<StarterAssetsInputs>();
                a.look = new Vector2(0, 0);
                a.cursorInputForLook = false;
                a.cursorLocked = false;
                var YerDegistirme = ButtonObj.GetComponent<YerDegistirme>();
                YerDegistirme.Objectcode = ObjeCode;
                YerDegistirme.DestroyedObje = gameObject;
                YerDegistirme.InputsObject = InputsObject;
                YerDegistirme.Canvas = Canvas;
                var paketle = PaketleObject.GetComponent<YerDegistirme>();
                paketle.Location = gameObject;
                paketle.Objectcode = ObjeCode;
                paketle.InputsObject = InputsObject;
                paketle.Canvas = Canvas;
                Canvas.SetActive(true);
            }
        }



    }
}