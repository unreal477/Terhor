using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth phealth;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
