using CTBGame.Core;

namespace CTBGame.Actions;

public class IsEqualAction : CTBGameAction
{
    public string What;
    public string With = null;
    public CTBGameAction TrueCase = null;
    public CTBGameAction FalseCase = null;

    protected override void Task(CTBGameEngine game)
    {
        _ = game.Data.TryGetValue(this.What, out this.What);
        if (this.With == null)
        {
            if (this.What != null && this.What == "0") this.FalseCase?.Run(game);
            else this.TrueCase?.Run(game);
        }
        else
        {
            _ = game.Data.TryGetValue(this.With, out this.With);
            if (this.What != null && this.With != null && this.What == this.With) this.TrueCase?.Run(game);
            else this.FalseCase?.Run(game);
        }
    }
}
