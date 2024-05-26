using CTBGame.Core;

namespace CTBGame.Actions;

public class DivisionAction : CTBGameAction
{
    public string What = "insurance";
    public string With = "insurance";
    public string Where = "insurance";
    public bool IsModule = false;

    protected override void Task(CTBGameEngine game)
    {
        _ = game.Data.TryGetValue(this.What, out this.What);
        _ = int.TryParse(this.What, out int what);
        _ = game.Data.TryGetValue(this.With, out this.With);
        _ = int.TryParse(this.With, out int with);

        if (this.IsModule) game.Data[this.Where] = (what % with).ToString();
        else game.Data[this.Where] = (what / with).ToString();
    }
}
