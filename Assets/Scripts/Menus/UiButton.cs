using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public int buttonNumber; //left = 1; right = 2;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonNumber == 1) PlayerMovement.currentDirection = -1f;
        else if(buttonNumber == 2) PlayerMovement.currentDirection = 1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerMovement.currentDirection = 0f;
    }
}
