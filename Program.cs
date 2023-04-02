class test
{
    public static void Main()
    {
        string AllStrok = "eat tea, tan,  ate, nat, ate, bat, dhen, qwer, rewq, wrqe, denh, ewqr, wrqe, asdfg, dsgfa, dfgas"; //, dhen, qwer, rewq, wrqe, denh, ewqr, wrqe, asdfg, dsgfa, dfgas

        List<List<string>> AllMass;
        AllMass = new List<List<string>>();
        List<string> allWords = new List<string>();
        string tempWord = ""; //временная строка из букв

        //---------- закидываем строку в массив allWords ------------

        for (int i = 0; i < AllStrok.Length; i++)// считываем всю строку и делим на буквы
        {
            char s = AllStrok[i];

            if (i < AllStrok.Length)// если строка не закончилась, то продолжаем
            {
                if ((Char.IsLetter(s)) == true)// если символ - буква, то продолжаем
                {
                    tempWord += s;// добавляем во временную строку
                    if (i == AllStrok.Length - 1)// проверяем, не последний ли знак в строке
                    {
                        allWords.Add(tempWord);// добавляем в массив слов
                        tempWord = "";// очищаем временную строку
                    }
                }
                else if (tempWord != "")// если временная строка не пустая, то добавляем слово в массив слов
                {
                    allWords.Add(tempWord);
                    tempWord = "";
                }
            }
        }
        List<List<string>> polyMassWords = new List<List<string>>();// многомерный массив для разделения по количествам букв
        List<List<string>> resultMass = new List<List<string>>();// окончательный массив


        //-------- собираем одинаковые слова из массива --------------


        while (allWords.Count > 0)// работаем пока массив из слов строки не опустеет
        {
            List<string> tempWords = new List<string>(); // складываем слова одинаковой длины
            List<string> tempBack = new List<string>(); // складываем остальные слова для возврата в общий массив
            int lettrsNum = allWords[0].Length;// длина первого слова массива из слов строки
            foreach (string temp in allWords)
            {
                if (temp.Length == lettrsNum)
                {
                    tempWords.Add(temp);//если длина совпадает со следующим словом, то добавляем во временный массив одинаковых слов
                }
                else
                {
                    tempBack.Add(temp);//если длина совпадает со следующим словом, то добавляем во общий временный массив
                }
            }
            allWords.Clear();//очищаем массив из слов строки
            allWords.AddRange(tempBack); //восстановление массива, после переноса слов в темповский массив
            polyMassWords.Add(tempWords);// добавили в многомерный массив
        }

        while (polyMassWords.Count > 0)// работаем пока многомерный массив не опустеет
        {
            for (int j = 0; j < polyMassWords.Count; j++)
            {
                List<string> tempWords2 = new List<string>(); // складываем слова одинаковой длины
                if (j < polyMassWords.Count)// пока j меньше размера многомерного массива работаем
                {
                    if (polyMassWords[j].Count != 0)// пока есть хоть одно значение в подмассиве работаем
                    {
                        string baseWord = polyMassWords[j][0];// первое слово в подмассиве
                        tempWords2.Add(polyMassWords[j][0]);// копирование первого слова из подмассива во временный массив
                        polyMassWords[j].RemoveAt(polyMassWords[j].IndexOf(baseWord));//удаление первого слова из подмассива
                        for (int i = 0; i < polyMassWords[j].Count; i++)
                        {
                            if (contrastWords(baseWord, polyMassWords[j][i], baseWord.Length) == true)
                            {
                                tempWords2.Add(polyMassWords[j][i]);// если буквы первого слова и следующего совпадают, то отправляем в временный массив
                            }
                        }

                        resultMass.Add(tempWords2);// временный массив отправлем в результирующий массив
                        foreach (string word in tempWords2)// удаление лишних слов из основного массива
                        {
                            polyMassWords[j].Remove(word);// удаляем в многомерном массива слова, которые перенесли в результирующий массив
                        }
                    }
                    else
                    {
                        polyMassWords.Remove(polyMassWords[j]);// удалем подмассив, если пустой
                    }
                }


            }
        }

        Console.WriteLine("Вывод результата: ");
        for (int j = 0; j < resultMass.Count; j++)
        {
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < resultMass[j].Count; i++)
            {
                Console.WriteLine(resultMass[j][i]);
            }
        }


    }


    //------- Проверка слов на одинаковые буквы ----------------
    public static bool contrastWords(string word1, string word2, int len)
    {
        int countLetter = 0;// счетчик совпадающих букв
        for (int k = 0; k < word1.Length; k++)//посимвольно из первого слова
        {
            for (int j = 0; j < word2.Length; j++)//посимвольно из второго слова
            {

                if (word2[j].Equals(word1[k]))
                {
                    countLetter++;
                }
            }
        }
        return (countLetter == word1.Length) ? true : false;
    }
}