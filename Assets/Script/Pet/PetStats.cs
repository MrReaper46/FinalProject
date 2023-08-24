using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetStats : MonoBehaviour
{
    [Range(0,20)]
    public int DecaySpd = 1;

    [Header("Base Stats")]
    public float MaxHunger;
    public float CurrentHunger;
    public float MaxHappiness;
    public float CurrentHappiness;


    [Header("Hunger Attribute")]
    public Sprite[] FoodSprite;
    public Sprite FoodEnable;
    public Sprite FoodDisable;

    [Header("Happiness Attribute")]
    public Image[] HeartImage;
    public GameObject[] HeartGO;
    public Sprite[] HeartSprite;
    public Sprite HeartEnable;
    public Sprite HeartDisable;

    [Header("Button Attribute")]
    public GameObject BtnGO_Feed;
    public GameObject BtnGO_Pet;
    public Button Btn_Feed;
    public Button Btn_Pet;

    private void Start()
    {
        SetButton();
        SetStats();
        LoadAttribute();
    }

    private void Update()
    {
        StatsOverTime();
        UpdateHunger();
        //UpdateHappiness();
    }

    private void SetButton()
    {
        BtnGO_Feed = GameObject.Find("Btn_Feed");
        BtnGO_Pet = GameObject.Find("Btn_Pet");
        Btn_Feed = BtnGO_Feed.GetComponent<Button>();
        Btn_Pet = BtnGO_Pet.GetComponent<Button>();
        Btn_Feed.onClick.AddListener(Feed);
        Btn_Pet.onClick.AddListener(Pet);
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

    private void LoadAttribute()
    {
        FoodEnable = Resources.Load<Sprite>("UI/food");
        FoodDisable = Resources.Load<Sprite>("UI/food_disable");
        HeartEnable = Resources.Load<Sprite>("UI/heart");
        HeartDisable = Resources.Load<Sprite>("UI/heart_disable");
        FoodSprite = new Sprite[(int)MaxHunger / 20];
        for (int i = 0; i < (int)MaxHunger / 20; i++)
        {
            FoodSprite[i] = GameObject.Find($"Food{i + 1}").GetComponent<Image>().sprite;
        }
        //UpdateUIHunger((int)MaxHunger/20);
        //UpdateUIHappiness((int)MaxHappiness/20);
    }
    
    private void UpdateUIHappiness(int length)
    {
        for (int i = 0; i < length / 20; i++)
        {
            HeartGO[i] = GameObject.Find($"Heart{i + 1}");
            HeartImage[i] = HeartGO[i].GetComponent<Image>();
            HeartSprite[i] = HeartImage[i].sprite;
        }
    }

    private void StatsOverTime()
    {
        CurrentHunger -= Time.deltaTime * DecaySpd;
        CurrentHappiness -= Time.deltaTime * DecaySpd;
    }
       
    private void UpdateHunger()
    {
        int hungerPts = (int)CurrentHunger / 20;
    }

    public void Feed()
    {
        CurrentHunger += 20;
    }

    public void Pet()
    {
        CurrentHappiness += 20;
    }
}
