using System;
using System.Xml.Linq;
using System.Reflection.Metadata;
using System.Dynamic;

namespace Ref_Out__Memory_aloocation__String_Char__Array_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yazi daxil edin: ");
            string text = Console.ReadLine();
            
            FixSentence(ref text);

            Console.WriteLine(text);
            Console.WriteLine(FindWordsCount(text));

            int[] numbers = { 1, 2, 3 };

            Add(ref numbers, 44);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }


            string[] fullnames = { "Hikmet Abbasov", "Tofiq Qulamov", "Nermin Memmedov" };

            var names = MakeFirstNameArr(fullnames);
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        //Verilmiş string dəyərindəki bütün sözlərin arasında bir boşluq qalacaq vəziyyətə salan metod.(Metoda "  Men   rusca    bilmirem" dəyəri göndərilərsə onu "Men rusca bilmirem" halına gətirməlidir.
        static void FixSentence(ref string str)
        {
            str = str.Trim();
            string newStr = "";

            var arr = str.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "")
                {
                    if (newStr != "")
                        newStr += ' ';

                    newStr += arr[i];
                }
            }

            str = newStr;
        }

        //- Verilmiş string dəyərdəki sözlərin sayını tapan metod (boşluqlarla ayrılmış bütün ifadələr)
        static int FindWordsCount(string str)
        {
            FixSentence(ref str);
            return str.Split(' ').Length;
        }

        //- Parameter olaraq integer array variable-ı(reference) və bir integer value qəbul edən və həmin integer value-nu integer array-ə yəni element kimi əlavə edən metod.
        static void Add(ref int[] arr, int value)
        {
            int[] newArr = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            newArr[newArr.Length - 1] = value;

            arr = newArr;           
        }

        //- Gonderilmis fullname arrayinden yeni bir names arrayi duzeldib geri qaytaran metod.Fullname arrayinin icindeki butun value-lar ad+" "+soyad formatindadir.Misalcun "Hikmet Abbasov". Misalcun gelen arraydeki deyerler { "Hikmet Abbasov","Abdulla Qulamov","Cemile Hikmetova"}
        //olarsa return olunan arraydeki deyerler {"Hikmet","Abdulla","Cemile"} olmalidir
        static string[] MakeFirstNameArr(string[] fullnames)
        {
            string[] arr = new string[fullnames.Length];
            for (int i = 0; i < fullnames.Length; i++)
            {
                int firstSpaceIndex = fullnames[i].IndexOf(' ');
                arr[i] = fullnames[i].Substring(0, firstSpaceIndex);
            }

            return arr;
        }
        //- Verilmiş string dəyərin bir fullname olub olmadığını yoxlayan metod.(Dəyərin fullname olma şərti daxilində yalnız hərflərin ola bilməsi, yalnız 2 sözdən ibarət olması və hər bir sözün böyük hərfə başlayıb kiçik hərflərlə davam etməsidir.
       
        static bool IsCapitalized(string str)
        {
            if (!Char.IsUpper(str[0]))
                return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsLower(str[i]))
                    return false;
            }


            return true;
        }

        static bool IsFullname(string str)
        {
            var words = str.Split(' ');

            if (words.Length != 2) 
                return false;

            if (!IsCapitalized(words[0]) || !IsCapitalized(words[1])) 
                return false;

            return true;
        }
    }
}
