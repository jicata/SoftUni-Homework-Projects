using System;

namespace numberPronounciation
{
    class Program
    {



       
        


            static void Main(string[] args)
            {

                string s = Console.ReadLine();
                ConvertMyword(int.Parse(s));

                Console.Read();

            }

            static void ConvertMyword(int number)
            {
                int flag = 0;
                int lflag = 0;
                string words = String.Empty;
                string[] places = { "ones", "ten", "hundred", "thousand", "ten thousand", "lacs", "tenlacs", "crore", "tencrore" };
                string rawnumber = number.ToString();
                char[] a = rawnumber.ToCharArray();
                Array.Reverse(a);
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (i % 2 == 0 && i > 2)
                    {
                        if (int.Parse(a[i].ToString()) > 1)
                        {
                            if (int.Parse(a[i - 1].ToString()) == 0)
                            {
                                words = words + getNumberStringty(int.Parse(a[i].ToString())) + " " + places[i - 1] + " ";
                            }
                            else
                            {
                                words = words + getNumberStringty(int.Parse(a[i].ToString())) + " ";
                            }
                        }
                        else if (int.Parse(a[i].ToString()) == 1)
                        {
                            if (int.Parse(a[i - 1].ToString()) == 0)
                            {
                                words = words + "Ten" + " ";
                            }
                            else
                            {
                                words = words + getNumberStringteen(int.Parse(a[i - 1].ToString())) + " ";
                            }
                            flag = 1;
                        }
                    }
                    else
                    {
                        if (i == 1 || i == 0)
                        {
                            if (int.Parse(a[i].ToString()) > 1)
                            {
                                words = words + getNumberStringty(int.Parse(a[i].ToString())) + " " + getNumberString(int.Parse(a[0].ToString())) + " ";
                                break;
                            }
                            else if (int.Parse(a[i].ToString()) == 1)
                            {
                                if (int.Parse(a[i - 1].ToString()) == 0)
                                {
                                    words = words + "Ten" + " ";
                                }
                                else
                                {
                                    words = words + getNumberStringteen(int.Parse(a[i - 1].ToString())) + " ";
                                }

                                break;
                            }
                            else if (int.Parse(a[i - 1].ToString()) != 0)
                            {
                                words = words + getNumberString(int.Parse(a[i - 1].ToString())) + " ";
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (flag == 0)
                            {
                                for (int l = i; l >= 0; l--)
                                {
                                    if (int.Parse(a[l].ToString()) != 0)
                                    {
                                        lflag = 1;
                                    }
                                }
                                if (lflag == 1 && int.Parse(a[i].ToString()) != 0)
                                {

                                    words = words + getNumberString(int.Parse(a[i].ToString())) + " " + places[i] + " ";
                                    lflag = 0;


                                }
                                else if (lflag == 0)
                                {
                                    // words = words + getNumberString(int.Parse(a[i].ToString())) + " " + places[i] + " ";
                                    lflag = 0;
                                    break;
                                }

                            }
                            else
                            {
                                words = words + " " + places[i] + " ";
                                flag = 0;
                            }

                        }
                    }
                }
                Console.WriteLine(words);
            }
            static string getNumberString(int num)
            {
                string Word = String.Empty;
                switch (num)
                {
                    case 1:
                        Word = "one";
                        break;
                    case 2:
                        Word = "two";
                        break;

                    case 3:
                        Word = "three";
                        break;

                    case 4:
                        Word = "four";
                        break;

                    case 5:
                        Word = "five";
                        break;

                    case 6:
                        Word = "six";
                        break;
                    case 7:
                        Word = "seven";
                        break;

                    case 8:
                        Word = "eight";
                        break;

                    case 9:
                        Word = "nine";
                        break;


                }
                return Word;
            }
            static string getNumberStringty(int num)
            {
                string Word = String.Empty;
                switch (num)
                {

                    case 2:
                        Word = "twenty";
                        break;

                    case 3:
                        Word = "thirty";
                        break;

                    case 4:
                        Word = "fourty";
                        break;

                    case 5:
                        Word = "fifty";
                        break;

                    case 6:
                        Word = "sixty";
                        break;
                    case 7:
                        Word = "seventy";
                        break;

                    case 8:
                        Word = "eighty";
                        break;

                    case 9:
                        Word = "ninty";
                        break;


                }
                return Word;
            }
            static string getNumberStringteen(int num)
            {
                string Word = String.Empty;
                switch (num)
                {
                    case 1:
                        Word = "eleven";
                        break;
                    case 2:
                        Word = "tewlve";
                        break;

                    case 3:
                        Word = "thirteen";
                        break;

                    case 4:
                        Word = "fourteen";
                        break;

                    case 5:
                        Word = "fifteen";
                        break;

                    case 6:
                        Word = "sixteen";
                        break;
                    case 7:
                        Word = "seventeen";
                        break;

                    case 8:
                        Word = "eighteen";
                        break;

                    case 9:
                        Word = "ninteen";
                        break;


                }
                return Word;
            }
        }

    }


