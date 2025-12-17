using System;
using UnityEngine;

public class HealthPotionPickUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            var inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.CanPickUpPotion()) {
                inventory.AddPotion();
                GetComponent<PickupSound>()?.Play();
                Destroy(gameObject);
            }
        }
    }
}
