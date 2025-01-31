using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform _c;
    [SerializeField] GameObject _camera;
    [SerializeField] private InputActionProperty _bButton;
    private GameObject _canvas;
    private void Start()
    {
        _canvas = GetComponentInChildren<Canvas>().gameObject;
        _canvas.SetActive(false);
        StartCoroutine(BButton());
    }
    private void Update()
    {
        if (_canvas.active)
        {
            _c.transform.position = _camera.transform.position;
            _c.transform.rotation = new Quaternion(0, _camera.transform.rotation.y, 0, _camera.transform.rotation.w);
        }
    }

    IEnumerator BButton()
    {
        while (true)
        {
            if (_bButton.action.IsInProgress())
            {
                if (!_canvas.active)
                {
                    _canvas.SetActive(true);
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    _canvas.SetActive(false);
                    yield return new WaitForSeconds(3f);
                }
            }
            yield return null;
        }
    }
}
