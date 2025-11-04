using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform pointA;      // Erster Punkt der Patrouille
    public Transform pointB;      // Zweiter Punkt der Patrouille
    public float speed = 2f;      // Bewegungsgeschwindigkeit

    private Vector3 target;       // Aktuelles Ziel

    void Start()
    {
        // Startziel setzen
        target = pointB.position;
    }

    void Update()
    {
        // Block zum Ziel bewegen
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Wenn Ziel erreicht, Ziel wechseln
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }

        // Optional: Block in Bewegungsrichtung spiegeln
        Flip();
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        if (target.x > transform.position.x)
            localScale.x = Mathf.Abs(localScale.x);
        else
            localScale.x = -Mathf.Abs(localScale.x);

        transform.localScale = localScale;
    }

    // Zeichnet die Patrol-Punkte im Editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (pointA != null && pointB != null)
        {
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawSphere(pointA.position, 0.1f);
            Gizmos.DrawSphere(pointB.position, 0.1f);
        }
    }
}