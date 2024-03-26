using System;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;

    [Header("Control parameters")]
    [Tooltip("How fast the ship changes its position when we press WASD")]
    [SerializeField] float controlSpeed;
    [Tooltip("Borders for the X axis when we move the ship horizontally")]
    [SerializeField] float xRange;
    [Tooltip("Borders for the Y axis when we move the ship vertically")]
    [SerializeField] float yRange;

    [Header("Pitch, Yaw, Roll parameters")]
    [SerializeField] float pitchFactor;
    [SerializeField] float pitchControlFactor;

    [SerializeField] float yawFactor;
    [SerializeField] float yawControlFactor;

    [SerializeField] float rollFactor;
    [SerializeField] float rollControlFactor;

    float xControls, yControls;


    void Start()
    {

    }

    void Update()
    {
        ProcessTranslate();
        ProcessRotate();
        ProcessFire();
    }

    void ProcessRotate()
    {
        float pitch = transform.localPosition.y * pitchFactor + yControls * pitchControlFactor;
        float yaw = transform.localPosition.x * yawFactor; 
        float roll = xControls * rollControlFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslate()
    {
        xControls = Input.GetAxis("Horizontal");
        yControls = Input.GetAxis("Vertical");

        float xOffset = xControls * Time.deltaTime * controlSpeed;
        float yOffset = yControls * Time.deltaTime * controlSpeed;

        float rawXPos = xOffset + transform.localPosition.x;
        float rawYPos = yOffset + transform.localPosition.y;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFire()
    {
        if (Input.GetMouseButton(0))
        {
            SetLaserEmissions(true);
        }
        else
        {
            SetLaserEmissions(false);
        }
    }

    void SetLaserEmissions(bool isActive)
    {
        foreach(GameObject items in lasers)
        {
            items.SetActive(isActive);
            //var laserEmissions = items.GetComponent<ParticleSystem>().emission;
            //laserEmissions.enabled = isActive;
        }
    }
}