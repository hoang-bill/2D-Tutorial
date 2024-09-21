using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLife : MonoBehaviour
{
    [SerializeField] float fallSpeed = 2f; 

    private void Update()
    {
        // Move the red pill downwards
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("increase health");
            GameManager.instance.ManageLives(1); // Increase the number of lives by 1
            Destroy(gameObject); // Destroy the red pill object
        }
    }

}
