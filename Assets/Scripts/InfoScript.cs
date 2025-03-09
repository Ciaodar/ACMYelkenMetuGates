using UnityEngine;
using TMPro;

public class InfoScript : MonoBehaviour
{
    // 3D TextMesh'leri burada public olarak tanımlıyoruz, böylece bunları Unity editor'ünden atayabiliriz.
    public TextMeshPro textMesh1;
    public TextMeshPro textMesh2;
    public TextMeshPro textMesh3;

    void Start()
    {
        // PlayerPrefs'ten "info1", "info2" ve "info3" adlı verileri alıyoruz.
        string info1 = PlayerPrefs.GetString("Fact2", " ");
        string info2 = PlayerPrefs.GetString("Fact3", " ");
        string info3 = PlayerPrefs.GetString("Fact4", " ");

        // TextMesh'lere metinleri ekliyoruz.
        textMesh1.text += info1; // TextMesh1'e info1 eklenir
        textMesh2.text += info2; // TextMesh2'ye info2 eklenir
        textMesh3.text += info3; // TextMesh3'e info3 eklenir
    }
}
