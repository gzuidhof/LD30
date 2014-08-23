using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

    public Transform around;
    public float distance;
    public float speed;
    private float position;

	// Use this for initialization
	void Start () {
	    if (around != null)
        {
            distance = Vector3.Distance(around.position, transform.position);
            position = Mathf.Atan2(transform.position.y - around.position.y, transform.position.x - around.position.x);
        }
	}
	
	// Update is called once per frame
	void Update () {
        position += speed * Time.deltaTime;
        transform.position = new Vector3(around.position.x + distance * Mathf.Cos(position), around.position.y + distance * Mathf.Sin(position), 0f);
	}
}
