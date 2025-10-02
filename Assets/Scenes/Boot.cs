using System.Threading.Tasks;
using Commons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class Boot : MonoBehaviour
    {
        private void Start()
        {
            SetUpServices();
            LoadMainSceneAsync().Forget();
        }

        private static void SetUpServices()
        {
        }

        private static async Task LoadMainSceneAsync()
        {
            await SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
        }
    }
}