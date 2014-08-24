using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Orbit))]
public class BuySattelitePreview : MonoBehaviour {

    public Orbit orbit;
    public static BuySattelitePreview instance;
    public Planet around;
    protected bool isValid = false;


    void Awake()
    {
        orbit = GetComponent<Orbit>();
        instance = this;
    }

	// Use this for initialization
	void Start () {
        
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, -Camera.main.ScreenToWorldPoint(Input.mousePosition).z); ;
        orbit.around = around.transform;
        orbit.distance = Vector3.Distance(transform.position, around.transform.position);
        
        orbit.initPosition();
        orbit.speed = 0f;

        if (around.isInRange(transform.position))
        {
            renderer.material.color = Color.white;
            isValid = true;
        }
        else
        {
            renderer.material.color = Color.red;
            isValid = false;
        }

	}





}
