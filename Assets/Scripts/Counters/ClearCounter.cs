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

            }
            else {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

}
