using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using System;
using System.Net.Http;
using System.IO;

namespace DataReader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Seed> listOfSeed = new List<Seed>();

            string[] array = File.ReadAllLines(@"C:\TEXTOS\sementes.txt");

            for (int k = 0; k < array.Length; k++)
            {
                Seed a = new Seed();

                string[] auxiliar = array[k].Split(',');

                a.Type = auxiliar[0];
                a.Level = Convert.ToDecimal(auxiliar[1], CultureInfo.InvariantCulture);
                a.Status = auxiliar[2];
                a.PlantingDate = Convert.ToDateTime(auxiliar[3]);

                listOfSeed.Add(a);

            }

            //Envia valores p/ API
            var json = JsonConvert.SerializeObject(listOfSeed);
            StringContent? httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:5001/api/Seed/SalvarLista", httpContent);

            Console.ReadKey();

            //Retona valores
            //var responseString = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(responseString);
            //Console.ReadKey();

        }
    }
}