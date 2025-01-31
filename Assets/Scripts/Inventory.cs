using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _productPrefab;
    [SerializeField] GameObject _content;
    [SerializeField] TextMeshProUGUI _coinsText;
    [SerializeField] Transform _c;
    [SerializeField] GameObject _camera;
    [SerializeField] private InputActionProperty _bButton;
    private GameObject _canvas;
    private Product[] products = new Product[10];
    public int coins = 670;

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
            _coinsText.text = $"Рублей: {coins}";
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

    public void AddProduct(Item item)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i] == null)
            {
                if (coins - item.Price >= 0)
                {
                    print(item.Price);
                    coins -= item.Price;
                    GameObject _products = Instantiate(_productPrefab, _content.transform);
                    _products.transform.localPosition = new Vector3(0, ((i * -30f) - 30f), 0);
                    products[i] = _products.GetComponent<Product>();
                    products[i].item = item;
                    break;
                }
            }
        }
    }
}
