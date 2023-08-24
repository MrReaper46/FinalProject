using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetStats : MonoBehaviour
{
    [Range(0,20)]
    public int TestTime = 1;

    public float MaxHunger;
    public float Hunger;
    public float MaxHappiness;
    public float Happiness;

    public Image[] FoodImage;
    public GameObject[] FoodGO;
    public Sprite FoodEnable;
    public Sprite FoodDisable;

    private void Start()
    {
        SetStats();
        SetFoodImg();
    }

    private void SetFoodImg()
    {
        FoodEnable = Resources.Load<Sprite>("UI/food");
        FoodDisable = Resources.Load<Sprite>("UI/food_disable");

        FoodGO = new GameObject[(int)MaxHunger / 20];
        FoodImage = new Image[(int)MaxHunger / 20];
        for (int i = 0; i < FoodImage.Length; i++)
        {
            FoodGO[i] = GameObject.Find($"Food{i + 1}");
            FoodImage[i] = FoodGO[i].GetComponent<Image>();
            FoodImage[i].sprite = FoodEnable;
        }
    }

    private void Update()
    {
        StatsOverTime();

        FoodImage = new Image[((int)Hunger / 20) + 1];

        if (Hunger <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void StatsOverTime()
    {
        Hunger -= Time.deltaTime * TestTime;
        Happiness -= Time.deltaTime * TestTime;
    }

    private void SetStats()
    {
        MaxHunger = 100;
        MaxHappiness = 100;
        Hunger = MaxHunger;
        Happiness = MaxHappiness;
    }
}
