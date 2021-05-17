using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    bool isCollision;
     void Start()
    {
        isCollision = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = true;
           
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = false;

        }
    }
    public void Damagio()
    {
        if(isCollision == true)
        {
            Destroy(gameObject);
        }
    }
}
