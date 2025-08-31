using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject {

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;


    public void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO) {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) {
            //Ingredient not valid for plate
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO)) {
            //Ingredient already on plate
            return false;
        }
        else {
            //Ingredient not on plate
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList() {
        return kitchenObjectSOList;
    }
}
