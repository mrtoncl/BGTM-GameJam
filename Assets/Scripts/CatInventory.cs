using UnityEngine;
using UnityEngine.UI;

public class CatInventory : MonoBehaviour
{
    public GameObject item;
    public SpriteRenderer itemSpriteRenderer;
    public Sprite icon;
    public CanvasRenderer canvasRenderer;
    private InventoryUI inventoryUI;
    [SerializeField] Transform putLocation;

    public bool AddItem(GameObject newItem)
    {
        if (item == null)
        {
            item = newItem;
            itemSpriteRenderer = newItem.GetComponent<SpriteRenderer>();
            item.SetActive(false);
            icon = itemSpriteRenderer.sprite;
            inventoryUI = canvasRenderer.GetComponent<InventoryUI>();
            inventoryUI.gameObject.SetActive(true);
            inventoryUI.SetIcon(icon);
            Debug.Log("Item is added in inventory!");
 
            return true;
        }
        Debug.Log("Item is not added in inventory!");
        return false;
    }

    public GameObject RemoveItem()
    {
        if (item != null)
        {
            GameObject tempItem = item; 
            item = null;
            inventoryUI.gameObject.SetActive(false);
            inventoryUI.SetIcon(null);
            Debug.Log("Item is removed!");
            return tempItem;
        }
        Debug.Log("There is no item in inventory!");
        return null;
    }

    public bool PutItem()
    {
        if (item != null)
        {
            GameObject newItem = RemoveItem();
            // Instantiate ederken newItem zaten sahnede var (referans), klonlama yapma
            GameObject droppedItem = Instantiate(newItem, putLocation.position, Quaternion.identity);
            droppedItem.SetActive(true);  // **Burada klonun kendisini aktif yapıyoruz**
            Debug.Log("Item has been put down!");
            return true;
        }
        Debug.Log("There is no item");
        return false;
    }
}
