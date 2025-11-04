using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image Healthbar;
    public GameObject player;
    public Transform respawnpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            player.transform.position = respawnpoint.position;
            health = maxHealth;

        }
    }
}
