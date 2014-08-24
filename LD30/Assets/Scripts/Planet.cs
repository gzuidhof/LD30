using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

    public static List<Planet> planets = new List<Planet>();

    public float radius = 1f;

    void Awake()
    {
        planets.Add(this);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isInRange(Vector3 position)
    {
        return Vector3.Distance(position, transform.position) < radius * transform.localScale.x + radius * transform.localScale.x * 15f
            && Vector3.Distance(position, transform.position) > radius * transform.localScale.x * 1.25f
                && (GetComponent<Orbit>() ? Vector3.Distance(position, transform.position) < GetComponent<Orbit>().distance * 0.50f : true);
    }

}
