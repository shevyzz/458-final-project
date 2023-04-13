using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TableFlipL : MonoBehaviour
{
    public Animator FlipL;
    public bool open;
    public Transform Player;

    void Start()
    {
        open = false;

        var xrGrabInteractable = GetComponent<XRGrabInteractable>();
        xrGrabInteractable.onSelectEntered.AddListener(OnGrabbed);
    }

    void OnGrabbed(XRBaseInteractor interactor)
    {
        if (open == false)
        {
            StartCoroutine(opening());
        }
        else
        {
            StartCoroutine(closing());
        }
    }

    IEnumerator opening()
    {
        print("you are opening the door");
        FlipL.Play("Lup");
        open = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        FlipL.Play("Ldown");
        open = false;
        yield return new WaitForSeconds(0.5f);
    }
}
