using UnityEngine;

public class JudgmentCollision : MonoBehaviour
{
    public float damage;
    /// <summary>
    /// 玩家:可以打到怪物
    /// 怪物:可以打到玩家
    /// </summary>
    public string type;

   // private void OnCollisionEnter(Collider other)
    //{
       // if (other.tag == "怪物" && type == "我方角色")//在友軍攻擊範圍內的怪物
        //{
          //  other.GetComponent<Enemy>().Damage(damage);//將傷害值傳給怪物
        //}
        //if (other.tag == "我方角色" && type == "怪物")//在怪物攻擊範圍內的友軍
       // {
         //   other.GetComponent<Alliance>().Damage(damage);//將傷害值傳給玩家

     //    }
   // }
}
