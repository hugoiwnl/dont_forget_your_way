using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_at_camera : MonoBehaviour
{
    // Start is called before the first frame update

    private void LateUpdate() {
        var r1 = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.forward);
        var euler2 = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(euler2.x, r1.eulerAngles.y, euler2.z); 
    }
}
