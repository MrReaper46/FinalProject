using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetStats : MonoBehaviour
{
    [Header("BASE STATS")]
    [Space]
    public float MaxHunger;
    public float CurrentHunger;
    public float MaxHappiness;
    public float CurrentHappiness;
    [Range(0, 20)]
    public int DecaySpd = 1;

    private void Start()
    {
        SetStats();
    }

    private void Update()
    {
        StatsOverTime();
    }

    private void SetStats()
    {
        MaxHunger = 100;
        MaxHappiness = 100;
        CurrentHunger = MaxHunger;
        CurrentHappiness = MaxHappiness;
        CurrentHunger = Mathf.Clamp(CurrentHunger, 0, MaxHunger);
        CurrentHappiness = Mathf.Clamp(CurrentHappiness, 0, MaxHappiness);
    }

    private void StatsOverTime()
    {
        CurrentHunger -= Time.deltaTime * DecaySpd;
        CurrentHappiness -= Time.deltaTime * DecaySpd;
    }
   
}
