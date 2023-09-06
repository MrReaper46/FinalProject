using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("SET_PETSTATS")]
    [SerializeField] protected PetStats PetStats_Select;

    [Header("SET_TEXT")]
    protected TMP_Text hungerVal;
    public TMP_Text HungerVal { get => hungerVal; set => hungerVal = value; }
    protected TMP_Text happinessVal;
    public TMP_Text HappinessVal { get => happinessVal; set => happinessVal = value; }

    [Header("SET_BUTTON")]
    protected Button petBtn;
    public Button PetBtn { get => petBtn; }
    protected Button feedBtn;
    public Button FeedBtn { get => feedBtn; }

    [Header("SET_IMG")]
    [SerializeField] protected GameObject[] ui_EN;
    [SerializeField] protected Image[] img_EN;
    
    [Header("LOAD_SPRITE")]
    [SerializeField] protected Sprite EN_on;
    [SerializeField] protected Sprite EN_off;

    [Header("LOAD_SLIDER")]
    [SerializeField] protected Slider HappinessFill;

    [Header("REMAINING_RESOURCE")]
    [SerializeField] protected int remainEN;
    [SerializeField] protected int remainHP;
    [SerializeField] protected int maxEN;
    [SerializeField] protected int maxHP;

    private static UIManager instance;
    public static UIManager Instance { get => instance; }
    

    void Awake()
    {
        instance = this;
    }

    public void LoadResourceForUI()
    {
        SetupStat();
        SetUI();
        SetSprite();
        SetButton();
    }

    private void SetupStat()
    {
        PetStats_Select = GameObject.Find("Pet").GetComponent<PetStats>();
        HungerVal = GameObject.Find("Hunger_stat").GetComponent<TMP_Text>();
        HappinessVal = GameObject.Find("Happiness_stat").GetComponent<TMP_Text>();
    }

    private void SetUI()
    {
        HappinessFill = GameObject.Find("Happiness/Bar_Happiness").GetComponent<Slider>();
        ui_EN = new GameObject[GameObject.FindGameObjectsWithTag("UI_EN").Length];
        ui_EN = GameObject.FindGameObjectsWithTag("UI_EN");

        img_EN = new Image[GameObject.FindGameObjectsWithTag("UI_EN").Length];
        for (int i = 0; i < img_EN.Length; ++i)
        {
            img_EN[i] = ui_EN[i].GetComponent<Image>();
        }
    }

    private void SetButton()
    {
        petBtn = GameObject.Find("Btn_Pet").GetComponent<Button>();
        feedBtn = GameObject.Find("Btn_Feed").GetComponent<Button>();
        PetBtn.onClick.AddListener(Pet);
        FeedBtn.onClick.AddListener(Feed);
    }

    private void SetSprite()
    {
        EN_on = Resources.Load<Sprite>("UI/energy");
        EN_off = Resources.Load<Sprite>("UI/energy_disable");
    }

    void Update()
    {
        UpdateStatsPanel();

        maxEN = Mathf.CeilToInt(PetStats_Select.MaxHunger / 20);
        maxHP = Mathf.CeilToInt(PetStats_Select.MaxHappiness);
        remainEN = Mathf.CeilToInt(PetStats_Select.CurrentHunger / 20);
        remainHP = Mathf.CeilToInt(PetStats_Select.CurrentHappiness);

        UpdateStat(maxEN,remainEN,img_EN,EN_on,EN_off);

        HappinessFill.value = remainHP;
    }

    private void UpdateStat(int max, int remain, Image[] img, Sprite sprite_On, Sprite  sprite_Off)
    {
        for (int i = 0; i < remain; i++)
        {
            img[i].sprite = sprite_On;
        }
        for (int i = max - 1; i >= remain; i--)
        {
            img[i].sprite = sprite_Off;
        }
    }

    private void UpdateStatsPanel()
    {
        HungerVal.text = PetStats_Select.CurrentHunger.ToString("0");
        HappinessVal.text = PetStats_Select.CurrentHappiness.ToString("0");
    }

    void Pet()
    {
        PetStats_Select.CurrentHappiness += 20;
    }

    void Feed()
    {
        PetStats_Select.CurrentHunger += 20;
    }

}
