using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInBox : MonoBehaviour
{
    public GameObject zoomInBox;
    public Image itemImage;
    public Text nameOfItem;
    public Text description;

    // FIXME: Exit zoom view. Does zooming on the object result in usage?
    public void Show(Item item)
    {
        itemImage.sprite = item.itemImage;
        description.text = item.description;
        nameOfItem.text = item.nameOfItem;

        if (zoomInBox.activeInHierarchy)
        {
            zoomInBox.SetActive(false);
        } else
        {
            zoomInBox.SetActive(true);
        }
    }
}
