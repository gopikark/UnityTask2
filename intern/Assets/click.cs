using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;
    public GameObject camerafour;


    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    AudioListener cameraThAudioLis;
    AudioListener camerafoAudioLis;

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
        cameraThAudioLis = cameraThree.GetComponent<AudioListener>();
        camerafoAudioLis = camerafour.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 3)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraThAudioLis.enabled = false;
            cameraThree.SetActive(false);

            camerafoAudioLis.enabled = false;
            camerafour.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraThAudioLis.enabled = false;
            cameraThree.SetActive(false);

            camerafoAudioLis.enabled = false;
            camerafour.SetActive(false);
        }

        if (camPosition == 2)
        {
            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraThAudioLis.enabled = true;
            cameraThree.SetActive(true);

            camerafoAudioLis.enabled = false;
            camerafour.SetActive(false);
        }

        if (camPosition == 3)
        {
            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraThAudioLis.enabled = false;
            cameraThree.SetActive(false);

            camerafoAudioLis.enabled = true;
            camerafour.SetActive(true);
        }

    }
}
