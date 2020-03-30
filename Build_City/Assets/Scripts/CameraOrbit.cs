using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    protected Transform _Xform_Camera;
    protected Transform _Xform_Parent;

    protected Vector3 LocalRotation;
    protected float CameraDistance = 10f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 6f;
    public float ScrollSpeed = 3f;
    public float OrbitSpeed = 5f;

    public bool CameraDisable = false;


    void Start()
    {
        this._Xform_Camera = this.transform;
        this._Xform_Parent = this.transform;


    }

    // Update is called once per frame

    // 
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        
            CameraDisable = !CameraDisable;

        if (!CameraDisable)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                //clam y Roattion to horizen so it will not flip at the top

                LocalRotation.y = Mathf.Clamp(LocalRotation.y, 0f, 90f);

            }

            //zoom function does not work properly and i could not figure out teh reason; I wuld continue tweaking the numbers or repositioning camera pivit may be
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                //Makes Camera zoon faster whe fuerther away and slower when closer to teh object
                ScrollAmount *= (this.CameraDistance * 0.3f);

                this.CameraDistance += ScrollAmount * -1f;

                //this makes camera go no clower thyan 1.5f and no further than 100f from the object
                this.CameraDistance = Mathf.Clamp(this.CameraDistance, 1.5f, 100f);

            }
            
        }

        //Actual Camera rig Transormation

        Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0f);

        this._Xform_Parent.rotation = Quaternion.Lerp(this._Xform_Parent.rotation, QT, Time.deltaTime * OrbitSpeed);

        if (this._Xform_Camera.localPosition.z != this.CameraDistance * -1f)
        {
            this._Xform_Camera.position = new Vector3(0f, 0f, Mathf.Lerp(this._Xform_Camera.localPosition.z, this.CameraDistance * -1f, Time.deltaTime * ScrollSpeed));
        
        
        }

    }
}
