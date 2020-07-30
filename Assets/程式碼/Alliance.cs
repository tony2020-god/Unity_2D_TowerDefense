using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Alliance : MonoBehaviour
{
    public float hp ;


    private BattleManager bm;
    /// <summary>
    /// 動畫控制器
    /// </summary>
    private Animator ani;

    public bool dead = false;

    private void Start()
    {
        gameObject.GetComponent<Alliance>().dead = dead; //添加元件<移動>.速度 = 速度
        ani = GetComponent<Animator>(); //取得元件<泛型>()
        bm = FindObjectOfType<BattleManager>();
    }


    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收收到的傷害值</param>
    public void Damage(float damage)
    {
       // print("刺客血量"+ hp);
        //GetComponentInChildren<SpriteRenderer>().color = Color.red;
        hp -= damage;
        //Invoke("ResetColor", 0.2f);
        if (dead == false)
        {
            if (hp <= 0)
            {
                StartCoroutine(Dead());
            }
        }

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private IEnumerator Dead()
    {
        dead = true;
        ani.SetTrigger("死亡觸發");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
   

    private void Update()
    {
        
       
    }

    
}
