using CTBGame.Core;

namespace CTBGame.Actions;

public class CompareAction : CTBGameAction
{
    public string What;
    public string With;
    public CTBGameAction TrueCase = null;
    public CTBGameAction FalseCase = null;
    public bool CanBeEqual = false;

    protected override void Task(CTBGameEngine game)
    {
        _ = game.Data.TryGetValue(this.What, out this.What);
        _ = int.TryParse(this.What, out int number1);
        _ = game.Data.TryGetValue(this.With, out this.With);
        _ = int.TryParse(this.With, out int number2);

        if (this.CanBeEqual)
        {
            if (number1 >= number2) this.TrueCase?.Run(game);
            else this.FalseCase?.Run(game);
        }
        else
        {
            if (number1 > number2) this.TrueCase?.Run(game);
            else this.FalseCase?.Run(game);
        }
    }
}
