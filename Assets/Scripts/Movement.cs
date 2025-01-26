using System;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Vector2 _inputDir_XZ;
    private Vector2 _inputDir_Y;
    private Vector3 _inputDir3;

    public float moveSpeed;
    public float rotSpeed;
    private Capsule_COntrol _control;
    private bool _paused = false;
    [SerializeField] GameObject pauseCanvas;

    private void Awake()
    {
        _control = new Capsule_COntrol();
    }

    public void Speed(Slider sl)
    {
        moveSpeed = sl.value;
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
        _control.Capsule_Controller.PauseActivate.started+= ctx => Pause();

    }
    void Pause()
    {
        _paused = !_paused;
        pauseCanvas.SetActive(_paused);
    }
    
    private void OnDisable()
    {
        _control.Disable();
    }
}
