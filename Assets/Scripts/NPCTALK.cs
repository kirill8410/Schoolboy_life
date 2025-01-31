using UnityEngine;

public class NPCTALK : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
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
