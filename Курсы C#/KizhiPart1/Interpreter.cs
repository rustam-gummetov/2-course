using System.IO;
using System.Collections.Generic;

namespace KizhiPart1
{
    public class Interpreter
    {
        private TextWriter _writer;

        public Interpreter(TextWriter writer)
        {
            _writer = writer;
        }

        static Dictionary<string, int> VariableDictionary = new Dictionary<string, int>();

        public void ExecuteLine(string command)
        {
            string[] SplitedCommand = command.Split(' ');
            if (!VariableDictionary.ContainsKey(SplitedCommand[1]) && SplitedCommand[0] != "set")
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

        public void ExecuteLine(string command)
        {
            string[] SplitedCommand = command.Split(' ');
            switch(SplitedCommand[0])
            {
                case "set":
                    {
                        if (!VariableDictionary.ContainsKey(SplitedCommand[1]))
                            VariableDictionary.Add(SplitedCommand[1], int.Parse(SplitedCommand[2]));
                        else
                            VariableDictionary[SplitedCommand[1]] = int.Parse(SplitedCommand[2]);
                        break;
                    }
                case "sub":
                    {
                        if (VariableDictionary.ContainsKey(SplitedCommand[1]))
                            VariableDictionary[SplitedCommand[1]] -= int.Parse(SplitedCommand[2]);
                        break;
                    }
                case "print":
                    {
                        if (VariableDictionary.ContainsKey(SplitedCommand[1]))
                            _writer.WriteLine(VariableDictionary[SplitedCommand[1]]);
                        break;
                    }
                case "rem":
                    {
                        if (VariableDictionary.ContainsKey(SplitedCommand[1]))
                            VariableDictionary.Remove(SplitedCommand[1]);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }
}