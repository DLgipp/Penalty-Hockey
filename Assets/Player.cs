using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float life = 3;
    private float diflife = 3;
    public float score = 0;
    private float difscore = 0;


    private Text text;
    public int count = 0;
    public GameOverScreen gos;


    public AudioSource goals;
    public AudioSource hits;
    public AudioSource attack;


    public Trajectory trajectory;
    private Vector3 mouse;
    public Camera cam;
    public Vector3 speed;

    void Start()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
        difscore = score;
        diflife = life;
        mouse = transform.position;
        speed = new Vector3(force, 0, 0);
    }

    private void Update()
    {
        
        if (Input.GetMouseButton(0) && life > 0)
        {
            speed.z += Input.GetAxis("Horizontal");
            trajectory.ShowTrajectory(transform.position, speed);
        }
        
        if (Input.GetMouseButtonUp(0) && life > 0)
        {
            rb.AddForce(speed, ForceMode.VelocityChange);
            attack.Play();
        }

        if (transform.position.z <= -1.5 || transform.position.z >= 1.5)
        {
            StartCoroutine(hit());
        }

        if (life == 0)
        {
            gos.ShowGOScreen(score);
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(end());
        }

    }

    IEnumerator hit()
    {
        diflife = life;
        yield return new WaitForSeconds(1f);
        if (score == difscore && life == diflife)
        {
            life--;
            text.text = $"Health - {life}\nScore - {score}";
            rb.transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            rb.transform.position = new Vector3(-4, 0.52f, 0);
            count++;
            hits.Play();
        }   
    }
    IEnumerator goal()
    {
        score += 50;
        text.text = $"Health - {life}\nScore - {score}";
        yield return new WaitForSeconds(1f);
        rb.transform.eulerAngles = new Vector3(0, 0, 0);
        rb.transform.position = new Vector3(-4, 0.52f, 0);
        rb.velocity = new Vector3(0, 0, 0);
        difscore = score;
        count++;
        goals.Play();
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hit")
        {
            StartCoroutine(hit());
        }
        if (other.tag == "Goal")
        {
            StartCoroutine(goal());
        }
    }


}
