using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform RectTransform;

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //RectTransform.anchoredPosition += eventData.delta / UIGeneratedGameScene.Canvas.GetComponent<RectTransform>().lossyScale;
        RectTransform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
