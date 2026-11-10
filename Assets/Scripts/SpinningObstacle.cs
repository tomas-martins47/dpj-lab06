using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    [SerializeField] private float xAngle = 0f;
    [SerializeField] private float yAngle = 0f;
    [SerializeField] private float zAngle = 0f;

    private void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
