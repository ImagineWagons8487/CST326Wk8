using System.Collections.Generic;
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
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //player holding plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //player carrying not plate
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //Counter holding plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                //player not holding anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
