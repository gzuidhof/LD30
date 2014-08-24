using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public float speed = 1f;
    public bool startRandom;


	// Use this for initialization
	void Start () {
        if (startRandom)
            transform.Rotate(transform.forward, Random.Range(0f, 360f));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.forward, Time.deltaTime * speed);
	}
}
