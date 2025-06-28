using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using RestApiMVC.Controller;
using RestApiMVC.View;

namespace RestApiMVC;

class Program
{
    public static void Main(string[] args)
    {
        switch (UserInput.userChooseByInitial("CHOOSE GAME: ", "BlackJack,NoMatch"))
        {
            case 'B':
                BlackJack.Start();
                break;
            case 'N':
                NoMatch.Start();
                break;
        }
    }
}
