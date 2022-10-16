using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageDealer : MonoBehaviour
{
   [SerializeField] int damage = 10;

   public int getDamage()
   {
       return damage;
   }
   public void Hit()
   {
       Destroy(gameObject);
   }
}
