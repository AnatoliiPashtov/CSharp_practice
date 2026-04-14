using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Blue
{
  public class Task1 : Blue
  {
    private static int _count = 0;
    private int _output;
    public int Output => _output;

    public Task1(string input) : base(input)
    {
      _output = 0;
    }

    public override void Review()
    {
      // обработать текст в Input, решая задание
      // (Текст в Input не должен изменяться)

      // по результатам выполнения метода
      // Output должен возврашать правильный ответ для текста в Input
      _output = ++_count;
    }
    public override string ToString()
    {
      return $"=(^w^)={base.Input}{Environment.NewLine /* \n */}{base.Input}";
    }
  }
}
