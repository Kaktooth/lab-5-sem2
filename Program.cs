using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    class Program
    {
        struct Student

        {

            public string surName;

            public string firstName;

            public string patronymic;

            public char gender;

            public string dateOfBirth;
            public string day;
            public string month;
            public string year;




            public Student(string sName, string fName,string patron,char gend,string birth, string dday, string dmonth, string dyear)
            {
                surName = sName;
                firstName = fName;
                patronymic = patron;
                gender = gend;
                dateOfBirth = birth;
                day = dday;
                month = dmonth;
                year = dyear;

            }

        }
  
        static Student[] ReadData(string fileName)
        {
            string path = @"C:\Users\Dell\source\repos\ConsoleApp37\text\data.txt";
            int count = File.ReadAllLines(path).Length;
            Student[] stud = new Student[count];
           string[] readText = File.ReadAllLines(path);
            char[] student;
            int j = 0;
            int y = 0;
           
              int c = 0;
            foreach (string str in readText)
            {
                student = str.ToCharArray();
                
                for (int i = 0; i < str.Length; i++)
                {
                  
                    if(student[i]==' ')
                    {
                        continue;
                    }
                    else
                    {
                        for (; i < student.Length; i++)
                        {

                            if(student[i]==' '){
                                break;
                            }
                            if (j == 0)
                            {
                                stud[c].surName += student[i];
                            }
                            else if (j == 1)
                            {
                                stud[c].firstName += student[i];
                            }
                            else if (j == 2)
                            {
                                stud[c].patronymic += student[i];
                            }
                            else if (j == 3)
                            {
                                stud[c].gender += student[i];
                            }
                            else if (j == 4)
                            {
                               
                                stud[c].dateOfBirth += student[i];
                            }
                        }
                    }
                    j++;
                }
       
                j = 0;
                c++;
               
            }
            for (int q = 0; q < stud.Length; q++)
            {
                for (int a = 0; a < stud[q].dateOfBirth.Length; a++)
                {
                    if (stud[q].dateOfBirth[a] == ' ' || stud[q].dateOfBirth[a] == '.' || stud[q].dateOfBirth[a] == ',')
                    {
                        continue;
                    }
                    if (y <= 1)
                    {
                       
                        stud[q].day += stud[q].dateOfBirth[a];

                    }
                    else if (y <= 3)
                    {
                       
                        stud[q].month += stud[q].dateOfBirth[a];

                    }
                    else if (y <= 7)
                    {
                       
                        stud[q].year += stud[q].dateOfBirth[a];

                    }
                    y++;
                }
                y = 0;
            }
         
            return stud;
        }



        static void runMenu(Student[] stud)
        {
            Console.WriteLine("Current Students");
            for (int i = 0; i < stud.Length; i++)
            {
                var today = DateTime.Today;
                int sday = Convert.ToInt32(stud[i].day);
                int smonth = Convert.ToInt32(stud[i].month);
                int syear = Convert.ToInt32(stud[i].year);
                var a = (today.Year * 100 + today.Month) * 100 + today.Day;
                var b = (syear * 100 + smonth) * 100 + sday;
                int years = (a - b) / 10000;
                Console.WriteLine("SurName:{0} Name:{1} patron:{2} Male/Female:{3} date:{4}",stud[i].surName, stud[i].firstName, stud[i].patronymic, stud[i].gender, stud[i].dateOfBirth);
                Console.WriteLine("Years: {0}", years);
               
            }
            Console.WriteLine("Students that 18 year old and more");
            for (int i = 0; i < stud.Length; i++)
            {
                var today = DateTime.Today;
                int sday= Convert.ToInt32(stud[i].day); 
                    int smonth = Convert.ToInt32(stud[i].month);
                    int syear = Convert.ToInt32(stud[i].year);
                var a = (today.Year * 100 + today.Month) * 100 + today.Day;
                var b = (syear * 100 + smonth) * 100 +sday;
                int years = (a - b) / 10000;
                

                if (years>=18)
                {
                    Console.WriteLine("SurName:{0} Name:{1} patron:{2}  date:{3}", stud[i].surName, stud[i].firstName, stud[i].patronymic, stud[i].dateOfBirth);
                    Console.WriteLine("Years: {0}", years);
                }
            
            }



        }



     static void Main(string[] args)
        {
           
            
            Student[] studData = ReadData("data");

            runMenu(studData);
            
        }
 
    }
}
