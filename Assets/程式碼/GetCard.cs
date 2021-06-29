using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //引用 網路連線API
using System.Collections;

public class GetCard : MonoBehaviour
{
    public CardData[] cards;

    [Header("卡牌物件")]
    public GameObject cardObject;

    [Header("戰鬥中人物按鈕")]
    public GameObject battlecardObject;

    [Header("卡牌內容")]
    public Transform contentCard;

    private CanvasGroup loadingPanel;
    private Image loading;

    /// <summary>
    /// 取得卡牌資料的實體物件
    /// </summary>
    public static GetCard instance;

    private IEnumerator GetCardData()
    {
        loadingPanel.alpha = 1; //顯示
        loadingPanel.blocksRaycasts = true; //啟動遮擋

        // 引用(網路要求 www = 網路要求.Post("網址", ""))
        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbxuHQ6x45NxGTwwGnALutKkLiQ42cplQU9yuqfQ9U4qCZVN3eM/exec", ""))
        {
            //yield return www.SendWebRequest(); //等待 網路要求時間
            www.SendWebRequest(); //網路要求

            while (www.downloadProgress < 1)
            {
                yield return null;
                loading.fillAmount = www.downloadProgress;
            }

            if (www.isHttpError || www.isNetworkError)
            {
                print("連線錯誤:" + www.error);
            }
            else
            {
                cards = JsonHelper.FromJson<CardData>(www.downloadHandler.text); //將 JSON 轉為陣列並儲存在cards內
                CreateCard();
            }
        }
        yield return new WaitForSeconds(0.5f); //等待
        loadingPanel.alpha = 0; //隱藏
        loadingPanel.blocksRaycasts = false; //取消遮擋
        if (dialogue.startdia == false)
        {
            dialogue.instance.Dia.SetActive(true);
            dialogue.instance.Startdia();
        }
    }

    /// <summary>
    /// 建立卡牌物件
    /// </summary>
    private void CreateCard()
    {
        if (LVsave.lastLV == 1)
        {
            for (int i = 0; i < 4; i++) //迴圈執行 卡牌數量
            {
                Transform temp = Instantiate(cardObject, contentCard).transform; //變形 = 生成(物件，父物件).變形
                CardData card = cards[i]; //卡片資料
                                          //尋找子物件並更新資料
                temp.Find("花費").GetComponent<Text>().text = card.cost.ToString();
                temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
                temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
                temp.Find("名稱").GetComponent<Text>().text = card.name;
                temp.Find("描述").GetComponent<Text>().text = card.description;
                temp.Find("遮色片").Find("圖片").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file); // 尋找圖片子物件.圖片 = 來源.載入<圖片>(檔案名稱)
                temp.gameObject.AddComponent<BookCard>().index = card.index; //添加元件<圖鑑卡片> 編號 = 卡牌.編號
            }
        }
        if (LVsave.lastLV == 2)
        {
            for (int i = 0; i < 5; i++) //迴圈執行 卡牌數量
            {
                Transform temp = Instantiate(cardObject, contentCard).transform; //變形 = 生成(物件，父物件).變形
                CardData card = cards[i]; //卡片資料
                                          //尋找子物件並更新資料
                temp.Find("花費").GetComponent<Text>().text = card.cost.ToString();
                temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
                temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
                temp.Find("名稱").GetComponent<Text>().text = card.name;
                temp.Find("描述").GetComponent<Text>().text = card.description;
                temp.Find("遮色片").Find("圖片").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file); // 尋找圖片子物件.圖片 = 來源.載入<圖片>(檔案名稱)
                temp.gameObject.AddComponent<BookCard>().index = card.index; //添加元件<圖鑑卡片> 編號 = 卡牌.編號
            }
        }
        if (LVsave.lastLV == 3)
        {
            for (int i = 0; i < 6; i++) //迴圈執行 卡牌數量
            {
                Transform temp = Instantiate(cardObject, contentCard).transform; //變形 = 生成(物件，父物件).變形
                CardData card = cards[i]; //卡片資料
                                          //尋找子物件並更新資料
                temp.Find("花費").GetComponent<Text>().text = card.cost.ToString();
                temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
                temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
                temp.Find("名稱").GetComponent<Text>().text = card.name;
                temp.Find("描述").GetComponent<Text>().text = card.description;
                temp.Find("遮色片").Find("圖片").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file); // 尋找圖片子物件.圖片 = 來源.載入<圖片>(檔案名稱)
                temp.gameObject.AddComponent<BookCard>().index = card.index; //添加元件<圖鑑卡片> 編號 = 卡牌.編號
            }
        }
        if (LVsave.lastLV == 4)
        {
            for (int i = 0; i < 7; i++) //迴圈執行 卡牌數量
            {
                Transform temp = Instantiate(cardObject, contentCard).transform; //變形 = 生成(物件，父物件).變形
                CardData card = cards[i]; //卡片資料
                                          //尋找子物件並更新資料
                temp.Find("花費").GetComponent<Text>().text = card.cost.ToString();
                temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
                temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
                temp.Find("名稱").GetComponent<Text>().text = card.name;
                temp.Find("描述").GetComponent<Text>().text = card.description;
                temp.Find("遮色片").Find("圖片").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file); // 尋找圖片子物件.圖片 = 來源.載入<圖片>(檔案名稱)
                temp.gameObject.AddComponent<BookCard>().index = card.index; //添加元件<圖鑑卡片> 編號 = 卡牌.編號
            }
        }
        if (LVsave.lastLV == 5)
        {
            for (int i = 0; i < 8; i++) //迴圈執行 卡牌數量
            {
                Transform temp = Instantiate(cardObject, contentCard).transform; //變形 = 生成(物件，父物件).變形
                CardData card = cards[i]; //卡片資料
                                          //尋找子物件並更新資料
                temp.Find("花費").GetComponent<Text>().text = card.cost.ToString();
                temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
                temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
                temp.Find("名稱").GetComponent<Text>().text = card.name;
                temp.Find("描述").GetComponent<Text>().text = card.description;
                temp.Find("遮色片").Find("圖片").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file); // 尋找圖片子物件.圖片 = 來源.載入<圖片>(檔案名稱)
                temp.gameObject.AddComponent<BookCard>().index = card.index; //添加元件<圖鑑卡片> 編號 = 卡牌.編號
            }
        }
    }
    private void Awake()
    {
        instance = this;
        loadingPanel = GameObject.Find("載入畫面").GetComponent<CanvasGroup>();
        loading = GameObject.Find("進度條").GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(GetCardData());
    }
}
/// <summary>
/// 卡片資料
/// </summary>
[System.Serializable] //序列化:讓資料顯示在屬性面板上
public class CardData
{
    public int index;
    public string name;
    public string description;
    public int cost;
    public float attack;
    public float hp;
    public float AttackCD;
    public float ProduceCD;
    public float speed;
    public float AtackDistance;
    public string file;
}


public static class JsonHelper //將json轉為陣列資料
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

