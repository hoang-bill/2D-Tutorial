using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,speed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ManageLives(-1);
            if (GameManager.instance.lives <= 0)
            {
                GameManager.instance.InitiateGameOver();
                Destroy(collision.gameObject); // hide the player ship when game is over
            }
        }
        else
        {
            GameManager.instance.IncreaseScore(10);
        }

        // GameManager.instance.IncreaseScore(10);
        Debug.Log("Collision!");
        Destroy(gameObject);
        
    }
}
