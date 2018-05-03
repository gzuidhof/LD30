using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Relay : MonoBehaviour {

    public Relay target;
    public bool isDestination = false;

    public static List<Relay> destinations;
    public Renderer rendererToColor;
    public Color color;

    private static List<Relay> relays = new List<Relay>();

	void Awake () {

        if (Relay.destinations == null)
            Relay.destinations = new List<Relay>();


        if (target == null)
        {
            //target = GetClosestRelay();
        }

        if (GetComponent<Orbit>() && GetComponent<Orbit>().around)
        {
            GameManager.SetRealisticSpeed(gameObject);
        }


        relays.Add(this);

        if(isDestination)
        {
            GameManager.RegisterDestination(this);
            destinations.Add(this);
        }
	}
	
    private Relay GetClosestRelay()
    {

        Relay closest = null;
        foreach (var rel in relays)
        {
            if (closest == null || Vector3.Distance(transform.position, rel.transform.position) < Vector3.Distance(transform.position, closest.transform.position))
                closest = rel;
        }
        return closest;
    }



	// Update is called once per frame
	void Update () {
	
	}

    public void PacketArrive(Packet package)
    {
        if (package.destination == this)
            GameManager.instance.Score(package);
        else if (target == null)
        {
            Debug.Log("Destroying package, because target is null");
            package.DestroyPackage();
        }
        else
        {
            package.target = target;
            package.GetComponent<AudioSource>().Play();
        }

    }


    public void SetColor(Color col)
    {
        this.color = col;
        rendererToColor.material.color = color;
    }

}
