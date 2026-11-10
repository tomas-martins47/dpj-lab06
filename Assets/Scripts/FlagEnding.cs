using UnityEngine;

public class FlagEnding : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You won! " + "You got " + UIManager.Instance.score + " points!");
        }
    }
}
