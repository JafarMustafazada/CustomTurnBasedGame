using CTBGame.Core;

namespace CTBGame.Actions;

public class ManyInOneAction : CTBGameAction
{
    public string Name = "insurance";
    public int SkipAmount = 0;
    public List<CTBGameAction> Actions = new();

    internal bool IsDeleted = false;

    protected override void Task(CTBGameEngine game)
    {
        if (this.SkipAmount > 0) this.SkipAmount--;
        else this.Actions.ForEach(action => action.Run(game));
    }
}
