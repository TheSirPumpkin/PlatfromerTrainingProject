using Services;
using UnityEngine;


namespace Player.Inventroy.PL
{
    public class InventoryScreenView : MonoBehaviour
    {
        public GameObject InventoryLayout;
        public GameObject ContentHolder;

        private IInventoryScreen inventoryScreen;
        private IPlayeController playeController;
        private void Start()
        {
            inventoryScreen = AllServices.Container.Single<IInventoryScreen>();
            playeController= AllServices.Container.Single<IPlayeController>();

            inventoryScreen.InitInventoryScreenFromView(InventoryLayout, ContentHolder.transform);
            inventoryScreen.UpdateInventoryState(false);
            inventoryScreen.UpdateInventory();
        }

        // TODO: disable inventory on death
        void Update()
        {
            if (Input.GetButtonDown(playeController.InventoryButton))
            {
                inventoryScreen.UpdateInventoryState();
            }
        }
    }
}
