using UnityEngine;
using System.Collections;

public class PacketSpawner : MonoBehaviour {


    public GameObject packagePrefab;

    public float spawnInterval = 6f;
    public float spawnIntervalReduction = 0.005f;

    public static PacketSpawner instance;


    public bool spawn = true;

	// Use this for initialization
	void Start () {
        instance = this;
        if(spawn)
            Invoke("AttemptSpawn", spawnInterval);
	}

    void AttemptSpawn()
    {
        //Debug.Log("Attempting spawn of package");

        int attemptNumber = 0;

        while(attemptNumber < 4)
        {
            Relay from = Relay.destinations[Random.Range(0, Relay.destinations.Count)];

            RaycastHit2D[] hits =Physics2D.RaycastAll(from.transform.position, from.target.transform.position - from.transform.position);
            bool possible = true;
            foreach (var hit in hits)
            {
                
                if (hit.collider && hit.collider.CompareTag("Planet")) 
                    possible = false;
            }

            if (!possible)
            {
                attemptNumber++;
            }
            else //Spawn package!
            {
                SpawnPackage(from);
                spawnInterval -= spawnIntervalReduction;
                Invoke("AttemptSpawn", spawnInterval);
                return;
            }

        }


    }

    public void SpawnPackage(Relay from, Relay destination = null)
    {
        GameManager.SendPackage();
        GameObject pack = (GameObject)GameObject.Instantiate(packagePrefab, from.transform.position, Quaternion.identity);
        Packet p = pack.GetComponent<Packet>();
        if (destination == null)
            p.destination = Relay.destinations[Random.Range(0, Relay.destinations.Count)];
        else
            p.destination = destination;
        p.target = from.target;
        p.SetColor(p.destination.color);
    }

}
