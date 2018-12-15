using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    interface IFriend
    {
        List<Friend> ListFriends();
        Friend GetFriendByName(string name);
        void AddFriend(Friend friend);
        void RemoveFriend(Friend friend);
        void UpdateFriendBirthDate(Friend targetFriend, string newBirthDate);

    }
}
