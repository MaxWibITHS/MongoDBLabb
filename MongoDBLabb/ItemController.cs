using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBLabb
{
    internal class ItemController
    {
        IStrings io;
        IDAO itemDao;

        public ItemController(IStrings io, IDAO itemDao)
        {
            this.io = io;
            this.itemDao = itemDao;
        }
        public void StartItemControl()
        {
            bool endProgram = true;

            while (endProgram == true)
            {
                try
                {
                    io.MainMenu();

                    int input = int.Parse(io.ReadString());
                   

                    io.Clear();

                    switch (input)
                    {
                        case 1:
                            io.PrintString("Mata in artikelnummer, namn, enhet, antal och märke till produkten.");
                            ItemModel item = new ItemModel { Id = int.Parse(io.ReadString()), Name = io.ReadString(), Unit = io.ReadString(), Qty = int.Parse(io.ReadString()), Brand = io.ReadString() };
                            itemDao.Create(item);
                            io.PrintString($"Artikel {item.Id} tillagt");
                            break;
                        case 2:
                            io.PrintString("Mata in vilken artikel du vill uppdatera.");
                            int i = int.Parse(io.ReadString());
                            if (itemDao.ReadOne(i) == null)
                            {
                                io.PrintString("Artikeln du vill uppdatera finns inte.");
                            }
                            else
                            {
                                io.PrintString("Mata in vad du vill ändra till: ");
                                int newid = int.Parse(io.ReadString());
                                itemDao.Update(i, newid);
                                io.PrintString($"Artikel {i} har nu uppdaterat qty till {newid}");
                            }
                            break;
                        case 3:
                            itemDao.ReadAll().ForEach(i => { io.PrintInt(i.Id); io.PrintString(i.Name); io.PrintString(i.Unit); io.PrintInt(i.Qty); io.PrintString(i.Brand); io.PrintString(""); });
                            break;
                        case 4:
                            io.PrintString("Mata in det artikelnr du vill visa.");
                            int id = int.Parse(io.ReadString());
                            io.PrintDocument(itemDao.ReadOne(id));
                            break;
                        case 5:
                            io.PrintString("Mata in vilket artnr du vill ta bort");
                            id = int.Parse(io.ReadString());
                            
                            if(itemDao.ReadOne(id) == null)
                            {
                                io.PrintString("Inget artikelnummer hittades");                        
                            }
                            else
                            {
                                io.PrintString($"Artikel {id} borttagen");                                
                                itemDao.Delete(id);
                            }
                            break;
                        case 6:
                            io.Exit();
                            break;

                        default: io.PrintString("Du valde inget alternativ i listan.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    io.PrintString("Fel inmatat värde. Inga ändringar har gjorts.");

                    continue;
                }
            }

        }
    }
}
        
    


