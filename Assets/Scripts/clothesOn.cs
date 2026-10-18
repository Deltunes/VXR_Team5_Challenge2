using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class clothesOn : MonoBehaviour
{
    private XRGrabInteractable _grabInteractable;

    private void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();

        _grabInteractable.selectEntered.AddListener(PickedUp);
    }

    private void PickedUp(SelectEnterEventArgs args)
    {
        Destroy(gameObject);
    }
}
