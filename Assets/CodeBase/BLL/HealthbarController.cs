using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hud.BLL
{
    public class HealthbarController : IHealthHud
    {
        private IPlayerHealth playerHealth;
        private List<Transform> filledHealthContainerList = new List<Transform>();

        public HealthbarController(IPlayerHealth playerHealth)
        {
            this.playerHealth = playerHealth;
        }
        public void InitHealthbar(Transform healthContainerParent, GameObject prefab)
        {
            filledHealthContainerList.Clear();
            for (int i = 0; i < playerHealth.GetInitialHealth(); i++)
            {
                HealthContainerView healthContainer = GameObject.Instantiate(prefab).GetComponent<HealthContainerView>();

                healthContainer.transform.parent = healthContainerParent;

                filledHealthContainerList.Add(healthContainer.FilledHeart);
            }
        }

        public void SetHealth()
        {
            foreach (var heart in filledHealthContainerList)
            {
                heart.gameObject.SetActive(false);
            }
            for (int i = 0; i < playerHealth.GetCurrentHealth(); i++)
            {
                filledHealthContainerList[i].gameObject.SetActive(true);
            }
        }

        public void RemoveHearts()
        {
            throw new System.NotImplementedException();
        }
        public void AddHearts()
        {
            throw new System.NotImplementedException();
        }
    }
}
