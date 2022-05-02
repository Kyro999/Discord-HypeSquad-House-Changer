using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using Discord;
using Discord.Commands;
using Discord.Gateway;
using Discord.Media;
using Discord.WebSockets;
namespace Hypesquad_Badge_Changer {
  class Program {
    static void Main() {
      Console.Title = "Hypesquad House Changer | By Kyro#5050";
      DiscordSocketClient client = new DiscordSocketClient();
      Console.Write("[+]: Enter Token: ");
      string Token = Console.ReadLine();
      try 
      {
        client.Login(Token);
        client.OnLoggedIn += LoggedIn;
        Thread.Sleep( - 1);
      } 
      catch(InvalidTokenException e) 
      {
        MessageBox.Show($ "{e.Message}\n\nToken: {e.Token}", "Invalid Token", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
    }
      
    private static void LoggedIn(DiscordSocketClient client, LoginEventArgs e) 
    {
      Options: DialogResult result;
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.WriteLine("[1]: Bravery");
      Console.WriteLine("[2]: Brilliance");
      Console.WriteLine("[3]: Balance");
      Console.WriteLine("[4]: Exit");
      Console.Write("\n>: ");
      string House = Console.ReadLine();

      switch (House) {
      case "1":
        client.User.SetHypesquad(Hypesquad.Bravery);
        break;
      case "2":
        client.User.SetHypesquad(Hypesquad.Brilliance);
        break;
      case "3":
        client.User.SetHypesquad(Hypesquad.Balance);
        break;
      case "4":
        result = MessageBox.Show("Are you sure you want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes) 
        {
          Thread.Sleep(50);
          Environment.Exit(0);
        } 
        else
         goto Options;
        break;
      default:
        MessageBox.Show($ "That isn't a valid option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Thread.Sleep(2000);
        Environment.Exit(0);
        break;
      }

      result = MessageBox.Show($ "Set House!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      if (result == DialogResult.OK) {
        Thread.Sleep(2000);
        Environment.Exit(0);
      }
    }
  }
}
