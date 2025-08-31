using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;



    public override void Interact(Player player) {

        if (!HasKitchenObject()) {
            //no kitchen object here
            if (player.HasKitchenObject()) {
                // player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else {
                // player not carrying anything
            }
        }
        else {
            //there is kitchen object here
            if (player.HasKitchenObject()) {
                //player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {                         //succesfully added ingredient to plate
                        GetKitchenObject().DestroySelf();
                    }
                }
                else {
                    //player is not holding a plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        //counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {                         //succesfully added ingredient to plate
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

}
