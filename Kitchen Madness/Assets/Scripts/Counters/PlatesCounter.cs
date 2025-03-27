using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatesCounter : BaseCounter
{

    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    
    private float spawnPlateTimer;

    private float spawnPlateTimerMax = 4f;

    private int plateSpawnedAmount;
    private int platesSpawnedAmountMax = 4;
    
    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if (plateSpawnedAmount < platesSpawnedAmountMax)
            {
                plateSpawnedAmount++;
                
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //player empty
            if (plateSpawnedAmount > 0)
            {
                //at least one plate here
                plateSpawnedAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
            
    }
}
