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
        if(StatsManager.Instance.CurrentHunger <= 0)
        {
            PetManager.Instance.CloneAnimator.SetTrigger("Fail");
            GameObject NoticePopup = GameObject.Find("Popup_Notice");
            NoticePopup.transform.DOScale(new Vector3(1, 1), 0.4f).SetEase(Ease.OutBack);
            //SoundManager.Instance.PlaySound(GameObject.Find("SFX_Fail").GetComponent<AudioSource>());
        }
    }
}
