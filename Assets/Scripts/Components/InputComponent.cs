using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class InputComponent : MonoBehaviour
{

    [SerializeField]private InputMode inputMode;
    [Header("InputKeys")]
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode sprintKey;
    [SerializeField] private KeyCode jumpKey;

    [Header("Rotation Parameters")]
    [SerializeField]private bool isInverted = false;
    [SerializeField]private float mouseSensitivity = 1;
    [SerializeField]private float maxLookAngle = 100;
    public Vector2 inputAxis;
    public Vector3 rotationAxis;
    private float pitch;
    private float yaw;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rotationAxis;
    }

    // Update is called once per frame
    void Update()
    {
        switch(inputMode)
        {
            case InputMode.AxisBased:
                inputAxis.y = Input.GetAxisRaw("Horizontal");
                inputAxis.x = Input.GetAxisRaw("Vertical");
                break;
            case InputMode.KeysBased:
                inputAxis = AxisKeysHandle(upKey, downKey, leftKey, rightKey);
                break;
            
        }
        rotationAxis = RotationAxis();

    }

    private Vector2 axisVector;
    private Vector2 AxisKeysHandle(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
    {
        axisVector = Vector2.zero;

        if(Input.GetKey(up))
        {
            axisVector.y = Mathf.Clamp(axisVector.y + 1, -1, 1);
        }
        if (Input.GetKey(down))
        {
            axisVector.y = Mathf.Clamp(axisVector.y - 1, -1, 1);
        }

        if (Input.GetKey(left))
        {
            axisVector.x = Mathf.Clamp(axisVector.y - 1, -1, 1);
        }
        if (Input.GetKey(right))
        {
            axisVector.x = Mathf.Clamp(axisVector.y + 1, -1, 1);
        }

        return axisVector;
    }

    private Vector3 RotationAxis()
    {
        rotationAxis = Vector3.zero;

            yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
            
            if (!isInverted)
            {
                pitch -= mouseSensitivity * Input.GetAxis("Mouse Y")*Screen.height/Screen.width;
            }
            else
            {
                // Inverted Y
                pitch += mouseSensitivity * Input.GetAxis("Mouse Y") * Screen.height / Screen.width;
            }

            // Clamp pitch between lookAngle
            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

            rotationAxis = new Vector3(pitch, yaw, 0);
        
        return rotationAxis;
    }
}

public enum InputMode
{
    AxisBased,
    KeysBased
}