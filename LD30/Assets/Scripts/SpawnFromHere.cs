using UnityEngine;
using System.Collections;

public class SpawnFromHere : MonoBehaviour {

    public Relay[] target;

    public float delay = 5f;
    public int amountLeft;


	// Use this for initialization
	void Start () {
        GameManager.AnnounceSpawn(amountLeft);
        if (amountLeft > 0)
            Invoke("Spawn", delay);
	}
	
	void Spawn()
    {
        PacketSpawner.instance.SpawnPackage(this.GetComponent<Relay>(), target[Random.Range(0, target.Length)]);
        amountLeft--;
        if (amountLeft > 0)
            Invoke("Spawn", delay);
        
    }
}
