using CTBGame.Actions;

namespace CTBGame.Core;

public class CTBGameEngine
{
    public CTBGameEngine(ManyInOneAction initial)
    {
        this.Data = new();
        this.Data["input"] = "0";
        this.Data["n0"] = "0";
        this.Data["n1"] = "1";
        this.Data["n2"] = "2";
        this.Data["n3"] = "3";
        this.Data["n4"] = "4";
        this.Data["n5"] = "5";
        this.Data["n6"] = "6";
        this.Data["n7"] = "7";
        this.Data["n8"] = "8";
        this.Data["n9"] = "9";

        this.GameRules = new();
        this.GameEvents = new();
        initial.Run(this);
    }

    public CTBGameEngine(Dictionary<string, string> loadData,
        List<ManyInOneAction> loadGameRules, 
        List<ManyInOneAction> loadGameEvents)
    {
        this.Data = loadData;
        this.GameRules = loadGameRules;
        this.GameEvents = loadGameEvents;
    }

    internal Dictionary<string, string> Data;
    internal List<ManyInOneAction> GameRules;
    internal List<ManyInOneAction> GameEvents;


    // methods //
    public IReadOnlyDictionary<string, string> Datas { get => this.Data; }

    public string GameIO
    {
        get => this.Data["input"];
        set
        {
            this.Data["input"] = value;

            foreach (ManyInOneAction action in this.GameRules)
            {
                if (action.IsDeleted) this.GameRules.Remove(action);
                else action.Run(this);
            }
        }
    }
}
