using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelSettings
{
    public int collectPackages = 3;
    public int satteliteCount = 0;

    public int packagesUnsent = 0;
    public int packagesSent = 0;
    public int packageLoss = 0;
    public int packageDelivered = 0;

    public TextMesh sat;
    public TextMesh loss;
    public TextMesh sent;
    public TextMesh unsent;
    public TextMesh obj;

    public void init()
    {
        sat = Camera.main.transform.Find("sat").GetComponent<TextMesh>();
        loss = Camera.main.transform.Find("loss").GetComponent<TextMesh>();
        sent = Camera.main.transform.Find("sent").GetComponent<TextMesh>();
        unsent = Camera.main.transform.Find("unsent").GetComponent<TextMesh>();
        obj = Camera.main.transform.Find("obj").GetComponent<TextMesh>();
        obj.text = "Messages Delivered = " + packageDelivered + " out of " + collectPackages;
    }



}

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject sattelitePrefab;
    public GameObject successPrefab;
    public GameObject finishedEnable;
    public GameObject failedEnable;
    public LevelSettings level;


    public void sendPackage()
    {

    }

    private int sattelitesLeft;


    void Awake()
    {
        instance = this;
        level.init();
        if (Relay.destinations == null) return;
        for (int i = 0; i < Relay.destinations.Count; i++)
        {
            if (!Relay.destinations[i])
            {
                Relay.destinations.Remove(Relay.destinations[i]);
                i--;
            }

        }
    }

	// Use this for initialization
	void Start () {

        finishedEnable = Camera.main.transform.Find("LevelCompleted").gameObject;
        level.sat.text = "Satellites = " + level.satteliteCount;
        failedEnable = Camera.main.transform.Find("LevelFailed").gameObject;

	}

    public void Score(Packet p)
    {
        GameObject suc = (GameObject) GameObject.Instantiate(successPrefab, p.transform.position, Quaternion.identity);
        suc.GetComponent<ParticleSystem>().startColor = p.color;
        suc.GetComponent<AudioSource>().pitch = p.GetComponent<AudioSource>().pitch;
        Destroy(p.gameObject);
        Destroy(suc.gameObject, 10f);
        level.packageDelivered++;

        level.obj.text = "Messages Delivered = " + level.packageDelivered + " out of " + level.collectPackages;

        if (level.packageDelivered >= level.collectPackages)
        {
            finishedEnable.SetActive(true);
        }
    }


    public void BuySattelite()
    {
        BuySattelitePreview p = BuySattelitePreview.instance;
        if (!p.isValid || level.satteliteCount<1) return;
        level.satteliteCount--;
        level.sat.text = "Satellites = " + level.satteliteCount;


        GameObject sat = (GameObject)GameObject.Instantiate(sattelitePrefab, p.transform.position, p.transform.rotation);
        sat.GetComponent<Orbit>().around = p.around.transform;
        SetRealisticSpeed(sat);

    }

    public static void SetRealisticSpeed(GameObject sat)
    {
        Vector3 extraP = sat.GetComponent<Orbit>().ExtraPolate(1f);
        float dist = Vector3.Distance(sat.transform.position, extraP);
        sat.GetComponent<Orbit>().speed = sat.GetComponent<Orbit>().speed * 30f / (dist * dist);
    }



    internal static void RegisterDestination(Relay relay)
    {
        relay.SetColor(ColorUtil.GenerateGoldenRatioColor());

    }

    internal static void AnnounceSpawn(int amountLeft)
    {
        instance.level.packagesUnsent += amountLeft;
        instance.level.unsent.text = "Packets unsent " + instance.level.packagesUnsent;
    }

    internal static void SendPackage()
    {

        instance.level.packagesUnsent --;
        instance.level.unsent.text = "Packets unsent " + instance.level.packagesUnsent;

        instance.level.packagesSent ++;
        instance.level.sent.text = "Packets sent " + instance.level.packagesSent;
    }

    internal static void PackageLoss()
    {
        instance.level.packageLoss++;
        instance.level.loss.text = "Packet loss " + instance.level.packageLoss;

        if (instance.level.collectPackages - instance.level.packageDelivered > instance.level.packagesSent + instance.level.packagesUnsent - instance.level.packageLoss)
            instance.failedEnable.SetActive(true);

    }
}
