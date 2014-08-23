using UnityEngine;
using System.Collections;

public class Packet : MonoBehaviour {

    /// <summary>
    /// Final destination
    /// </summary>
    public Relay destination;

    public float speed;

    /// <summary>
    /// Current target
    /// </summary>
    public Relay target;

    public float value;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Bumped into something, arrived Relay without a target (Failure!).
    /// </summary>
    public void DestroyPackage()
    {

    }

}
