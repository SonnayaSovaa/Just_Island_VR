using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 _inputDir_XZ;
    private Vector2 _inputDir_Y;
    private Vector3 _inputDir3;

    public float moveSpeed;
    public float rotSpeed;
    private Capsule_COntrol _control;

    private void Awake()
    {
        _control = new Capsule_COntrol();
    }
 
    private void FixedUpdate()
    {
        OnMovement();
    }

    void OnMovement()
    {
        _inputDir_XZ = _control.Capsule_Controller.MoveXZ.ReadValue<Vector2>();

        _inputDir_Y = _control.Capsule_Controller.MoveY.ReadValue<Vector2>();

        _inputDir3 = new Vector3(_inputDir_XZ.y*transform.forward.x, _inputDir_Y.y, _inputDir_XZ.y*transform.forward.z);
        

        transform.eulerAngles+= new Vector3(0, _inputDir_XZ.x*rotSpeed, 0);

        Vector3 deltaPos = _inputDir3 * Time.deltaTime * moveSpeed;
        
        transform.position += deltaPos;
        
    }
    
    private void OnEnable()
    {
        _control.Enable();
    }
    
    private void OnDisable()
    {
        _control.Disable();
    }
}
