using CTBGame.Core;

namespace CTBGame.Actions;

public class SkipRulesAction : CTBGameAction
{
    public string Name = "insurance";
    public bool IsExactlyAsName = true;

    protected override void Task(CTBGameEngine game)
    {
        if (this.IsExactlyAsName)
        {
            foreach (ManyInOneAction action in game.GameRules)
            {
                if (action.Name == this.Name) action.SkipAmount++;
            }
        }
        else
        {
            foreach (ManyInOneAction action in game.GameRules)
            {
                if (action.Name.Contains(this.Name)) action.SkipAmount++;
            }
        }
    }
}
