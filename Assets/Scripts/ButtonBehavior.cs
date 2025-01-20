using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private Vector3 _startScale;
    [SerializeField] private float scaleFactor;
    [SerializeField] private AudioClip onHover;
    [SerializeField] private AudioSource source;

    public void OnHover(Transform obj)
    {
        _startScale = obj.localScale;
        obj.localScale *= scaleFactor;
        source.PlayOneShot(onHover);
    }

    public void ExitHover(Transform obj)
    {
        obj.localScale = _startScale;
    }
}
