using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game4v1
{
    public class Actionjoystick : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Action()
        {
            if (Swaprole.chooserole.Role == "Survival")
            {
                if (Player.CanInvest == true)
                {
                    Debug.Log("Invest");
                }

                if (Player.canOpenChest == true)
                {
                    Debug.Log("Openbox");
                    Box.isOpen = true;
                }
                    
            }
            else
            {
                Debug.Log("Attack");
            }
        }
        public void SkillandUseItem()
        {
            if (Swaprole.chooserole.Role == "Survival")
            {

                Debug.Log("Useitem");
            }
            else
            {
                Debug.Log("Skill");
            }
        }
    }
}
