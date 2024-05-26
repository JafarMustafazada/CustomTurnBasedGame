using CTBGame.Core;

namespace CTBGame.Actions;

public class AddRuleAction : CTBGameAction
{
    public ManyInOneAction Rule = null;
    public string EventName = null;
    public bool IsExactlyAsName = true;

    protected override void Task(CTBGameEngine game)
    {
        if (this.Rule != null) game.GameRules.Add(this.Rule);
        else if (this.EventName != null)
        {
            if (this.IsExactlyAsName)
            {
                foreach (ManyInOneAction action in game.GameEvents)
                {
                    if (action.Name == this.EventName) game.GameRules.Add(action);
                }
            }
            else
            {
                foreach (ManyInOneAction action in game.GameEvents)
                {
                    if (action.Name.Contains(this.EventName)) game.GameRules.Add(action);
                }
            }
        }
    }
}
