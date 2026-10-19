using UnityEngine;

public class keyDetector : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] trackTasks taskManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Keys" && taskManager.allTasksComplete == true)
        {
            anim.SetTrigger("Open");
            Destroy(other.gameObject);
        }
    }
}
