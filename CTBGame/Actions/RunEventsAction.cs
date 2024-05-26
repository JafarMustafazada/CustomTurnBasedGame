using CTBGame.Core;

namespace CTBGame.Actions;

public class RunEventsAction : CTBGameAction
{
    public string Name = "insurance";
    public bool IsExactlyAsName = true;

    protected override void Task(CTBGameEngine game)
    {
        if (this.IsExactlyAsName)
        {
            foreach (ManyInOneAction action in game.GameEvents)
            {
                if (action.Name == this.Name) action.Run(game);
            }
        }
        else
        {
            foreach (ManyInOneAction action in game.GameEvents)
            {
                if (action.Name.Contains(this.Name)) action.Run(game);
            }
        }
    }
}
