namespace CTBGame.Core;

public abstract class CTBGameAction
{
    public int RunAmount = 1;
    public string CustomAmount = null;

    public virtual void Run(CTBGameEngine game)
    {
        if (this.CustomAmount != null && game.Data.TryGetValue(this.CustomAmount, out this.CustomAmount))
        {
            _ = int.TryParse(this.CustomAmount, out this.RunAmount);
        }
        for (int i = 0; i < this.RunAmount; i++)
        {
            this.Task(game);
        }
    }

    protected abstract void Task(CTBGameEngine game);
}
