using UnityEngine;

public class laundryFill : MonoBehaviour
{
    private int laundryCount;
    [SerializeField] int maxLaundry;
    [SerializeField] Transform cleanLaundrySpawnpoint;
    [SerializeField] GameObject cleanLaundry;
    [SerializeField] trackTasks taskManager;

    private void Start()
    {
        laundryCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DirtyLaundry")
        {
            Destroy(other.gameObject);
            laundryCount += 1;
            if (laundryCount >= maxLaundry)
            {
                taskManager.laundryDone = true;
                taskManager.checkProgress();
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
