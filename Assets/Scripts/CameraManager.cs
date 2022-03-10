using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private GameObject fullCam;
    private GameObject playerCam;

    // Start is called before the first frame update
    void Start()
    {
        fullCam = GameObject.Find("FullscreenCamera");
        playerCam = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerCam) {
            playerCam = GameObject.Find("PlayerCamera");
        }
        else {
            if (Input.GetKeyDown("1")) {
                fullCam.SetActive(true);
                playerCam.SetActive(false);
            }
            if (Input.GetKeyDown("2")) {
                fullCam.SetActive(false);
                playerCam.SetActive(true);
            }
        }

        
    }
}
