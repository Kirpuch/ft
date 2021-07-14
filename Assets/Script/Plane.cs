using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    [SerializeField]private AudioSource jumpSound;
    [SerializeField]private AudioSource deathSound;

    [SerializeField]private AudioSource Rolemusic;
    public float force;
    Rigidbody2D PlaneRigid;

    public GameObject RestartButton; 
    void Start()
    {
        Time.timeScale = 0;
        PlaneRigid = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rolemusic.Play();
            PlaneRigid.velocity = Vector2.up * force;
            jumpSound.Play();
            Time.timeScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        deathSound.Play();

        if (collision.collider.tag == "Enemy")          
        {                         
            RestartButton.SetActive(true);  
            deathSound.Play();
            Destroy(gameObject); 
            Time.timeScale = 0;
        }
    }    
}
