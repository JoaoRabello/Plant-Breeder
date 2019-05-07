using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour {

    float timer = 0f;
	
	void Update () {
		if(timer <= 1f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
