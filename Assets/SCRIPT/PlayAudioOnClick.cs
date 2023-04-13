using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAudioOnClick : MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
