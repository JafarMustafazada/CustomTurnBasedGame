using CTBGame.Core;

namespace CTBGame.Actions;

public class CombineAction : CTBGameAction
{
    public string LeftSide = null;
    public string RightSide = null;
    public string Middle = null;
    public string Where = "insurance";

    protected override void Task(CTBGameEngine game)
    {
        string result = "";
        if (this.LeftSide != null && game.Data.TryGetValue(this.LeftSide, out this.LeftSide)) result += this.LeftSide;
        if (this.Middle != null && game.Data.TryGetValue(this.Middle, out this.Middle)) result += this.Middle;
        if (this.RightSide != null && game.Data.TryGetValue(this.RightSide, out this.RightSide)) result += this.RightSide;
        game.Data[this.Where] = result;
    }
}
