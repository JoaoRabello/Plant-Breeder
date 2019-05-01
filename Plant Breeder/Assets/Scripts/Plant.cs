using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject {

    [Tooltip("Sprite da planta")]
    public Sprite sprite;

    [Tooltip("Valor de felicidade individual que a planta gera")]
    public float plantHappinessValue;

    [Tooltip("Valor máximo de água da planta")]
    public float waterMax;
    [Tooltip("Valor máximo de luz da planta")]
    public float lightMax;
    [Tooltip("Valor máximo de saúde da planta")]
    public float healthMax;
	
}
