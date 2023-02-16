using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class KoliObject : MonoBehaviour
    {
        public GameObject BuildSystem;
        public int ObjeCode;
        void OnMouseOver()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                BuildSystem.GetComponent<BuildSystem>().Objectcode = ObjeCode;
                BuildSystem.GetComponent<BuildSystem>().Yapi();
                BuildSystem.GetComponent<BuildSystem>().Yerlestiriyorum = true;
                Destroy(gameObject);
            }
        }
    }
}