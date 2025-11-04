using UnityEngine;

public class Player_Script : MonoBehaviour
{
public float moveSpeed = 3f;
public float jumpForce = 4f;

public float superJump = 8f;
public float superSpeed = 6f;

private Rigidbody2D rb;

private bool grounded;

void OnCollisionEnter2D(Collision2D collision)
{
if (collision.gameObject.tag == ("Ground"))
{
grounded = true;
Debug.Log("Grounded");
}
}
void OnCollisionExit2D(Collision2D collision)
{
if (collision.gameObject.tag == "Ground")
{
grounded = false;
Debug.Log("UnGrounded");
}
}

void Start()
{
rb = GetComponent<Rigidbody2D>();
rb.freezeRotation = true;

}

void Update()
{
//superSpeed
if (Input.GetKey(KeyCode.LeftShift))
{
moveSpeed = superSpeed;
}
else
{
moveSpeed = 3f;
}

// Move Right
if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
{
transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
}

// Move Left
if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
{
transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
}

// Jump
if (Input.GetKeyDown(KeyCode.Space) && grounded)
{
rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
}
//superJump
if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Space) && grounded)
{
rb.AddForce(Vector2.up * superJump, ForceMode2D.Impulse);
}
}
}


