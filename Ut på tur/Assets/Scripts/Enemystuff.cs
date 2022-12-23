using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystuff : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    public float speed;
    public float distanceBetween;

    private float distance;
    public float horizontal;
    float oldPosition = 0f;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        oldPosition = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //uhhh rotering ved f�lging? har ikkeno � si n� tydeligvis
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        //Roteringsgreia ==== hadde visst ikkeno � si fordi de floater ikke de er p� platofrm
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        // f�lger kun n�r man kommer n�rme

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

        /*if (transform.position.x > oldPosition)
            {
            animator.SetBool("isMoving", true);
            spriteRenderer.flipX = true;
        }

        if (transform.position.x < oldPosition)
        {
            animator.SetBool("isMoving", false);
            spriteRenderer.flipX = false;
        }*/
    }

    /*private void LateUpdate()
    {
        oldPosition = transform.position.x;
    }*/
}
