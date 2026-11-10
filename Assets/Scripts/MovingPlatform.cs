using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    private Transform targetPoint;
    
    private float movingSpeed = 2f;
    private float waitingTime = 0f;
    private float waitTimer;
    
    private bool isWaiting;

    private void Start()
    {
        targetPoint = PointB;
        waitTimer = 0f;
        isWaiting = false;
    }

    private void Update()
    {
        if (isWaiting == true)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitingTime)
            {
                targetPoint = (targetPoint == PointA) ? PointB : PointA;
                isWaiting = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, movingSpeed * Time.deltaTime);

            // Verifica se a distância entre a plataforma e o ponto de destino é inferior a 0.01 unidades
            // Se for, posiciona a plataforma exatamente no destino e reinicia o tempo de espera
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
            {
                transform.position = targetPoint.position;
                isWaiting = true;
                waitTimer = 0f;
            }
        }
        
    }
}
