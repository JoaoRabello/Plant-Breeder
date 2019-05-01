using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    public float plantValue;
    public float timeToEarnHappiness;
    private float timer;

    public float happiness;
    public float water;
    public float sun;
    public float health;
	
	void Start () {
        happiness = 0f;
        water = 0f;
        sun = 0f;
        health = 0f;
	}
	
	void Update () {
		
        if(timer <= timeToEarnHappiness)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            happiness += plantValue;
            Debug.Log("Felicidade: " + happiness.ToString("F0"));
        }
	}
}
