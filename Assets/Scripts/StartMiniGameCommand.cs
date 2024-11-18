using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;
using DTT.MinigameMemory;

[CommandAlias("startMiniGame")]
public class StartMiniGameCommand : Command
{
    public StringParameter GameName;
    private MemoryGameManager memoryGameManager;

    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        await SceneManager.LoadSceneAsync("Demo");
        memoryGameManager = Object.FindObjectOfType<MemoryGameManager>();
        memoryGameManager.Finish += OnGameFinished;
    }

    private void OnGameFinished(MemoryGameResults results)
    {
        memoryGameManager.Finish -= OnGameFinished;
        SceneManager.LoadScene("GameScene");
    }
}
