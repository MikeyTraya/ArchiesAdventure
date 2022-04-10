using System.Collections;
using System.IO;
using UnityEngine;

namespace WarriorOrigins
{
    public class Screenshot : MonoBehaviour
    {
        Texture2D texture;

        public GameObject UI;

        private IEnumerator ScreenShot()
        {
            yield return new WaitForEndOfFrame();
            texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

            texture.ReadPixels(new Rect(0, 0, 1600, 900), 0, 0);
            texture.Apply();

            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/Screenshots/Screenshot.png", bytes); 
            
            Destroy(texture);
            UI.SetActive(true);

        }

        public void TakeScreenshot()
        {
            UI.SetActive(false);
            StartCoroutine("ScreenShot");
        }
    }
}
