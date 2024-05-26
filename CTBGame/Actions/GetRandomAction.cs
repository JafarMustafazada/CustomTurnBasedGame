using CTBGame.Core;

namespace CTBGame.Actions;

public class GetRandomAction : CTBGameAction
{
    public string Where = "insurance";
    public int Seed = 0;

    public override void Run(CTBGameEngine game)
    {
        Random gen = this.Seed == 0 ? new Random() : new(this.Seed);

        if (this.CustomAmount != null && game.Data.TryGetValue(this.CustomAmount, out this.CustomAmount))
        {
            _ = int.TryParse(this.CustomAmount, out this.RunAmount);
        }
        for (int i = 1; i < this.RunAmount; i++)
        {
            gen.Next();
        }

        game.Data[this.Where] = gen.Next().ToString();
    }

    protected override void Task(CTBGameEngine game)
    {
        throw new NotImplementedException();
    }
}
