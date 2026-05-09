using UnityEngine;
using UnityEngine.InputSystem;

public class CatInteraction : MonoBehaviour
{
    private CatInventory catInventory;
    private bool isItem = false;
    private bool check = false;

    public bool didMeow = false;

    private GameObject originalItem;  // Orijinal obje referansı

    void Start()
    {
        catInventory = GetComponent<CatInventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isItem)
            {
                Interact();
                Debug.Log("Cat interacted with item");
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Meow();
            Debug.Log("Meow");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PutItem();
        }
    }

    public void Meow()
    {
        didMeow = true;
        // ses dosyası gelecek
    }

    public void Interact()
    {
        if (originalItem != null)
        {
            check = catInventory.AddItem(originalItem);
            if (check)
            {
                // Orijinal sahnedeki obje envantere eklendikten sonra silinmeli
                Destroy(originalItem);
                originalItem = null;
                isItem = false;
            }
            Debug.Log(check);
        }
    }

    public void PutItem()
    {
        catInventory.PutItem();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            isItem = true;
            originalItem = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            isItem = false;
            originalItem = null;
        }
    }
}
