using System;

public interface IStageResultNotifier
{
    event Action<StageResult> OnStageFinished;
}
