using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Packet : MonoBehaviour {

    /// <summary>
    /// Final destination
    /// </summary>
    public Relay destination;



    public float speed = 1f;


    /// <summary>
    /// Current target
    /// </summary>
    public Relay target;

    /// <summary>
    /// Value if it arrives, deteriorates over time?
    /// </summary>
    public float value;




	// Use this for initialization
	void Start () {
        audio.pitch = 0.95f + Random.Range(0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = (target.transform.position - transform.position).normalized * speed;

        transform.LookAt(target.transform, Vector3.up);


        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            target.PacketArrive(this);
        }

	}

    /// <summary>
    /// Bumped into something, arrived Relay without a target (Failure!).
    /// </summary>
    public void DestroyPackage()
    {

    }

}
