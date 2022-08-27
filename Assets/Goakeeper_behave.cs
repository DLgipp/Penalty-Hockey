using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goakeeper_behave : MonoBehaviour
{
    private GameObject go;
    public Rigidbody rb;
    public float speed = 10;
    public float speedacc;
    public float accel = 1;
    public int count;
    private Player pl;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, speed + speedacc);
        pl = GameObject.Find("Washer").GetComponent<Player>();
    }

    private void Update()
    {
        count = pl.count;
        speedacc = accel * count;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.transform.position.z >= 1)
            rb.velocity = new Vector3(0, 0, -speed - speedacc);

        if (rb.transform.position.z <= -1)
            rb.velocity = new Vector3(0, 0, speed + speedacc);
    }
}
