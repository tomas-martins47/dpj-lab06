using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Token : MonoBehaviour
{
    public int value;
    public AudioClip pickupSfx;

    private new Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddScore(value);
        }

        if (pickupSfx != null)
        {
            AudioSource.PlayClipAtPoint(pickupSfx, transform.position);
        }

        Destroy(gameObject);
    }
}