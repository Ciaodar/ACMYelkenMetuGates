using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoruCevapManager : MonoBehaviour
{
    public string birinci;
    public string ikinci;
    public string ucuncu;

    // Her sorunun 3 tane TextMeshPro nesnesi
    public TextMeshPro[] soru1Secenekler = new TextMeshPro[3];
    public TextMeshPro[] soru2Secenekler = new TextMeshPro[3];
    public TextMeshPro[] soru3Secenekler = new TextMeshPro[3];

    // Butonlar (TextMeshPro'nun üstünde şeffaf butonlar)
    public Button[] soru1Butonlar = new Button[3];
    public Button[] soru2Butonlar = new Button[3];
    public Button[] soru3Butonlar = new Button[3];

    // Feedback için
    public TextMeshPro feedbackText;

    private string dogruCevapSoru1;
    private string dogruCevapSoru2;
    private string dogruCevapSoru3;

    void Start()
    {
        // Doğru cevapları PlayerPrefs'ten al
        dogruCevapSoru1 = PlayerPrefs.GetString(birinci, "C)Cola");
        dogruCevapSoru2 = PlayerPrefs.GetString(ikinci, "B)Cherry \n    Juice");
        dogruCevapSoru3 = PlayerPrefs.GetString(ucuncu, "B)When it was spilled water on it");

        Debug.Log(dogruCevapSoru1);
        Debug.Log(dogruCevapSoru2);
        Debug.Log(dogruCevapSoru3);

        // Oyuncu puanını sıfırla
        PlayerPrefs.SetInt("userpoint", 0);

        // Butonlara tıklama event'lerini ekle
        for (int i = 0; i < 3; i++)
        {
            int index = i; // Lambda fonksiyonu için yerel değişken
            soru1Butonlar[i].onClick.AddListener(() => CevapKontrol(soru1Secenekler[index], dogruCevapSoru1, soru1Secenekler, soru1Butonlar));
            soru2Butonlar[i].onClick.AddListener(() => CevapKontrol(soru2Secenekler[index], dogruCevapSoru2, soru2Secenekler, soru2Butonlar));
            soru3Butonlar[i].onClick.AddListener(() => CevapKontrol(soru3Secenekler[index], dogruCevapSoru3, soru3Secenekler, soru3Butonlar));
        }
    }

    // Kullanıcı bir cevabı seçtiğinde çağrılacak fonksiyon
    private void CevapKontrol(TextMeshPro tiklananCevap, string dogruCevap, TextMeshPro[] secenekler, Button[] butonlar)
    {
        if (tiklananCevap.text == dogruCevap)
        {
            feedbackText.text = "Doğru!";
            PlayerPrefs.SetInt("userpoint", PlayerPrefs.GetInt("userpoint", 0) + 1);
        }
        else
        {
            feedbackText.text = tiklananCevap.text + " - Yanlış cevap!";
        }

        // Yanlış cevapları gizle (doğru olan hariç)
        for (int i = 0; i < secenekler.Length; i++)
        {
            if (secenekler[i].text != dogruCevap)
            {
                secenekler[i].gameObject.SetActive(false); // Yanlış şık TextMeshPro'yu gizle
                butonlar[i].gameObject.SetActive(false);   // Yanlış şık Butonu gizle
            }
        }
    }
}
