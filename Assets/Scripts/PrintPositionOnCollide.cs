using UnityEngine;

public class PrintPositionOnCollide : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 homePos;

    private void Start()
    {
        homePos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Teleportable")
        {
            Vector3 playerNewPos = player.transform.position;
            playerNewPos.x = transform.position.x;
            playerNewPos.z = transform.position.z;
            player.transform.position = playerNewPos;
            transform.position = homePos;
        }
    }
}
