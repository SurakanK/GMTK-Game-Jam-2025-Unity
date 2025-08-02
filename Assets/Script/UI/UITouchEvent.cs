using UnityEngine;

public class UITouchEvent : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out BaseItem item))
                {
                    if (!BaseGamePlay.Inventory.CheckSlotLimit())
                    {
                        UIGeneric.ShowMessage(
                            null,
                            null,
                            "Inventory Full",
                            "Please drop some items",
                            "Ok"
                            );
                        return;
                    }

                    SpawnItemManager.Instance.PickUpItem(item);
                }
            }
        }
    }
}