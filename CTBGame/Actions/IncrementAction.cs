using CTBGame.Core;

namespace CTBGame.Actions;

public class IncrementAction : CTBGameAction
{
    public string What = "n0";
    public string With = "n1";
    public string Where = "insurance";

    public override void Run(CTBGameEngine game)
    {
        _ = game.Data.TryGetValue(this.What, out this.What);
        _ = int.TryParse(this.What, out int result);
        _ = game.Data.TryGetValue(this.With, out this.With);
        _ = int.TryParse(this.With, out int how);

        if (this.CustomAmount != null && game.Data.TryGetValue(this.CustomAmount, out this.CustomAmount))
        {
            _ = int.TryParse(this.CustomAmount, out this.RunAmount);
        }
        for (int i = 0; i < this.RunAmount; i++)
        {
            result += how;
        }
        game.Data[this.Where] = result.ToString();
    }

    protected override void Task(CTBGameEngine game)
    {
        throw new NotImplementedException();
    }
}
