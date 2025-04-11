using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject gameObject;
    }
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectList;
    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObjectOnOnIngredientAdded;
        
        foreach (KitchenObjectSO_GameObject kitchenObjectSoGameObject in kitchenObjectSOGameObjectList)
        {
            kitchenObjectSoGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObjectOnOnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject kitchenObjectSoGameObject in kitchenObjectSOGameObjectList)
        {
            if (kitchenObjectSoGameObject.KitchenObjectSO == e.kitchenObjectSO)
            {    
                kitchenObjectSoGameObject.gameObject.SetActive(true);
            }
            
        }
    }
}
