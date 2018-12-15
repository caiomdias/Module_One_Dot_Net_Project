using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class FriendList : Repository
    {
        private List<Friend> Friends;

        public FriendList()
        {
            //Friend test = new Friend(1, "caio", "dias", "1995-03-23");
            //Friend test2 = new Friend(2, "dias", "caio", "1995-03-23");
            //Friend test3 = new Friend(3, "test1", "test", "1995-12-02");
            //Friend test4 = new Friend(4, "test2", "test", "1995-12-02");

            //AddFriend(test);
            //AddFriend(test2);
            //AddFriend(test3);
            //AddFriend(test4);

            Friends = ListFriends();
        }

        public List<Friend> ListToDayBirthday()
        {
            Friends = ListFriends();

            List<Friend> toDayBirthday = new List<Friend>();

            DateTime toDay = DateTime.Now;

            foreach (var friend in Friends)
            {
                if ((friend.BirthDate.Day == toDay.Day) && (friend.BirthDate.Month == toDay.Month))
                {
                    toDayBirthday.Add(friend);
                }
            }

            return toDayBirthday;
        }
    }
}
