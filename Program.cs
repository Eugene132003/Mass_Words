class test
{
    public static void Main()
    {
        string[] LowNames = { "eat", "tea", "tan", "ate", "nat", "bat" }; // вводные данные
        List<List<string>> SortMass;// двухмерный массив для разделения по количеству букв
        SortMass = new List<List<string>>();
        List<string> firstNames = new List<string>();
        ContrastMeNow(LowNames[0], LowNames, firstNames);
        
        for (int i = 0; i < LowNames.Length; i++)//удаление из основного массива обработанных слов
        {
            for (int j = 0; j < firstNames.Count; j++)
            {
                if (LowNames[i] == firstNames[j])
                {
                    LowNames[i] = null;
                    firstNames[j] = null;
                }
            }
        }
            foreach (string Myarray1 in LowNames)
                if (Myarray1!=null)
                Console.Write(Myarray1+"\t");

        SortMass.Add(firstNames);
        SortMass.Add(firstNames);
        //Console.WriteLine("Первый массив");
        SortMass[0].ForEach(Console.WriteLine);
        //Console.WriteLine("второй массив");
        SortMass[1].ForEach(Console.WriteLine);
    }
    public static void ContrastMeNow(String firstString, string[] LowNamesC, List<string> firstNamesF)
    {
        int countLetter = 0;// проверка на совпадение от 3х и более
        firstNamesF.Add(LowNamesC[0]); //добавление первого слова из массива в общий массив отсортированных слов
        for (int i = 1; i < LowNamesC.Length; i++)
        {
            String newString = LowNamesC[i];
            for (int k = 0; k < firstString.Length; k++)//посимвольно из основного слова
            {
                for (int j = 0; j < newString.Length; j++)//посимвольно из сравниваемого слова
                {

                    if (newString[j].Equals(firstString[k]))
                    {
                        countLetter = countLetter + 1;
                    }
                }
            }
            if (countLetter == 3)// если все три буквы совпадают, то слово добавляем
            {
                firstNamesF.Add(newString);//добавляем в массив подходящее слово
            }
            countLetter = 0;
        }
    }
}