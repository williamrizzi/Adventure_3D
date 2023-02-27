using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private enum State
    {
        Entry, Exit 
    }

    [SerializeField]
    private State status;

    [SerializeField]
    private Transform exitPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(status == State.Entry)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl>().TeleportToNextStage(exitPortal);
        }
    }
}
