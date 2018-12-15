using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FriendList friendList = new FriendList();

            while (true)
            {

                try
                {
                    Console.WriteLine("\r\tBirthday Remember");
                    Console.WriteLine("\r\tEssa aplicação tem a finlidade de te lembrar os aniversarios");
                    Console.WriteLine("\r\tde seus amigos e grenciar-los");

                    List<Friend> birthdayToDay = friendList.ListToDayBirthday();

                    DateTime toDay = DateTime.Now;

                    if (birthdayToDay.Count > 0)
                    {
                        Console.WriteLine($"\n\tAMIGOS ANIVERSARIANTES DO DIA DE HOJE ({toDay.Day}/{toDay.Month})\n");
                        Console.WriteLine("\r\tNome Sobre nome");
                        foreach (var friend in birthdayToDay)
                        {
                            Console.WriteLine($"\r\t{friend.Name} {friend.LastName}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\tNENHUM AMIGO ANIVERSARIANTE NO DIA DE HOJE\n");
                    }
                    

                    Console.WriteLine("\n\r\tSELECIOENE UMA DAS OPERAÇÕES A BAIXO: ");
                    Console.WriteLine("\r\t1 - CADASTRAR UM NOVO AMIGO");
                    Console.WriteLine("\r\t2 - BUSCAR UM AMIGO PELO NOME");
                    Console.WriteLine("\r\t3 - ATUALIZAR DADOS DE UM AMIGO");
                    Console.WriteLine("\r\t4 - APAGAR DADOS DE UM AMIGO");
                    Console.WriteLine("\r\t5 - LISTAR TODOS OS AMIGOS");
                    Console.WriteLine("\n\r\t0 - PARA SAIR");

                    int op = int.Parse(Console.ReadLine());

                    string tempName;
                    string tempLastName;
                    string tempBirthDay;
                    Friend friendFound;

                    switch (op)
                    {
                        case 1:
                            Random rnd = new Random();
                            int tempId = rnd.Next();

                            Console.WriteLine("\n\r\tENTRE COM O NOME DO AMIGO");
                            tempName = Console.ReadLine();

                            Console.WriteLine("\n\r\tENTRE COM O SOBRE NOME DO AMIGO");
                            tempLastName = Console.ReadLine();

                            Console.WriteLine("\n\r\tENTRE COM A DATA DE NASCIMENTO DO AMIGO (YYYY-MM-DD)");
                            tempBirthDay = Console.ReadLine();

                            Friend tempFriend = new Friend(tempId, tempName, tempLastName, tempBirthDay);
                            friendList.AddFriend(tempFriend);

                            Console.WriteLine("\n\r\t AMIGO ADICIONADO COM SUCESSO !");
                            Console.WriteLine("\n\n\r\t APERTE QUALQUER TECLA PARA VOLTAR AO MENU");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("\n\r\tENTRE COM O NOME DO AMIGO QUE DESEJA BUSCAR");
                            tempName = Console.ReadLine();

                            friendFound = friendList.GetFriendByName(tempName);

                            Console.WriteLine($"\n\r\tAMIGO ENCONTRADO:");
                            Console.WriteLine($"\n\r\tNOME: {friendFound.Name}");
                            Console.WriteLine($"\n\r\tSOBRE NOME: {friendFound.LastName}");
                            Console.WriteLine($"\n\r\tDATA DE ANIVERSARIO: {friendFound.BirthDate}");
                            Console.WriteLine($"\n\r\tFALTAM {friendFound.GetDaysToBirthDate()} DIAS PARA O ANIVERSARIO DELE !");
                            Console.WriteLine("\n\n\r\tAPERTE QUALQUER TECLA PARA VOLTAR AO MENU");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 3:
                            Console.WriteLine("\n\r\tENTRE COM O NOME DO AMIGO QUE DESEJA ATUALIZAR");
                            tempName = Console.ReadLine();

                            friendFound = friendList.GetFriendByName(tempName);

                            Console.WriteLine("\n\r\tENTRE COM A NOVA DATA DE ANIVERSARIO DO AMIGO (YYYY-MM-DD)");
                            tempBirthDay = Console.ReadLine();

                            friendList.UpdateFriendBirthDate(friendFound, tempBirthDay);

                            Console.WriteLine("\n\r\tAMIGO ATUALIZADO COM SUCESSO !");
                            Console.WriteLine("\n\n\r\tAPERTE QUALQUER TECLA PARA VOLTAR AO MENU");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 4:
                            Console.WriteLine("\n\r\tENTRE COM O NOME DO AMIGO QUE DESEJA DELETAR");
                            tempName = Console.ReadLine();

                            friendFound = friendList.GetFriendByName(tempName);
                            friendList.RemoveFriend(friendFound);

                            Console.WriteLine("\n\r\tAMIGO REMOVIDO COM SUCESSO !");
                            Console.WriteLine("\n\n\r\tAPERTE QUALQUER TECLA PARA VOLTAR AO MENU");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
							var tempList = friendList.ListFriends();

							foreach (var friend in tempList)
                            {
                                Console.WriteLine($"\n\r\tNOME: {friend.Name}");
                                Console.WriteLine($"\r\tSOBRE NOME: {friend.LastName}");
                                Console.WriteLine($"\r\tDATA DE ANIVERSARIO: {friend.BirthDate}");
                            }
                            Console.WriteLine("\n\n\r\tAPERTE QUALQUER TECLA PARA VOLTAR AO MENU");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
