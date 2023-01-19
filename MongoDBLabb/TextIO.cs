using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.IO;

namespace MongoDBLabb
{
    
    public class TextIO : IStrings
    {
        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string ReadString()
        {
            return Console.ReadLine();
        }
        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }
       
        public void MainMenu()
        {
            Console.WriteLine("===Vad vill du göra?===\n1. Lägg till artikel.\n2. Uppdatera artikel\n3. Hämta alla artiklar\n4. Hämta en artikel\n5. Ta bort en artikel\n6. Avsluta program");
        }

        public void PrintInt(int intoutput)
        {
            Console.WriteLine(intoutput);
        }
        public void PrintDec(decimal decoutput)
        {
            Console.WriteLine(decoutput);
        }

        public void Clear()
        {
           Console.Clear();
        }
        public void PrintDocument(ItemModel item)
        {   if(item == null)
            {
                PrintString("Inget artikelnummer hittades");
                return;
           }
           PrintString($"1 BsonID : {item.BsonID}\n2 Artnr: {item.Id}\n3 Namn: {item.Name}\n4 Enhet: {item.Unit}\n4 Antal: {item.Qty}\n5 Märke: {item.Brand}\n\n");
        }
    }
}



