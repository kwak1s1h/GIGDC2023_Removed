using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform handle;
    private RectTransform rect;
    [SerializeField, Range(10f, 100f)]
    private float leverRange;

    [SerializeField] private Vector3 inputVector;

    private Vector3 direction;
    public Vector3 InputVector => direction;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        player.transform.position += inputVector * Time.deltaTime * 5;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }
    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rect.anchoredPosition;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;
        handle.anchoredPosition = clampedDir;
        inputVector = clampedDir / leverRange;
        direction = inputVector;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
