using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //กระโดดไหม
    [SerializeField] bool isJumping;
    //เดิน
    private Rigidbody2D rb2d;
    private float move;
    [SerializeField] float Speed;
    //กระโดด
    [SerializeField]float JumpForce;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        //กดเสปดบากระโดด
        if (Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            rb2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            Debug.Log(JumpForce);
        }
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
