using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hud.PL
{
    public class HealthbarView : MonoBehaviour
    {
        public GameObject HealthContainerPrefab;

        private IHealthHud healthHud;

        void Start()
        {
            healthHud = AllServices.Container.Single<IHealthHud>();

            healthHud.InitHealthbar(transform, HealthContainerPrefab);
        }
    }
}
