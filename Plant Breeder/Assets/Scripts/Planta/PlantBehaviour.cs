using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBehaviour : MonoBehaviour
{
    public PlantDisplay plant;

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Water"))
        {
            if(plant.water < plant.waterMax)
                plant.water++;
        }
    }

}
