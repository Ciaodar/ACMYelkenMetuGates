using UnityEngine;
using TMPro;

public class ClassInfos3 : MonoBehaviour
{
    // 3D TextMesh'leri burada public olarak tanımlıyoruz, böylece bunları Unity editor'ünden atayabiliriz.
    public TextMeshPro textMesh122;
    public TextMeshPro textMesh222;
    public TextMeshPro textMesh322;
    public string temp = "";

    void Start()
    {
        // PlayerPrefs'ten "info1", "info2" ve "info3" adlı verileri alıyoruz.
        string info1 = PlayerPrefs.GetString("info8", " ");
        string info2 = PlayerPrefs.GetString("info9", " ");
        string info3 = PlayerPrefs.GetString("info10", " ");

        // TextMesh'lere metinleri ekliyoruz.
        textMesh122.text += info1; // TextMesh1'e info1 eklenir
        temp = info2 + textMesh222.text;
        textMesh222.text += temp; // TextMesh2'ye info2 eklenir
        temp = "1 kilograms " + info3 + textMesh322.text;
        textMesh322.text += temp; // TextMesh3'e info3 eklenir
    }
}
