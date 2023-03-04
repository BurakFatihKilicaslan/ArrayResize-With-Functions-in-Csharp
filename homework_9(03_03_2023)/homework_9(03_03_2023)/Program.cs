using System.Threading.Channels;

namespace homework_9_03_03_2023_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Homework9:Kullanıcı "tamam" yazana kadar girdiği şarkı isimlerinden oluşan bir playlist oluşturan ve kullanıcıdan bu playlistten çıkarmak istediği bir şarkı ismi alan; eğer o şarkı playlistte varsa çıkarılmış yeni playlist'i listeleyen yoksa "Bu playlist'te böyle bir şarkı yok çıktısı" ile beraber aynı playlist'i veren uygulamayı yazın.
            int find = 0;
            string line = "-.-.-.-.-.-.-.-.-.-", line2 = "***";
            string[] playlist = new string[0];
            Console.WriteLine($"{line}Kisisel Listenize Hosgeldiniz{line}\n");
            Console.WriteLine("Playlistiniz Icın Kolaylikla Muzik Ekleyebilirsiniz\n");
            Console.Write($"{line2} !!! Bilgi !!!Cikis Yapmak Icin 'Tamam' Yazabilirsiniz {line2}\n\n");
            string[] loadPlaylist = MakeArraySize(playlist, line);
            Console.Write("Silmek Istediginiz Bir Parca Var Mi?(Evet / Hayir): ");
            string questionForAnswer = Console.ReadLine();
            questionForAnswer.ToLower();
            if (questionForAnswer == "evet")
            {
                SelectMessageDelete(loadPlaylist, ref find);
                string[] newPlaylist = GenerateNewArray(loadPlaylist, ref find);
                WritePlaylist(newPlaylist);
            }
            else
            {
                Console.WriteLine("Islemleriniz Icin Tesekkurler..");
                WritePlaylist(loadPlaylist);
            }
            #endregion
        }
        static string[] MakeArraySize(string[] playlist, string line)
        {
            string answer;
            for (; ; )
            {
                Console.Write("Eklemek Istediginiz Parcanin Adini Giriniz(Cıkıs Icin -->'tamam'):");
                string music = Console.ReadLine();
                music = DeleteExtraSpace(music);
                music.ToLower();

                if (!music.Contains("tamam"))
                {
                    Array.Resize(ref playlist, playlist.Length + 1);
                    playlist[playlist.Length - 1] = music;
                }
                else break;
            }
            return playlist;
        }
        static string DeleteExtraSpace(string result)
        {
            bool isNotSpace = true;

            string newResult = "";

            foreach (char c in result)
            {
                if (c != ' ')                                              ////Eger Gelen Bosluk Harici Bir Karakter Ise Dogrudan Ekle
                {
                    newResult += c;
                    isNotSpace = true;
                }
                else
                {                                           ////Eger Bosluk Degilse ilk seferde ekle sonra IsNotSpace degiskenini false hale getir.
                    if (isNotSpace) newResult += c;      //Boylece Ilk Bosluk Eklenir Sonraki Bosluklar normal bir karakter gelinceye kadar eklenmez
                    isNotSpace = false;
                }
            }
            return newResult;
        }
        static void SelectMessageDelete(string[] loadPlaylist, ref int find)
        {
            Console.Write("Cikarmak Istediginiz Sarkinin Ismini Giriniz:");
            string deleteMusic = Console.ReadLine();
            deleteMusic = DeleteExtraSpace(deleteMusic);
            bool selectedMusic = loadPlaylist.Contains(deleteMusic);
            if (selectedMusic)
            {
                Console.WriteLine($"Silmek Istediginiz Parca:{deleteMusic}");
                for (int i = 0; i < loadPlaylist.Length; i++)
                {
                    if (loadPlaylist[i] == deleteMusic)
                    {
                        find = i;
                    }
                }
            }
            else
            {
                Console.WriteLine("Cikarmak Istediginiz Parca Zaten Listenizde Bulunmamaktadir..\nListeniz Asagidaki Gibidir..");
                WritePlaylist(loadPlaylist);
            }
        }
        static string[] GenerateNewArray(string[] loadPlaylist, ref int find)
        {
            string[] newPlaylist = new string[loadPlaylist.Length - 1];
            if (find != 0)
            {
                for (int i = 0; i < loadPlaylist.Length; i++)
                {
                    if (i < find)
                    {
                        newPlaylist[i] = loadPlaylist[i];
                    }
                    else if (i == find) continue;
                    else
                    {
                        newPlaylist[i - 1] = loadPlaylist[i];
                    }
                }
            }
            return newPlaylist;
        }
        static void WritePlaylist(string[] playlist)
        {
            for (int i = 0; i < playlist.Length; i++)
            {
                Console.WriteLine(playlist[i]);
            }
        }
    }
}