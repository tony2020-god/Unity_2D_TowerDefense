using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public float hp = 20;
    public int maxhp = 1000;
    private BattleManager bm;
    
    [Header("血量")]
    public Text HP;
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收收到的傷害值</param>
    public void Damage(float damage)
    {

        if (hp > 0) 
        {
            hp -= damage;
            HP.text = "HP:" + hp + "/1000";
            GetComponentInChildren<SpriteRenderer>().color = Color.red;

            Invoke("ResetColor", 0.2f);
            if (hp <= 0)
            {
                
                Destroy(gameObject, 0.5f);
                BattleManager.instance.Win();
            }
        } 
     
    }
    private void ResetColor()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
