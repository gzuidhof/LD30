using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

    //Transform it is orbiting around.
    public Transform around;

    //Radius from body which it is orbiting around to orbiting body.
    public float distance;

    //Rad per sec
    public float speed;

    // Current position, ranges from 1pi to -1pi (although it's % 2pi)
    public float position;

	// Use this for initialization
	void Start () {
	    if (around != null)
        {
            distance = Vector3.Distance(around.position, transform.position);
            position = Mathf.Atan2(
                transform.position.y - around.position.y, 
                transform.position.x - around.position.x);
        }

        

	}
	
	// Update is called once per frame
	void Update () {
        position += speed * Time.deltaTime;
        transform.position = new Vector3(
            around.position.x + distance * Mathf.Cos(position), 
            around.position.y + distance * Mathf.Sin(position), 0f);
	}

    public Vector3 ExtraPolate(float time)
    {
        return new Vector3(
            around.position.x + distance * Mathf.Cos(position + speed * time),
            around.position.y + distance * Mathf.Sin(position + speed * time), 0f);
    }

    public void initPosition()
    {
        position = Mathf.Atan2(
                transform.position.y - around.position.y,
                transform.position.x - around.position.x);
    }

}
