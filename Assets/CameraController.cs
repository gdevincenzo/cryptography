using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - camera.transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        camera.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        if (Input.GetKeyDown("e") && !camera.activeSelf)
        {
            camera.SetActive(true);
        }
        else if (Input.GetKeyDown("e") && camera.activeSelf)
        {
            camera.SetActive(false);
        }
    }
}
