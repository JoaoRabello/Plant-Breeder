using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour {

    [SerializeField] private List<PlantBehaviour> plants = new List<PlantBehaviour>();

    private string selectedPlant;
    public PlantBehaviour SelectedPlant;

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
                //Debug.Log(p.name + " water: " + p.water.ToString("F0"));
            }
        }
        UpdateVisuals(SelectedPlant);
    }

    private void ReduceStatus(PlantBehaviour p)             //Redução do status de água das plantas pelo tempo
    {
        p.water -= Time.deltaTime * 0.5f;
        p.pLight -= Time.deltaTime * 0.5f;
        p.health -= Time.deltaTime * 0.5f;
    }

    public void SelectPlant(PlantBehaviour p)
    {
        selectedPlant = p.plant.name;
        SelectedPlant = p;
    }

    private void UpdateVisuals(PlantBehaviour p)
    {
        image.sprite = p.pSprite;
        waterText.text = "Water: " + p.water.ToString("F0");
        lightText.text = "Light: " + p.pLight.ToString("F0");
        healthText.text = "Health: " + p.health.ToString("F0");
    }
}
