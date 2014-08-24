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

    public GameObject explosion;

    public Color color = Color.white;



	// Use this for initialization
	void Start () {
        audio.pitch = 0.95f + Random.Range(0f, 0.1f);
        SetColor(destination.color);
	}


	// Update is called once per frame
	void FixedUpdate () {
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
        GameObject expl = (GameObject)GameObject.Instantiate(explosion, transform.position + new Vector3(0f,0f,-0.1f), Quaternion.identity);
        expl.rigidbody.velocity = rigidbody2D.velocity;
        expl.particleSystem.startColor = this.color;
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        DestroyPackage();
    }

    public void SetColor(Color color)
    {
        this.color = color;
        TrailRenderer rend = GetComponent<TrailRenderer>();
        rend.material.color =  color;

    }


}
