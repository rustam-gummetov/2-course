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