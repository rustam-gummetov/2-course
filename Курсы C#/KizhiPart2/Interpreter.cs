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
                            //�������� ���������� ����������� � ������
                            _writer.WriteLine("���������� ����������� � ������");
                        }
                        else if (oneCommand[0] == "set" && !VariableDictionary.ContainsKey(oneCommand[1])) //���� ������� set � ���������� ��� �� ���� �������
                        {
                            VariableDictionary.Add(oneCommand[1], int.Parse(oneCommand[2]));//��������� � ������� ������,��� ����-�������� ����������,�
                                                                                            //��������-��������� ��������,����������� � int
                        }
                        else if (oneCommand[0] == "set" && VariableDictionary.ContainsKey(oneCommand[1]))//���� ������� set � ���������� ��� ���� �������,��
                        {
                            VariableDictionary[oneCommand[1]] = int.Parse(oneCommand[2]);// �������� ��������,������� �� ������� ����� � �������
                        }
                        else if (oneCommand[0] == "sub")//���� ������� sub,�� �� ��������,�������� �� ������� �����,���������� �������� ��������,����������� � int
                        {
                            VariableDictionary[oneCommand[1]] -= int.Parse(oneCommand[2]);
                        }
                        else if (oneCommand[0] == "print")//���� ������� print,�� � textwriter �������� ������ �� ��������� ����������
                        {
                            _writer.WriteLine(VariableDictionary[oneCommand[1]]);
                        }
                        else if (oneCommand[0] == "rem")//���� ������� rem,������� �������� � ������� �� �����
                        {
                            VariableDictionary.Remove(oneCommand[1]);
                        }
                    }
                }
                else if (!VariableDictionary.ContainsKey(SplitedCommand[1]) && SplitedCommand[0] != "set")
                {
                    //�������� ���������� ����������� � ������
                    _writer.WriteLine("���������� ����������� � ������");
                }
                else if (SplitedCommand[0] == "set" && !VariableDictionary.ContainsKey(SplitedCommand[1])) //���� ������� set � ���������� ��� �� ���� �������
                {
                    VariableDictionary.Add(SplitedCommand[1], int.Parse(SplitedCommand[2]));//��������� � ������� ������,��� ����-�������� ����������,�
                                                                                            //��������-��������� ��������,����������� � int
                }
                else if (SplitedCommand[0] == "set" && VariableDictionary.ContainsKey(SplitedCommand[1]))//���� ������� set � ���������� ��� ���� �������,��
                {
                    VariableDictionary[SplitedCommand[1]] = int.Parse(SplitedCommand[2]);// �������� ��������,������� �� ������� ����� � �������
                }
                else if (SplitedCommand[0] == "sub")//���� ������� sub,�� �� ��������,�������� �� ������� �����,���������� �������� ��������,����������� � int
                {
                    VariableDictionary[SplitedCommand[1]] -= int.Parse(SplitedCommand[2]);
                }
                else if (SplitedCommand[0] == "print")//���� ������� print,�� � textwriter �������� ������ �� ��������� ����������
                {
                    _writer.WriteLine(VariableDictionary[SplitedCommand[1]]);
                }
                else if (SplitedCommand[0] == "rem")//���� ������� rem,������� �������� � ������� �� �����
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