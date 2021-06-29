﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;

    private Animator ani;
    public float hp;
    private float timer;
    public bool dead = false;
    public bool havewake = false;
    public CapsuleCollider2D colliderzombe;
    public GameObject expolution;
    public GameObject FireGod;
    public GameObject lastexpolution;
    public AudioSource aud;
    public AudioClip shout;
    public AudioClip explotion1;
    public AudioClip explotion2;
    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
        colliderzombe = GetComponent<CapsuleCollider2D>();
        gameObject.GetComponent<EnemyMove>().speed = data.speed; //添加元件<移動>.速度 = 怪物速度
        gameObject.GetComponent<EnemyMove>().damage = data.attack; //添加元件<移動>.傷害 = 怪物攻擊力
        gameObject.GetComponent<EnemyMove>().AttackCD = data.attackcd; //添加元件<移動>.攻擊速度 = 怪物攻擊速度
        gameObject.GetComponent<EnemyMove>().AttackDistance = data.AttackDistance; //添加元件<移動>.攻擊距離 = 怪物攻擊距離
        gameObject.GetComponent<EnemyMove>().dead = dead; //添加元件<移動>.死亡 = 怪物死亡
        if ( gameObject.layer == LayerMask.NameToLayer("火靈王"))
        {
            aud.PlayOneShot(shout);

        }
        if (gameObject.layer == LayerMask.NameToLayer("冰龍"))
        {
            aud.PlayOneShot(shout);
        }
        if (gameObject.layer == LayerMask.NameToLayer("夢魘"))
        {
            aud.PlayOneShot(shout);
        }
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
        hp -= damage;
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
        gameObject.GetComponent<EnemyMove>().dead = dead; //添加元件<移動>.死亡 = 怪物死亡
        if (gameObject.layer == LayerMask.NameToLayer("殭屍") && havewake == false)
        {
            ani.SetBool("死亡觸發", true);
            colliderzombe.enabled = false;
            yield return new WaitForSeconds(5);
            hp = 10;
            havewake = true;
            colliderzombe.enabled = true;
            ani.SetBool("死亡觸發", false);
            dead = false;
            gameObject.GetComponent<EnemyMove>().dead = dead; //添加元件<移動>.死亡 = 怪物死亡
        }
        else if (gameObject.layer == LayerMask.NameToLayer("夢魘"))
        {
            ani.SetBool("死亡觸發", true);
            colliderzombe.enabled = false;
            yield return new WaitForSeconds(5);
            hp = 50;
            colliderzombe.enabled = true;
            ani.SetBool("死亡觸發", false);
            dead = false;
            gameObject.GetComponent<EnemyMove>().dead = dead; //添加元件<移動>.死亡 = 怪物死亡
        }
        else if (gameObject.layer == LayerMask.NameToLayer("火靈巫師"))
        {
            ani.SetBool("死亡觸發", true);
            colliderzombe.enabled = false;
            yield return new WaitForSeconds(2);
            Vector3 posFireWich = transform.position; //火球座標 = 火靈巫師座標          
            GameObject temp = Instantiate(expolution, posFireWich, Quaternion.identity); //生成(物件,座標,角度)，Quaternion.identity 角度類型-零角度   
            yield return new WaitForSeconds(0.3f);
            GameObject temp2 = Instantiate(FireGod, posFireWich, Quaternion.identity); //生成(物件,座標,角度)，Quaternion.identity 角度類型-零角度   
            aud.PlayOneShot(explotion1);
            Destroy(gameObject);
        }
        else if(gameObject.layer == LayerMask.NameToLayer("火靈王"))
        {
            aud.PlayOneShot(explotion2);
            Vector3 posFireWich = transform.position; //火球座標 = 火靈王座標          
            GameObject temp = Instantiate(lastexpolution, posFireWich, Quaternion.identity); //生成(物件,座標,角度)，Quaternion.identity 角度類型-零角度   
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }
        else
        {
            GameObject.Find("遊戲管理器").GetComponent<MoneyManager>().killmoney = data.deadmoney; //添加元件<移動>.擊殺金錢 = 怪物死亡金錢
            ani.SetTrigger("死亡觸發");
            MoneyManager.instance.killmonster();
            if (gameObject.layer == LayerMask.NameToLayer("冰龍"))
            {
                LVsave.icedead = true;
            }
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }
}
