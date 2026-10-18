using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 homePos;
    private XRGrabInteractable _grabInteractable;
    // 0 = Inactive, 1 = held, 2 = thrown
    private int isActive = 0;

    [SerializeField] private CameraFade _blackscreenFade;

    private void Start()
    {
        // Sets up the object for later
        _grabInteractable = GetComponent<XRGrabInteractable>();
        homePos = transform.position;

        // 
        _grabInteractable.selectEntered.AddListener(PickedUp);
        _grabInteractable.selectExited.AddListener(LetGo);
    }

    private void PickedUp(SelectEnterEventArgs args) 
    {
        isActive = 1;
    }

    private void LetGo(SelectExitEventArgs args)
    {
        isActive = 2;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // if the item has been thrown, check if the surface it hits is valid whenever it hits one. If it is, deactivate the object and then teleport player.
        if (isActive == 2)
        {
            if (collision.gameObject.tag == "Teleportable")
            {
                isActive = 0;
                StartCoroutine(fadedelayunfade(0.8f));
                Vector3 playerNewPos = player.transform.position;
                playerNewPos.x = transform.position.x;
                playerNewPos.z = transform.position.z;
                player.transform.position = playerNewPos;
                transform.position = homePos;
            }
        }
    }

    private IEnumerator fadedelayunfade(float delay)
    {
        _blackscreenFade.Fade(true);

        yield return new WaitForSeconds(delay);

        _blackscreenFade.Fade(false);
    }
}
