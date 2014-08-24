using UnityEngine;
using System.Collections;

/// <summary>
/// Draws the little orbs flying from one relay to another
/// </summary>
public class PathDrawer : MonoBehaviour {


    public ParticleSystem system;
    public Relay relay;

    private Transform prevTarget;

	// Use this for initialization
	void Start () {
        system = GetComponent<ParticleSystem>();
        relay = transform.parent.GetComponent<Relay>();
	}
	
	// Update is called once per frame
	void Update () {

        if (relay.target == null)
        {
            system.Stop();
            return;
        }
        Transform target = relay.target.transform;

        if (target != prevTarget)
        {
            prevTarget = target;
            system.Stop();
            system.Play();
        }

        Vector3 lookAtPos;
        float estTime = Vector3.Distance(transform.position, target.position) / system.startSpeed;

        Orbit o = target.root.GetComponent<Orbit>();
        if (o)
        {
            lookAtPos = o.ExtraPolate(estTime);
            estTime = Vector3.Distance(transform.position, lookAtPos) / system.startSpeed;
        }
        else
        {
            lookAtPos = target.position;
        }


        transform.LookAt(lookAtPos);
        system.startLifetime = estTime;
	}




}
