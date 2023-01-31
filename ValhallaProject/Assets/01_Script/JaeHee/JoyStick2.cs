using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rect;
    [SerializeField] private RectTransform handle;

    [SerializeField, Range(10f, 100f)] private float handleRange;

    private Vector2 inputVector;
    private bool isInput;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 inputDir = eventData.position - rect.anchoredPosition;
        Vector2 clampedDir = inputDir.magnitude < handleRange ? inputDir : inputDir.normalized * handleRange;
        
        handle.anchoredPosition = clampedDir;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 inputDir = eventData.position - rect.anchoredPosition;
        Vector2 clampedDir = inputDir.magnitude < handleRange ? inputDir : inputDir.normalized * handleRange;
        
        handle.anchoredPosition = clampedDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
    }
}
