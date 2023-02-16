using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private Canvas canvas;
    RawImage rawImage;
    public Texture Onyuz, ArkaYuz;
    public bool OnTaraf;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rawImage = GetComponent<RawImage>();
    }
    private void OnEnable()
    {
        rawImage.texture = Onyuz;
        OnTaraf = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            if (OnTaraf)
            {
                rawImage.texture = ArkaYuz;
                OnTaraf = false;
            }
            else
            {
                rawImage.texture = Onyuz;
                OnTaraf = true;
            }
        }
    }

}
