using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        PetManager.Instance.LoadPet();
        StatsManager.Instance.SetStats();
        UIManager.Instance.LoadResourceForUI();
    }

    void Update()
    {
        StatsManager.Instance.StatsUpdate();
        UIManager.Instance.UpdateUI();
        Debug.Log(StatsManager.Instance.CurrentPet);
        if(StatsManager.Instance.CurrentHunger == 0)
        {
            StartCoroutine(PlayFailAnim());
        }
    }

    IEnumerator PlayFailAnim()
    {
        PetManager.Instance.CloneAnimator.SetTrigger("Fail");
        GameObject NoticePopup = GameObject.Find("Popup_Notice");
        NoticePopup.transform.localScale = Vector3.zero;
        NoticePopup.transform.DOScale(new Vector3(1, 1), 0.4f).SetEase(Ease.OutBack);
        yield return null;
    }

}
