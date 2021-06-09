using System.IO;
using System.Collections.Generic;

namespace KizhiPart2
{
    public class Interpreter
    {
        
        private TextWriter _writer;

        Dictionary<string, int> VariableDictionary = new Dictionary<string, int>();
        Dictionary<string, List<string>> functions = new Dictionary<string, List<string>>();
        string[] AllCommands;
        


        public Interpreter(TextWriter writer)
        {
            _writer = writer;
        }
        
        public void ExecuteLine(string command)
        {
            AllCommands = command.Split('\n');
            for(int i = 0; i < AllCommands.Length; i++)
            {
                var SplitedCommand = AllCommands[i].Split(' ');
                if (SplitedCommand[0] == "def")
                {
                    int j = i + 1;
                    var function = new List<string>();
                    while (AllCommands[j][0] == ' ')
                    {
                        function.Add(AllCommands[j]);
                        j += 1;
                    }
                    functions.Add(SplitedCommand[1], function);
                }
            }

            for (int i = 0; i < AllCommands.Length; i++)
            {
                if (AllCommands[i][0] == ' ')
                    continue;
                var SplitedCommand = AllCommands[i].Split(' ');
                if (SplitedCommand[0] == "def")
                    continue;

                if (SplitedCommand[0] == "call")
                {
                    var commandsFromFunction = functions[SplitedCommand[1]];
                    for (int j = 0; j < commandsFromFunction.Count; j++)
                    {
                        commandsFromFunction[j] = commandsFromFunction[j].Remove(0, 4);
                        var oneCommand = commandsFromFunction[j].Split(' ');
                        if (!VariableDictionary.ContainsKey(oneCommand[1]) && oneCommand[0] != "set")
                        {
                            //передать ѕеременна€ отсутствует в пам€ти
                            _writer.WriteLine("ѕеременна€ отсутствует в пам€ти");
                        }
                        else if (oneCommand[0] == "set" && !VariableDictionary.ContainsKey(oneCommand[1])) //≈сли команда set и переменна€ еще не была создана
                        {
                            VariableDictionary.Add(oneCommand[1], int.Parse(oneCommand[2]));//добавл€ет в словарь запись,где ключ-название переменной,а
                                                                                            //значение-введенное значение,приведенное к int
                        }
                        else if (oneCommand[0] == "set" && VariableDictionary.ContainsKey(oneCommand[1]))//≈сли команда set и переменна€ уже была создана,то
                        {
                            VariableDictionary[oneCommand[1]] = int.Parse(oneCommand[2]);// измен€ем значение,лежащее по данному ключу в словаре
                        }
                        else if (oneCommand[0] == "sub")//≈сли команда sub,то из значени€,лежащего по данному ключу,вычитаетс€ заданное значение,приведенное к int
                        {
                            VariableDictionary[oneCommand[1]] -= int.Parse(oneCommand[2]);
                        }
                        else if (oneCommand[0] == "print")//≈сли команда print,то в textwriter добавить строку со значением переменной
                        {
                            _writer.WriteLine(VariableDictionary[oneCommand[1]]);
                        }
                        else if (oneCommand[0] == "rem")//≈сли команда rem,удал€ет значение в словаре по ключу
                        {
                            VariableDictionary.Remove(oneCommand[1]);
                        }
                    }
                }
                else if (!VariableDictionary.ContainsKey(SplitedCommand[1]) && SplitedCommand[0] != "set")
                {
                    //передать ѕеременна€ отсутствует в пам€ти
                    _writer.WriteLine("ѕеременна€ отсутствует в пам€ти");
                }
                else if (SplitedCommand[0] == "set" && !VariableDictionary.ContainsKey(SplitedCommand[1])) //≈сли команда set и переменна€ еще не была создана
                {
                    VariableDictionary.Add(SplitedCommand[1], int.Parse(SplitedCommand[2]));//добавл€ет в словарь запись,где ключ-название переменной,а
                                                                                            //значение-введенное значение,приведенное к int
                }
                else if (SplitedCommand[0] == "set" && VariableDictionary.ContainsKey(SplitedCommand[1]))//≈сли команда set и переменна€ уже была создана,то
                {
                    VariableDictionary[SplitedCommand[1]] = int.Parse(SplitedCommand[2]);// измен€ем значение,лежащее по данному ключу в словаре
                }
                else if (SplitedCommand[0] == "sub")//≈сли команда sub,то из значени€,лежащего по данному ключу,вычитаетс€ заданное значение,приведенное к int
                {
                    VariableDictionary[SplitedCommand[1]] -= int.Parse(SplitedCommand[2]);
                }
                else if (SplitedCommand[0] == "print")//≈сли команда print,то в textwriter добавить строку со значением переменной
                {
                    _writer.WriteLine(VariableDictionary[SplitedCommand[1]]);
                }
                else if (SplitedCommand[0] == "rem")//≈сли команда rem,удал€ет значение в словаре по ключу
                {
                    VariableDictionary.Remove(SplitedCommand[1]);
                }

                
            }
        }

        static public void Main()
        {
            TextWriter txt = null;
            Interpreter t = new Interpreter(txt);
            string str = "def test\n    set a 5\n    sub a 3\n    print b\nset b 7\ncall test";
            t.ExecuteLine(str);
        }
    }
}