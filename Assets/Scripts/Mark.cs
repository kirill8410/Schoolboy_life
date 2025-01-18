using UnityEngine;

public class Mark : MonoBehaviour
{
    private bool _isActive;
    [SerializeField] private SpriteRenderer _circle;

    public void ChangeActive()
    {
        if (!_isActive)
        {
            _isActive = true;
            _circle.color = new Color(150 / 255, 1, 150 / 255);
        }
        else
        {
            _isActive = false;
            _circle.color = new Color(100 / 255, 0, 0);
        }

    }


}
