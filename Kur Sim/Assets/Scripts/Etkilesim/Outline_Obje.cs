using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class Outline_Obje : MonoBehaviour
    {
        private void OnMouseEnter()
        {
            GetComponent<Outline>().eraseRenderer = false;
        }
        private void OnMouseExit()
        {
            GetComponent<Outline>().eraseRenderer = true;
        }
    }
}