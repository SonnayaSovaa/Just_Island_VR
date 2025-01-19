using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private Vector3 _startScale;
    [SerializeField] private float scaleFactor;

    public void OnHover(Transform obj)
    {
        _startScale = obj.localScale;
        obj.localScale *= scaleFactor;
    }

    public void ExitHover(Transform obj)
    {
        obj.localScale = _startScale;
    }
}
