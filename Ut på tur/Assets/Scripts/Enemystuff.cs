using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystuff : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //uhhh rotering ved følging? har ikkeno å si nå tydeligvis
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        //Roteringsgreia ==== hadde visst ikkeno å si fordi de floater ikke de er på platofrm
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        // følger kun når man kommer nærme

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
