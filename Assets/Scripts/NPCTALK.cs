using UnityEngine;

public class NPCTALK : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Talk();
        }
    }
    private void Talk()
    {
        audioSource.Play();
    }
}
