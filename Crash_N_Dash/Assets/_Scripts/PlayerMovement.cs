using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * speed;
        float vMovement = Input.GetAxis("Vertical") * speed / 2;

        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);
    }
}
