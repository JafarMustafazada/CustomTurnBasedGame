using CTBGame.Core;

namespace CTBGame.Actions;

public class AddEventAction : CTBGameAction
{
    public ManyInOneAction Event = null;

    protected override void Task(CTBGameEngine game)
    {
        if (this.Event != null) game.GameEvents.Add(this.Event);
    }
}
