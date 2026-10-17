using UnityEngine;

public class laundryFill : MonoBehaviour
{
    private int laundryCount;
    [SerializeField] int maxLaundry;
    public bool laundryComplete;
    [SerializeField] Transform cleanLaundrySpawnpoint;
    [SerializeField] GameObject cleanLaundry;

    private void Start()
    {
        laundryCount = 0;
        laundryComplete = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DirtyLaundry")
        {
            Destroy(other.gameObject);
            laundryCount += 1;
            if (laundryCount >= maxLaundry)
            {
                print("Laundry Machine Filled!");
                laundryComplete = true;
                spawnCleanLaundry();
            }
        }
    }

    private void spawnCleanLaundry()
    {
        for (int i = 0; i < maxLaundry; i++)
        {
            Instantiate(cleanLaundry, cleanLaundrySpawnpoint.position, cleanLaundrySpawnpoint.rotation);
        }
    }
}
