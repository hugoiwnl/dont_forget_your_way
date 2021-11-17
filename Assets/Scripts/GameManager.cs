using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject MyChunk1;
    public GameObject MyChunk2;
    public GameObject MyChunk3;
    public GameObject MyChunk4;
    public GameObject MyChunk5;

    public Transform cam;

    public GameObject collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((collider.transform.position - cam.position).sqrMagnitude < 25.0f) {
            GameObject myref = MyChunk3.transform.GetChild(0).gameObject;
            float angle = Vector3.Angle(cam.forward, myref.transform.position - cam.position);
            if (angle > 90)
            {
                MyChunk4.SetActive(false);
                MyChunk3.SetActive(false);
                MyChunk2.SetActive(true);
                MyChunk5.SetActive(true);
                MyChunk4.SetActive(true);
            }
        }

    }
}
