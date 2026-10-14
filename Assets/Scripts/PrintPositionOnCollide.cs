using UnityEngine;

public class PrintPositionOnCollide : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        print(transform.position);
        Vector3 playerNewPos = player.transform.position;
        playerNewPos.x = transform.position.x;
        playerNewPos.z = transform.position.z;
        player.transform.position = playerNewPos;
    }
}
