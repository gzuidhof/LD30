using UnityEngine;
using System.Collections;

public class SpawnFromHere : MonoBehaviour {

    public Relay[] target;

    public float delay = 8f;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", delay, delay);
	}
	
	void Spawn()
    {
        PacketSpawner.instance.SpawnPackage(this.GetComponent<Relay>(), target[Random.Range(0, target.Length)]);
    }
}
