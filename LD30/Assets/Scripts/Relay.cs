using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Relay : MonoBehaviour {

    public Relay target;
    public bool isDestination = false;

    public static List<Relay> destinations;
    public Renderer rendererToColor;
    public Color color;

	void Awake () {
        if (Relay.destinations == null)
            Relay.destinations = new List<Relay>();

        if(isDestination)
        {
            destinations.Add(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PacketArrive(Packet package)
    {
        if (package.destination == this)
            ;//Do something
        else if (target == null)
            package.DestroyPackage();
        else
        {
            package.target = target;
            package.audio.Play();
        }

    }


    public void SetColor(Color col)
    {
        this.color = col;
        rendererToColor.material.color = color;
    }

}
