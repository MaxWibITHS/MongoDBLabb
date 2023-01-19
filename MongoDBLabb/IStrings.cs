using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBLabb
{
    internal interface IStrings
    {
        public string ReadString();
        public void PrintString(string output);
        public void PrintDec(decimal decoutput);
        public void PrintInt(int intoutput);
        public void Exit();
        public void MainMenu();

        public void Clear();

        public void PrintDocument(ItemModel item);
        
    }
}

