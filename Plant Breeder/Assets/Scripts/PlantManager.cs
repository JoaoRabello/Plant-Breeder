using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour {

    [SerializeField] private List<PlantBehaviour> plants = new List<PlantBehaviour>();

    [HideInInspector] public PlantBehaviour SelectedPlant;

    private int happinessCurrency;
    private int totalCurrencyIn;
    private float timer = 0f;
    [SerializeField] private float timeToHappiness = 3f;

    [SerializeField] private Text happinessText;

    [SerializeField] private Text waterText;
    [SerializeField] private Text lightText;
    [SerializeField] private Text healthText;
    [SerializeField] private Image image;

    void Awake () {
        SelectedPlant = plants[0];
	}

    void Update () {

        foreach (PlantBehaviour p in plants)
        {
            if(p != null)
            {
                ReduceStatus(p);
            }
        }
        UpdateVisuals(SelectedPlant);
        EarnHappiness();
    }

    private void ReduceStatus(PlantBehaviour p)             //Redução do status de água das plantas pelo tempo
    {
        p.water -= Time.deltaTime * 0.5f;
        p.pLight -= Time.deltaTime * 0.5f;
        p.health -= Time.deltaTime * 0.5f;
    }

    public void SelectPlant(PlantBehaviour p)
    {
        SelectedPlant = p;
    }

    private void UpdateVisuals(PlantBehaviour p)
    {
        image.sprite = p.pSprite;
        waterText.text = "Water: " + p.water.ToString("F0");
        lightText.text = "Light: " + p.pLight.ToString("F0");
        healthText.text = "Health: " + p.health.ToString("F0");
    }

    public void UpdateCurrencyIn()
    {
        totalCurrencyIn = 0;
        foreach (PlantBehaviour p in plants)
        {
            if (p != null)
            {
                totalCurrencyIn += p.plantHappinessValue;
            }
        }
        Debug.Log("Total de felicidade: " + totalCurrencyIn);
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
        }
    }

    public void BuyPlant(PlantBehaviour p)
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
