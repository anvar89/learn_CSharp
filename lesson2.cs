using System.Runtime.InteropServices;

class lesson2
{

    static void Main(string[] args)
    {
        //������ 1
        Console.WriteLine(min(1,2,3));
    }

    #region ������ 1 - ����� ����������� ����� �� ���
    static int min(int num1, int num2, int num3)
    {
        int tmp = (num1 < num2) ? num1 : num2;
        if (tmp < num3) return tmp;
        return num3;
    }
    #endregion

}