using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

}
