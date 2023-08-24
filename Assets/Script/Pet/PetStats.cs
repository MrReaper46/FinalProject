using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetStats : MonoBehaviour
{
    [Range(0,20)]
    public int DecaySpd = 1;

    public float MaxHunger;
    public float Hunger;
    public float MaxHappiness;
    public float Happiness;

    public Image[] FoodImage;
    public GameObject[] FoodGO;
    public Sprite FoodEnable;
    public Sprite FoodDisable;

    public Image[] HeartImage;
    public GameObject[] HeartGO;
    public Sprite HeartEnable;
    public Sprite HeartDisable;

    private void Start()
    {
        SetStats();
        SetFoodImg();
        SetHeartImg();
    }

    private void Update()
    {
        StatsOverTime();
        UpdateHunger();
        UpdateHappiness();
    }

    private void StatsOverTime()
    {
        Hunger = Mathf.Clamp(Hunger, 0, MaxHunger);
        Happiness = Mathf.Clamp(Happiness, 0, MaxHappiness);
        Hunger -= Time.deltaTime * DecaySpd;
        Happiness -= Time.deltaTime * DecaySpd;
    }

    private void SetStats()
    {
        MaxHunger = 100;
        MaxHappiness = 100;
        Hunger = MaxHunger;
        Happiness = MaxHappiness;
    }

    private void SetFoodImg()
    {
        FoodEnable = Resources.Load<Sprite>("UI/food");
        FoodDisable = Resources.Load<Sprite>("UI/food_disable");

        FoodGO = new GameObject[(int)MaxHunger / 20];
        FoodImage = new Image[(int)MaxHunger / 20];
        FillHunger(MaxHunger / 20);
    }
    private void SetHeartImg()
    {
        HeartEnable = Resources.Load<Sprite>("UI/heart");
        HeartDisable = Resources.Load<Sprite>("UI/heart_disable");

        HeartGO = new GameObject[(int)MaxHappiness / 20];
        HeartImage = new Image[(int)MaxHappiness / 20];
        FillHappiness(MaxHappiness / 20);
    }
    private void FillHunger(float ArrLength)
    {
        for (int i = 0; i < ArrLength; i++)
        {
            FoodGO[i] = GameObject.Find($"Food{i + 1}");
            FoodImage[i] = FoodGO[i].GetComponent<Image>();
            FoodImage[i].sprite = FoodEnable;
        }
    }

    private void FillHappiness(float ArrLength)
    {
        for (int i = 0; i < ArrLength; i++)
        {
            HeartGO[i] = GameObject.Find($"Heart{i + 1}");
            HeartImage[i] = HeartGO[i].GetComponent<Image>();
            HeartImage[i].sprite = HeartEnable;
        }
    }

    private void UpdateHunger()
    {
        int remainFood = (int)Hunger / 20;

        switch (remainFood)
        {
            case 4:
                FoodImage[4].sprite = FoodDisable;
                break;
            case 3:
                FoodImage[3].sprite = FoodDisable;
                break;
            case 2:
                FoodImage[2].sprite = FoodDisable;
                break;
            case 1:
                FoodImage[1].sprite = FoodDisable;
                break;
            case 0:
                FoodImage[0].sprite = FoodDisable;
                Destroy(gameObject);
                Debug.Log("Pet is dead");
                break;
        }
    }

    private void UpdateHappiness()
    {
        int remainFood = (int)Happiness / 20;

        switch (remainFood)
        {
            case 4:
                HeartImage[4].sprite = HeartDisable;
                break;
            case 3:
                HeartImage[3].sprite = HeartDisable;
                break;
            case 2:
                HeartImage[2].sprite = HeartDisable;
                break;
            case 1:
                HeartImage[1].sprite = HeartDisable;
                break;
            case 0:
                HeartImage[0].sprite = HeartDisable;
                Debug.Log("Pet is sad");
                break;
        }
    }
}
