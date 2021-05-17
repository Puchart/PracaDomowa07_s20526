using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10;
    public float jumpForce = 400;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float xDisplacement = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        isGrounded = true;
    }

    public void HealUsage()
    {
        animator.SetBool("HealBool", true);
        StartCoroutine(PauzaHeal());
    }
    public void WeaponUsage()
    {
        animator.SetBool("WeaponBool", true);
        StartCoroutine(PauzaWeapon());
       
       
    }
    public IEnumerator PauzaHeal()
    {
        
        yield return new WaitForSeconds(1f);
        animator.SetBool("HealBool", false);

    }
    public IEnumerator PauzaWeapon()
    {

        yield return new WaitForSeconds(1f);
        animator.SetBool("WeaponBool", false);

    }
    

}
