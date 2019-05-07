using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour {

    Camera cam;
    public GameObject gota;
    float timer = 0f;
    float timeToSpawn = 0.05f;

	// Use this for initialization
	void Start () {

        cam = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {

        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(timer <= timeToSpawn)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                Instantiate(gota, new Vector3(transform.position.x + Random.Range(-0.4f,0.4f), transform.position.y), Quaternion.identity);
            }
        }

	}
}
