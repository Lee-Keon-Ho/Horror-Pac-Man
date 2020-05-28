using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    private int stage = 1;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveForward();
        }
        
    }

    void MoveForward()
    {
        if (stage == 1)
        {
            //head.transform.position = new Vector3(this.transform.position.x, 12.0f, this.transform.position.z);
            if (mainCam.transform.rotation.x <= 0.1f && mainCam.transform.rotation.x >= -0.1f)
            {
                head.transform.Translate(mainCam.transform.forward * 0.2f);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("오잉?");
    }
}
