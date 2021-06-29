using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)
using System;
public class BattleManager : MonoBehaviour
{
    public static BattleManager instance; //對戰管理實體物件

    public SpawnAlliance data;
    public GameObject pass;
    public GameObject lose;
    
    public bool passLv;

    [Header("派遣區")]
    public Transform trambattle;

    [Header("遊戲載入畫面")]
    public GameObject gameView;

    [Header("角色雇用照片")]
    public List<Transform> BattleRoleTransform = new List<Transform>();

    [Header("角色雇用按鍵")]
    public List<GameObject> BattleRolebutton = new List<GameObject>();

    [Header("角色雇用按鍵")]
    public List<int> RoleCost = new List<int>();

    public int LV;

    public Image loading;

    public float imageCD = 0.9f;

    public float imageCD2 = 0f;
    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        LVsave.exitdeck = true;
        LVsave.icedead = false;
        LVsave.magiciandead = false;
        LVsave.isMinerSpawn = false;
        LVsave.boosspawn = false;
        LVsave.finalboss = false;
        CreateCard(DeckManager.instance);
        StartCoroutine(Startloadingimage());
    }
    
    public IEnumerator Startloadingimage()
    {
        while (imageCD > 0)        //迴圈 while(布林值) "當布林值為 true 時執行敘述"
        {
            imageCD = imageCD - 0.01f;
            loading.fillAmount = imageCD / 0.9f;                            //更新載入吧條
                                                                            //等待
            if (imageCD <= 0)    //判斷式 if(布林值) "當布林值為true時執行一次"  
            {
                gameView.SetActive(false); //關閉遊戲載入畫面
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    public IEnumerator Endloadingimage()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        ao.allowSceneActivation = false;
        gameView.SetActive(true); //關閉遊戲載入畫面
        while (imageCD < 1)        //迴圈 while(布林值) "當布林值為 true 時執行敘述"
        {
            imageCD = imageCD + 0.01f;
            loading.fillAmount = imageCD / 0.9f;                            //更新載入吧條
                                                                            //等待
            if (imageCD >= 0.9f)    //判斷式 if(布林值) "當布林值為true時執行一次"  
            {
                gameView.SetActive(false); //關閉遊戲載入畫面
                ao.allowSceneActivation = true;    //允許自動載入場景
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void Lose() //失敗:我方基地血量小於0，遊戲顯示失敗畫面
    {
        lose.SetActive(true);
    }
    public void Win() //過關:敵方基地血量小於0，遊戲顯示過關畫面
    {
        passLv = true;
        pass.SetActive(true);
    }
    public void NextLv()
    {
        LVsave.lastLV = LVsave.lastLV + 1;
        StartCoroutine(Endloadingimage());
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToChooseRoleLose()
    {
        SceneManager.LoadScene("選擇角色選單");    
    }
    public void BackToChooseRoleWin()
    {
        LVsave.lastLV = LVsave.lastLV + 1;
        SceneManager.LoadScene("選擇角色選單");
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CreateCard(DeckManager deck)
    {
        for (int i = 0; i < deck.deck.Count; i++) //迴圈執行 卡牌數量
        {
            Transform temp = Instantiate(GetCard.instance.battlecardObject, trambattle).transform; //變形 = 生成(物件，父物件).變形
            CardData card = deck.deck[i]; //卡片資料
            //尋找子物件並更新資料
            temp.Find("花費").GetComponent<Text>().text = card.cost.ToString();
            temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
            temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();         
            temp.Find("遮色片").Find("圖片").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file); // 尋找圖片子物件.圖片 = 來源.載入<圖片>(檔案名稱)
            temp.gameObject.AddComponent<BattleCard>().index = card.index; //添加元件<戰鬥卡牌> 編號 = 卡牌.編號
            temp.gameObject.GetComponent<BattleCard>().temp = temp.transform; //添加元件<戰鬥卡牌> 圖鑑 = 物件.變形
            temp.gameObject.GetComponent<BattleCard>().cost = card.cost; //添加元件<戰鬥卡牌> 消耗 = 卡牌.消耗
            BattleRoleTransform.Add(temp.transform);
            BattleRolebutton.Add(temp.gameObject);
            RoleCost.Add(card.cost);
        }
    }
 
    public void RoleSpawm(int index,GetCard cards)
    {     
        CardData card = cards.cards[index - 1]; //卡片資料(Element從0開始，編號從1開始，故-1)
        if (index == 1)
        {   
            Vector3 pos = new Vector2(-7.4f, -3); //座標
            Quaternion qua = Quaternion.Euler(0, 0, 0); //角度
            GameObject temp = Instantiate(data.Spawn[index - 1].Alliance, pos, qua); //生成
            temp.gameObject.GetComponent<Alliance>().hp = card.hp; //添加元件<盟友>.血量 = 卡片.血量      
            temp.gameObject.GetComponent<RoleMove>().speed = card.speed; //添加元件<盟友移動> 速度 = 卡牌.速度
            temp.gameObject.GetComponent<RoleMove>().damage = card.attack; //添加元件<盟友移動>.傷害 = 卡牌.攻擊
            temp.gameObject.GetComponent<RoleMove>().AttackCD = card.AttackCD; //添加元件<盟友移動>.攻擊速度 = 卡片.攻擊速度
            temp.gameObject.GetComponent<RoleMove>().AttackDistance = card.AtackDistance; //添加元件<盟友移動>.攻擊距離 = 卡片.攻擊距離    
        }
        else if (index == 5)
        {
            Vector3 pos = new Vector2(-8f, -1.66f); //座標
            Quaternion qua = Quaternion.Euler(0, 0, 0); //角度
            GameObject temp = Instantiate(data.Spawn[index - 1].Alliance, pos, qua); //生成
            temp.gameObject.GetComponent<Alliance>().hp = card.hp; //添加元件<盟友>.血量 = 卡片.血量   
            temp.gameObject.GetComponent<RoleMove>().speed = card.speed; //添加元件<盟友移動> 速度 = 卡牌.速度
            temp.gameObject.GetComponent<RoleMove>().damage = card.attack; //添加元件<盟友移動>.傷害 = 卡牌.攻擊
            temp.gameObject.GetComponent<RoleMove>().AttackCD = card.AttackCD; //添加元件<盟友移動>.攻擊速度 = 卡片.攻擊速度
            temp.gameObject.GetComponent<RoleMove>().AttackDistance = card.AtackDistance; //添加元件<盟友移動>.攻擊距離 = 卡片.攻擊距離        
        }
        else if(index ==8)
        {
            Vector3 pos = new Vector2(-7.4f, -2.8f); //座標
            Quaternion qua = Quaternion.Euler(0, 0, 0); //角度  
            GameObject temp = Instantiate(data.Spawn[index - 1].Alliance, pos, qua); //生成
            temp.gameObject.GetComponent<Alliance>().hp = card.hp; //添加元件<盟友>.血量 = 卡片.血量   
            temp.gameObject.GetComponent<RoleMove>().speed = card.speed; //添加元件<盟友移動> 速度 = 卡牌.速度
            temp.gameObject.GetComponent<RoleMove>().damage = card.attack; //添加元件<盟友移動>.傷害 = 卡牌.攻擊
            temp.gameObject.GetComponent<RoleMove>().AttackCD = card.AttackCD; //添加元件<盟友移動>.攻擊速度 = 卡片.攻擊速度
            temp.gameObject.GetComponent<RoleMove>().AttackDistance = card.AtackDistance; //添加元件<盟友移動>.攻擊距離 = 卡片.攻擊距離  
        }
        else
        {
            Vector3 pos = new Vector2(-7.4f, -2.3f); //座標
            Quaternion qua = Quaternion.Euler(0, 0, 0); //角度
            GameObject temp = Instantiate(data.Spawn[index - 1].Alliance, pos, qua); //生成
            temp.gameObject.GetComponent<Alliance>().hp = card.hp; //添加元件<盟友>.血量 = 卡片.血量
            temp.gameObject.GetComponent<RoleMove>().speed = card.speed; //添加元件<盟友移動> 速度 = 卡牌.速度
            temp.gameObject.GetComponent<RoleMove>().damage = card.attack; //添加元件<盟友移動>.傷害 = 卡牌.攻擊
            temp.gameObject.GetComponent<RoleMove>().AttackCD = card.AttackCD; //添加元件<盟友移動>.攻擊速度 = 卡片.攻擊速度
            temp.gameObject.GetComponent<RoleMove>().AttackDistance = card.AtackDistance; //添加元件<盟友移動>.攻擊距離 = 卡片.攻擊距離
        }
    }
}