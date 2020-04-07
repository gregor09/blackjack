using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Game.Controllers
{
    class Player
    {
        public string Name { get; set; }
        public int Bet { get; set; }
        public int Balance { get; set; }
        string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=BlackJack_Players;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void GetBudget(string name)
        {

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Budgets WHERE Name = @name", connection);
            cmd.Parameters.Add(new SqlParameter("name", name));
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        Name = reader.GetString(0);
                        Balance = reader.GetInt32(1);
                        Bet = reader.GetInt32(2);
                    };
                    PrintData();
                }
                else
                {
                    CreatBudget();
                }
            }
            connection.Close();

        }


        public void CreatBudget()
        {
            Console.SetCursorPosition(35, 9);
            Console.WriteLine("Sign Up!");
            Console.SetCursorPosition(35, 11);
            Console.WriteLine("                                      ");
            Console.SetCursorPosition(35, 11);
            Console.Write("Enter your nickname: ");
            this.Name = Console.ReadLine();
            do
            {
                Console.SetCursorPosition(35, 13);
                Console.Write("Enter your Balance (min 10 eur, max 1000 eur): ");
                this.Balance = Convert.ToInt32(Console.ReadLine());
            } while (!CheckBalance());

            do
            {
                Console.SetCursorPosition(35, 15);
                Console.Write("Enter your Bet (1 eur, 5 eur, 10 eur): ");
                this.Bet = Convert.ToInt32(Console.ReadLine());
            } while (!CheckBet());
            

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Budgets(Name, Balance, Bet)" +
                " VALUES (@Name, @Balance, @Bet)", connection))
            {
                cmd.Parameters.AddWithValue("Name", this.Name);
                cmd.Parameters.AddWithValue("Balance", this.Balance);
                cmd.Parameters.AddWithValue("Bet", this.Bet);
                int rows = cmd.ExecuteNonQuery();
            }
            connection.Close();

        }


        public void MakeBet(string name)
        {
            Balance = Balance - Bet;
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(@"UPDATE Budgets
                                                      SET Balance = @balance
                                                      WHERE Name = @name;", connection))
            {
                cmd.Parameters.AddWithValue("Name", this.Name);
                cmd.Parameters.AddWithValue("Balance", this.Balance);
                cmd.Parameters.AddWithValue("Bet", this.Bet);
                int rows = cmd.ExecuteNonQuery();
            }
            connection.Close();

        }

        public void AddWin(string name)
        {
            Balance = Balance + (Bet * 2);
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(@"UPDATE Budgets
                                                      SET Balance = @balance
                                                      WHERE Name = @name;", connection))
            {
                cmd.Parameters.AddWithValue("Name", this.Name);
                cmd.Parameters.AddWithValue("Balance", this.Balance);
                cmd.Parameters.AddWithValue("Bet", this.Bet);
                int rows = cmd.ExecuteNonQuery();
            }
            connection.Close();

        }

        public void ReturnBet(string name)
        {
            Balance = Balance + Bet;
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(@"UPDATE Budgets
                                                      SET Balance = @balance
                                                      WHERE Name = @name;", connection))
            {
                cmd.Parameters.AddWithValue("Name", this.Name);
                cmd.Parameters.AddWithValue("Balance", this.Balance);
                cmd.Parameters.AddWithValue("Bet", this.Bet);
                int rows = cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public bool CheckBet()
        {
            if (Bet == 1 || Bet == 5 || Bet == 10)
                return true;
            else
                return false;
        }

        public bool CheckBalance()
        {
            if (Balance >= 10 && Balance <= 1000)
                return true;
            else
                return false;
        }

        public void PrintData()
        {
            ConsoleKeyInfo pressedChar;

            Console.SetCursorPosition(35, 12);
            Console.WriteLine("Your Balanace is " + Balance + " eur. Do you want to change it? Y/N");
            pressedChar = Console.ReadKey(true);
            int hashCode = pressedChar.Key.GetHashCode();
            if (pressedChar.Key == ConsoleKey.Y)
            {
                    do
                    {
                        Console.SetCursorPosition(35, 13);
                        Console.Write("Enter new Balance (min 10 eur, max 1000 eur): ");
                        this.Balance = Convert.ToInt32(Console.ReadLine());
                    } while (!CheckBalance());

            }
            do
            {
                Console.SetCursorPosition(35, 14);
                Console.Write("Enter your Bet (1 eur, 5 eur, 10 eur): ");
                this.Bet = Convert.ToInt32(Console.ReadLine());
            } while (!CheckBet());

        }

        public void AskName()
        {
            Console.SetCursorPosition(35, 11);
            Console.Write("Enter your nickname: ");
        }

        public void Render()
        {
            Console.SetCursorPosition(38, 25);
            Console.WriteLine("Bet: " + Bet);
            Console.SetCursorPosition(72, 25);
            Console.WriteLine("             ");
            Console.SetCursorPosition(72, 25);
            Console.WriteLine("Balance: " + Balance);
        }

    }

}
