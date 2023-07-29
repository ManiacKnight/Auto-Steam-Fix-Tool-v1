using INI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutoSteamFix
{
    class Program
    {

        public static bool Re = false;

        private static int SetNumber(string outputText)
        {
            int parse;
            Console.Write(outputText);
            string tempInput = Console.ReadLine();
            while (!int.TryParse(tempInput, out parse))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(outputText);
                tempInput = Console.ReadLine();

            }

            return int.Parse(tempInput);
        }




        static void Main(string[] args)
        {
            Console.Title = ("Auto Steam Fix Tool");

            Console.ForegroundColor = ConsoleColor.White;

            //INI sh*t
            var MyIni = new IniFile(@"AutoSteamFixTool\Wrappers\Cream_Api\creamapi.ini");


            //Testing Cell


            //Data cell
            string INILoc = @"AutoSteamFixTool\Wrappers\Cream_Api\creamapi.ini";
            string OapiLoc = @"AutoSteamFixTool\Wrappers\Cream_Api\steamapi.dll";
            string Oapi64Loc = @"AutoSteamFixTool\Wrappers\Cream_Api\steamapi64.dll";
            string SAfolder = @"AutoSteamFixTool\Original_Files\steam_api_o.dll";
            string oSAfolder = @"AutoSteamFixTool\Original_Files\steam_api.dll";
            string oSAfolder64 = @"AutoSteamFixTool\Original_Files\steam_api64.dll";
            string SAfolder64 = @"AutoSteamFixTool\Original_Files\steam_api64_o.dll";
            string Olaytxt = @"AutoSteamFixTool\Steam_Overlay\x32\dlllist.txt";
            string Olaywin = @"AutoSteamFixTool\Steam_Overlay\x32\winmm.dll";
            string Olaydll = @"AutoSteamFixTool\Steam_Overlay\x32\SteamOverlay32.dll";
            string Olaytxt64 = @"AutoSteamFixTool\Steam_Overlay\x64\dlllist.txt";
            string Olaywin64 = @"AutoSteamFixTool\Steam_Overlay\x64\winmm.dll";
            string Olaydll64 = @"AutoSteamFixTool\Steam_Overlay\x64\SteamOverlay64.dll";
            string cDir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);




            start:
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nWelcome to ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Auto Steam Fix Tool By ManiacKnight");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nVersion: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1.1.5");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nIt is highly recommended to read the ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("'Read Me.txt'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" file!");

            Console.Write("\n\nPlease Select an option: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n1.Apply Steam fix");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n\n2.Configure/Troubleshoot already applied fix");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n3.Re-Edit Applied Fix.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n\n4.Join Our Discord Server!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\nSelect option: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string option = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (option == "1")
            {
                goto AppID;
            }

            else if (option == "2")
            {
                goto ConfigT;
            }

            else if (option == "3")
            {
                goto ReEdit;
            }

            else if (option== "4")
            {
                
                System.Diagnostics.Process.Start("https://discord.gg/H3XDnvZ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYay! You get a cookie :D");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();

                goto start;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBruh, did you pass first Grade?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto start;
            }

            AppID:

            string[] steamapio = Directory.GetFiles(cDir,
           "steam_api_o.dll",
           SearchOption.AllDirectories);

            string[] steamapio64 = Directory.GetFiles(cDir,
          "steam_api64_o.dll",
          SearchOption.AllDirectories);

            foreach (string apio in steamapio)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou have already applied a Fix or 'steam_api_o.dll' exists within the game files (Delete it).");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto start;

            }

            foreach (string api64o in steamapio64)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou have already applied a Fix or 'steam_ap64_o.dll' exists within the game files (Delete it).");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto start;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\nOriginal AppID of the game = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string AppID = Console.ReadLine();



            if (int.TryParse(AppID, out var appId))
            {
                MyIni.Write("appid", new string(' ', 1) + appId, "steam");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Input! Numbers only please");
                Console.ForegroundColor = ConsoleColor.White;
                goto AppID;
            }


            FakeAppID:
            Console.Write("\nFakeAppID (Usually 480) = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string FakeAppID = Console.ReadLine();
            if (int.TryParse(FakeAppID, out var FakerAppID))
            {
                MyIni.Write("newappid", new string(' ', 1) + FakerAppID, "steam_wrapper");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Input! Numbers only please");
                Console.ForegroundColor = ConsoleColor.White;
                goto FakeAppID;
            }


            //Language
            Console.Write("\nLanguage = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string Language = Console.ReadLine();
            MyIni.Write("language", new string(' ', 1) + Language, "steam");
            Console.ForegroundColor = ConsoleColor.White;

            //Dlcs
            DLC:
            Console.WriteLine("\nDLCs = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string s = "1";
            List<string> result = new List<string> { };
            while (!string.IsNullOrEmpty(s))
            {

                s = Console.ReadLine();
                result.Add(s);
            }
            foreach (string s1 in result)
            {
                s = s + "\n" + s1;
            }
            Console.ForegroundColor = ConsoleColor.White;


            string fileName = INILoc;
            bool aboveBelow = true;
            string lineToSearch = "[dlc]";
            string lineToAdd = s;

            var txtLines = File.ReadAllLines(fileName).ToList();
            int index = aboveBelow ? txtLines.IndexOf(lineToSearch) + 1 : txtLines.IndexOf(lineToSearch);
            if (index > 0)
            {
                txtLines.Insert(index, lineToAdd);
                File.WriteAllLines(fileName, txtLines);
            }


            if (Re == true)
            {
                goto CrimCopy;
            }

            //Console Work begins here


            //find steamapi.dll

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\nFinding steam_api.dll.........");
            Console.ForegroundColor = ConsoleColor.White;

            // string cDir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] steamapi = Directory.GetFiles(cDir,
            "steam_api.dll",
            SearchOption.AllDirectories);



            if (steamapi is null || steamapi.Length == 0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nsteam_api.dll was not found!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nsteam_api.dll was found!");
                Console.ForegroundColor = ConsoleColor.White;

            }

            //find steamapi64.dll   

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nFinding steam_api64.dll.........");
            Console.ForegroundColor = ConsoleColor.White;

            string[] steamapi64 = Directory.GetFiles(cDir,
            "steam_api64.dll",
            SearchOption.AllDirectories);

            if (steamapi64 is null || steamapi64.Length == 0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nsteam_api64.dll was not found!");
                Console.ForegroundColor = ConsoleColor.White;

            }

            else
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nsteam_api64.dll was found!");
                Console.ForegroundColor = ConsoleColor.White;

            }

            

            foreach (string api in steamapi)
            {
                string cApi = api.Substring(0, api.Length - 13);

                File.Move(api, cApi + "steam_api_o.dll");

                if (!File.Exists(SAfolder))
                {
                    File.Copy(cApi + "steam_api_o.dll", SAfolder);
                }



                File.Copy(OapiLoc, cApi + "steam_api.dll");
                if (!File.Exists(oSAfolder))
                {
                    File.Copy(OapiLoc, oSAfolder);
                }

                if (!File.Exists(cApi + "cream_api.ini"))
                {
                    File.Copy(INILoc, cApi + "cream_api.ini");
                }
            }



            foreach (string api64 in steamapi64)
            {
                string cApi64 = api64.Substring(0, api64.Length - 15);
                File.Move(api64, cApi64 + "steam_api64_o.dll");
                if (!File.Exists(SAfolder64))
                {
                    File.Copy(cApi64 + "steam_api64_o.dll", SAfolder64);
                }


                File.Copy(Oapi64Loc, cApi64 + "steam_api64.dll");
                if (!File.Exists(oSAfolder64))
                {
                    File.Copy(Oapi64Loc, oSAfolder64);
                }

                if (!File.Exists(cApi64 + "cream_api.ini"))
                {
                    File.Copy(INILoc, cApi64 + "cream_api.ini");
                }
            }

           

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n************************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\nSuccess! Steam fix has been Applied.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n\nIf you are still getting problems try Configure/Troubleshoot..");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            goto start;

            //Configure/Troubleshoot
            ConfigT:
            Console.Clear();
            Console.Write("\nWelcome to ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Auto Steam Fix Tool By ManiacKnight");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nVersion: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1.1.5");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nConfigure / Troubleshoot Tool -");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nWhat seems to be the problem?");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n 1)Configuration File was not found.");
            Console.Write("\n\n 2)Game starts as spacewar/Payday 2 but no Steam Overlay");
            Console.Write("\n\n 3)After doing everything correctly, opening EXE still takes me to Storepage");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\nSelect Option: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string CToption = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (CToption == "1")
            {
                confignotfound:
                Console.Write("\nPlease enter the Entire File name of the MAIN game exe (With .exe) : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string CFnf = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int exeL = CFnf.Length;


                string[] exeloc = Directory.GetFiles(cDir,
            CFnf,
            SearchOption.AllDirectories);

                if (exeloc is null || exeloc.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n" + CFnf + " was not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    goto confignotfound;
                }

                foreach (string exeloca in exeloc)
                {
                    string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);
                    if (File.Exists(SAfolder))
                    {
                        File.Copy(SAfolder, cExeloc + @"\steam_api_o.dll");
                    }

                }

                foreach (string exeloca in exeloc)
                {
                    string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);
                    if (File.Exists(SAfolder64))
                    {
                        File.Copy(SAfolder64, cExeloc + @"\steam_api64_o.dll");

                    }

                }


                foreach (string exeloca in exeloc)
                {
                    string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);
                    if (File.Exists(oSAfolder))
                    {
                        File.Copy(oSAfolder, cExeloc + "steam_api.dll");
                    }

                }

                foreach (string exeloca in exeloc)
                {
                    string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);
                    if (File.Exists(oSAfolder64))
                    {
                        File.Copy(oSAfolder64, cExeloc + "steam_api64.dll");
                    }

                }

                foreach (string exeloca in exeloc)
                {
                    string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);
                    File.Copy(INILoc, cExeloc + @"\cream_api.ini");

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success! If you entered the right executable name, problem should be fixed.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto start;




            }

            else if (CToption == "2")
            {

                arch:
                Console.Clear();
                Console.Write("\nPlease enter the Entire File name of the MAIN game exe (With .exe) : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string CFnf = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int exeL = CFnf.Length;


                string[] exeloc = Directory.GetFiles(cDir,
            CFnf,
            SearchOption.AllDirectories);

                if (exeloc is null || exeloc.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n" + CFnf + " was not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();

                }

                Console.Write("\nIs the game x64 or x32? : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string oBit = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (oBit == "x32")
                {
                    foreach (string exeloca in exeloc)
                    {
                        string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);
                        File.Copy(Olaytxt, cExeloc + @"\dlllist.txt");
                        File.Copy(Olaydll, cExeloc + @"SteamOverlay32.dll");
                        File.Copy(Olaywin, cExeloc + @"winmm.dll");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\nSuccess! x32 files were copied.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        goto start;
                    }
                }

                if (oBit == "x64")
                {
                    foreach (string exeloca in exeloc)
                    {
                        string cExeloc = exeloca.Substring(0, exeloca.Length - exeL);

                        File.Copy(Olaytxt64, cExeloc + "dlllist.txt");
                        File.Copy(Olaydll64, cExeloc + "SteamOverlay64.dll");
                        File.Copy(Olaywin64, cExeloc + "winmm.dll");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nSuccess! x64 files were copied.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        goto start;
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nPlease type x32 or x64!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    goto arch;
                }
            }

            else if (CToption == "3")
            {
                Console.Write("\n\nIf you are getting this error, it means that " +
                    "\nyou need to remove the Steam Stub from your exe, that is prevent the game" +
                    "\nfrom needing steam to run, to do this, you will need to download" +
                    "\n'Steamless' by atm0s, which can be found here: https://cs.rin.ru/forum/viewtopic.php?f=29&t=88528&hilit=steamless" +
                    "\nThe steps are pretty straightforward. Thank you atm0s!");
                Console.ReadKey();
                goto start;
            }

            ReEdit:
            Console.Clear();
            

            string App = MyIni.Read("appid", "steam");
            string fake = MyIni.Read("newappid", "steam_wrapper");
            string language = MyIni.Read("language", "steam");

            if (App is null || App.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n Online Fix isn't Applied Yet!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto start;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nWelcome to ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Auto Steam Fix Tool By ManiacKnight");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nVersion: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1.1.5");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nRe-Edit Applied Fix");
            Console.ForegroundColor = ConsoleColor.White;
            


            


            Console.Write("\n\n1)AppID = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(App);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n2)Fake App Id = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(fake);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n3)Language = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(language);

            Console.ForegroundColor = ConsoleColor.White;
            bool containsSearchResult = false;
            string[] lines = File.ReadAllLines(INILoc);
            Console.Write("\n\n4)DLC : \n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in lines)
            {

                if (containsSearchResult)
                {
                    Console.WriteLine(line);
                }

                if (line.Contains("[dlc]"))
                {
                    containsSearchResult = true;
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n5)Go Back");



            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n\nWhat would you like to change? : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string option2 = Console.ReadLine();

            if (option2 == "1")
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\nOriginal AppID of the game = ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string idofapp = Console.ReadLine();



                if (int.TryParse(idofapp, out var AppId))
                {
                    MyIni.Write("appid", new string(' ', 1) + AppId, "steam");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Input! Numbers only please");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto ReEdit;
                }

                goto CrimCopy;

            }

            else if (option2 == "2")
            {

                Console.Write("\nFakeAppID (Usually 480) = ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string FakeAppID2 = Console.ReadLine();


                if (int.TryParse(FakeAppID2, out var FakerAppID2))
                {
                    MyIni.Write("newappid", new string(' ', 1) + FakerAppID2, "steam_wrapper");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Input! Numbers only please");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    goto ReEdit;

                }

                goto CrimCopy;

            }

            else if (option2 == "3")
            {

                Console.Write("\nLanguage = ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string Language2 = Console.ReadLine();


                MyIni.Write("language", new string(' ', 1) + Language2, "steam");
                Console.ForegroundColor = ConsoleColor.White;

                goto CrimCopy;
                

            }

            else if (option2 == "4")
            {


                string[] liness = File.ReadAllLines(INILoc);
                StringBuilder newText = new StringBuilder();
                bool containsSearchResul = false;

                foreach (string line in liness)
                {
                    newText.Append(line);
                    newText.Append(Environment.NewLine);


                    if (line.Contains("[dlc]"))
                        break;

                }

                File.WriteAllText(INILoc, newText.ToString());


                Re = true;
                goto DLC;

            }

            else if (option2 == "5")
            {
                goto start;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nI am seriously doubting your IQ right now....");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto ReEdit;
            }



            CrimCopy:
            string[] crimapi = Directory.GetFiles(cDir,
            "cream_api.ini",
            SearchOption.AllDirectories);

            foreach(string crim in crimapi)
            {
                string cCrim = crim.Substring(0, crim.Length - 13);

                File.Copy(INILoc, cCrim + "cream_api.ini", true);
            }
            goto ReEdit;








        }


    }
}
    

