using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class empt_PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        head.gameObject.transform.position = new Vector3(this.transform.position.x, 15.0f, this.transform.position.z);
        if (Input.GetMouseButton(0))
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        if (mainCam.transform.rotation.x <= 0.5f && mainCam.transform.rotation.x >= -0.5f)
        {
            head.transform.Translate(mainCam.transform.forward * 0.1f);
        }
    }
}
