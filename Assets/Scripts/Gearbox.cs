using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarCore
{
    public class Gearbox : MonoBehaviour
    {
        public enum Gear
        {
            neutral = 0,
            first = 1,
            second = 2,
            third = 3,
            fourth = 4,
            fifth = 5,
            sixth = 6,
            reverse = -1
        }

        private bool automatic;
        private Gear currentGear;

        Gearbox(bool automatic)
        {
            this.automatic = automatic;
            currentGear = Gear.neutral;
        }

        public Gear GetCurrentGear() { return currentGear; }

        public void GearUp()
        {
            if (!currentGear.Equals(Gear.sixth))
            {
                currentGear += 1;
            }
        }

        public void GearDown()
        {
            if (!currentGear.Equals(Gear.reverse))
            {
                currentGear -= 1;
            }
        }

    }
}