using UnityEngine;
using TMPro;

public class ClassInfos : MonoBehaviour
{
    // 3D TextMesh'leri burada public olarak tanımlıyoruz, böylece bunları Unity editor'ünden atayabiliriz.
    public TextMeshPro textMesh1;
    public TextMeshPro textMesh2;
    public TextMeshPro textMesh3;
    public string temp = "";

    void Start()
    {
        // PlayerPrefs'ten "info1", "info2" ve "info3" adlı verileri alıyoruz.
        string info1 = PlayerPrefs.GetString("info1", " ");
        string info2 = PlayerPrefs.GetString("info2", " ");
        string info3 = PlayerPrefs.GetString("info3", " ");

        // TextMesh'lere metinleri ekliyoruz.
        textMesh1.text += info1; // TextMesh1'e info1 eklenir
        temp = info2 + textMesh2.text;
        textMesh2.text += temp; // TextMesh2'ye info2 eklenir
        temp = "1 kilograms " + info3 + textMesh3.text;
        textMesh3.text += temp; // TextMesh3'e info3 eklenir
    }
}
