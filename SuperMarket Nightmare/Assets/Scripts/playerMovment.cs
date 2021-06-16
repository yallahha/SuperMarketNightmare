using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovment : MonoBehaviour
{
    public float speed;
    public float jump;
    public int health;
    public Rigidbody2D rb;
    private float width;
    private float height;

    public bool isGrounded;
    public LayerMask ground;
    public Slider healthBar;

    private Vector2 screenBoundries;

    private Collider2D myCollider;

    float mx;
    float my;

    private void Start(){
        myCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            scoreScript.scoreVal = scoreScript.scoreVal - 5;
            health = health - 2;
            Destroy(other.gameObject);
            if(health == 0){
                Destroy(myCollider.gameObject);
                Application.Quit();

            }
        }
        else if(other.gameObject.CompareTag("Karen")){
            Destroy(myCollider.gameObject);
            Destroy(other.gameObject);
            Application.Quit();
        }
        
    }

    private void Update(){
        mx = Input.GetAxisRaw("Horizontal");
        healthBar.value = health;
    }


    private void FixedUpdate(){

        isGrounded = Physics2D.IsTouchingLayers(myCollider, ground);
        
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, (float)0.07, (float)0.93);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Vector2 jumpmovment = new Vector2(rb.velocity.x, jump);
            rb.velocity = jumpmovment;
        }
        else{
        Vector2 movement = new Vector2(mx * speed, rb.velocity.y);
        rb.velocity = movement;
        }
        
    }
}
