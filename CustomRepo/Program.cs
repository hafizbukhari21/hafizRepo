using System;
using System.Data.SqlClient;
using CustomRepo.Repository.Data;
using CustomRepo.Models;
using System.Collections.Generic;

namespace CustomRepo
{
    class Program
    {
        static UserRepository userRep = new UserRepository();
        
        static void Main(string[] args)
        {
            int pilih = 1;
            do
            {
                //new Branch Ceritanya
                Console.Clear(); //ini delete
                ShowData();
                Console.Write("\n\n 1. Insert\n 2.Update\n 3.Delete\n 4.Exit\n Masukan :");
                pilih = Int32.Parse(Console.ReadLine());

                switch (pilih)
                {
                    case 1:
                        Insert();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        return;
                        break;
                }

            } while (pilih != 4);
        }

        static void Delete()
        {
            Console.Write("Pilih id yang mau dihapus : ");
            int id = Int32.Parse(Console.ReadLine());

            if (userRep.Delete(id) == 1)
                Console.WriteLine("Data BerHasil Dihapus");
            else
                Console.WriteLine("Data Gagal Dihapus");


        }

        static void Update()
        {
            Console.Write("Masukan id yang Mau di update : ");
            int id =Int32.Parse(Console.ReadLine());
            Console.Write("Masukan Nama : ");
            string nama = Console.ReadLine();
            Console.Write("Masukan Kota : ");
            string kota = Console.ReadLine();

            
            int check = userRep.Update(id, new Dictionary<string, string> {
                {"nama",nama },
                {"kota",kota },
            });

            if (check == 1) Console.WriteLine("ok");
            else Console.WriteLine("err");
            UserRepository.conn.Close();


        }

        static void Insert()
        {

            Console.WriteLine("Masukan Data Baru: ");
            Console.Write("Masukan Nama : ");
            string nama = Console.ReadLine();
            Console.Write("Masukan Kota : ");
            string kota = Console.ReadLine();

           
            if (userRep.Insert(new List<string> { nama, kota }) == 1) Console.WriteLine("ok");
            else Console.WriteLine("Sw");
            UserRepository.conn.Close();

        }

        static void ShowData()
        {

            List<UserModel> users = new List<UserModel>();
            SqlDataReader userDataReader=  userRep.GetAll();

            while (userDataReader.Read())
            {
                users.Add(new UserModel() {
                    id = userDataReader.GetInt32(0),
                    nama = userDataReader.GetString(1),
                    kota = userDataReader.GetString(2),
                });
            }

            foreach(var user in users)
            {
                Console.WriteLine(user.nama+" | id="+user.id + " | Kota=" +user.kota);
            }

            UserRepository.conn.Close();

        }
    }
}
