using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

    [SerializeField]
    public static float speed;
    [SerializeField]
    private float turnSpeed;
    public static float verticalInput;
    private float horizontalInput;
    
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Mathf.Abs(verticalInput) > 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameController.diminuiVida();
            if (GameController.vidas <= 0)
            {
                GameController.instance.ShowGameOver();
                //Debug.Log("Game Over");
                this.enabled = false;
                Destroy(gameObject);
            }
        }

     }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Orange")
        {
            collision.enabled = false;
            GameController.somaOrange();
            Destroy(collision.gameObject);
        }
    }
}
