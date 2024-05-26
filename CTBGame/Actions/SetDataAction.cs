using CTBGame.Core;

namespace CTBGame.Actions;

public class SetDataAction : CTBGameAction
{
    public string Text = "0";
    public string Where = "insurance";
    public bool TextIsPlace = false;
    public bool WhereIsPlace = false;

    protected override void Task(CTBGameEngine game)
    {
        if (this.TextIsPlace && game.Data.TryGetValue(this.Text, out string data)) this.Text = data;
        if (this.WhereIsPlace && game.Data.TryGetValue(this.Where, out data)) this.Where = data;
        game.Data[this.Where] = this.Text;
    }
}
