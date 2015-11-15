using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Animator anim;
    // Use this for initialization
    void Start () {
        anim = this.gameObject.GetComponent<Animator>();
    }
    public bool isGrounded = false;
    bool GravSwitch = false;
    bool once = false;
    int moveDistance = 5;

    // Update is called once per frame
    void Update()
    {
        if (!once && Time.timeScale == 0)
        {
            once = true;
            if (isGrounded)
            {
                Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(Physics2D.gravity.y * Vector2.up * 20);
            }
        }
        if(Time.timeScale == 1)
        {
            once = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
            if ((deltaPosition.y >= moveDistance && Physics2D.gravity.y < 0 || deltaPosition.y <= -moveDistance && Physics2D.gravity.y > 0) && Time.timeScale == 1)
            {
                if (isGrounded)
                {
                    ChangeGravity();
                    GravSwitch = true;
                    anim.SetInteger("Gravity", (int)Physics2D.gravity.y);
                }
            }
        }

        if (!GravSwitch)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && Time.timeScale == 1)
            {
                if (isGrounded)
                {
                    Jump();
                    anim.SetTrigger("Jump");
                }
            }
        }
        else
        {
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                GravSwitch = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                anim.SetTrigger("Jump");
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isGrounded)
            {
                ChangeGravity();
                anim.SetInteger("Gravity", (int)Physics2D.gravity.y);
            }
        }

        if(this.gameObject.transform.position.y <= -100 || this.gameObject.transform.position.y>=100)
        {
            Physics2D.gravity = new Vector3(0, -Mathf.Abs(Physics2D.gravity.y));
            Application.LoadLevel(0);
        }
    }

    void Jump()
    {
        Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(-Physics2D.gravity.y * Vector2.up * 20);
    }

    void ChangeGravity()
    {
        Physics2D.gravity = -Physics2D.gravity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Level"))
        {
            if (Physics2D.gravity.y < 0)
            {
                RaycastHit2D hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.down * 5 + Vector2.left * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }

                hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.down * 5 + Vector2.right * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.up * 5 + Vector2.left * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }

                hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.up * 5 + Vector2.right * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Level"))
        {
            if (Physics2D.gravity.y < 0)
            {
                RaycastHit2D hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.down * 5 + Vector2.left * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }

                hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.down * 5 + Vector2.right * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.up * 5 + Vector2.left * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }

                hit = Physics2D.Raycast((Vector2)this.gameObject.transform.position + Vector2.up * 5 + Vector2.right * 3, Vector2.down, 0.1f);
                if (hit)
                {
                    isGrounded = true;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Level"))
        {
            isGrounded = false;
        }
    }
}
