using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyProject1.UIs
{
    public class FuelSlider : MonoBehaviour
    {
        Slider _slider;
        Fuel _fuel;

        private void Awake()
        {
            _slider= GetComponent<Slider>();
            _fuel=FindObjectOfType<Fuel>();
        }

        private void Update()
        {
            _slider.value = _fuel.CurrentFuel;
        }
    }

}
