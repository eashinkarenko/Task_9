using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    class Element  //элемент списка
    {
        public int number;  //номер N
        public int info;  //информация
        public Element next;  //ссылка на следующий элемент
        public Element prev;  //ссылка на предыдущий элемент
        public Element end;  //ссылка на конец списка

        public Element(int num, int inf)  //конструктор
        {
            number = num;
            info = inf;
            next = null;
            prev = null;
            end = this;
        }

        public void Add(int num, int inf)  //добавить элемент в список
        {
            Element temp = new Element(num, inf);
            end.next = temp;
            temp.prev = end;
            end = temp;
            return;
        }

        public Element Find(int inf)  //найти элемент
        {
            Element t = this;
            while (t != null)
            {
                if (t.info == inf)
                {
                    return t;
                }
                else
                    t = t.next;
            }
            return null;
        }

        public void Delete(int inf)  //удалить элемент
        {
            Element t = this.Find(inf);
            if(t!=null)
                t.prev.next = t.next;
            return;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            bool okN=false;
            int inputN=0;
            do
            {
                okN = false;
                Console.WriteLine("Введите N - количество элементов");
                try
                {
                    inputN = Convert.ToInt32(Console.ReadLine());  //ввод N-количество чисел
                    okN = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Некорректный ввод");
                }
            } while (!okN);
            Element positiveList = null;  //список для положительных элементов
            Element nullList = null;  //список для нулевых элементов
            Element negativeList = null;  //список для отрицательных элементов

            int count = 1;
            for (int i = 0; i < inputN; i++)  //построчный ввод и обработка-добавление в соответствующий список
            {
                bool okE = false;
                int inputInfo = 0;
                do
                {
                    okE = false;
                    Console.WriteLine("Введите {0} элемент", i+1);
                    try
                    {
                        inputInfo = Convert.ToInt32(Console.ReadLine());
                        okE = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                } while (!okE);
                if (inputInfo > 0)  
                {
                    if (positiveList == null)
                    {
                        positiveList = new Element(count, inputInfo);
                    }
                    else
                    {
                        positiveList.Add(count, inputInfo);
                    }
                }
                else if (inputInfo == 0)
                {
                    if (nullList == null)
                    {
                        nullList = new Element(count, inputInfo);
                    }
                    else
                    {
                        nullList.Add(count, inputInfo);
                    }
                }
                else
                {
                    if (negativeList == null)
                    {
                        negativeList = new Element(count, inputInfo);
                    }
                    else
                    {
                        negativeList.Add(count, inputInfo);
                    }
                }
                count++;
            }
            Element totalList = positiveList;  //объединение всех 3 списков в один
            totalList.end.next = nullList;
            totalList.end = nullList.end;
            totalList.end.next = negativeList;
            totalList.end = negativeList.end;


            Element found = totalList.Find(0);  //нахождение значения

            totalList.Delete(5);  //удаление значения
        }
    }
}
