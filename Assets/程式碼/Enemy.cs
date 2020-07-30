using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;

    private Animator ani;
    private float hp;
    private float timer;
    public bool dead =false;

    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
        gameObject.GetComponent<EnemyMove>().speed = data.speed; //添加元件<移動>.速度 = 速度
        gameObject.GetComponent<EnemyMove>().damage = data.attack; //添加元件<移動>.速度 = 速度
        gameObject.GetComponent<EnemyMove>().AttackCD = data.attackcd; //添加元件<移動>.速度 = 速度
        gameObject.GetComponent<EnemyMove>().AttackDistance = data.AttackDistance; //添加元件<移動>.速度 = 速度
        gameObject.GetComponent<EnemyMove>().dead = dead; //添加元件<移動>.速度 = 速度
    }
    public void Update()
    {
        if (dead == false)
        {
            if (BattleManager.instance.passLv == true)
            {
                StartCoroutine(Dead());
            }
        }
           
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        //print("哥布林血量" + hp);
        hp -= damage;

        // GetComponentInChildren<SpriteRenderer>().color = Color.red;
        // Invoke("ResetColor", 0.2f);
        if (dead == false)
        {
            if (hp <= 0)
            {
                StartCoroutine(Dead());
            }
        }
        
    }

    private void ResetColor()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private IEnumerator Dead()
    {
        dead = true;
        
        ani.SetTrigger("死亡觸發");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }



}
