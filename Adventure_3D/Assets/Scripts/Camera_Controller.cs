using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Vector3 cameraPosition = Vector3.zero;

    [SerializeField]
    private float offSetY;

    [SerializeField]
    private float followSpeed;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {        
    //    cameraPosition = new Vector3(transform.position.x, Mathf.SmoothStep(transform.position.y, target.transform.position.y + offSetY, followSpeed), transform.position.z);
    //    transform.position = cameraPosition;
    }
}
