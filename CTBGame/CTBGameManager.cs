using CTBGame.Actions;
using CTBGame.Core;

namespace CTBGame;

public static class CTBGameManager // not complete
{
    public static CTBGameEngine RRP()
    {
        ManyInOneAction initial = new()
        {
            Actions =
            {
                new SetDataAction()
                {
                    Text = "2",
                    Where = "p_max"
                },
                new SetDataAction()
                {
                    Text = "000001",
                    Where = "drum",
                },
                new SetDataAction()
                {
                    Text = "0",
                    Where = "b_turn"
                },
                new SetDataAction()
                {
                    Text = "0",
                    Where = "p_turn"
                },
                new SetDataAction()
                {
                    Text = "player#",
                    Where = "player_"
                },
                new SetDataAction()
                {
                    Text = "_coin",
                    Where = "_coin"
                },
                new SetDataAction()
                {
                    Text = "_hp",
                    Where = "_hp"
                },
                new AddEventAction()
                {
                    Event =
                    {
                        Name = "menu-0",
                        Actions =
                        {
                            new IsEqualAction()
                            {
                                What = "input",
                                With = "n1",
                                TrueCase = new SetDataAction()
                                {
                                    Where = "nextMenu",
                                    Text = "n1"
                                }
                            },
                            new IsEqualAction()
                            {
                                What = "input",
                                With = "n2",
                                TrueCase = new SetDataAction()
                                {
                                    Where = "nextMenu",
                                    Text = "n2"
                                }
                            },
                            new IsEqualAction()
                            {
                                What = "input",
                                With = "n3",
                                TrueCase = new SetDataAction()
                                {
                                    Where = "nextMenu",
                                    Text = "n3"
                                }
                            },
                            new SetDataAction()
                            {
                                Where = "input",
                                Text = "n0"
                            },
                        }
                    }
                },
                new AddEventAction()
                {
                    Event =
                    {
                        Name = "setup-pmax",
                        Actions =
                        {
                            new IncrementAction()
                            {
                                CustomAmount = "input",
                                Where = "p_max"
                            },
                            new CompareAction()
                            {
                                What = "n2",
                                With = "p_max",
                                TrueCase = new SetDataAction()
                                {
                                    Where = "p_max",
                                    Text = "2"
                                }
                            },
                            new CompareAction()
                            {
                                What = "p_max",
                                With = "8",
                                TrueCase = new SetDataAction()
                                {
                                    Where = "p_max",
                                    Text = "8"
                                }
                            },
                            new SetDataAction()
                            {
                                Where = "index",
                                Text = "0"
                            },
                            new ManyInOneAction()
                            {
                                Name = "setup_loop",
                                CustomAmount = "p_max",
                                Actions =
                                {
                                    new IncrementAction()
                                    {
                                        What = "index",
                                        Where = "index",
                                    },
                                    new CombineAction()
                                    {
                                        LeftSide = "player_",
                                        Middle = "index",
                                        RightSide = "_coin",
                                        Where = "current_p_coin",
                                    },
                                    new CombineAction()
                                    {
                                        LeftSide = "player_",
                                        Middle = "index",
                                        RightSide = "_hp",
                                        Where = "current_p_hp",
                                    },
                                    new CombineAction()
                                    {
                                        LeftSide = "player_",
                                        Middle = "index",
                                        RightSide = "_card",
                                        Where = "current_p_card",
                                    },
                                    new SetDataAction()
                                    {
                                        WhereIsPlace = true,
                                        Where = "current_p_coin",
                                        Text = "3"
                                    },
                                    new SetDataAction()
                                    {
                                        WhereIsPlace = true,
                                        Where = "current_p_hp",
                                        Text = "1"
                                    },
                                    new ManyInOneAction()
                                    {
                                        Name = "inner_loop",
                                        CustomAmount = "n3",
                                        Actions =
                                        {
                                            new IncrementAction()
                                            {
                                                What = "jndex",
                                                Where = "jndex",
                                            },
                                            new CombineAction()
                                            {
                                                LeftSide = "current_p_card",
                                                Middle = "jndex",
                                                Where = "current_p_cards",
                                            },
                                            new GetRandomAction()
                                            {
                                                Where = "random",
                                            },
                                            new DivisionAction()
                                            {
                                                IsModule = true,
                                                What = "random",
                                                With = "n6",
                                                Where = "random",
                                            },
                                            new SetDataAction()
                                            {
                                                WhereIsPlace = true,
                                                TextIsPlace = true,
                                                Where = "current_p_cards",
                                                Text = "random"
                                            }
                                        }
                                    }
                                }
                            },
                            new AddRuleAction()
                            {
                                EventName = "menu-0"
                            },
                            new DeleteRulesAction()
                            {
                                Name = "setup-pmax"
                            }
                        }
                    }
                },
                new AddRuleAction()
                {
                    EventName = "setup-pmax"
                }
            }
        };

        return new(initial);
    }
}
