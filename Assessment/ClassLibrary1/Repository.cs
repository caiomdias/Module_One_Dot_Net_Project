using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ClassLibrary1
{
    public class Repository : IFriend
    {
        private string strPathFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\Repository.txt";

        public Repository()
        {
            if (!File.Exists(strPathFile))
            {
                using (FileStream fs = File.Create(strPathFile))
                {
                    Console.WriteLine("Arquivo criado com sucesso");
                }
            }
        }

        public void AddFriend(Friend friend)
        {
            if (File.Exists(strPathFile))
            {
                using (StreamWriter sw = File.AppendText(strPathFile))
                {
                    sw.Write($"{friend.Id};{friend.Name};{friend.LastName};{friend.BirthDate}\r\n");
                }

            }
            else
            {
                Console.WriteLine("Nao foi possivel adicionar ao arquivo !");
            }
        }

        public List<Friend> ListFriends()
        {

			List<Friend> Friends = new List<Friend>();

			try
            {
                if (File.Exists(strPathFile))
                {
                    using (StreamReader sr = new StreamReader(strPathFile))
                    {
                        string line;

                        string[] temp;

                        while ((line = sr.ReadLine()) != null)
                        {
                            temp = line.Split(';');

                            Friend friend = new Friend(int.Parse(temp[0]), temp[1], temp[2], temp[3]);

                            Friends.Add(friend);
                        }
						
						return Friends;
                    }
                }
                else
                {
                    return new List<Friend>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Friend GetFriendByName(string name)
        {
            try
            {
                List<Friend> friendList = ListFriends();

                Friend friend = friendList.Find(el => el.Name == name);

                return friend;
            }
            catch (Exception)
            {
                Console.WriteLine("Amigo nao encontrado");
                throw;
            }

        }

        public void RemoveFriend(Friend friend)
        {
            try
            {
                if (File.Exists(strPathFile))
                {
                    List<string> file = new List<string>(System.IO.File.ReadAllLines(strPathFile));

                    // GAMBI
                    int indexItemToRemove = 9999;

                    string[] temp;

                    foreach (var line in file)
                    {
                         temp = line.Split(';');

                        if(temp[1] == friend.Name)
                        {
                            indexItemToRemove = file.IndexOf(line);
                        }
                    }

                    file.RemoveAt(index: indexItemToRemove);

                    File.WriteAllLines(strPathFile, file.ToArray());
                }
                else
                {
                    Console.WriteLine("Lista vazia !");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateFriendBirthDate(Friend targetFriend, string newBirthDate)
        {
            try
            {
                List<string> file = new List<string>(System.IO.File.ReadAllLines(strPathFile));

                var newValue = DateTime.Parse(newBirthDate);

                targetFriend.BirthDate = newValue;

                RemoveFriend(targetFriend);

                AddFriend(targetFriend);


            }
            catch (Exception)
            {
                Console.WriteLine("Amigo nao encontrado");
                throw;
            }

        }
    }
}
