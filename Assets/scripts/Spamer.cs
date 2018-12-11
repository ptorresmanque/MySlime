using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spamer : MonoBehaviour {

    public GameObject pajarraco;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeBtwSpawn <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-23.0f, 7.0f), Random.Range(-13.0f, 7.0f), 0);
            Instantiate(pajarraco, position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            startTimeBtwSpawn -= decreaseTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
	}
}
