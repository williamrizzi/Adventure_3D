using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Script : MonoBehaviour
{
    [SerializeField]
    private Vector3[] angles;

    [SerializeField]
    private float lerpTime;

    [SerializeField]
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case 0:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(angles[0]), lerpTime * Time.deltaTime);
                break;
            case 1:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(angles[1]), lerpTime * Time.deltaTime);
                break;
            case 2:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(angles[2]), lerpTime * Time.deltaTime);
                break;
            case 3:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(angles[3]), lerpTime * Time.deltaTime);
                break;
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Q))
        {
            if (direction < 3)
            {
                direction++;
            }
            else
            {
                direction = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.E))
        {
            if (direction > 0)
            {
                direction--;
            }
            else
            {
                direction = 3;
            }
        }
    }

    public int Direction { get => direction; }
}
