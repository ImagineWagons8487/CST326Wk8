using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //nothing on top
            if (player.HasKitchenObject())
            {
                //player holding something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not holding anything
            }
        }
        else
        {
            //something on top
            if (player.HasKitchenObject())
            {
                //player holding something
            }
            else
            {
                //player not holding anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
