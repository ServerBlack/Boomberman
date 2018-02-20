using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    private PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 _velocity = Vector3.zero;

        //Vector3 _movHorizontal = xMov * transform.right;
        //Vector3 _movVertical = yMov * transform.up;

        //_velocity = (_movHorizontal + _movVertical).normalized;

        //_movVertical = Vector3.zero;
        //_movHorizontal = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            _velocity += transform.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _velocity -= transform.up;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _velocity -= transform.right;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _velocity += transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Vector3 pos = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
            
            FindObjectOfType<BombSpawner>().SpawnBomb2(transform.position);
        }


        playerMotor.Move(_velocity);


    }
}
