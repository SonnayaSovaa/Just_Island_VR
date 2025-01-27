using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.Rotate(speed*Time.deltaTime, 0, 0);
    }
}
