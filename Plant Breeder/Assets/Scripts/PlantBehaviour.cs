using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBehaviour : MonoBehaviour
{
    public Plant plant;

    [HideInInspector] public float plantHappinessValue;

    [HideInInspector] public float waterMax, water;
    [HideInInspector] public float lightMax, pLight;
    [HideInInspector] public float healthMax, health;
     public Sprite pSprite;

    void Awake()
    {
        GetComponent<Image>().sprite = plant.sprite;
        pSprite = plant.sprite;

        waterMax = plant.waterMax;
        lightMax = plant.lightMax;
        healthMax = plant.healthMax;

        water = waterMax;
        pLight = lightMax;
        health = healthMax;
    }
}
