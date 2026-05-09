using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Transform slotContainer;
    public Image itemIcon;
    public int slotCount = 20;

    void Start()
    {
        itemIcon.enabled = false;
        gameObject.SetActive(false);
    }
     public void SetIcon(Sprite icon)
    {
        if (icon != null)
        {
            itemIcon.sprite = icon;
            itemIcon.enabled = true;
            
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }
  

}

