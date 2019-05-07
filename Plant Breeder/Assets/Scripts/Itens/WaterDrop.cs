using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour {

    float timer = 0f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-80f, 80f), 0f), ForceMode2D.Force);
    }

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

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("Plant"))
            Destroy(this.gameObject);
    }
}
