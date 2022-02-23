using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image _image;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.enabled = false;
    }
}
