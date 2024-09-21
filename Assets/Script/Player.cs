using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float yPosition;
    [SerializeField] GameObject laser;
    [SerializeField] float boostDuration = 5f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float normalSpeed = 3f;
    [SerializeField] float horizontalInput;

    private bool isBoosted = false;

    // Start is called before the first frame update
    void Start()
    {
        yPosition = transform.position.y;
        // Debug.Log("Player Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 convertedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        horizontalInput = Input.GetAxis("Horizontal");
        
        float speed = isBoosted ? boostSpeed : normalSpeed;
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if(Input.GetButtonDown("FireLaser")){
             Instantiate(laser, transform.position, Quaternion.identity);
        }
    }

    public void BoostSpeed()
    {
        if (!isBoosted)
        {
            isBoosted = true;
            StartCoroutine(BoostCoroutine());
        }
    }

    IEnumerator BoostCoroutine()
    {
        yield return new WaitForSeconds(boostDuration);
        isBoosted = false;
    }
}
