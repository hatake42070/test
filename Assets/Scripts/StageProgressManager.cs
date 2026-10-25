public class StageProgressManager
{
    private bool[] isStageUnlocked = new bool[20];
    private int[] stageClearRanks = new int[20];
    private int nextStageIndex = 0;

    public StageProgressManager()
    {
        isStageUnlocked[0] = true;  // 初期ステージのみアンロック
        isStageUnlocked[1] = true;
    }

    public int GetClearRank(int stageIndex)
    {
        return stageClearRanks[stageIndex];
    }

    public bool IsStageUnlocked(int stageIndex)
    {
        return isStageUnlocked[stageIndex];
    }

    public void SetNextStageIndex(int stageIndex)
    {
        nextStageIndex = stageIndex;
    }

    public int GetNextStageIndex()
    {
        return nextStageIndex;
    }
}
