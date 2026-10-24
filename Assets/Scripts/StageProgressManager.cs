public class StageProgressManager
{
    private bool[] isStageUnlocked = new bool[20];
    private int[] stageClearRanks = new int[20];

    public StageProgressManager()
    {
        isStageUnlocked[0] = true;  // 初期ステージのみアンロック
    }

    public int GetClearRank(int stageIndex)
    {
        return stageClearRanks[stageIndex];
    }

    public bool IsStageUnlocked(int stageIndex)
    {
        return isStageUnlocked[stageIndex];
    }
}
