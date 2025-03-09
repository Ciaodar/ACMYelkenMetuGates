using UnityEngine;
using TMPro;

public class InfoScript_uc : MonoBehaviour
{
    // 3D TextMesh'leri burada public olarak tanımlıyoruz, böylece bunları Unity editor'ünden atayabiliriz.
    public TextMeshPro textMesh8;
    public TextMeshPro textMesh9;
    public TextMeshPro textMesh10;

    void Start()
    {
        // PlayerPrefs'ten "info1", "info2" ve "info3" adlı verileri alıyoruz.
        string info1 = PlayerPrefs.GetString("Fact8", " ");
        string info2 = PlayerPrefs.GetString("Fact9", " ");
        string info3 = PlayerPrefs.GetString("Fact10", " ");

        // TextMesh'lere metinleri ekliyoruz.
        textMesh8.text += info1; // TextMesh1'e info1 eklenir
        textMesh9.text += info2; // TextMesh2'ye info2 eklenir
        textMesh10.text += info3; // TextMesh3'e info3 eklenir
    }
}
