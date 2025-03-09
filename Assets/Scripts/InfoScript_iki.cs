using UnityEngine;
using TMPro;

public class InfoScript_iki : MonoBehaviour
{
    // 3D TextMesh'leri burada public olarak tanımlıyoruz, böylece bunları Unity editor'ünden atayabiliriz.
    public TextMeshPro textMesh4;
    public TextMeshPro textMesh5;
    public TextMeshPro textMesh6;

    void Start()
    {
        // PlayerPrefs'ten "info1", "info2" ve "info3" adlı verileri alıyoruz.
        string info1 = PlayerPrefs.GetString("Fact5", " ");
        string info2 = PlayerPrefs.GetString("Fact6", " ");
        string info3 = PlayerPrefs.GetString("Fact7", " ");

        // TextMesh'lere metinleri ekliyoruz.
        textMesh4.text += info1; // TextMesh1'e info1 eklenir
        textMesh5.text += info2; // TextMesh2'ye info2 eklenir
        textMesh6.text += info3; // TextMesh3'e info3 eklenir
    }
}
