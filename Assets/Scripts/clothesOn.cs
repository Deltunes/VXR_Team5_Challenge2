using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class teethBrushed : MonoBehaviour
{
    private XRGrabInteractable _grabInteractable;
    [SerializeField] trackTasks taskManager;

    private void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();

        _grabInteractable.selectEntered.AddListener(PickedUp);
    }

    private void PickedUp(SelectEnterEventArgs args)
    {
        taskManager.clothesDone = true;
        taskManager.checkProgress();
        Destroy(gameObject);
    }
}
