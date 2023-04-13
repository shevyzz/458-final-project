using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenCloseDoor : MonoBehaviour
{
    public Animator openandclose;
    public bool open;
    public XRGrabInteractable handle;

    void Start()
    {
        open = false;
        handle.onSelectEntered.AddListener(HandleGrabbed);
    }

    void HandleGrabbed(XRBaseInteractor interactor)
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
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator closing()
    {
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(0.5f);
    }
}
