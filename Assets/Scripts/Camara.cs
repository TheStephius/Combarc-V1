using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public GameObject player;
    public Vector2 Min;
    public Vector2 Max;
    public float suavizado;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, suavizado);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posx, Min.x, Max.x), Mathf.Clamp(posy, Min.y, Max.y), transform.position.z);
    }

}
