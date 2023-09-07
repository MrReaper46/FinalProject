using System;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [Header("BASE STATS")]
    [Space]
    [SerializeField] private float maxHunger;
    [SerializeField] private float currentHunger;
    [SerializeField] private float maxHappiness;
    [SerializeField] private float currentHappiness;
    [Range(0, 50)]
    [SerializeField] private int DecaySpd = 1;

    public float CurrentHunger { get => currentHunger; set => currentHunger = value; }
    public float CurrentHappiness { get => currentHappiness; set => currentHappiness = value; }
    public float MaxHunger { get => maxHunger; }
    public float MaxHappiness { get => maxHappiness; }

    private static StatsManager instance;
    public static StatsManager Instance { get => instance; set => instance = value; }

    private void Start()
    {
        instance = this;
    }

    public void StatsUpdate()
    {
        CurrentHunger = Mathf.Clamp(CurrentHunger, 0, maxHunger);
        CurrentHappiness = Mathf.Clamp(CurrentHappiness, 0, maxHappiness);

        if (CurrentHunger <= 0)
        {
            CurrentHunger = 0;
        }
        else
        {
            CurrentHunger -= Time.deltaTime * DecaySpd;
        }

        if (CurrentHappiness <= 0)
        {
            CurrentHappiness = 0;
        }
        else
        {
            CurrentHappiness     -= Time.deltaTime * DecaySpd;
        }
    }

    public void SetStats()
    {
        maxHunger = 100;
        maxHappiness = 100;
        currentHunger = maxHunger;
        currentHappiness = maxHappiness;
    }

}
