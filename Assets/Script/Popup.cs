using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    public void Popup_On(GameObject popup)
    {
        if (popup != null)
        {
            popup.transform.localScale = Vector3.zero;
            popup.transform.DOScale(new Vector3(1, 1), 0.4f).SetEase(Ease.OutBack);
        }
    }
    public void Popup_Off(GameObject popup)
    {
        popup.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);
        popup.SetActive(false);
    }
}
