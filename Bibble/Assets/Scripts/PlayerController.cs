using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public float MovementSpeed;    
    public  AnimationClip animWalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = CalculateDirection();
        transform.Translate(direction * MovementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 90);
        //camera.transform.Translate(direction * MovementSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<Animator>().enabled = true;
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.GetComponent<Animator>().Play("Attack");
        }
        else
        {
            //this.GetComponent<Animator>().enabled = false;
        }
    }

    public Vector3 CalculateDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1.0f;
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.GetComponent<Animator>().enabled = true;            
            this.GetComponent<Animator>().Play("Walk");
        }      

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1.0f;
            this.GetComponent<Animator>().enabled = true;
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.GetComponent<Animator>().Play("Walk");
        }       

        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1.0f;
            this.GetComponent<Animator>().enabled = true;
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.GetComponent<Animator>().Play("Walk");
        }       

        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
            this.GetComponent<Animator>().enabled = true;
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.GetComponent<Animator>().Play("Walk");
        }      

        return direction.normalized;
    }
}
