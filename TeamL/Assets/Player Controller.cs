using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100f ;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveX, moveZ);
        transform.Translate(move* moveSpeed* Time.deltaTime);
    }
}