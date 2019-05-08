using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour {

    public static PlantManager instance;

    [SerializeField] private List<PlantDisplay> plants = new List<PlantDisplay>();

    [HideInInspector] public PlantDisplay SelectedPlant;

    public int happinessCurrency;
    private int totalCurrencyIn;
    private float timer = 0f;
    [SerializeField]
    private float timeToHappiness = 3f;

    [SerializeField] private Text happinessText;

    [SerializeField] private Text waterText;
    [SerializeField] private Slider waterSld;
    [SerializeField] private Text lightText;
    [SerializeField] private Text healthText;
    [SerializeField] private Image image;

    void Awake () {

        if(instance == null)
        {
            instance = this;
        }

        SelectedPlant = plants[0];
	}

    void Update () {

        foreach (PlantDisplay p in plants)
        {
            if(p != null)
            {
                ReduceStatus(p);
            }
        }
        UpdateVisuals(SelectedPlant);
        EarnHappiness();
    }

    private void ReduceStatus(PlantDisplay p)             //Redução do status de água das plantas pelo tempo
    {
        p.water -= Time.deltaTime * 0.5f;
        p.pLight -= Time.deltaTime * 0.5f;
        p.health -= Time.deltaTime * 0.5f;
    }

    public void SelectPlant(PlantDisplay p)
    {
        SelectedPlant = p;
    }

    private void UpdateVisuals(PlantDisplay p)
    {
        image.sprite = p.pSprite;
        waterText.text = "Água: " + p.water.ToString("F0");
        waterSld.value = p.water;
        lightText.text = "Luz: " + p.pLight.ToString("F0");
        healthText.text = "Saúde: " + p.health.ToString("F0");
    }

    public void UpdateCurrencyIn()
    {
        totalCurrencyIn = 0;
        foreach (PlantDisplay p in plants)
        {
            if (p != null)
            {
                totalCurrencyIn += p.plantHappinessValue;
            }
        }
    }

    private void EarnHappiness()
    {
        happinessText.text = "Felicidade: " + happinessCurrency.ToString();
        if (timer <= timeToHappiness)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            happinessCurrency += totalCurrencyIn;
            SaveSystem.instance.Save();
        }
    }

    public void BuyPlant(PlantDisplay p)
    {
        if (p.plant.plantPrice <= happinessCurrency && p.owned == false)
        {
            happinessCurrency -= p.plant.plantPrice;
            plants.Add(p);
            p.owned = true;
            p.gameObject.SetActive(true);
        }
    }
}
